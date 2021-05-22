using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Math;
using System.Diagnostics;
using System.Globalization;


namespace Barnes_Hut_GUI
{


    public delegate void MyEventHandler(object source, MyEventArgs e);



    public class MyEventArgs : EventArgs
    {
        private int EventInfo;

        public MyEventArgs(int Text)
        {
            EventInfo = Text;
        }

        public int GetInfo()
        {
            return EventInfo;
        }
    }

    class QuadTree
    {
        public List<Particle> AllParticles { get; set; }

        public Node RootNode { get; set; }
        private const float G = 9.8f;
        public float theta = 2f;

        public bool ShowTree { get; set; }
        public bool ShowForceVect { get; set; }

        public AlgToUse alg { get; set; }

        public event MyEventHandler OnProgress;
        public event EventHandler OnCompleted;

        bool[,] pointMap = new bool[737, 737];

        public TimeSpan Thread1Worktime;
        public TimeSpan Thread2Worktime;
        public TimeSpan Thread3Worktime;
        public TimeSpan Thread4Worktime;
        private Stopwatch m_Sw = new Stopwatch();
        private bool m_InitialPartition = false;


        #region Visualization Variables

        public bool DrawNodeCOG;
        public bool DrawEmptyCells { get; set; }
        public bool DrawBhNodeGrouping { get; set; }


        #endregion


     


        #region Enums

        public enum threadModes
        {
            selfMade,
            fromParallelLib

        };

        public enum AlgToUse
        {
            PWI, PPWI, BH, PBH
        }

        #endregion

        #region Initialization

        public QuadTree()
        {
            PointF bottomLeft = new Point(0, 737);
            PointF topRight = new Point(737, 0);
            RootNode = new Node(topRight, bottomLeft);
            RootNode.IsRoot = true;
            AllParticles = new List<Particle>();

        }

        #endregion

        #region Events

        private void RaiseEventOnUIThread(Delegate theEvent, object[] args)
        {
            foreach (Delegate d in theEvent.GetInvocationList())
            {
                ISynchronizeInvoke syncer = d.Target as ISynchronizeInvoke;
                if (syncer == null)
                {
                    d.DynamicInvoke(args);
                }
                else
                {
                    syncer.BeginInvoke(d, args);  // cleanup omitted
                }
            }
        }

        #endregion

        #region Force Calculations



        #endregion

        #region Core Fore Calculation Functions



        #endregion

        #region Visualization
        public void VisualizeTreeNodes(Node nextNode, Graphics currentGraphics, Pen rectPen)
        {
            if (nextNode == null)
            {
                return;
            }

            if (nextNode.nodeParticles.Count == 1)
            {
                currentGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength, nextNode.SideLength);
                if (DrawNodeCOG)
                {
                    currentGraphics.FillEllipse(Brushes.MediumPurple, nextNode.centerOfMass.X - 5,
                            nextNode.centerOfMass.Y - 5, 5 * 2, 5 * 2);
                    currentGraphics.FillEllipse(Brushes.White, nextNode.centerOfMass.X - 0.5f,
                        nextNode.centerOfMass.Y - 0.5f, 0.5f * 2, 0.5f * 2);
                }
                return;
            }

            if (nextNode.nodeParticles.Count == 0 && DrawEmptyCells)
            {
                currentGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength, nextNode.SideLength);
                currentGraphics.FillRectangle(Brushes.IndianRed, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength - 10, nextNode.SideLength - 10);
            }

            else
            {
                currentGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength, nextNode.SideLength);

