using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime;
using System.Threading;
using System.Windows.Media;
using CsvHelper;
using LiveCharts;
using LiveCharts.Wpf;
using Brush = System.Drawing.Brush;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;


namespace Barnes_Hut_GUI
{
    public partial class Form1 : Form
    {
        #region Pens

        private Pen m_ParticlePen = new Pen(Color.White);
        private Pen m_TreePen = new Pen(Color.LightBlue);
        private Pen m_MinforceVectPen = new Pen(Color.ForestGreen);
        private Pen m_MidforceVectPen = new Pen(Color.SandyBrown);
        private Pen m_MaxforceVectPen = new Pen(Color.OrangeRed);

        #endregion

        #region Brushes

        private Brush particleBrush = new SolidBrush(Color.CornflowerBlue);
        private Brush particleBrushRed = new SolidBrush(Color.Red);
        private Brush particleBrushYellow = new SolidBrush(Color.Yellow);

        List<Brush> Brushes = new List<Brush>()
        {
            new SolidBrush(Color.Green),
            new SolidBrush(Color.Orange),
            new SolidBrush(Color.BlueViolet),
            new SolidBrush(Color.Red),
            new SolidBrush(Color.CornflowerBlue)
        };

        #endregion

        #region Drawing Constants

        private const int m_ElipseRadius1 = 3;
        private const int m_ElipseRadius2 = 2;
        private const float m_ElipseRadius3 = 0.5f;

        #endregion

        #region Graphics

        private Graphics graphics;
        private Graphics forceVectGraphics;

        #endregion

        #region Draw Flags

        private bool ShowTree;
        private bool ShowEmptyCells;
        private bool ShowForceVect;
        private bool ShowGrouping;
        private bool DrawGraphics;

        #endregion

        #region Thread Vairables

        private Thread m_partitionThread;
        private bool isWorking;
        private bool canReset = true;
        private long PWITicks = 0;
        private long BHTicks = 0;
        private long PBHTicks = 0;
        private threadMode m_currentMode = threadMode.fromParallelLib;
        private TestingMode m_currentTestingMode = TestingMode.ThreadTest;

        enum TestingMode
        {
            SingleFrame,
            ThreadTest,
            SingleFramePlusThreadTest
        }

        #endregion

        private QuadTree mainTree;


        private AlgToUse alg = AlgToUse.PWI;
        private int currentParticleValue = 0;


        public Form1()
        {
            InitializeComponent();
            mainTree = new QuadTree();
            graphics = p_SimulationArea.CreateGraphics();
            forceVectGraphics = p_ForcePanel.CreateGraphics();
            mainTree.alg = AlgToUse.PWI;
            cb_ShowGrouping.Enabled = false;
            rb_UsePWI.Checked = true;
            DrawGraphics = false;
            mainTree.OnProgress += MainTree_OnProgress;
            mainTree.OnCompleted += MainTree_OnCompleted; 
            ShowForceVect = cb_ForceVect.Checked;
            mainTree.ShowForceVect = cb_ForceVect.Checked;
            mainTree.DrawBhNodeGrouping = cb_ShowGrouping.Checked;
            mainTree.DrawNodeCOG = cb_ShowCOG.Checked;
            mainTree.ShowForceVect = cb_TreeOutline.Checked;
            DrawGraphics = cb_DrawGraphics.Checked;
            ShowGrouping = cb_ShowGrouping.Checked;


        }

        #region Event subscriber functions

        private void MainTree_OnCompleted(object sender, EventArgs e)
        {
            if (DrawGraphics)
            {
                DrawTree();
            }
        }

        private void MainTree_OnProgress(object source, MyEventArgs e)
        {
            l_Progress.Text = e.GetInfo().ToString();
        }

        #endregion

        #region Manual Controls Panel

        #region Initialization Controls

        private void btn_Gen100PlusParticles_Click(object sender, EventArgs e)
        {
            mainTree.Reset();
            graphics.Clear(Color.White);
            currentParticleValue += 100;
            tb_ParticleCount.Text = currentParticleValue.ToString();
            mainTree.GenerateParticles(currentParticleValue);
            DrawParticles(currentParticleValue);
            CalculateForces();
        }

        #endregion

        #region Visualization Options

