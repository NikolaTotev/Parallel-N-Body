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
using System.Globalization;
using System.IO;
using System.Threading;
using CsvHelper;
using LiveCharts;
using LiveCharts.Wpf;


namespace Barnes_Hut_GUI
{
    public partial class Form1 : Form
    {
        private QuadTree mainTree;
        private Graphics graphics;
        private Graphics forceVectGraphics;
        private Pen particlePen = new Pen(Color.White);
        private Pen treePen = new Pen(Color.LightBlue);
        private Pen minforceVectPen = new Pen(Color.ForestGreen);
        private Pen midforceVectPen = new Pen(Color.SandyBrown);
        private Pen maxforceVectPen = new Pen(Color.OrangeRed);
        private Brush particleBrush = new SolidBrush(Color.CornflowerBlue);
        private Brush particleBrushRed = new SolidBrush(Color.Red);
        private Brush particleBrushYellow = new SolidBrush(Color.Yellow);
        private int ElipseRadius1 = 3;
        private int ElipseRadius2 = 2;
        private float ElipseRadius3 = 0.5f;
        private bool ShowTree;
        private bool ShowEmptyCells;
        private bool ShowForceVect;
        private bool ShowGrouping;
        private bool DrawGraphics;
        private bool isWorking;
        private AlgToUse alg = AlgToUse.PWI;
        private Thread m_partitionThread;
        private int currentParticleValue = 0;
        private long PWITicks = 0;
        private long BHTicks = 0;
        private long PBHTicks = 0;


        List<Brush> Brushes = new List<Brush>()
        {
            new SolidBrush(Color.Green),
            new SolidBrush(Color.Orange),
            new SolidBrush(Color.BlueViolet),
            new SolidBrush(Color.Red),
            new SolidBrush(Color.CornflowerBlue)

        };

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
            mainTree.OnCompleted += MainTree_OnCompleted; ;
        }

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

        private void btn_Partition_Click(object sender, EventArgs e)
        {
            Partition();
            isWorking = true;
        }

        private void Partition()
        {
            m_partitionThread = new Thread(() => mainTree.ParitionSpace(), 1073741824);
            m_partitionThread.Name = "PartThread";
            m_partitionThread.Start();
        }

        private void DrawTree()
        {
            m_partitionThread.Join(500);
            m_partitionThread = null;
            if (DrawGraphics)
            {
                mainTree.Traverse(mainTree.RootNode, graphics, treePen);
                for (int i = 0; i < mainTree.AllParticles.Count; i++)
                {
                    graphics.DrawEllipse(particlePen, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius1,
                        mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius1, ElipseRadius1 * 2, ElipseRadius1 * 2);
                    graphics.FillEllipse(particleBrushRed, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius2,
                        mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius2, ElipseRadius2 * 2, ElipseRadius2 * 2);
                    graphics.FillEllipse(particleBrushYellow, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius3,
                        mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius3, ElipseRadius3 * 2, ElipseRadius3 * 2);
                }
            }
        }

        private void btn_GenerateParticles_Click(object sender, EventArgs e)
        {
            int particleCount = int.Parse(tb_ParticleCount.Text);
            currentParticleValue = particleCount;
            mainTree.GenerateParticles(particleCount);

            DrawParticles(particleCount);

        }

