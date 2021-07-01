using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using PNB_Lib;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;
using Brushes = System.Drawing.Brushes;
using Path = System.IO.Path;


namespace Parallel_N_Body
{
    //public delegate void SimFrameCompleteEventHandler(object source, SimFrameCompleteArgs e);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentSimImage = "./Resources/Images/default_sim_image.svg";
        private SKSvg m_SKSvg;
        private bool m_IsStartUp = true;
        private ProgramManager m_ProgramManager = new ProgramManager(0, 0);
        private int m_SimHeight;
        private int m_SimWidth;


        private string m_PrevNumberOfParticles;
        private string m_PrevTheta;
        private string m_PrevTargetParticle;
        private string m_PrevAutoConfigMaxThreads;
        private string m_PrevThreadConfigMaxThreads;
        private string m_PrevSimConfigNumberOfFrames;
        private string m_PrevRepeatFactor;
        private int m_SimFrameCount;

        private SKCanvas m_SimCanvas;
        private Thread m_SimulationThread;
        private Thread m_VideoGenerationThread;
        //public event SimFrameCompleteEventHandler OnFrameDraw;
        //public event EventHandler OnSimulationComplete;
        public event EventHandler OnVideoGenerationComplete;

        private bool m_DrawPartition;
        public MainWindow()
        {
            InitializeComponent();
            m_SimWidth = (int)g_SimGrid.Width;
            m_SimHeight = (int)g_SimGrid.Height;
            m_ProgramManager = new ProgramManager(m_SimWidth, m_SimHeight);
            //OnFrameDraw += MainWindow_OnFrameDraw;
            //OnSimulationComplete += MainWindow_OnSimulationComplete;
            OnVideoGenerationComplete += MainWindow_OnVideoGenerationComplete;
            m_ProgramManager.QuadTree.OnFrameComplete += QuadTree_OnFrameComplete;
            m_ProgramManager.QuadTree.OnSimulationComplete += QuadTree_OnSimulationComplete;
            m_ProgramManager.QuadTree.OnAutoTestComplete += QuadTree_OnAutoTestComplete;
            m_ProgramManager.QuadTree.OnAutoTestStepComplete += QuadTree_OnAutoTestStepComplete;

            m_ProgramManager.QuadTree.SetAlgorithm(InteractionAlgorithm.PWI);
            m_ProgramManager.QuadTree.SetParallelStatus(true);
            m_ProgramManager.QuadTree.SetDrawFlagUseDifferentColors(true);
            m_ProgramManager.QuadTree.SetAutoConfigThreadMode(ThreadMode.customThreads);
            m_ProgramManager.QuadTree.SetThreadConfigThreadMode(ThreadMode.customThreads);
            m_ProgramManager.QuadTree.OnPartitionComplete += QuadTree_OnPartitionComplete;
            FFmpegDownloader.GetLatestVersion(FFmpegVersion.Full);
        }

