using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using static System.Math;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace PNB_Lib
{
    public delegate void SimFrameCompleteEventHandler(object source, SimFrameCompleteArgs e);
    public delegate void AutoTestCompleteHandler(object source, AutoTestCompleteArgs e);
    public delegate void AutoTestStepComplete(object source, AutoTestStepCompleteArgs e);

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
        private float m_Dt = 0.4f;
        private float m_Boost = 3000;

        private InteractionAlgorithm m_AlgToUse;
        private bool m_IsParallel = false;
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
        private int m_AutoConfigCurrentThreadCount = 1;

        private int m_SimConfigNumberOfFrames = 200;
        private bool m_SimConfigShouldStopSim = false;

        private int m_ThreadConfigMaxThreads = 1;
        private ThreadMode m_ThreadConfigThreadMode = ThreadMode.customThreads;

        public event SimFrameCompleteEventHandler OnFrameComplete;
        public event AutoTestCompleteHandler OnAutoTestComplete;
        public event AutoTestStepComplete OnAutoTestStepComplete;
        public event EventHandler OnSimulationComplete;
        public event EventHandler OnPartitionComplete;
        private Thread m_SimulationThread;
        private Thread m_PartitionThread;

        public QuadTree(int simSpaceX, int simSpaceY)
        {
            m_Particles = new List<Particle>();
            m_SimSpaceXLen = simSpaceX;
            m_SimSpaceYLen = simSpaceY;
            m_ParticleMap = new bool[m_SimSpaceXLen, m_SimSpaceYLen];

            ResetRootNode();
        }

        public void CleanUpPartitionThread()
        {
            if (m_PartitionThread != null && Thread.CurrentThread != m_PartitionThread)
            {
                if (m_PartitionThread.IsAlive)
                {
                    if (m_PartitionThread.Join(1000))
                    {
                        Debug.WriteLine("Partition thread joined!");
                    }
                    else
                    {
                        m_PartitionThread.Abort();
                    }
                }
                else
                {
                    m_PartitionThread = null;
                }
            }
        }

        public List<Particle> GetParticles()
        {
            return m_Particles;
        }

        public int GetParticleCount()
        {
            return m_ParticleCount;
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
                int x = rand.Next(5, 730);
                int y = rand.Next(5, 970);

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
                                    colorCounter = 0;
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
                        y = rand.Next(5, 970);
                        doubleHit++;
                    }
                }
            }
        }


        public void StartAutoTest()
        {
            int prevMilis;
            int currentMilis;
            Stopwatch frameSw = Stopwatch.StartNew();
            Stopwatch totalSw = new Stopwatch();
            m_IsParallel = true;
            int repeatFactor = 10;
            double execTimeSum = 0;
            double avgExecTime;
            List<double> execTimes = new List<double>();
            totalSw.Start();
            for (int i = 0; i < m_AutoConfigMaxThreads; i++)
            {
                for (int j = 0; j < repeatFactor; j++)
                {
                    frameSw = Stopwatch.StartNew();
                    PrepareStepExecution(m_ThreadConfigThreadMode, i + 1, SimulationStep.first, false);
                    PairwiseForceCalculation(m_IsParallel, i + 1);
                    PrepareStepExecution(m_ThreadConfigThreadMode, i + 1, SimulationStep.second, false);
                    execTimeSum += frameSw.Elapsed.Milliseconds;
                }

                avgExecTime = execTimeSum / repeatFactor;
                execTimes.Add(avgExecTime);
                AutoTestStepCompleteArgs args = new AutoTestStepCompleteArgs(i, m_AutoConfigMaxThreads, totalSw.Elapsed, avgExecTime);
                execTimeSum = 0;
                OnAutoTestStepComplete?.Invoke(this, args);
            }

            GenerateChartSeriesData(execTimes);
        }

        public double CalculateParallelismLevel(double singleThreadExecTime, double multithreadExecTime)
        {
            return singleThreadExecTime / multithreadExecTime;

        }

        public double CalculateEffectivenessLevels(double parallelismLevel, double numberOfThreads)
        {
            return parallelismLevel / numberOfThreads;

        }

        public void GenerateChartSeriesData(List<double> execTimes)
        {
            List<double> parallelismLevels = new List<double>();
            List<double> effectivenessLevels = new List<double>();

            for (int i = 0; i < execTimes.Count; i++)
            {
                double parallelismLevel = CalculateParallelismLevel(execTimes[0], execTimes[i]);
                parallelismLevels.Add(parallelismLevel);
                effectivenessLevels.Add(CalculateEffectivenessLevels(parallelismLevel, i + 1));

            }

            AutoTestCompleteArgs args = new AutoTestCompleteArgs(parallelismLevels, execTimes, effectivenessLevels);
            OnAutoTestComplete?.Invoke(this, args);
        }

        public void StartParition()
        {
            m_PartitionThread = new Thread(Partition);
            m_PartitionThread.Name = "PartitionThread";
            Debug.WriteLine($"Preparing to start partition thread on {Thread.CurrentThread.Name}");
            m_PartitionThread.Start();
        }



        private void Partition()
        {
            Debug.WriteLine($"Starting partition thread on thread {Thread.CurrentThread.Name}");
            for (int q = 0; q < m_Particles.Count; q++)
            {
                //Debug.WriteLine($"Adding particle {q}...");
                m_RootNode.AddParticle(m_Particles[q]);

                if (q % 5 == 0)
                {
                    //TODO Add events for partition status.
                }
            }

            OnPartitionComplete?.Invoke(null, new EventArgs());
        }

        public void StartSimulation()
        {
            switch (m_AlgToUse)
            {
                case InteractionAlgorithm.PWI:
                    m_SimulationThread = new Thread((() => ExecuteSimulation(false)));
                    m_SimulationThread.Name = "SimulationThread";
                    m_SimulationThread.Start();
                    break;
                case InteractionAlgorithm.BH:
                    m_SimulationThread = new Thread((() => ExecuteSimulation(true)));
                    m_SimulationThread.Name = "SimulationThread";
                    m_SimulationThread.Start();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteSimulation(bool isBH)
        {

            int imageNum = 0;

            for (int i = 0; i < m_SimConfigNumberOfFrames; i++)
            {
                if (!isBH)
                {
                    PrepareStepExecution(m_ThreadConfigThreadMode, m_ThreadConfigMaxThreads, SimulationStep.first, false);
                    PairwiseForceCalculation(m_IsParallel, m_ThreadConfigMaxThreads);
                    PrepareStepExecution(m_ThreadConfigThreadMode, m_ThreadConfigMaxThreads, SimulationStep.second, false);
                }
                else
                {
                    PrepareStepExecution(m_ThreadConfigThreadMode, m_ThreadConfigMaxThreads, SimulationStep.first, false);
                    Partition();
                    PrepareStepExecution(m_ThreadConfigThreadMode, m_ThreadConfigMaxThreads, SimulationStep.first, isBH);
                    PrepareStepExecution(m_ThreadConfigThreadMode, m_ThreadConfigMaxThreads, SimulationStep.second, false);
                    ResetRootNode();
                }

                TimeSpan defaultTS = new TimeSpan();
                Debug.WriteLine($"On Frame {i}");

                SKImageInfo info = new SKImageInfo(737, 979);
                SKBitmap newBitm = new SKBitmap(info);
                SKCanvas canvas = new SKCanvas(newBitm);
                canvas.Clear(SKColors.White);

                foreach (Particle particle in m_Particles)
                {

                    var paint = new SKPaint
                    {
                        Color = particle.particleColor.ToSKColor(),
                        IsAntialias = true,
                        Style = SKPaintStyle.Fill,
                    };
                    canvas.DrawCircle(particle.CenterPoint.X, particle.CenterPoint.Y, 3, paint);
                }


                SKImage image = SKImage.FromBitmap(newBitm);
                var data = image.Encode();


                using (var stream = File.OpenWrite($"D:/Documents/Project Files/N-Body/SimImages/{imageNum}.png"))
                {
                    // save the data to a stream
                    data.SaveTo(stream);
                    stream.Close();
                    stream.Dispose();
                    imageNum++;
                }

                SimFrameCompleteArgs args = new SimFrameCompleteArgs(defaultTS, i);
                OnFrameComplete.Invoke(this, args);
            }

            OnSimulationComplete?.Invoke(this, EventArgs.Empty);
        }

        public void PrepareStepExecution(ThreadMode threadMode, int threadCount, SimulationStep simulationStep, bool isBH)
        {
            if (m_IsParallel)
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
                            if (!isBH)
                            {
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
                            }
                            else
                            {
                                worker = new Thread((() => PartitionBHExecution(startIndex, endIndex)));
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

                                if (!isBH)
                                {
                                    switch (simulationStep)
                                    {
                                        case SimulationStep.first:
                                            ExecuteFirstSimulationStepCalculations(currentParticle);
                                            break;
                                        case SimulationStep.second:
                                            ExecuteSecondSimulationStepCalculations(currentParticle);
                                            break;
                                    }
                                }
                                else
                                {
                                    currentParticle.AccelerationComponents.X = 0;
                                    currentParticle.AccelerationComponents.Y = 0;
                                    BarnesHutForceCalculation(currentParticle, m_RootNode.SeChild);
                                    BarnesHutForceCalculation(currentParticle, m_RootNode.NeChild);
                                    BarnesHutForceCalculation(currentParticle, m_RootNode.NwChild);
                                    BarnesHutForceCalculation(currentParticle, m_RootNode.SwChild);
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

        public void ExecuteSecondSimulationStepCalculations(Particle currentParticle)
        {
            currentParticle.VelocityComponents.X += m_Boost * currentParticle.AccelerationComponents.X * m_Dt / 2;
            currentParticle.VelocityComponents.Y += m_Boost * currentParticle.AccelerationComponents.Y * m_Dt / 2;
        }

        void ErrorInSimPart()
        {

        }


        public void PairwiseForceCalculation(bool isParalell, int threadCount = 1)
        {

            foreach (Particle currentParticle in m_Particles)
            {
                currentParticle.AccelerationComponents.X = 0;
                currentParticle.AccelerationComponents.Y = 0;
            }

            switch (isParalell)
            {
                case true:
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
                    break;
                case false:
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
                    break;
            }
        }

        /// <summary>
        /// Calculate the forces on the particles in the AllParticles array starting from index <startIndex> to <endIndex> (inclusive)
        /// using the BH algorithm for traversing the tree.
        /// For calculating forces using 1 thread, start index is set to 0 and end index the last index of the array.
        /// For calculating forces using multiple threads, partitioning must be done by the calling function
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        private void PartitionBHExecution(int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                Particle currentParticle = m_Particles[i];
                currentParticle.AccelerationComponents.X = 0;
                currentParticle.AccelerationComponents.Y = 0;
                BarnesHutForceCalculation(currentParticle, m_RootNode.SeChild);
                BarnesHutForceCalculation(currentParticle, m_RootNode.NeChild);
                BarnesHutForceCalculation(currentParticle, m_RootNode.NwChild);
                BarnesHutForceCalculation(currentParticle, m_RootNode.SwChild);

            }
        }

        public void BarnesHutForceCalculation(Particle currentParticle, Node startNode)
        {

            List<float> distanceToNodeInfo = new List<float>();
            float currentAccelerationX;
            float currentAccelerationY;
            float inv_r2 = 0;


            if (startNode.nodeParticles.Count == 0)
            {
                return;
            }

            if (startNode.nodeParticles.Count == 1)
            {
                distanceToNodeInfo = CalculateDistanceBetweenPoints(currentParticle.CenterPoint, startNode.nodeParticles[0].CenterPoint);
            }
            else
            {
                distanceToNodeInfo = CalculateDistanceBetweenPoints(currentParticle.CenterPoint, startNode.centerOfMass);
            }

            if (IsDistanceOverDoubleSideLenght(startNode.SideLength, distanceToNodeInfo[0]) || startNode.nodeParticles.Count == 1)
            {

                float force = GravitationalForceCalculation(distanceToNodeInfo[0], currentParticle.Mass, startNode.totalWeight);



                inv_r2 = (float)Pow((Pow(distanceToNodeInfo[3], 2) + Pow(distanceToNodeInfo[4], 2) + Pow(m_Softening, 2)), -1.5);

                if (startNode.nodeParticles.Count == 1)
                {
                    currentAccelerationX = m_G * (distanceToNodeInfo[3] * inv_r2) * startNode.nodeParticles[0].Mass;
                    currentAccelerationY = m_G * (distanceToNodeInfo[4] * inv_r2) * startNode.nodeParticles[0].Mass;
                }
                else
                {
                    currentAccelerationX = m_G * (distanceToNodeInfo[3] * inv_r2) * startNode.totalWeight;
                    currentAccelerationY = m_G * (distanceToNodeInfo[4] * inv_r2) * startNode.totalWeight;
                }

                if (startNode.nodeParticles[0] != currentParticle)
                {
                    currentParticle.AccelerationComponents.X += currentAccelerationX;
                    currentParticle.AccelerationComponents.Y += currentAccelerationY;
                }

            }
            else
            {
                BarnesHutForceCalculation(currentParticle, startNode.SeChild);
                BarnesHutForceCalculation(currentParticle, startNode.NeChild);
                BarnesHutForceCalculation(currentParticle, startNode.NwChild);
                BarnesHutForceCalculation(currentParticle, startNode.SwChild);
            }
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
            PointF bottomLeft = new Point(0, m_SimSpaceYLen);
            PointF topRight = new Point(m_SimSpaceXLen, 0);
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