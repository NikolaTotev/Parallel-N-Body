﻿using System;
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
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Controls;


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
    #region Enums
    public enum threadMode
    {
        selfMade,
        fromParallelLib

    };

    public enum AlgToUse
    {
        PWI, PPWI, BH, PBH
    }

    #endregion
    class QuadTree
    {
        public List<Particle> AllParticles { get; set; }

        public Node RootNode { get; set; }
        private float G = (float)(6.67408 * Pow(10, -8));
        public float theta = 2f;
        public bool UseStaticPoints;

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

        public bool DrawNodeCOG { get; set; }
        public bool DrawEmptyCells { get; set; }
        public bool DrawBhNodeGrouping { get; set; }
        public bool ShowResultantForce { get; set; }
        public bool ShowShiftedVectors { get; set; }

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

        /// <summary>
        /// Partitions the space until there is only 1 particle per node.
        /// </summary>
        public void PartitionSpace()
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

        /// <summary>
        /// Generates unique particles based on the particle count passed to the function.
        /// No duplicates are created.
        /// </summary>
        /// <param name="particleCount"></param>
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
                new Point(153, 88),
                new Point(89, 396),
                new Point(50, 395),
                new Point(250, 400)
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
                        if (UseStaticPoints)
                        {
                            newParticle.CenterPoint = testPoints2[i];
                        }
                        else
                        {
                            newParticle.CenterPoint = particleCenter;
                        }
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


        /// <summary>
        /// Calculate a single frame of the N-Body simulation using Pairwise interation (brute force).
        /// Returns the time required for the whole frame to be calculated.
        /// </summary>
        /// <returns>TimeSpan</returns>
        public TimeSpan SingleFramePairwiseSimulation(bool isParalell, int threadCount = 1)
        {

            switch (isParalell)
            {
                case true:
                    m_Sw.Reset();
                    m_Sw.Start();
                    Parallel.ForEach(AllParticles, new ParallelOptions { MaxDegreeOfParallelism = threadCount },
                        currentParticle =>
                        {
                            currentParticle.ForcesToApply.Clear();
                            for (int j = 0; j < AllParticles.Count; j++)
                            {
                                if (AllParticles[j] != currentParticle)
                                {
                                    List<float> distanceInfo =
                                        CalculateDistanceToNode(currentParticle, AllParticles[j].CenterPoint);
                                    float forceVecMag =
                                        GravitationalForceCalculation(distanceInfo[0], currentParticle.Mass, AllParticles[j].Mass);
                                    currentParticle.AddForce(new ForceVector(currentParticle.CenterPoint,
                                        AllParticles[j].CenterPoint, forceVecMag, distanceInfo[1], distanceInfo[2]));



                                }
                            }
                            CalculateResultantVector(currentParticle);

                        });
                    m_Sw.Stop();
                    break;
                case false: //Is the "default:" case false:?
                    m_Sw.Reset();
                    m_Sw.Start();
                    foreach (Particle currentParticle in AllParticles)
                    {
                        currentParticle.ForcesToApply.Clear();
                        for (int j = 0; j < AllParticles.Count; j++)
                        {
                            if (AllParticles[j] != currentParticle)
                            {
                                List<float> distanceInfo = CalculateDistanceToNode(currentParticle, AllParticles[j].CenterPoint);
                                float forceVecMag = GravitationalForceCalculation(distanceInfo[0], currentParticle.Mass, AllParticles[j].Mass);
                                currentParticle.AddForce(new ForceVector(currentParticle.CenterPoint, AllParticles[j].CenterPoint, forceVecMag, distanceInfo[1], distanceInfo[2]));
                            }
                            
                        }
                        currentParticle.CalculateResultantForce();




                        //currentParticle.MoveParticle();
                        //CalculateResultantVector(currentParticle);
                    }
                    m_Sw.Stop();
                    break;
            }

            return m_Sw.Elapsed;
        }


        public void Method2AccelerationCalculation()
        {
            float diffX = 0;
            float diffY = 0;
            float inv_r2X = 0;
            float inv_r2Y = 0;
            float softening = 0.1f;


            foreach (Particle currentParticle in AllParticles)
            {
                for (int j = 0; j < AllParticles.Count; j++)
                {
                    if (AllParticles[j] != currentParticle)
                    {
                        diffX = AllParticles[j].CenterPoint.X - currentParticle.CenterPoint.X;
                        diffY = AllParticles[j].CenterPoint.Y - currentParticle.CenterPoint.Y;
                        inv_r2X = (float)Pow((Pow(diffX, 2) + softening), -1.5);
                        inv_r2Y = (float)Pow((Pow(diffY, 2) + softening), -1.5);
                        currentParticle.Method2AccelComponents.X += G * (diffX * inv_r2X) * AllParticles[j].Mass;
                        currentParticle.Method2AccelComponents.Y += G * (diffY * inv_r2Y) * AllParticles[j].Mass;

                    }
                }
            }
        }

        /// <summary>
        /// Calculate a single frame of the simulation using the BH algorithm. It can be executed sequentially or in parallel with the option
        /// for selecting the number of threads being used as well as the multithreading implementation.
        /// </summary>
        /// <param name="isParallel"></param>
        /// <param name="numberOfThreads"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public TimeSpan SingleFrameBHSimulation(bool isParallel, int numberOfThreads = 1, threadMode mode = threadMode.fromParallelLib)
        {

            switch (isParallel)
            {
                case true:

                    int particlesPerThread = AllParticles.Count / numberOfThreads;

                    switch (mode)
                    {
                        case threadMode.selfMade:
                            List<Thread> workerThreads = new List<Thread>();


                            List<int> threadStartIndecencies = new List<int>(numberOfThreads);
                            List<int> threadEndIndecencies = new List<int>();
                            int currentStartIndex = 0;
                            int endIndex;
                            for (int i = 0; i < numberOfThreads; i++)
                            {
                                if (i != numberOfThreads - 1)
                                {
                                    threadStartIndecencies.Add(currentStartIndex);
                                    endIndex = currentStartIndex + particlesPerThread;
                                    threadEndIndecencies.Add(endIndex);
                                    currentStartIndex = endIndex + 1;
                                }
                                else
                                {
                                    threadStartIndecencies.Add(currentStartIndex);
                                    endIndex = AllParticles.Count;
                                    threadEndIndecencies.Add(endIndex);
                                }
                            }

                            for (int i = 0; i < numberOfThreads; i++)
                            {
                                int si = threadStartIndecencies[i];
                                int ei = threadEndIndecencies[i];
                                Thread worker = new Thread((() => BhAlgForceCalculation(si, ei)));
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
                        case threadMode.fromParallelLib:
                            Partitioner<Particle> rangePartitioner = Partitioner.Create(AllParticles, true);
                            //var rn = Partitioner.Create(0, AllParticles.Count, 10);

                            m_Sw.Reset();
                            m_Sw.Start();
                            Parallel.ForEach(rangePartitioner,
                                new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads },
                                (currentParticle) =>
                                {

                                    Thread.CurrentThread.Priority = ThreadPriority.Highest;


                                    BhAlgApplyForceOnParticle(currentParticle, RootNode.SeChild);
                                    BhAlgApplyForceOnParticle(currentParticle, RootNode.NeChild);
                                    BhAlgApplyForceOnParticle(currentParticle, RootNode.NwChild);
                                    BhAlgApplyForceOnParticle(currentParticle, RootNode.SwChild);
                                    CalculateResultantVector(currentParticle);
                                });

                            m_Sw.Stop();

                            return m_Sw.Elapsed;
                        default:
                            return new TimeSpan();
                    }

                case false:
                    m_Sw.Reset();
                    m_Sw.Start();
                    BhAlgForceCalculation(0, AllParticles.Count - 1);
                    m_Sw.Stop();
                    break;
            }
            return m_Sw.Elapsed;

        }


        /// <summary>
        /// Calculate the forces on the particles in the AllParticles array starting from index <startIndex> to <endIndex> (inclusive)
        /// using the BH algorithm for traversing the tree.
        /// For calculating forces using 1 thread, start index is set to 0 and end index the last index of the array.
        /// For calculating forces using multiple threads, partitioning must be done by the calling function
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        private void BhAlgForceCalculation(int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                Particle currentParticle = AllParticles[i];
                BhAlgApplyForceOnParticle(currentParticle, RootNode.SeChild);
                BhAlgApplyForceOnParticle(currentParticle, RootNode.NeChild);
                BhAlgApplyForceOnParticle(currentParticle, RootNode.NwChild);
                BhAlgApplyForceOnParticle(currentParticle, RootNode.SwChild);
                CalculateResultantVector(AllParticles[i]);
            }
        }

        #endregion

        #region Core Force Calculation Functions

        /// <summary>
        /// Calculate the forces for a given particle.
        /// </summary>
        /// <param name="currentParticle"></param>
        /// <param name="startNode"></param>
        public void BhAlgApplyForceOnParticle(Particle currentParticle, Node startNode)
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

            if (LengthIsOverDouble(startNode.SideLength, distanceToNodeInfo[0]) || startNode.nodeParticles.Count == 1)
            {

                float force = GravitationalForceCalculation(distanceToNodeInfo[0], currentParticle.Mass, startNode.totalWeight);
                ForceVector forceVect = new ForceVector(currentParticle.CenterPoint, startNode.centerOfMass, mag: force, sinAng: distanceToNodeInfo[1], cosAng: distanceToNodeInfo[2]);
                if (startNode.nodeParticles.Count == 1)
                {
                    forceVect = new ForceVector(currentParticle.CenterPoint, startNode.nodeParticles[0].CenterPoint, mag: force, sinAng: distanceToNodeInfo[1], cosAng: distanceToNodeInfo[2]);
                }

                if (startNode.nodeParticles[0] != currentParticle)
                {
                    currentParticle.AddForce(forceVect);
                }

            }
            else
            {
                BhAlgApplyForceOnParticle(currentParticle, startNode.SeChild);
                BhAlgApplyForceOnParticle(currentParticle, startNode.NeChild);
                BhAlgApplyForceOnParticle(currentParticle, startNode.NwChild);
                BhAlgApplyForceOnParticle(currentParticle, startNode.SwChild);
            }

        }

        public void CalculateResultantVector(Particle currentParticle)
        {
            PointF resultantVectorStart = currentParticle.CenterPoint;
            PointF resultantVectorEnd = currentParticle.CenterPoint;

            foreach (ForceVector forceVector in currentParticle.ForcesToApply)
            {
                forceVector.ShiftEndPoint(resultantVectorEnd);
                resultantVectorEnd = forceVector.ShiftedEnd;
            }

            currentParticle.ResultantVectorStart = resultantVectorStart;
            currentParticle.ResultantVectorEnd = resultantVectorEnd;

        }

        /// <summary>
        /// Calculate the gravitational forces on a particle based on the particle mass, the node its interacting with and the distance between them.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="particleMass"></param>
        /// <param name="nodeMass"></param>
        /// <returns></returns>
        float GravitationalForceCalculation(float distance, float particleMass, float nodeMass)
        {
            float totalMass = particleMass * nodeMass;
            return G * totalMass / (float)Math.Pow(distance, 2);
        }


        /// <summary>
        /// Checks if the distance to a node is over double the side length of the node.
        /// </summary>
        /// <param name="nodeSideLength"></param>
        /// <param name="distanceToNode"></param>
        /// <returns>bool</returns>
        bool LengthIsOverDouble(float nodeSideLength, float distanceToNode)
        {

            return distanceToNode > nodeSideLength * theta;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetParticle"></param>
        /// <param name="targetPoint"></param>
        /// <returns>
        /// Returns a List<float>
        /// first item = distance to node
        /// second item = sin of the angle between the vector from center to center and the X axis
        /// third item = cos of the angle between the vector from center to center and the X axis
        /// </returns>
        public List<float> CalculateDistanceToNode(Particle targetParticle, PointF targetPoint)
        {
            float sideA = targetPoint.X - targetParticle.CenterPoint.X;
            float sideB = targetPoint.Y - targetParticle.CenterPoint.Y;
            float distance = (float)Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            float angleSin = sideB / distance;
            float angleCos = sideA / distance;
            return new List<float>() { distance, angleSin, angleCos };
        }

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


        /// <summary>
        /// Shows how the BH algorithm has grouped the particles into nodes.
        /// </summary>
        /// <param name="particleNumber"></param>
        /// <param name="currenctGraphics"></param>
        /// <param name="graphicsPen"></param>
        public void VisualizeGrouping(int particleNumber, Graphics currenctGraphics, Pen graphicsPen)
        {
            Pen drawPen = new Pen(Color.Orange, 1.0f);
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


        /// <summary>
        /// Visualizes the force vectors acting upon a given particle.
        /// The strongest vector is in red, the weakest in green and the rest in orange.
        /// </summary>
        /// <param name="particleNumber"></param>
        /// <param name="currenctGraphics"></param>
        /// <param name="minPen"></param>
        /// <param name="midPen"></param>
        /// <param name="maxPen"></param>
        public void VisualizeForceVectors(int particleNumber, Graphics currenctGraphics, Pen minPen, Pen midPen, Pen maxPen)
        {
            PointF ResultantStart = AllParticles[particleNumber].ResultantVectorStart;
            PointF ResultantEnd = AllParticles[particleNumber].ResultantVectorEnd;

            if (ShowResultantForce)
            {
                Pen resultantPen = new Pen(Brushes.Indigo, 2.0f);
                currenctGraphics.DrawLine(resultantPen, ResultantStart, ResultantEnd);
            }

            for (int i = 0; i < AllParticles[particleNumber].ForcesToApply.Count; i++)
            {
                float forceVecMag = AllParticles[particleNumber].ForcesToApply[i].Magnitude;
                PointF forceVectStart = AllParticles[particleNumber].ForcesToApply[i].Start;
                PointF forceVectEnd = AllParticles[particleNumber].ForcesToApply[i].End;
                PointF ShiftedVectorStart = AllParticles[particleNumber].ForcesToApply[i].ShiftedStart;
                PointF ShiftedVectorEnd = AllParticles[particleNumber].ForcesToApply[i].ShiftedEnd;


                if (ShowForceVect)
                {
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



                if (ShowShiftedVectors)
                {
                    Pen resultantPen = new Pen(Brushes.Red, 2.0f);
                    resultantPen.DashStyle = DashStyle.DashDot;
                    resultantPen.DashCap = DashCap.Triangle;
                    currenctGraphics.DrawLine(resultantPen, ShiftedVectorStart, ShiftedVectorEnd);
                }
            }
        }
        #endregion


        public void BHonSingleParticle(int targetParticle)
        {
            BhAlgApplyForceOnParticle(AllParticles[targetParticle], RootNode.SeChild);
            BhAlgApplyForceOnParticle(AllParticles[targetParticle], RootNode.NeChild);
            BhAlgApplyForceOnParticle(AllParticles[targetParticle], RootNode.NwChild);
            BhAlgApplyForceOnParticle(AllParticles[targetParticle], RootNode.SwChild);
            CalculateResultantVector(AllParticles[targetParticle]);
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
            BhAlgApplyForceOnParticle(currentParticle, startNode);
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







        public void Reset()
        {
            AllParticles.Clear();
            RootNode = null;
            PointF bottomLeft = new Point(0, 737);
            PointF topRight = new Point(737, 0);
            RootNode = new Node(topRight, bottomLeft);
            RootNode.IsRoot = true;

        }
    }
}