        private void cb_TreeOutline_CheckedChanged(object sender, EventArgs e)
        {
            ShowForceVect = cb_TreeOutline.Checked;
            mainTree.ShowForceVect = cb_TreeOutline.Checked;
        }


        private void cb_ShowEmptyCells_CheckedChanged(object sender, EventArgs e)
        {
            ShowEmptyCells = cb_ShowEmptyCells.Checked;
            mainTree.DrawBhNodeGrouping = cb_ShowEmptyCells.Checked;
        }

        private void cb_DrawGraphics_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraphics = cb_DrawGraphics.Checked;
        }

        #endregion


        #region Algorithm Selection

        private void rb_UsePWI_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_UsePWI.Checked)
            {
                alg = AlgToUse.PWI;
                mainTree.alg = AlgToUse.PWI;
                cb_ShowGrouping.Enabled = false;
                ShowGrouping = false;
                mainTree.DrawBhNodeGrouping = false;
            }
        }

        private void rb_ParallelPWI_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ParallelPWI.Checked)
            {
                alg = AlgToUse.PPWI;
                mainTree.alg = AlgToUse.PPWI;
                cb_ShowGrouping.Enabled = false;
            }
        }

        private void rb_UseBH_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_UseBH.Checked)
            {
                alg = AlgToUse.BH;
                mainTree.alg = AlgToUse.BH;
                cb_ShowGrouping.Enabled = true;
            }
        }

        private void rb_ParlBH_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ParlBH.Checked)
            {
                alg = AlgToUse.PBH;
                mainTree.alg = AlgToUse.PBH;
                cb_ShowGrouping.Enabled = true;
            }
        }

        #endregion


        #region Action Buttons

        private void btn_GenerateParticles_Click(object sender, EventArgs e)
        {
            int particleCount = int.Parse(tb_ParticleCount.Text);
            currentParticleValue = particleCount;
            mainTree.GenerateParticles(particleCount);

            DrawParticles(particleCount);
        }


        private void btn_Partition_Click(object sender, EventArgs e)
        {
            Partition();
            isWorking = true;
        }


        private void Partition()
        {
            m_partitionThread = new Thread(() => mainTree.PartitionSpace(), 1073741824);
            m_partitionThread.Name = "PartThread";
            m_partitionThread.Start();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            mainTree.Reset();


            graphics.Clear(Color.White);
        }

        #endregion

        #endregion Manual Controls Panel


        #region Single Particle Diagnostics Panel

        private void cb_ForceVect_CheckedChanged(object sender, EventArgs e)
        {
            ShowForceVect = cb_ForceVect.Checked;
            mainTree.ShowForceVect = cb_ForceVect.Checked;
        }


        private void cb_ShowGrouping_CheckedChanged(object sender, EventArgs e)
        {
            ShowGrouping = cb_ShowGrouping.Checked;
            mainTree.DrawBhNodeGrouping = cb_ShowGrouping.Checked;
        }

        private void cb_ShowResForce_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btn_CalcForces_Click(object sender, EventArgs e)
        {
            CalculateForces();
        }

        private void cb_ShowCOG_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ShowCOG.Checked)
            {
                mainTree.DrawNodeCOG = cb_ShowCOG.Checked;
            }
        }

        #endregion


        #region Auto Testing

        private void rb_ThreadTesting_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ThreadTesting.Checked)
            {
                m_currentTestingMode = TestingMode.ThreadTest;
            }
        }

        private void rb_SFandTT_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_SFandTT.Checked)
            {
                m_currentTestingMode = TestingMode.SingleFramePlusThreadTest;
            }
        }

        private void rb_SFPerformance_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_SFPerformance.Checked)
            {
                m_currentTestingMode = TestingMode.SingleFrame;
            }
        }

        private void btn_AutoTest_Click(object sender, EventArgs e)
        {
            int startParticleCount = int.Parse(tb_AutoIncStart.Text);
            int endParticleCount = int.Parse(tb_AutoIncEnd.Text);
            int stepSize = int.Parse(tb_AutoIncValue.Text);
            int maxThreadCount = int.Parse(tb_MaxThreads.Text);
            int numberOfSteps = (endParticleCount - startParticleCount) / stepSize;

            int currentParticleCount = startParticleCount;

            List<string> xAxisVals = new List<string>();
            List<int> pwiExecTimes = new List<int>();
            List<int> ppwiExecTimes = new List<int>();
            List<int> bhExecTimes = new List<int>();
            List<int> pbhExecTimes = new List<int>();
            List<int> threadComparison = new List<int>();
            List<string> threadCounts = new List<string>();

            TimeSpan execTime = new TimeSpan();

            switch (m_currentTestingMode)
            {
                case TestingMode.SingleFrame:
                    SingleFrame(numberOfSteps, ref currentParticleCount,
                        stepSize, ref execTime, ref pwiExecTimes,
                        ref ppwiExecTimes, ref bhExecTimes, ref pbhExecTimes, ref xAxisVals);

                    break;
                case TestingMode.ThreadTest:

                    ThreadTesting(endParticleCount, maxThreadCount, ref threadComparison, ref threadCounts);
                    break;
                case TestingMode.SingleFramePlusThreadTest:

                    SingleFrame(numberOfSteps, ref currentParticleCount,
                        stepSize, ref execTime, ref pwiExecTimes,
                        ref ppwiExecTimes, ref bhExecTimes, ref pbhExecTimes, ref xAxisVals);
                    ThreadTesting(endParticleCount, maxThreadCount, ref threadComparison, ref threadCounts);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            DrawThreadComparisonChart(threadCounts, threadComparison);

            DrawExecutionTimesChart(xAxisVals, bhExecTimes, pbhExecTimes);

            //ChartWindow chartWindow = new ChartWindow(xAxisVals, threadComparison, threadCounts, pwiExecTimes, ppwiExecTimes, bhExecTimes, pbhExecTimes, startParticleCount, endParticleCount);
            //chartWindow.Show();

        }





        private void ThreadTesting(int endParticleCount, int maxThreadCount, ref List<int> threadComparison, ref List<string> threadCounts)
        {
            int currentParticleCount;
            TimeSpan execTime;
            mainTree.Reset();
            currentParticleCount = endParticleCount;
            l_Status.Text = "Status: Starting thread testing.";

            Partition();
            m_partitionThread.Join();
            for (int j = 1; j < maxThreadCount + 1; j++)
            {
                switch (alg)
                {
                    case AlgToUse.PWI:
                        l_AutoProgress.Text = "Algorithm selection err";
                        break;
                    case AlgToUse.PPWI:
                        mainTree.GenerateParticles(currentParticleCount);
                        execTime = mainTree.SingleFramePairwiseSimulation(isParalell: true, threadCount: j);
                        threadComparison.Add(execTime.Milliseconds);
                        threadCounts.Add(j.ToString());
                        l_AutoProgress.Text = $"Progress: Comparing thread performance. PPWI Thread:{j}";
                        mainTree.Reset();
                        break;
                    case AlgToUse.BH:
                        l_AutoProgress.Text = "Algorithm selection err";
                        break;
                    case AlgToUse.PBH:
                        mainTree.GenerateParticles(currentParticleCount);
                        l_Status.Text = "Status: Partitioning...";
                        Partition();
                        m_partitionThread.Join();
                        m_partitionThread = null;

                        l_Status.Text = "Status: Starting BH sim...";

                        execTime = mainTree.SingleFrameBHSimulation(isParallel: true, j,
                            mode: m_currentMode);
                        threadComparison.Add(execTime.Milliseconds);
                        threadCounts.Add(j.ToString());
                        l_AutoProgress.Text = $"Progress: Comparing thread performance. Thread:{j}";

                        mainTree.Reset();
                        break;
                    default:
                        l_AutoProgress.Text = "Algorithm selection err";
                        break;

                }

            }
        }
        /// <summary>
        /// Calculate the single frame performance used all of the available algorithms
        /// </summary>
        /// <param name="numberOfSteps"></param>
        /// <param name="currentParticleCount"></param>
        /// <param name="stepSize"></param>
        /// <param name="execTime"></param>
        /// <param name="pwiExecTimes"></param>
        /// <param name="ppwiExecTimes"></param>
        /// <param name="bhExecTimes"></param>
        /// <param name="pbhExecTimes"></param>
        /// <param name="xAxisVals"></param>
        void SingleFrame(int numberOfSteps, ref int currentParticleCount, int stepSize,
            ref TimeSpan execTime, ref List<int> pwiExecTimes,
            ref List<int> ppwiExecTimes, ref List<int> bhExecTimes,
            ref List<int> pbhExecTimes, ref List<string> xAxisVals)
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                l_Status.Text = "Status: Generating Particles";
                mainTree.GenerateParticles(currentParticleCount);



                //Run PWI
                l_Status.Text = "Status: Running PWI...";
                execTime = mainTree.SingleFramePairwiseSimulation(isParalell: false);
                pwiExecTimes.Add(execTime.Milliseconds);

                //Run PPWI
                l_Status.Text = "Status: Running PPWI...";
                execTime = mainTree.SingleFramePairwiseSimulation(isParalell: true);
                ppwiExecTimes.Add(execTime.Milliseconds);
                //Partition
                l_Status.Text = "Status: Partitioning...";
                Partition();
                m_partitionThread.Join();
                m_partitionThread = null;

                //Run BH
                l_Status.Text = "Status: Running BH...";
                execTime = mainTree.SingleFrameBHSimulation(isParallel: false);
                bhExecTimes.Add(execTime.Milliseconds);

                //Run PBH
                l_Status.Text = "Status: Running Parallel BH...";
                execTime = mainTree.SingleFrameBHSimulation(isParallel: true, numberOfThreads: 6, mode: m_currentMode);
                pbhExecTimes.Add(execTime.Milliseconds);


                xAxisVals.Add(currentParticleCount.ToString());
                l_AutoProgress.Text = $"Progress: {i} Total: {numberOfSteps} Particles: {currentParticleCount}";

                mainTree.Reset();
                currentParticleCount += stepSize;
            }
        }

        #endregion


        #region Visualization

        /// <summary>
        /// Visualize the chart showing the level of parallelism. 
        /// </summary>
        /// <param name="threadCounts"></param>
        /// <param name="threadComparison"></param>
        private void DrawThreadComparisonChart(List<string> threadCounts, List<int> threadComparison)
        {
            chart_ThreadComparison.AxisX.RemoveAt(0);
            chart_ThreadComparison.AxisX.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Thread Count",
                Labels = threadCounts,
            });
            chart_ThreadComparison.AxisY.RemoveAt(0);
            chart_ThreadComparison.AxisY.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Level of Parallelism",
            });
            chart_ThreadComparison.LegendLocation = LiveCharts.LegendLocation.Bottom;
            chart_ThreadComparison.Series.Clear();
            SeriesCollection parlComp = new SeriesCollection();

            List<double> parlLevels = new List<double>();


            for (int i = 0; i < threadComparison.Count; i++)
            {
                //float p = threadCountComparison[0] / threadCountComparison[i];
                //float pm1 = 1 - p;
                //float pover = p / float.Parse(threadCounts[i]);
                //float speedup = 1 / (pm1 + pover);
                double speedUp = (double)threadComparison[0] / (double)threadComparison[i];
                parlLevels.Add(speedUp);
            }

            parlComp.Add(new LineSeries()
            {
                Title = "Level of Parallelism",
                Values = new ChartValues<double>(parlLevels),
                PointGeometry = DefaultGeometries.Circle
            });

            chart_ThreadComparison.Series = parlComp;
        }

        /// <summary>
        /// Visualize the execution times for different amounts of particles. 
        /// </summary>
        /// <param name="xAxisVals"></param>
        /// <param name="bhExecTimes"></param>
        /// <param name="pbhExecTimes"></param>
        private void DrawExecutionTimesChart(List<string> xAxisVals, List<int> bhExecTimes, List<int> pbhExecTimes)
        {
            chart_ExecTime.AxisX.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Particle Count",
                Labels = xAxisVals
            });

            chart_ExecTime.AxisY.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Execution Time",
            });

            chart_ExecTime.LegendLocation = LiveCharts.LegendLocation.Bottom;
            chart_ExecTime.Series.Clear();
            SeriesCollection execTimes = new SeriesCollection();

            execTimes.Add(new LineSeries()
            {
                Title = "BH",
                Values = new ChartValues<int>(bhExecTimes),
                PointGeometry = DefaultGeometries.Diamond
            });
            execTimes.Add(new LineSeries()
            {
                Title = "PBH",
                Values = new ChartValues<int>(pbhExecTimes),
                PointGeometry = DefaultGeometries.Triangle,
            });
            chart_ExecTime.Series = execTimes;
        }


        /// <summary>
        /// Visualize the tree and re-draw particles to avoid them being covered by the nodes.
        /// </summary>
        private void DrawTree()
        {
            m_partitionThread.Join(500);
            m_partitionThread = null;
            if (DrawGraphics)
            {
                mainTree.VisualizeTreeNodes(mainTree.RootNode, graphics, m_TreePen);
                for (int i = 0; i < mainTree.AllParticles.Count; i++)
                {
                    graphics.DrawEllipse(m_ParticlePen, mainTree.AllParticles[i].CenterPoint.X - m_ElipseRadius1,
                        mainTree.AllParticles[i].CenterPoint.Y - m_ElipseRadius1, m_ElipseRadius1 * 2,
                        m_ElipseRadius1 * 2);
                    graphics.FillEllipse(particleBrushRed, mainTree.AllParticles[i].CenterPoint.X - m_ElipseRadius2,
                        mainTree.AllParticles[i].CenterPoint.Y - m_ElipseRadius2, m_ElipseRadius2 * 2,
                        m_ElipseRadius2 * 2);
                    graphics.FillEllipse(particleBrushYellow, mainTree.AllParticles[i].CenterPoint.X - m_ElipseRadius3,
                        mainTree.AllParticles[i].CenterPoint.Y - m_ElipseRadius3, m_ElipseRadius3 * 2,
                        m_ElipseRadius3 * 2);
                }
            }
        }

        /// <summary>
        /// Draw all the particles.
        /// </summary>
        /// <param name="particleCount"></param>
        private void DrawParticles(int particleCount)
        {
            for (int i = 0; i < particleCount; i++)
            {
                graphics.DrawEllipse(m_ParticlePen, mainTree.AllParticles[i].CenterPoint.X - m_ElipseRadius1,
                    mainTree.AllParticles[i].CenterPoint.Y - m_ElipseRadius1, m_ElipseRadius1 * 2, m_ElipseRadius1 * 2);
                graphics.FillEllipse(particleBrushRed, mainTree.AllParticles[i].CenterPoint.X - m_ElipseRadius2,
                    mainTree.AllParticles[i].CenterPoint.Y - m_ElipseRadius2, m_ElipseRadius2 * 2, m_ElipseRadius2 * 2);
                graphics.FillEllipse(particleBrushYellow, mainTree.AllParticles[i].CenterPoint.X - m_ElipseRadius3,
                    mainTree.AllParticles[i].CenterPoint.Y - m_ElipseRadius3, m_ElipseRadius3 * 2, m_ElipseRadius3 * 2);
            }
        }

        #endregion

        #region Single Particles Diagnostics
        private void CalculateForces()
        {
            int targetParticle = int.Parse(tb_TargetParticleNum.Text);
            Stopwatch sw = new Stopwatch();

            switch (alg)
            {
                case AlgToUse.BH:
                    sw.Start();
                    mainTree.theta = float.Parse(tb_Theta.Text);
                    mainTree.SingleBHStep(targetParticle);
                    sw.Stop();
                    l_TotalTimeValue.Text = sw.Elapsed.ToString();
                    l_BHSingleStepTimeValue.Text = sw.Elapsed.ToString();
                    //Clipboard.SetText(sw.Elapsed.ToString());
                    BHTicks = sw.Elapsed.Ticks;
                    break;
                case AlgToUse.PWI:
                    sw.Start();
                    mainTree.SingleFramePairwiseSimulation(isParalell: false);
                    sw.Stop();
                    l_TotalTimeValue.Text = sw.Elapsed.ToString();
                    l_PWITimeValue.Text = sw.Elapsed.ToString();
                    //Clipboard.SetText(sw.Elapsed.ToString());
                    PWITicks = sw.Elapsed.Ticks;
                    break;
                case AlgToUse.PBH:
                    //sw.Start();
                    mainTree.theta = float.Parse(tb_Theta.Text);
                    TimeSpan time = mainTree.ParallelSingleParticleBH(targetParticle);
                    //sw.Stop();
                    l_TotalTimeValue.Text = time.ToString();
                    l_BHParlTimeValue.Text = time.ToString();
                    //Clipboard.SetText(time.ToString());
                    PBHTicks = time.Ticks;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (ShowForceVect && DrawGraphics)
            {
                mainTree.VisualizeForceVectors(targetParticle, forceVectGraphics, m_MinforceVectPen, m_MidforceVectPen,
                    m_MaxforceVectPen);
            }

            if (ShowGrouping && DrawGraphics)
            {
                mainTree.VisualizeGrouping(targetParticle, forceVectGraphics, m_MidforceVectPen);
            }
        }


        #endregion

        #region Thread Mode Configuration

        private void rb_CustomThreads_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_CustomThreads.Checked)
            {
                m_currentMode = threadMode.selfMade;
            }
        }

        private void rb_TPLThreads_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_TPLThreads.Checked)
            {
                m_currentMode = threadMode.fromParallelLib;
            }
        }

        #endregion


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_partitionThread != null)
            {
                if (m_partitionThread.IsAlive)
                {
                    if (m_partitionThread.Join(500))
                    {
                        Debug.WriteLine("Thread joined");
                    }
                    else
                    {
                        m_partitionThread.Abort();
                    }
                }
            }
        }

        #region Image Saving Functionality


        private void btn_SaveExecGraph_Click(object sender, EventArgs e)
        {
            dia_SaveLocation.DefaultExt = ".png";
            dia_SaveLocation.FileName = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}_{int.Parse(tb_AutoIncStart.Text)}_{tb_AutoIncEnd.Text}p_execData";
            dia_SaveLocation.ShowDialog();
            string fileName = dia_SaveLocation.FileName;
            SaveToPng(chart_ExecTime, fileName);
            SaveToPng(chart_ExecTime,
                fileName);
        }

        private void btn_SaveThreadComp_Click(object sender, EventArgs e)
        {
            dia_SaveLocation.FileName = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}_{int.Parse(tb_AutoIncEnd.Text)}p_threadComp";
            dia_SaveLocation.DefaultExt = ".png";
            dia_SaveLocation.ShowDialog();
            string fileName = dia_SaveLocation.FileName;
            SaveToPng(chart_ThreadComparison, fileName);
        }

        public void SaveToPng(CartesianChart chart, string fileName)
        {
            Bitmap bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(fileName, ImageFormat.Png);
        }

        #endregion


        private void btn_Simulate_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            TimeSpan time;
            switch (alg)
            {
                case AlgToUse.PWI:
                    sw.Start();
                    time = mainTree.SingleFramePairwiseSimulation(isParalell: false);
                    sw.Stop();
                    l_TotalTimeValue.Text = time.ToString();
                    l_PWITimeValue.Text = time.ToString();
                    //Clipboard.SetText(sw.Elapsed.ToString());
                    PWITicks = sw.Elapsed.Ticks;
                    break;
                case AlgToUse.PPWI:
                    time = mainTree.SingleFramePairwiseSimulation(isParalell: true);
                    l_TotalTimeValue.Text = time.ToString();
                    l_PPWITimeValue.Text = time.ToString();
                    break;
                case AlgToUse.BH:
                    mainTree.theta = float.Parse(tb_Theta.Text);
                    time = mainTree.SingleFrameBHSimulation(isParallel: false, numberOfThreads: 1,
                        mode: m_currentMode);
                    l_TotalTimeValue.Text = time.ToString();
                    l_BHSingleStepTimeValue.Text = time.ToString();
                    //Clipboard.SetText(sw.Elapsed.ToString());
                    BHTicks = sw.Elapsed.Ticks;
                    break;

                case AlgToUse.PBH:

                    mainTree.theta = float.Parse(tb_Theta.Text);
                    time = mainTree.SingleFrameBHSimulation(isParallel: true, numberOfThreads: 6,
                        mode: m_currentMode);
                    l_TotalTimeValue.Text = time.ToString();
                    l_BHParlTimeValue.Text = time.ToString();
                    //Clipboard.SetText(time.ToString());
                    PBHTicks = time.Ticks;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_ClearForceVect_Click(object sender, EventArgs e)
        {
            forceVectGraphics.DrawEllipse(Pens.Blue, 100, 100, 5, 5);
            p_ForcePanel = new TransparentPanel();
        }
    }
}