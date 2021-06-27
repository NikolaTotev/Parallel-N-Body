using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using static System.Math;
using System.Drawing;
using System.Drawing.Text;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PNB_Lib
{
    public delegate void SimFrameCompleteEventHandler(object source, SimFrameCompleteArgs e);

    public enum SimulationStep
    {
        first, second
    }

    public class QuadTree
    {
        private int m_ParticleCount;
        private List<Particle> m_Particles;
        private int m_SimSpaceXLen;
        private int m_SimSpaceYLen;
        private Node m_RootNode;
        private bool[,] m_ParticleMap;
        private float m_Theta = 2f;
        private float m_G = (float)(6.67408 * Pow(10, -7));
        private float m_Softening = 0.9f;
        private Stopwatch m_Sw;
        private float m_Dt = 0.4f;
        private float m_Boost = 3000;

        private InteractionAlgorithm m_AlgToUse;
        private bool m_IsParallel;
        private int m_TargetParticle = 0;

        private bool m_DrawFlagShowAccelDirection;
        private bool m_DrawFlagShowTree;
        private bool m_DrawFlagShowVelDirection;
        private bool m_DrawFlagShowBHGrouping;
        private bool m_DrawFlagShowEmptyTreeCells;
        private bool m_DrawFlagUseDifferentColors;
        private bool m_DrawFlagShowCOG;

        private int m_AutoConfigMaxThreads = 1;
        private ThreadMode m_AutoConfigThreadMode = ThreadMode.customThreads;
        private bool m_AutoConfigShouldStopTest = false;

        private int m_SimConfigNumberOfFrames = 200;
        private bool m_SimConfigShouldStopSim = false;

        private int m_ThreadConfigMaxThreads = 1;
        private ThreadMode m_ThreadConfigThreadMode = ThreadMode.customThreads;

        public event SimFrameCompleteEventHandler OnFrameComplete;

        public QuadTree(int simSpaceX, int simSpaceY)
        {
            m_Particles = new List<Particle>();
            m_SimSpaceXLen = simSpaceX;
            m_SimSpaceYLen = simSpaceY;
            m_ParticleMap = new bool[m_SimSpaceXLen, m_SimSpaceYLen];
            m_Sw = new Stopwatch();
        }

        public List<Particle> GetParticles()
        {
            return m_Particles;
        }
        public void SetTheta(float newTheta)
        {
            m_Theta = newTheta;
        }

        public void SetParticleCount(int newParticleCount)
        {
            m_ParticleCount = newParticleCount;
        }

        public void SetAlgorithm(InteractionAlgorithm newAlg)
        {
            m_AlgToUse = newAlg;
        }

        public void SetParallelStatus(bool? newStatus)
        {
            m_IsParallel = newStatus ?? false;
        }

        public void SetTargetParticle(int newTarget)
        {
            m_TargetParticle = newTarget;
        }


        public void SetDrawFlagShowAccelDirection(bool? newFlag)
        {
            m_DrawFlagShowAccelDirection = newFlag ?? false;
        }

        public void SetDrawFlagShowVelDirection(bool? newFlag)
        {
            m_DrawFlagShowVelDirection = newFlag ?? false;
        }

        public void SetDrawFlagShowTree(bool? newFlag)
        {
            m_DrawFlagShowTree = newFlag ?? false;
        }

        public void SetDrawFlagShowEmptyTreeCells(bool? newFlag)
        {
            m_DrawFlagShowEmptyTreeCells = newFlag ?? false;
        }

        public void SetDrawFlagShowBHGrouping(bool? newFlag)
        {

            m_DrawFlagShowBHGrouping = newFlag ?? false;
        }

        public void SetDrawFlagUseDifferentColors(bool? newFlag)
        {
            m_DrawFlagUseDifferentColors = newFlag ?? false;
        }

        public void SetDrawFlagShowCOG(bool? newFlag)
        {
            m_DrawFlagShowCOG = newFlag ?? false;
        }

        public void SetAutoConfigMaxThreadCount(int newMaxCount)
        {
            m_AutoConfigMaxThreads = newMaxCount;
        }

        public void SetAutoConfigThreadMode(ThreadMode newMode)
        {
            m_AutoConfigThreadMode = newMode;
        }

        public void SetAutoConfigShouldStopTest(bool shouldStop)
        {
            m_AutoConfigShouldStopTest = shouldStop;
        }


        public void SetThreadConfigMaxThreads(int newMaxCount)
        {
            m_ThreadConfigMaxThreads = newMaxCount;
        }

        public void SetThreadConfigThreadMode(ThreadMode newMode)
        {
            m_ThreadConfigThreadMode = newMode;
        }

        public void SetSimConfigNumberOfFrames(int newFrameCount)
        {
            m_SimConfigNumberOfFrames = newFrameCount;
        }

        public void SetSimConfigShouldStopSim(bool shouldStop)
        {
            m_SimConfigShouldStopSim = shouldStop;
        }

        public void GenerateParticles()
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

            int colorCounter = 0;
            for (int i = 0; i < m_ParticleCount; i++)
            {
                Particle newParticle = new Particle();
                //int x = rand.Next(5, 730);
                //int y = rand.Next(5, 730);
                int x = rand.Next(250, 550);
                int y = rand.Next(250, 550);

                bool pointSet = false;
                int doubleHit = 0;
                while (!pointSet)
                {
                    pointSet = false;
                    if (!m_ParticleMap[x, y])
                    {
                        Point particleCenter = new Point(x, y);
                        if (false)
                        {
                            newParticle.CenterPoint = testPoints2[i];
                        }
                        else
                        {
                            newParticle.CenterPoint = particleCenter;
                        }

                        if (m_DrawFlagUseDifferentColors)
                        {
                            switch (colorCounter)
                            {
                                case 0:
                                    newParticle.particleColor = Color.MediumPurple;
                                    break;
                                case 1:
                                    newParticle.particleColor = Color.Violet;
                                    break;
                                case 2:
                                    newParticle.particleColor = Color.Purple;
                                    break;
                                case 3:
                                    newParticle.particleColor = Color.Orange;
                                    break;
                                case 4:
                                    newParticle.particleColor = Color.DarkOrange;
                                    break;
                                case 5:
                                    newParticle.particleColor = Color.OrangeRed;
                                    break;
                            }
                            colorCounter++;
                        }
                        else
                        {
                            newParticle.particleColor = Color.Orange;
                        }
                        
                        m_Particles.Add(newParticle);
                        m_ParticleMap[x, y] = true;
                        pointSet = true;
                    }
                    else
                    {
                        x = rand.Next(5, 730);
                        y = rand.Next(5, 830);
                        doubleHit++;
                    }
                }
            }
        }

        public void Partition()
        {

        }

        public void StartAutoTest()
        {

        }

        public void StartSimulation()
        {


            Stopwatch frameSw = new Stopwatch();
            switch (m_AlgToUse)
            {
                case InteractionAlgorithm.PWI:

                    for (int i = 0; i < m_SimConfigNumberOfFrames; i++)
                    {
                        frameSw.Start();
                        PrepareStepExecution(m_ThreadConfigThreadMode, m_ThreadConfigMaxThreads, SimulationStep.first);
                        PairwiseForceCalculation(m_IsParallel, m_ThreadConfigMaxThreads);
                        PrepareStepExecution(m_ThreadConfigThreadMode, m_ThreadConfigMaxThreads, SimulationStep.second);
                        frameSw.Stop();
                        Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                        {
                            SimFrameCompleteArgs args = new SimFrameCompleteArgs(frameSw.Elapsed, i);
                            RaiseEventOnUIThread(OnFrameComplete, new object[] { null, args });
                        }), DispatcherPriority.Background);
                      
                        frameSw.Reset();
                    }

                    break;
                case InteractionAlgorithm.BH:
                    //TODO Implement BH alg.
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region First Simulation Step




        public void PrepareStepExecution(ThreadMode threadMode, int threadCount, SimulationStep simulationStep)
        {
            if (!m_IsParallel)
            {
                int particlesPerThread = m_Particles.Count / threadCount;

                switch (threadMode)
                {
                    case ThreadMode.customThreads:
                        List<Thread> workerThreads = new List<Thread>();

                        List<int> threadStartIndecencies = new List<int>(threadCount);
                        List<int> threadEndIndecencies = new List<int>();

                        int currentStartIndex = 0;

                        for (int i = 0; i < threadCount; i++)
                        {
                            int endIndex;
                            if (i != threadCount - 1)
                            {
                                threadStartIndecencies.Add(currentStartIndex);
                                endIndex = currentStartIndex + particlesPerThread;
                                threadEndIndecencies.Add(endIndex);
                                currentStartIndex = endIndex + 1;
                            }
                            else
                            {
                                threadStartIndecencies.Add(currentStartIndex);
                                endIndex = m_Particles.Count;
                                threadEndIndecencies.Add(endIndex);
                            }
                        }

                        for (int i = 0; i < threadCount; i++)
                        {
                            int startIndex = threadStartIndecencies[i];
                            int endIndex = threadEndIndecencies[i];
                            Thread worker;

                            switch (simulationStep)
                            {
                                case SimulationStep.first:
                                    worker = new Thread((() => PartitionMultithreadExecution(startIndex, endIndex, simulationStep)));
                                    break;
                                case SimulationStep.second:
                                    worker = new Thread((() => PartitionMultithreadExecution(startIndex, endIndex, simulationStep)));
                                    break;
                                default:
                                    worker = new Thread((ErrorInSimPart));
                                    break;
                            }

                            worker.Priority = ThreadPriority.Highest;
                            worker.Name = $"Thread_{i}";
                            workerThreads.Add(worker);
                        }

                        foreach (var workerThread in workerThreads)
                        {
                            workerThread.Start();
                        }

                        foreach (var workerThread in workerThreads)
                        {
                            workerThread.Join();
                        }

                        workerThreads.Clear();

                        break;

                    case ThreadMode.tplThreads:
                        Partitioner<Particle> rangePartitioner = Partitioner.Create(m_Particles, true);

                        Parallel.ForEach(rangePartitioner,
                            new ParallelOptions { MaxDegreeOfParallelism = threadCount },
                            (currentParticle) =>
                            {

                                Thread.CurrentThread.Priority = ThreadPriority.Highest;

                                switch (simulationStep)
                                {
                                    case SimulationStep.first:
                                        ExecuteFirstSimulationStepCalculations(currentParticle);
                                        break;
                                    case SimulationStep.second:
                                        ExecuteSecondSimulationStepCalculations(currentParticle);
                                        break;
                                }

                            });

                        break;
                }
            }


            foreach (Particle particle in m_Particles)
            {
                ExecuteFirstSimulationStepCalculations(particle);
            }
        }

        void ErrorInSimPart()
        {

        }

        public void PartitionMultithreadExecution(int startIndex, int endIndex, SimulationStep simulationStep)
        {
            switch (simulationStep)
            {
                case SimulationStep.first:
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        Particle currentParticle = m_Particles[i];
                        ExecuteFirstSimulationStepCalculations(currentParticle);
                    }
                    break;
                case SimulationStep.second:
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        Particle currentParticle = m_Particles[i];
                        ExecuteSecondSimulationStepCalculations(currentParticle);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(simulationStep), simulationStep, null);
            }


        }

        public void ExecuteFirstSimulationStepCalculations(Particle currentParticle)
        {
            currentParticle.VelocityComponents.X += m_Boost * currentParticle.AccelerationComponents.X * m_Dt / 2;
            currentParticle.VelocityComponents.Y += m_Boost * currentParticle.AccelerationComponents.Y * m_Dt / 2;

            PointF newCenter = currentParticle.CenterPoint;

            newCenter.X += currentParticle.VelocityComponents.X * m_Dt;
            newCenter.Y += currentParticle.VelocityComponents.Y * m_Dt;

            currentParticle.CenterPoint = newCenter;

            if (currentParticle.CenterPoint.X > m_SimSpaceXLen)
            {
                currentParticle.VelocityComponents.X = -currentParticle.VelocityComponents.X;
            }
            else if (currentParticle.CenterPoint.X < 0)
            {
                currentParticle.VelocityComponents.X = -currentParticle.VelocityComponents.X;
            }

            if (currentParticle.CenterPoint.Y > m_SimSpaceYLen)
            {
                currentParticle.VelocityComponents.Y = -currentParticle.VelocityComponents.Y;
            }
            else if (currentParticle.CenterPoint.Y < 0)
            {
                currentParticle.VelocityComponents.Y = -currentParticle.VelocityComponents.Y;
            }
        }

        #endregion


        public void ExecuteSecondSimulationStepCalculations(Particle currentParticle)
        {
            currentParticle.VelocityComponents.X += m_Boost * currentParticle.AccelerationComponents.X * m_Dt / 2;
            currentParticle.VelocityComponents.Y += m_Boost * currentParticle.AccelerationComponents.Y * m_Dt / 2;
        }

        public TimeSpan PairwiseForceCalculation(bool isParalell, int threadCount = 1)
        {
            
            foreach (Particle currentParticle in m_Particles)
            {
                currentParticle.AccelerationComponents.X = 0;
                currentParticle.AccelerationComponents.Y = 0;
            }

            switch (isParalell)
            {
                case true:
                    m_Sw.Reset();
                    m_Sw.Start();
                    Parallel.ForEach(m_Particles, new ParallelOptions { MaxDegreeOfParallelism = threadCount },
                        currentParticle =>
                        {
                            for (int j = 0; j < m_Particles.Count; j++)
                            {
                                if (m_Particles[j] != currentParticle)
                                {
                                    ParticleToParticleForceCalculation(currentParticle, m_Particles[j]);
                                }
                            }
                        });
                    m_Sw.Stop();
                    break;
                case false:
                    m_Sw.Reset();
                    m_Sw.Start();
                    foreach (Particle currentParticle in m_Particles)
                    {
                        currentParticle.AccelerationComponents.X = 0;
                        currentParticle.AccelerationComponents.Y = 0;

                        for (int j = 0; j < m_Particles.Count; j++)
                        {
                            if (m_Particles[j] != currentParticle)
                            {
                                ParticleToParticleForceCalculation(currentParticle, m_Particles[j]);
                            }

                        }
                    }
                    m_Sw.Stop();
                    break;
            }

            return m_Sw.Elapsed;
        }

        public void BarnesHutForceCalculation()
        {
            //TODO Implement BH Force Calculation Function
        }

        public void ParticleToParticleForceCalculation(Particle targetParticle, Particle effector)
        {
            List<float> distanceInfo =
                CalculateDistanceBetweenPoints(targetParticle.CenterPoint, effector.CenterPoint);

            float diffXT = distanceInfo[3]; // AllParticles[j].CenterPoint.X - currentParticle.CenterPoint.X;
            float diffYT = distanceInfo[4]; // AllParticles[j].CenterPoint.Y - currentParticle.CenterPoint.Y;

            float inv_r2t = (float)Pow((Pow(diffXT, 2) + Pow(diffYT, 2) + Pow(m_Softening, 2)), -1.5);

            float xVal = m_G * (diffXT * inv_r2t) * effector.Mass;
            float yVal = m_G * (diffYT * inv_r2t) * effector.Mass;
            targetParticle.ApplyAcceleration(xVal, yVal);
        }

        public void ParticleToNodeForceCalculation(Particle currentParticle, Node currentNode)
        {
            //TODO Implement Particle -> Node interaction
        }


        public List<float> CalculateDistanceBetweenPoints(PointF firstPoint, PointF secondPoint)
        {
            float diffX = secondPoint.X - firstPoint.X; //equiv of diffX
            float diffY = secondPoint.Y - firstPoint.Y; //equiv of diffY
            float distance = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            float angleSin = diffY / distance;
            float angleCos = diffX / distance;
            return new List<float>() { distance, angleSin, angleCos, diffX, diffY };
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
            return m_G * totalMass / (float)Math.Pow(distance, 2);
        }


        public bool IsDistanceOverDoubleSideLenght(float nodeSideLength, float distanceToNode)
        {
            return distanceToNode > nodeSideLength * m_Theta;
        }

        public void ResetTree()
        {
            m_Particles.Clear();
            ResetRootNode();
        }

        public void ResetRootNode()
        {
            m_RootNode = null;
            PointF bottomLeft = new Point(0, 737);
            PointF topRight = new Point(737, 0);
            m_RootNode = new Node(topRight, bottomLeft);
            m_RootNode.IsRoot = true;
        }

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

    }
}