                if (DrawNodeCOG)
                {
                    if (nextNode.IsRoot)
                    {
                        currentGraphics.FillEllipse(Brushes.Pink, nextNode.centerOfMass.X - 7,
                            nextNode.centerOfMass.Y - 7, 7 * 2, 7 * 2);
                        currentGraphics.FillEllipse(Brushes.DarkBlue, nextNode.centerOfMass.X - 0.5f,
                            nextNode.centerOfMass.Y - 0.5f, 0.5f * 2, 0.5f * 2);
                    }
                    else
                    {
                        if (nextNode.nodeParticles.Count > 0)
                        {
                            currentGraphics.FillEllipse(Brushes.Thistle, nextNode.centerOfMass.X - 8,
                                nextNode.centerOfMass.Y - 8, 8 * 2, 8 * 2);
                            currentGraphics.FillEllipse(Brushes.DeepPink, nextNode.centerOfMass.X - 0.5f,
                                nextNode.centerOfMass.Y - 0.5f, 0.5f * 2, 0.5f * 2);
                        }

                    }
                }

            }



            VisualizeTreeNodes(nextNode.SeChild, currentGraphics, rectPen);
            VisualizeTreeNodes(nextNode.NeChild, currentGraphics, rectPen);
            VisualizeTreeNodes(nextNode.NwChild, currentGraphics, rectPen);
            VisualizeTreeNodes(nextNode.SwChild, currentGraphics, rectPen);

        }

        #endregion






        public void PairWiseForceCalculation()
        {

            for (int i = 0; i < AllParticles.Count; i++)
            {
                for (int j = 0; j < AllParticles.Count; j++)
                {
                    if (j != i)
                    {
                        List<float> distanceInfo = CalculateDistanceToNode(AllParticles[i], AllParticles[j].CenterPoint);
                        float forceVecMag = CalculateForces(distanceInfo[0], AllParticles[i].Mass, AllParticles[j].Mass);
                        AllParticles[i].AddForce(new ForceVector(AllParticles[i].CenterPoint, AllParticles[j].CenterPoint, forceVecMag, distanceInfo[1], distanceInfo[2]));
                    }
                }
            }
        }

        public void VisualizeForceVectors(int particleNumber, Graphics currenctGraphics, Pen minPen, Pen midPen, Pen maxPen)
        {

            for (int i = 0; i < AllParticles[particleNumber].ForcesToApply.Count; i++)
            {
                float forceVecMag = AllParticles[particleNumber].ForcesToApply[i].Magnitude;
                PointF forceVectStart = AllParticles[particleNumber].ForcesToApply[i].Start;
                PointF forceVectEnd = AllParticles[particleNumber].ForcesToApply[i].End;

                if (forceVecMag == AllParticles[particleNumber].MinForce)
                {
                    currenctGraphics.DrawLine(minPen, forceVectStart, forceVectEnd);
                }
                else if (forceVecMag == AllParticles[particleNumber].MaxForce)
                {
                    currenctGraphics.DrawLine(maxPen, forceVectStart, forceVectEnd);
                }
                else { currenctGraphics.DrawLine(midPen, forceVectStart, forceVectEnd); }
            }
        }

        public void VisualizeGrouping(int particleNumber, Graphics currenctGraphics, Pen graphicsPen)
        {
            Pen drawPen = new Pen(Color.SkyBlue, 2.0f);
            for (int i = 0; i < AllParticles[particleNumber].ForcesToApply.Count; i++)
            {
                float forceVecMag = AllParticles[particleNumber].ForcesToApply[i].Magnitude;
                PointF forceVectStart = AllParticles[particleNumber].ForcesToApply[i].Start;
                PointF forceVectEnd = AllParticles[particleNumber].ForcesToApply[i].EffectorCOM;

                currenctGraphics.DrawLine(graphicsPen, forceVectStart, forceVectEnd);
                currenctGraphics.DrawEllipse(drawPen, forceVectEnd.X - 4,
                    forceVectEnd.Y - 4, 4 * 2, 4 * 2);
                currenctGraphics.FillEllipse(Brushes.NavajoWhite, forceVectEnd.X - 0.5f,
                    forceVectEnd.Y - 0.5f, 0.5f * 2, 0.5f * 2);
            }
        }

        public void BHAlg()
        {
            foreach (Particle particle in AllParticles)
            {
                ForceTraversal(particle, RootNode);
            }
        }

        public void SingleBHStep(int targetParticle)
        {
            ForceTraversal(AllParticles[targetParticle], RootNode.SeChild);
            ForceTraversal(AllParticles[targetParticle], RootNode.NeChild);
            ForceTraversal(AllParticles[targetParticle], RootNode.NwChild);
            ForceTraversal(AllParticles[targetParticle], RootNode.SwChild);
        }

        public TimeSpan SingleFramePairwiseSimulation()
        {
            m_Sw.Reset();
            m_Sw.Start();
            foreach (Particle currentParticle in AllParticles)
            {
                for (int j = 0; j < AllParticles.Count; j++)
                {
                    if (AllParticles[j] != currentParticle)
                    {
                        List<float> distanceInfo = CalculateDistanceToNode(currentParticle, AllParticles[j].CenterPoint);
                        float forceVecMag = CalculateForces(distanceInfo[0], currentParticle.Mass, AllParticles[j].Mass);
                        currentParticle.AddForce(new ForceVector(currentParticle.CenterPoint, AllParticles[j].CenterPoint, forceVecMag, distanceInfo[1], distanceInfo[2]));
                    }
                }
            }
            m_Sw.Stop();
            return m_Sw.Elapsed;
        }

        public TimeSpan SingleFramePairwiseParallelSimulation()
        {
            m_Sw.Reset();
            m_Sw.Start();
            Parallel.ForEach(AllParticles, currentParticle =>
            {
                for (int j = 0; j < AllParticles.Count; j++)
                {
                    if (AllParticles[j] != currentParticle)
                    {
                        List<float> distanceInfo =
                            CalculateDistanceToNode(currentParticle, AllParticles[j].CenterPoint);
                        float forceVecMag =
                            CalculateForces(distanceInfo[0], currentParticle.Mass, AllParticles[j].Mass);
                        currentParticle.AddForce(new ForceVector(currentParticle.CenterPoint,
                            AllParticles[j].CenterPoint, forceVecMag, distanceInfo[1], distanceInfo[2]));
                    }
                }
            });
            m_Sw.Stop();
            return m_Sw.Elapsed;
        }




        public TimeSpan SingleFrameParallelBHSimulationThreadControl(int numberOfThreads, threadModes mode)
        {
            int particlesPerThread = AllParticles.Count / numberOfThreads;

            switch (mode)
            {
                case threadModes.selfMade:
                    List<Thread> workerThreads = new List<Thread>();


                    List<int> threadStartIndecies = new List<int>();
                    List<int> threadEndIndecies = new List<int>();
                    int currentStartIndex = 0;
                    int endIndex;
                    for (int i = 0; i < numberOfThreads; i++)
                    {
                        if (i != numberOfThreads - 1)
                        {
                            threadStartIndecies.Add(currentStartIndex);
                            endIndex = currentStartIndex + particlesPerThread;
                            threadEndIndecies.Add(endIndex);
                            currentStartIndex = endIndex + 1;
                        }
                        else
                        {
                            threadStartIndecies.Add(currentStartIndex);
                            endIndex = AllParticles.Count;
                            threadEndIndecies.Add(endIndex);
                        }




                    }

                    for (int i = 0; i < numberOfThreads; i++)
                    {
                        int si = threadStartIndecies[i];
                        int ei = threadEndIndecies[i];
                        Thread worker = new Thread((() => ForceCalculation(si, ei)));
                        worker.Priority = ThreadPriority.Highest;
                        worker.Name = $"Thread_{i}";
                        workerThreads.Add(worker);
                    }

                    m_Sw.Reset();
                    m_Sw.Start();
                    foreach (var workerThread in workerThreads)
                    {
                        workerThread.Start();
                    }

                    foreach (var workerThread in workerThreads)
                    {
                        workerThread.Join();
                    }

                    m_Sw.Stop();


                    workerThreads = null;
                    return m_Sw.Elapsed;
                    break;
                case threadModes.fromParallelLib:
                    Partitioner<Particle> rangePartitioner = Partitioner.Create(AllParticles, true);
                    //var rn = Partitioner.Create(0, AllParticles.Count, 10);

                    m_Sw.Reset();
                    m_Sw.Start();
                    Parallel.ForEach(rangePartitioner,
                        new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads },
                        (currentParticle) =>
                        {

                            Thread.CurrentThread.Priority = ThreadPriority.Highest;


                            ForceTraversal(currentParticle, RootNode.SeChild);
                            ForceTraversal(currentParticle, RootNode.NeChild);
                            ForceTraversal(currentParticle, RootNode.NwChild);
                            ForceTraversal(currentParticle, RootNode.SwChild);
                        });
                    m_Sw.Stop();

                    return m_Sw.Elapsed;
                    break;
                default:
                    return new TimeSpan();
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }


        }

        public TimeSpan SingleFrameBHSimulation()
        {
            m_Sw.Reset();
            m_Sw.Start();
            foreach (Particle currentParticle in AllParticles)
            {
                ForceTraversal(currentParticle, RootNode.SeChild);
                ForceTraversal(currentParticle, RootNode.NeChild);
                ForceTraversal(currentParticle, RootNode.NwChild);
                ForceTraversal(currentParticle, RootNode.SwChild);
            }
            m_Sw.Stop();
            return m_Sw.Elapsed;
        }

        private void ForceCalculation(int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                Particle currentParticle = AllParticles[i];
                ForceTraversal(currentParticle, RootNode.SeChild);
                ForceTraversal(currentParticle, RootNode.NeChild);
                ForceTraversal(currentParticle, RootNode.NwChild);
                ForceTraversal(currentParticle, RootNode.SwChild);
            }

        }

        public TimeSpan ParallelSingleFrameBHSimulation()
        {
            m_Sw.Reset();
            int numberOfThreads = 6;
            int particlesPerThread = AllParticles.Count / 6;

            List<int> threadStartIndecies = new List<int>();
            int currentStartIndex = 0;
            threadStartIndecies.Add(currentStartIndex);
            for (int i = 0; i < numberOfThreads - 1; i++)
            {
                currentStartIndex += particlesPerThread;
                threadStartIndecies.Add(currentStartIndex);
            }
            Thread firstThread = new Thread((() => ForceCalculation(threadStartIndecies[0], particlesPerThread)));
            Thread secondThread = new Thread((() => ForceCalculation(threadStartIndecies[1], particlesPerThread)));
            Thread thirdThread = new Thread((() => ForceCalculation(threadStartIndecies[2], particlesPerThread)));
            Thread fourthThread = new Thread((() => ForceCalculation(threadStartIndecies[3], particlesPerThread)));
            Thread fifthThread = new Thread((() => ForceCalculation(threadStartIndecies[4], particlesPerThread)));
            Thread sixthThread = new Thread((() => ForceCalculation(threadStartIndecies[5], particlesPerThread)));

            m_Sw.Start();

            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();
            fourthThread.Start();
            fifthThread.Start();
            sixthThread.Start();

            firstThread.Join();
            secondThread.Join();
            thirdThread.Join();
            fourthThread.Join();
            fifthThread.Join();
            sixthThread.Join();

            m_Sw.Stop();
            return m_Sw.Elapsed;
        }

        public TimeSpan ParallelSingleParticleBH(int targetParticle)
        {
            m_Sw.Reset();
            Thread SeThread = new Thread(new ThreadStart(() => ProxyForceTrav(AllParticles[targetParticle], RootNode.SeChild)
                ));
            Thread NeThread = new Thread(new ThreadStart(() => ProxyForceTrav(AllParticles[targetParticle], RootNode.NeChild)
                ));
            Thread NwThread = new Thread(new ThreadStart(() => ProxyForceTrav(AllParticles[targetParticle], RootNode.NwChild)
                ));
            Thread SwThread = new Thread(new ThreadStart(() => ProxyForceTrav(AllParticles[targetParticle], RootNode.SwChild)
                ));

            SeThread.Name = "One";
            NeThread.Name = "Two";
            NwThread.Name = "Three";
            SwThread.Name = "Four";

            SeThread.Start();
            NeThread.Start();
            NwThread.Start();
            SwThread.Start();

            m_Sw.Start();
            SeThread.Join();
            NeThread.Join();
            NwThread.Join();
            SwThread.Join();
            m_Sw.Stop();
            return Thread1Worktime + Thread2Worktime + Thread3Worktime + Thread4Worktime;
        }

        public void ProxyForceTrav(Particle currentParticle, Node startNode)
        {
            Thread thr = Thread.CurrentThread;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            ForceTraversal(currentParticle, startNode);
            sw.Stop();
            if (thr.Name == "One")
            {
                Thread1Worktime = sw.Elapsed;
            }

            if (thr.Name == "Two")
            {
                Thread2Worktime = sw.Elapsed;
            }

            if (thr.Name == "Three")
            {
                Thread3Worktime = sw.Elapsed;
            }

            if (thr.Name == "Four")
            {
                Thread4Worktime = sw.Elapsed;
            }
        }

        public void ForceTraversal(Particle currentParticle, Node startNode)
        {


            List<float> distanceToNodeInfo = new List<float>();

            if (startNode.nodeParticles.Count == 0)
            {
                return;

            }

            if (startNode.nodeParticles.Count == 1)
            {
                distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.nodeParticles[0].CenterPoint);
            }
            else
            {
                distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.centerOfMass);
            }

            //if (startNode.IsLeaf)
            //{
            //    distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.nodeParticles[0].CenterPoint);

            //}
            //else
            //{
            //    distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.centerOfMass);
            //}


            if (LengthIsOverDouble(startNode.SideLength, distanceToNodeInfo[0]) || startNode.nodeParticles.Count == 1)
            {

                float force = CalculateForces(distanceToNodeInfo[0], currentParticle.Mass, startNode.TotalMass);
                ForceVector forceVect = new ForceVector(currentParticle.CenterPoint, startNode.centerOfMass, mag: distanceToNodeInfo[0], sinAng: distanceToNodeInfo[1], cosAng: distanceToNodeInfo[2]);
                if (startNode.nodeParticles.Count == 1)
                {
                    forceVect = new ForceVector(currentParticle.CenterPoint, startNode.nodeParticles[0].CenterPoint, mag: distanceToNodeInfo[0], sinAng: distanceToNodeInfo[1], cosAng: distanceToNodeInfo[2]);
                }

                if (startNode.nodeParticles[0] != currentParticle)
                {
                    currentParticle.ForcesToApply.Add(forceVect);
                }

            }
            else
            {
                ForceTraversal(currentParticle, startNode.SeChild);
                ForceTraversal(currentParticle, startNode.NeChild);
                ForceTraversal(currentParticle, startNode.NwChild);
                ForceTraversal(currentParticle, startNode.SwChild);
            }

        }

        float CalculateForces(float distance, float particleMass, float nodeMass)
        {
            float totalMass = particleMass * nodeMass;
            return G * totalMass / (float)Math.Pow(distance, 2);
        }

        bool LengthIsOverDouble(float nodeSideLength, float distanceToNode)
        {

            return distanceToNode > nodeSideLength * theta;
        }

        public List<float> CalculateDistanceToNode(Particle targetParticle, PointF targetPoint)
        {
            float sideA = targetPoint.X - targetParticle.CenterPoint.X;
            float sideB = targetPoint.Y - targetParticle.CenterPoint.Y;
            float distance = (float)Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            float angleSin = sideB / distance;
            float angleCos = sideA / distance;
            return new List<float>() { distance, angleSin, angleCos };
        }

        public void ParitionSpace()
        {
            for (int q = 0; q < AllParticles.Count; q++)
            {
                Debug.WriteLine($"Adding particle {q}...");
                RootNode.AddParticle(AllParticles[q]);

                if (q % 5 == 0)
                {
                    MyEventArgs args = new MyEventArgs(q);
                    RaiseEventOnUIThread(OnProgress, new object[] { null, args });
                }
            }

            RaiseEventOnUIThread(OnCompleted, new object[] { null, new EventArgs() });

        }

        public void GenerateParticles(int particleCount)
        {
            Random rand = new Random();
            List<Point> testPoints = new List<Point>()
            {
                new Point(91, 395),
                new Point(500, 10),
                new Point(110, 605),
                new Point(414, 695),
                new Point(705, 295)
            };

            List<Point> testPoints2 = new List<Point>()
            {
                new Point(103, 89),
                new Point(103, 88),
                new Point(89, 396),
                new Point(100, 395),
                new Point(90, 400)
            };
            for (int i = 0; i < particleCount; i++)
            {
                Particle newParticle = new Particle();
                int x = rand.Next(5, 730);
                int y = rand.Next(5, 730);
                bool pointSet = false;
                int doubleHit = 0;
                while (!pointSet)
                {
                    pointSet = false;
                    if (!pointMap[x, y])
                    {
                        Point particleCenter = new Point(x, y);
                        //newParticle.CenterPoint = testPoints2[i];
                        newParticle.CenterPoint = particleCenter;
                        AllParticles.Add(newParticle);
                        pointMap[x, y] = true;
                        pointSet = true;
                    }
                    else
                    {
                        x = rand.Next(5, 730);
                        y = rand.Next(5, 730);
                        doubleHit++;
                    }
                }
            }
        }


        public void ClearParticles()
        {
            AllParticles.Clear();
            Point bottomLeft = new Point(0, 737);
            Point topRight = new Point(737, 0);
            RootNode = new Node(topRight, bottomLeft);
            RootNode.IsRoot = true;
        }
    }
}