        private void DrawParticles(int particleCount)
        {
            for (int i = 0; i < particleCount; i++)
            {
                graphics.DrawEllipse(particlePen, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius1,
                    mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius1, ElipseRadius1 * 2, ElipseRadius1 * 2);
                graphics.FillEllipse(particleBrushRed, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius2,
                    mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius2, ElipseRadius2 * 2, ElipseRadius2 * 2);
                graphics.FillEllipse(particleBrushYellow, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius3,
                    mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius3, ElipseRadius3 * 2, ElipseRadius3 * 2);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            mainTree.ClearParticles();
            graphics.Clear(Color.White);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_ForceVect_CheckedChanged(object sender, EventArgs e)
        {
            ShowForceVect = cb_ForceVect.Checked;
            mainTree.ShowForceVect = cb_ForceVect.Checked;
        }

        private void cb_TreeOutline_CheckedChanged(object sender, EventArgs e)
        {
            ShowForceVect = cb_TreeOutline.Checked;
            mainTree.ShowForceVect = cb_TreeOutline.Checked;
        }

        private void cb_ShowEmptyCells_CheckedChanged(object sender, EventArgs e)
        {
            ShowEmptyCells = cb_ShowEmptyCells.Checked;
            mainTree.ShowEmptyCells = cb_ShowEmptyCells.Checked;
        }

        private void cb_ShowGrouping_CheckedChanged(object sender, EventArgs e)
        {
            ShowGrouping = cb_ShowGrouping.Checked;
            mainTree.ShowGrouping = cb_ShowGrouping.Checked;
        }

        private void rb_UsePWI_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_UsePWI.Checked)
            {
                alg = AlgToUse.PWI;
                mainTree.alg = AlgToUse.PWI;
                cb_ShowGrouping.Enabled = false;
                ShowGrouping = false;
                mainTree.ShowGrouping = false;

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

        private void btn_CalcForces_Click(object sender, EventArgs e)
        {
            CalculateForces();
        }

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
                    mainTree.PairWiseForceCalculation();
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
                mainTree.VisualizeForceVectors(targetParticle, forceVectGraphics, minforceVectPen, midforceVectPen,
                    maxforceVectPen);
            }

            if (ShowGrouping && DrawGraphics)
            {
                mainTree.VisualizeGrouping(targetParticle, forceVectGraphics, midforceVectPen);
            }
        }