        private void QuadTree_OnPartitionComplete(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    m_ProgramManager.QuadTree.CleanUpPartitionThread();
                    m_DrawPartition = true;
                    skg_SimGraphics.InvalidateVisual();
                }), DispatcherPriority.Normal);
        }

        private void QuadTree_OnAutoTestStepComplete(object source, AutoTestStepCompleteArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                Lb_AutoTestStatCurrentThreadCount.Content = $"Executing test: {e.GetCurrentThreadCount()}/{e.GetTotalThreadCount()}";
                TimeSpan elapsedTime = e.GetElapsedTime();
                Lb_AutoTestStatElapsedTime.Content = $"Elapsed time: {elapsedTime.Minutes} min, {elapsedTime.Seconds} sec, {elapsedTime.Milliseconds}";
                Lb_AutoTestStatTimeForLastTest.Content = $"Time for last test: {e.GetLastThreadExecTime()}";
            }), DispatcherPriority.Normal);
        }

        private void QuadTree_OnAutoTestComplete(object source, AutoTestCompleteArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                Btn_StartAutoTest.IsEnabled = true;
                GenerateChartSeries(e.GetParlLevels(), e.GetExecTimes(), e.GetEffectivenessLevels());
                TakeTheChart(e.GetPartCount(), e.GetTestNumber());
            }), DispatcherPriority.Normal);
        }

        private void QuadTree_OnSimulationComplete(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                Btn_StartSimulation.IsEnabled = true;
                Btn_StopSimulation.IsEnabled = false;
            }), DispatcherPriority.Normal);


        }

        private void QuadTree_OnFrameComplete(object source, SimFrameCompleteArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                string currentFrame = e.GetFrameNumber().ToString();
                //TimeSpan timeForLastFrame = e.GetExecTime();

                Lb_CurrentFrame.Content = $"{currentFrame}/{m_SimFrameCount}";
                //skg_SimGraphics.InvalidateVisual();
            }), DispatcherPriority.Normal);
        }

        private void MainWindow_OnVideoGenerationComplete(object sender, EventArgs e)
        {
            Btn_GenerateVideo.IsEnabled = true;
            Btn_SelectSimSaveLocation.IsEnabled = true;
        }

        private void MainWindow_OnFrameDraw(object sender, SimFrameCompleteArgs e)
        {
            string currentFrame = e.GetFrameNumber().ToString();
            //TimeSpan timeForLastFrame = e.GetExecTime();

            Lb_CurrentFrame.Content = $"{currentFrame}/{m_SimFrameCount}";
            //skg_SimGraphics.InvalidateVisual();
        }

        #region General Settings

        private void Tb_ParticleCount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb_NumberOfParticles.Text))
            {
                try
                {
                    m_ProgramManager.QuadTree.SetParticleCount(int.Parse(Tb_NumberOfParticles.Text));
                    //Tb_NumberOfParticles.BorderBrush = new SolidColorBrush(Colors.Transparent);
                }
                catch (Exception exception)
                {
                    //Tb_NumberOfParticles.BorderBrush= new SolidColorBrush((System.Windows.Media.Color)App.Current.Resources["InputErrorColor"]);
                    Debug.Print($"INPUT EXCEPTION: Tb_NumberOfParticles OnTextChanged threw an exception. Text was: {Tb_NumberOfParticles.Text}");
                }

            }
        }

        private void Tb_ParticleCount_OnGotFocus(object sender, RoutedEventArgs e)
        {
            m_PrevNumberOfParticles = Tb_NumberOfParticles.Text;
            Tb_NumberOfParticles.Text = "";
        }

        private void Tb_ParticleCount_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_NumberOfParticles.Text == "")
            {
                Tb_NumberOfParticles.Text = m_PrevNumberOfParticles;
            }
        }

        private void Tb_Theta_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb_Theta.Text))
            {
                try
                {
                    m_ProgramManager.QuadTree.SetTheta(int.Parse(Tb_Theta.Text));
                }
                catch (Exception exception)
                {
                    Debug.Print($"INPUT EXCEPTION: Tb_NumberOfParticles OnTextChanged threw an exception. Text was: {Tb_Theta.Text}");
                }

            }
        }

        private void Tb_Theta_OnGotFocus(object sender, RoutedEventArgs e)
        {
            m_PrevTheta = Tb_Theta.Text;
            Tb_Theta.Text = "";
        }


        private void Tb_Theta_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_Theta.Text == "")
            {
                Tb_Theta.Text = m_PrevTheta;
            }
        }



        private void Btn_Generate_Click(object sender, RoutedEventArgs e)
        {
            m_IsStartUp = false;
            m_DrawPartition = false;
            if (m_ProgramManager.QuadTree.GetParticleCount() > 250)
            {
                Lb_ErrorMsg.Content = "";
            }

            m_ProgramManager.QuadTree.GenerateParticles();
            skg_SimGraphics.InvalidateVisual();

        }

        private void Btn_Partition_Click(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.StartParition();
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.ResetTree();
        }

        private void Rb_PairwiseSelector_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetAlgorithm(InteractionAlgorithm.PWI);
        }

        private void Rb_BHSelector_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetAlgorithm(InteractionAlgorithm.BH);
        }

        private void Cb_ParallelSelector_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetParallelStatus(Cb_ParallelSelector.IsChecked);
        }
        #endregion


        #region Single Particle Testing

        private void Tb_TargetParticle_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb_TargetParticle.Text))
            {
                try
                {
                    m_ProgramManager.QuadTree.SetTargetParticle(int.Parse(Tb_NumberOfParticles.Text));
                }
                catch (Exception exception)
                {
                    Debug.Print($"INPUT EXCEPTION: Tb_NumberOfParticles OnTextChanged threw an exception. Text was: {Tb_TargetParticle.Text}");
                }

            }
        }

        private void Tb_TargetParticle_OnGotFocus(object sender, RoutedEventArgs e)
        {
            m_PrevTargetParticle = Tb_TargetParticle.Text;
            Tb_TargetParticle.Text = "";
        }

        private void Tb_TargetParticle_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_TargetParticle.Text == "")
            {
                Tb_TargetParticle.Text = m_PrevTargetParticle;
            }
        }

        private void Cb_ShowAccelDirection_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetDrawFlagShowAccelDirection(Cb_ShowAccelDirection.IsChecked);
        }

        private void Cb_ShowVelDirection_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetDrawFlagShowVelDirection(Cb_ShowVelDirection.IsChecked);
        }

        #endregion


        #region Visualization Settings
        private void Cb_ShowTree_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetDrawFlagShowTree(Cb_ShowTree.IsChecked);
        }

        private void Cb_ShowBHGrouping_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetDrawFlagShowBHGrouping(Cb_ShowBHGrouping.IsChecked);
        }

        private void Cb_ShowCOG_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetDrawFlagShowCOG(Cb_ShowCOG.IsChecked);
        }

        private void Cb_ShowEmptyCells_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetDrawFlagShowEmptyTreeCells(Cb_ShowEmptyCells.IsChecked);
        }

        private void Cb_EnableMultiColorParticles_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetDrawFlagUseDifferentColors(Cb_EnableMultiColorParticles.IsChecked);
        }

        #endregion


        #region Auto Test Settings

        private void Tb_MaxThreadsForAuto_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb_MaxThreadsForAuto.Text))
            {
                try
                {
                    m_ProgramManager.QuadTree.SetAutoConfigMaxThreadCount(int.Parse(Tb_MaxThreadsForAuto.Text));
                }
                catch (Exception exception)
                {
                    Debug.Print($"INPUT EXCEPTION: Tb_NumberOfParticles OnTextChanged threw an exception. Text was: {Tb_MaxThreadsForAuto.Text}");
                }

            }
        }

        private void Tb_MaxThreadsForAuto_OnGotFocus(object sender, RoutedEventArgs e)
        {

            m_PrevAutoConfigMaxThreads = Tb_MaxThreadsForAuto.Text;
            Tb_MaxThreadsForAuto.Text = "";
        }

        private void Tb_MaxThreadsForAuto_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_MaxThreadsForAuto.Text == "")
            {
                Tb_MaxThreadsForAuto.Text = m_PrevAutoConfigMaxThreads;
            }
        }

        private void Tb_RepeatFactor_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb_RepeatFactor.Text))
            {
                try
                {
                    m_ProgramManager.QuadTree.SetAutoConfigRepeatFactor(int.Parse(Tb_RepeatFactor.Text));
                }
                catch (Exception exception)
                {
                    Debug.Print($"INPUT EXCEPTION: Tb_NumberOfParticles OnTextChanged threw an exception. Text was: {Tb_RepeatFactor.Text}");
                }

            }
        }

        private void Tb_RepeatFactor_OnGotFocus(object sender, RoutedEventArgs e)
        {

            m_PrevRepeatFactor = Tb_RepeatFactor.Text;
            Tb_RepeatFactor.Text = "";
        }

        private void Tb_RepeatFactor_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_RepeatFactor.Text == "")
            {
                Tb_RepeatFactor.Text = m_PrevRepeatFactor;
            }
        }

        private void Rb_AutoTestCustomThreads_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetAutoConfigThreadMode(ThreadMode.customThreads);
        }

        private void Rb_AutoTestTPLThreads_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetAutoConfigThreadMode(ThreadMode.tplThreads);
        }

        private void Btn_StartAutoTest_OnClick(object sender, RoutedEventArgs e)
        {

            if (m_ProgramManager.QuadTree.GetParticleCount() > 250)
            {
                Btn_StartAutoTest.IsEnabled = false;
                Lb_ErrorMsg.Content = "";
                m_ProgramManager.QuadTree.SetAutoConfigShouldStopTest(false);
                m_ProgramManager.QuadTree.AutoTest();
            }
            else
            {
                Lb_ErrorMsg.Content = "Use more than 250 particles \n for Auto Test";
            }

        }

        private void Btn_StopAutoTest_OnClick(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetAutoConfigShouldStopTest(true);
        }

        private void GenerateChartSeries(List<double> parlLevels, List<double> execTimes, List<double> effectivenessLevels)
        {
            SeriesCollection execTimeSeries = new SeriesCollection();
            SeriesCollection parlLevelsSeries = new SeriesCollection();
            SeriesCollection effectivenessLevelsSeries = new SeriesCollection();

            List<string> threadCounts = new List<string>();

            for (int i = 0; i < parlLevels.Count; i++)
            {
                threadCounts.Add($"{i + 1}");
            }

            ColorsCollection cols = new ColorsCollection();
            cols.Add(Colors.MediumPurple);

            Lc_LevelOfParallelism.SeriesColors = cols;
            Lc_Effectiveness.SeriesColors = cols;
            Lc_ExecutionTime.SeriesColors = cols;

            //Exec times chart setup
            Lc_ExecutionTime.AxisX.RemoveAt(0);
            Lc_ExecutionTime.AxisX.Add(new Axis() { Title = "Thread Count", Labels = threadCounts });

            Lc_ExecutionTime.AxisY.RemoveAt(0);
            Lc_ExecutionTime.AxisY.Add(new Axis() { Title = "Execution times" });

            Lc_ExecutionTime.LegendLocation = LegendLocation.Bottom;
            Lc_ExecutionTime.Series.Clear();

            execTimeSeries.Add(new LineSeries()
            {
                Title = "Execution times",
                Values = new ChartValues<double>(execTimes),
                PointGeometry = DefaultGeometries.Circle,
            });

            Lc_ExecutionTime.Series = execTimeSeries;

            //Levels of parallelism chart setup
            Lc_LevelOfParallelism.AxisX.RemoveAt(0);
            Lc_LevelOfParallelism.AxisX.Add(new Axis() { Title = "Thread Count", Labels = threadCounts });

            Lc_LevelOfParallelism.AxisY.RemoveAt(0);
            Lc_LevelOfParallelism.AxisY.Add(new Axis() { Title = "Level of Parallelism" });

            Lc_LevelOfParallelism.LegendLocation = LegendLocation.Bottom;
            Lc_LevelOfParallelism.Series.Clear();

            parlLevelsSeries.Add(new LineSeries()
            {
                Title = "Level of Parallelism",
                Values = new ChartValues<double>(parlLevels),
                PointGeometry = DefaultGeometries.Circle
            });

            Lc_LevelOfParallelism.Series = parlLevelsSeries;

            //Levels of effectiveness chart setup
            Lc_Effectiveness.AxisX.RemoveAt(0);
            Lc_Effectiveness.AxisX.Add(new Axis() { Title = "Thread Count", Labels = threadCounts });

            Lc_Effectiveness.AxisY.RemoveAt(0);
            Lc_Effectiveness.AxisY.Add(new Axis() { Title = "Level of Effectiveness" });

            Lc_Effectiveness.LegendLocation = LegendLocation.Bottom;
            Lc_Effectiveness.Series.Clear();

            effectivenessLevelsSeries.Add(new LineSeries()
            {
                Title = "Level of Effectiveness",
                Values = new ChartValues<double>(effectivenessLevels),
                PointGeometry = DefaultGeometries.Circle
            });

            Lc_Effectiveness.Series = effectivenessLevelsSeries;



        }

        #endregion


        #region Thread Settings
        private void Tb_NumberOfThreads_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tb_NumberOfThreads.Text)) return;
            try
            {
                m_ProgramManager.QuadTree.SetThreadConfigMaxThreads(int.Parse(Tb_NumberOfThreads.Text));
            }
            catch (Exception exception)
            {
                Debug.Print($"INPUT EXCEPTION: Tb_NumberOfParticles OnTextChanged threw an exception. Text was: {Tb_NumberOfThreads.Text}");
            }
        }

        private void Tb_NumberOfThreads_OnGotFocus(object sender, RoutedEventArgs e)
        {
            m_PrevThreadConfigMaxThreads = Tb_NumberOfThreads.Text;
            Tb_NumberOfThreads.Text = "";
        }

        private void Tb_NumberOfThreads_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_NumberOfThreads.Text == "")
            {
                Tb_NumberOfThreads.Text = m_PrevThreadConfigMaxThreads;
            }
        }


        private void Rb_UserCustomThreads_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetThreadConfigThreadMode(ThreadMode.customThreads);
        }

        private void Rb_UseTPLThreads_OnChecked(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetThreadConfigThreadMode(ThreadMode.tplThreads);
        }
        #endregion


        #region Simulation Settings

        private void Tb_NumberOfFrames_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb_NumberOfFrames.Text))
            {
                try
                {
                    m_SimFrameCount = int.Parse(Tb_NumberOfFrames.Text);
                    m_ProgramManager.QuadTree.SetSimConfigNumberOfFrames(int.Parse(Tb_NumberOfFrames.Text));
                }
                catch (Exception exception)
                {
                    Debug.Print($"INPUT EXCEPTION: Tb_NumberOfParticles OnTextChanged threw an exception. Text was: {Tb_NumberOfFrames.Text}");
                }

            }
        }

        private void Tb_NumberOfFrames_OnGotFocus(object sender, RoutedEventArgs e)
        {
            m_PrevSimConfigNumberOfFrames = Tb_NumberOfFrames.Text;
            Tb_NumberOfFrames.Text = "";
        }
        private void Tb_NumberOfFrames_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_NumberOfFrames.Text == "")
            {
                Tb_NumberOfFrames.Text = m_PrevSimConfigNumberOfFrames;
            }
        }

        private void Btn_StartSimulation_OnClick(object sender, RoutedEventArgs e)
        {
            Btn_StartSimulation.IsEnabled = false;
            Btn_StopSimulation.IsEnabled = true;
            m_ProgramManager.QuadTree.SetSimConfigShouldStopSim(false);
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                m_ProgramManager.QuadTree.StartSimulation();
            }), DispatcherPriority.Normal);

        }

        void VideoGenerationParentFunction()
        {
            string dir = "D:/Documents/Project Files/N-Body/SimImages/";
            List<string> files = new List<string>();

            for (int i = 0; i < m_SimFrameCount; i++)
            {
                files.Add($"{dir}/{i}.png");
            }


            Conversion conv = new Conversion();
            conv.SetInputFrameRate(60).BuildVideoFromImages(files).SetFrameRate(60).SetOutputFormat(Format.mp4).SetOutput("D:/Documents/Project Files/N-Body/SimImages/output.mp4").Start();


            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                RaiseEventOnUIThread(OnVideoGenerationComplete, new object[] { null, new EventArgs() });
            }), DispatcherPriority.Normal);

        }
        async Task GenerateVideo(List<string> files)
        {
            await Task.Run(() => new Conversion().SetInputFrameRate(60).BuildVideoFromImages(files).SetFrameRate(60).SetOutputFormat(Format.mp4).SetOutput("D:/Documents/Project Files/N-Body/SimImages/output.mp4").Start());
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


        private void Btn_StopSimulation_OnClick(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetSimConfigShouldStopSim(true);
        }


        private void Btn_GenerateVideo_OnClick(object sender, RoutedEventArgs e)
        {
            Btn_GenerateVideo.IsEnabled = false;
            Btn_SelectSimSaveLocation.IsEnabled = false;
            m_VideoGenerationThread = new Thread(VideoGenerationParentFunction);
            m_VideoGenerationThread.Name = "VideoGenThread";
            m_VideoGenerationThread.Start();
            Debug.WriteLine("Starting video generation.");
        }

        private void Btn_SelectSimSaveLocation_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO Implement animation saving.
        }
        #endregion


        #region Performace Charts 

        private void Lc_LevelOfParallelism_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //TODO Implement opening to new/bigger window.
        }

        private void Lc_ExecutionTime_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //TODO Implement opening to new/bigger window.
        }

        #endregion



        #region Drawing Logic

        private void LoadSVG()
        {
            // create a new SVG object
            m_SKSvg = new SKSvg();
            m_SKSvg.Load(currentSimImage);
        }


        private void ps_SimSpace(object sender, SKPaintSurfaceEventArgs e)
        {
            // the the canvas and properties
            var canvas = e.Surface.Canvas;

            // get the screen density for scaling
            var scale = (float)PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M11;
            var scaledSize = new SKSize(e.Info.Width / scale, e.Info.Height / scale);

            // handle the device screen density
            canvas.Scale(scale);
            // make sure the canvas is blank
            canvas.Clear(SKColors.White);


            int particleNumber = 0;
            if (m_IsStartUp)
            {
                m_SKSvg = new SKSvg();
                m_SKSvg.Load(currentSimImage);
                canvas.DrawPicture(m_SKSvg.Picture);
            }
            else
            {
                foreach (Particle particle in m_ProgramManager.QuadTree.GetParticles())
                {

                    var paint = new SKPaint
                    {
                        Color = particle.particleColor.ToSKColor(),
                        IsAntialias = true,
                        Style = SKPaintStyle.Fill,
                    };

                    canvas.DrawCircle(particle.CenterPoint.X, particle.CenterPoint.Y, 3, paint);
                    Debug.WriteLine($"Drawing particle {particleNumber} at X: {particle.CenterPoint.X} Y: {particle.CenterPoint.Y}");
                    particleNumber++;
                }

                if (m_DrawPartition)
                {
                    var treePaint = new SKPaint
                    {
                        Color = new SKColor(255, 106, 0),
                        IsAntialias = true,
                        Style = SKPaintStyle.Stroke,
                    };

                    VisualizeTreeNodes(m_ProgramManager.QuadTree.GetRootNode(), canvas, treePaint);
                }
                //SKImage image = e.Surface.Snapshot();
                //var data = image.Encode();


                //using (var stream = File.OpenWrite($"D:/Documents/Project Files/N-Body/SimImages/Image_{imageNum}.png"))
                //{
                //    // save the data to a stream
                //    data.SaveTo(stream);
                //    stream.Close();
                //    stream.Dispose();
                //    imageNum++;
                //}
            }
        }


        public void VisualizeTreeNodes(Node nextNode, SKCanvas canvas, SKPaint paint)
        {
            if (nextNode == null)
            {
                return;
            }

            if (nextNode.nodeParticles.Count == 1)
            {
                canvas.DrawRect(nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.YSideLength, nextNode.YSideLength, paint);
                return;
            }

            if (nextNode.nodeParticles.Count == 0 && false)
            {
                // currentGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.YSideLength, nextNode.YSideLength);
                //currentGraphics.FillRectangle(Brushes.IndianRed, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.YSideLength - 10, nextNode.YSideLength - 10);
            }

            else
            {
                canvas.DrawRect(nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.YSideLength, nextNode.YSideLength, paint);
            }



            VisualizeTreeNodes(nextNode.SeChild, canvas, paint);
            VisualizeTreeNodes(nextNode.NeChild, canvas, paint);
            VisualizeTreeNodes(nextNode.NwChild, canvas, paint);
            VisualizeTreeNodes(nextNode.SwChild, canvas, paint);

        }
        #endregion

        private void Lc_Effectiveness_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void TakeTheChart(int particleCount, int testNumber)
        {
            //Lc_LevelOfParallelism.Measure(Lc_LevelOfParallelism.RenderSize);
            //Lc_LevelOfParallelism.Arrange();
            //vb_Parl.Measure(Lc_LevelOfParallelism.RenderSize);
            //vb_Parl.Arrange(new Rect(new System.Windows.Point(0, 0), Lc_LevelOfParallelism.RenderSize));
            //Lc_LevelOfParallelism.Update(true, true); //force chart redraw
            //vb_Parl.UpdateLayout();

            SaveToPng(Lc_LevelOfParallelism, $"D:/Documents/Project Files/N-Body/Charts/TestChart_LcParl_{testNumber}_{particleCount}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.png");

            //vb_Exec.Measure(Lc_ExecutionTime.RenderSize);
            //vb_Exec.Arrange(new Rect(new System.Windows.Point(0, 0), Lc_ExecutionTime.RenderSize));
            //Lc_ExecutionTime.Update(true, true); //force chart redraw
            //vb_Exec.UpdateLayout();
            SaveToPng(Lc_LevelOfParallelism, $"D:/Documents/Project Files/N-Body/Charts/TestChart_LcExec_{testNumber}_{particleCount}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.png");

            //vb_Eff.Measure(Lc_Effectiveness.RenderSize);
            //vb_Eff.Arrange(new Rect(new System.Windows.Point(0, 0), Lc_Effectiveness.RenderSize));
            //Lc_Effectiveness.Update(true, true); //force chart redraw
            //vb_Eff.UpdateLayout();
            SaveToPng(Lc_LevelOfParallelism, $"D:/Documents/Project Files/N-Body/Charts/TestChart_LcEff_{testNumber}_{particleCount}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.png");

            string lcEffPath =
                $"D:/Documents/Project Files/N-Body/Charts/TestChart_LcEff_{testNumber}_{particleCount}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.png";
            string lcParlPath =
                $"D:/Documents/Project Files/N-Body/Charts/TestChart_LcParl_{testNumber}_{particleCount}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.png";
            string lcExecPath =
                $"D:/Documents/Project Files/N-Body/Charts/TestChart_LcExec_{testNumber}_{particleCount}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.png";

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)Lc_LevelOfParallelism.ActualWidth, (int)Lc_LevelOfParallelism.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(Lc_LevelOfParallelism);

            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            MemoryStream stream = new MemoryStream();
            png.Save(stream);
            
            

            //var encoder = new PngBitmapEncoder();
            //var bitmap = new RenderTargetBitmap((int)Lc_LevelOfParallelism.ActualWidth, (int)Lc_LevelOfParallelism.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            //bitmap.Render(Lc_LevelOfParallelism);
            //var frame = BitmapFrame.Create(bitmap);
            //encoder.Frames.Add(frame);
            //using (var stream = File.OpenWrite(lcEffPath))
            //{
            //    encoder.Save(stream);
            //    stream.Close();
            //    stream.Dispose();
            //}
        }

        public void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.OpenWrite(fileName))
            {
                encoder.Save(stream);
                stream.Close();
                stream.Dispose();
            }



        }
    }
}
