using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using PNB_Lib;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;

namespace Parallel_N_Body
{
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

        private SKCanvas m_SimCanvas;
        public MainWindow()
        {
            InitializeComponent();
            m_SimWidth = (int)g_SimGrid.Width;
            m_SimHeight = (int)g_SimGrid.Height;
            m_ProgramManager = new ProgramManager(m_SimWidth, m_SimHeight);
            m_ProgramManager.QuadTree.OnFrameComplete += QuadTree_OnFrameComplete;
            OnFrameDraw += MainWindow_OnFrameDraw;
        }

        private void MainWindow_OnFrameDraw(object sender, EventArgs e)
        {
            skg_SimGraphics.InvalidateVisual();
        }

        private void QuadTree_OnFrameComplete(object source, SimFrameCompleteArgs e)
        {
            skg_SimGraphics.InvalidateVisual();
        }


        #region General Settings

        private void Tb_ParticleCount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb_NumberOfParticles.Text))
            {
                try
                {
                    m_ProgramManager.QuadTree.SetParticleCount(int.Parse(Tb_NumberOfParticles.Text));
                }
                catch (Exception exception)
                {
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
            m_ProgramManager.QuadTree.GenerateParticles();
            skg_SimGraphics.InvalidateVisual();
        }

        private void Btn_Partition_Click(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.Partition();
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
            m_ProgramManager.QuadTree.SetAutoConfigShouldStopTest(false);
            m_ProgramManager.QuadTree.StartAutoTest();
        }

        private void Btn_StopAutoTest_OnClick(object sender, RoutedEventArgs e)
        {
            m_ProgramManager.QuadTree.SetAutoConfigShouldStopTest(true);
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
            m_ProgramManager.QuadTree.SetSimConfigShouldStopSim(false);
            Thread simThread = new Thread(SimTest);
            simThread.Start();
        }
        public event EventHandler OnFrameDraw;

        public void SimTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                m_ProgramManager.QuadTree.StartSimulation();
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    skg_SimGraphics.InvalidateVisual();
                }), DispatcherPriority.Background);
                //RaiseEventOnUIThread(OnFrameDraw, new object[] { null, new EventArgs() });
            }

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
            Debug.Print("Redrawing graphics! ===========");
            // the the canvas and properties
            var canvas = e.Surface.Canvas;

            // get the screen density for scaling
            var scale = (float)PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M11;
            var scaledSize = new SKSize(e.Info.Width / scale, e.Info.Height / scale);
            Debug.Print($"Width: {e.Info.Width / scale} Height:e.Info.Height / scale");


            // handle the device screen density
            canvas.Scale(scale);
            // make sure the canvas is blank
            canvas.Clear(SKColors.White);


            if (m_IsStartUp)
            {
                m_SKSvg = new SKSvg();
                m_SKSvg.Load(currentSimImage);
                canvas.DrawPicture(m_SKSvg.Picture);
            }
            else
            { //particle.ParticleColor.ToSKColor(),
                //var paint = new SKPaint
                //{
                //    Color = Colors.Orange.ToSKColor(),
                //    IsAntialias = true,
                //    Style = SKPaintStyle.Fill,
                //};
                //canvas.DrawCircle(300, 700, 5, paint);

                foreach (Particle particle in m_ProgramManager.QuadTree.GetParticles())
                {

                    var paint = new SKPaint
                    {
                        Color = particle.particleColor.ToSKColor(),
                        IsAntialias = true,
                        Style = SKPaintStyle.Fill,
                    };
                    canvas.DrawCircle(particle.CenterPoint.X, particle.CenterPoint.Y, 3, paint);
                }
            }

             
        }
        #endregion
    }
}