        private void cb_DrawGraphics_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraphics = cb_DrawGraphics.Checked;
        }

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

        private void btn_Gen100PlusParticles_Click(object sender, EventArgs e)
        {
            mainTree.ClearParticles();
            graphics.Clear(Color.White);
            currentParticleValue += 100;
            tb_ParticleCount.Text = currentParticleValue.ToString();
            mainTree.GenerateParticles(currentParticleValue);
            DrawParticles(currentParticleValue);
            CalculateForces();
        }

        private void btn_AutoTest_Click(object sender, EventArgs e)
        {
            int startParticleCount = int.Parse(tb_AutoIncStart.Text);
            int endParticleCount = int.Parse(tb_AutoIncEnd.Text);
            int stepSize = int.Parse(tb_AutoIncValue.Text);
            int maxThreadCount = 12;
            int numberOfSteps = (endParticleCount - startParticleCount) / stepSize;

            int currentParticleCount = startParticleCount;

            List<string> xAxisVals = new List<string>();
            List<int> pwiExecTimes = new List<int>();
            List<int> ppwiExecTimes = new List<int>();
            List<int> bhExecTimes = new List<int>();
            List<int> pbhExecTimes = new List<int>();
            List<int> threadComparison = new List<int>();
            List<string> threadCounts = new List<string>();

            TimeSpan execTime;
            //long pbhAvgSum = 0;
            //long pbhAvg = 0;

            //long bhAvgSum = 0;
            //long bhAvg = 0;

            //long bhMin;
            //long pbhMin;

            //int sampleSize = 20;

            for (int i = 0; i < numberOfSteps; i++)
            {

                l_Status.Text = "Status: Generating Particles";
                mainTree.GenerateParticles(currentParticleCount);
                tb_TargetParticleNum.Text = "40";


                alg = AlgToUse.PBH;

                //for (int j = 0; j < sampleSize; j++)
                //{
                //    CalculateForces();
                //    if (PBHTicks < pbhMin)
                //    {
                //        pbhMin = PBHTicks;
                //    }
                //    //pbhAvgSum += PBHTicks;
                //    //  Thread.Sleep(500);
                //}

                //pbhAvg = pbhAvgSum / sampleSize;

                //alg = AlgToUse.BH;
                //l_Status.Text = "Status: Partitioning";

                //for (int j = 0; j < sampleSize; j++)
                //{
                //    CalculateForces();
                //    if (BHTicks < bhMin)
                //    {
                //        bhMin = BHTicks;
                //    }
                //    //bhAvgSum += BHTicks;
                //    // Thread.Sleep(500);
                //}

                //bhAvg = bhAvgSum / sampleSize;


                //Run PWI
                alg = AlgToUse.PWI;
              //  execTime = mainTree.SingleFramePairwiseSimulation();
              //  pwiExecTimes.Add(execTime.Milliseconds);

                //Run PPWI
             //   execTime = mainTree.SingleFramePairwiseParallelSimulation();
              //  ppwiExecTimes.Add(execTime.Milliseconds);
                //Partition
                //Partition();
                //m_partitionThread.Join();
                //m_partitionThread = null;

                ////Run BH
                //execTime = mainTree.SingleFrameBHSimulation();
                //bhExecTimes.Add(execTime.Milliseconds);

                ////Run PBH


                //execTime = mainTree.ParallelSingleFrameBHSimulation();
                //pbhExecTimes.Add(execTime.Milliseconds);


                //xAxisVals.Add(currentParticleCount.ToString());

                //mainTree.ClearParticles();
                //currentParticleCount += stepSize;


                //l_AutoProgress.Text = $"Progress: {i} Total: {numberOfSteps} Particles: {currentParticleCount}";

            }
            


            mainTree.ClearParticles();
            currentParticleCount = endParticleCount;
            l_Status.Text = "Status: Comparing thread performance.";
            tb_TargetParticleNum.Text = $"{currentParticleCount}";

            Partition();
            m_partitionThread.Join();
            for (int j = 1; j < maxThreadCount + 1; j++)
            {
                l_Status.Text = $"Status: Comparing thread performance. Thread:{j}";
                mainTree.GenerateParticles(currentParticleCount);
                Partition();
                m_partitionThread.Join();
                m_partitionThread = null;

                execTime = mainTree.SingleFrameParallelBHSimulationThreadControl(j);
                threadComparison.Add(execTime.Milliseconds);
                threadCounts.Add(j.ToString());
                mainTree.ClearParticles();
            }


            chart_ThreadComparison.AxisX.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Thread Count",
                Labels = threadCounts
            });

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

            //ChartWindow chartWindow = new ChartWindow(xAxisVals, threadComparison, threadCounts, pwiExecTimes, ppwiExecTimes, bhExecTimes, pbhExecTimes, startParticleCount, endParticleCount);
            //chartWindow.Show();
            //Debug.WriteLine("Moving to save");
            //dia_SaveLocation.AddExtension = true;
            //dia_SaveLocation.DefaultExt = ".csv";
            //Debug.WriteLine("Dialogue Setting Set");
            //dia_SaveLocation.ShowDialog();
            //string savePath = dia_SaveLocation.FileName;
            //using (var writer = new StreamWriter(savePath))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(records);
            //}
        }

        private void btn_Simulate_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            TimeSpan time;
            switch (alg)
            {
                case AlgToUse.PWI:
                    sw.Start();
                    time = mainTree.SingleFramePairwiseSimulation();
                    sw.Stop();
                    l_TotalTimeValue.Text = time.ToString();
                    l_PWITimeValue.Text = time.ToString();
                    //Clipboard.SetText(sw.Elapsed.ToString());
                    PWITicks = sw.Elapsed.Ticks;
                    break;
                case AlgToUse.PPWI:
                    time = mainTree.SingleFramePairwiseParallelSimulation();
                    l_TotalTimeValue.Text = time.ToString();
                    l_PPWITimeValue.Text = time.ToString();
                    break;
                case AlgToUse.BH:
                    mainTree.theta = float.Parse(tb_Theta.Text);
                    time = mainTree.SingleFrameBHSimulation();
                    l_TotalTimeValue.Text = time.ToString();
                    l_BHSingleStepTimeValue.Text = time.ToString();
                    //Clipboard.SetText(sw.Elapsed.ToString());
                    BHTicks = sw.Elapsed.Ticks;
                    break;

                case AlgToUse.PBH:

                    mainTree.theta = float.Parse(tb_Theta.Text);
                    time = mainTree.ParallelSingleFrameBHSimulation();
                    l_TotalTimeValue.Text = time.ToString();
                    l_BHParlTimeValue.Text = time.ToString();
                    //Clipboard.SetText(time.ToString());
                    PBHTicks = time.Ticks;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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
    }

    class AutoPerformancClass
    {
        public int particleCount { get; set; }
        public TimeSpan pwiTicks { get; set; }
        public TimeSpan bhTicks { get; set; }
        public TimeSpan pbhTicks { get; set; }

        public AutoPerformancClass(int pCount, TimeSpan pwTick, TimeSpan bhTick, TimeSpan pbhTick)
        {
            particleCount = pCount;
            pwiTicks = pwTick;
            bhTicks = bhTick;
            pbhTicks = pbhTick;
        }
    }
}