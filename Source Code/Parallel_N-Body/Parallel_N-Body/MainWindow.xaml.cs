using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using PNB_Lib;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace Parallel_N_Body
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string defaultSimImage = "./Resources/Images/default_sim_image.svg";
        private SKSvg m_SKSvg;
        private bool m_IsStartUp = true;
        private ProgramManager m_ProgramManager;
        private int m_SimHeight;
        private int m_SimWidth;
        
        public MainWindow()
        {
            InitializeComponent();
            m_SimWidth = (int)g_SimGrid.Width;
            m_SimHeight = (int) g_SimGrid.Height;
            m_ProgramManager = new ProgramManager(m_SimWidth, m_SimHeight);
        }

        private void Tb_ParticleCount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Tb_ParticleCount_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_ParticleCount_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_Theta_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_Theta_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_Theta_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Btn_Generate_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_Partition_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
        }
        
        private void Rb_PairwiseSelector_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Rb_BHSelector_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cb_ParallelSelector_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_TargetParticle_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_TargetParticle_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_TargetParticle_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Cb_ShowAccelDirection_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cb_ShowVelDirection_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cb_ShowTree_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cb_ShowBHGrouping_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cb_ShowCOG_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cb_ShowEmptyCells_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_MaxThreadsForAuto_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_MaxThreadsForAuto_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Tb_MaxThreadsForAuto_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }
        private void Rb_AutoTestTPLThreads_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Rb_AutoTestCustomThreads_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_StartAutoTest_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_StopAutoTest_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_NumberOfFrames_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_NumberOfFrames_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_NumberOfFrames_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Btn_StopSimulation_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_StartSimulation_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Lc_LevelOfParallelism_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Lc_ExecutionTime_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void LoadSVG()
        {
            // create a new SVG object
            m_SKSvg = new SKSvg();
            m_SKSvg.Load(defaultSimImage);
        }

        private void ps_SimSpace(object sender, SKPaintSurfaceEventArgs e)
        {
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
                m_SKSvg.Load(defaultSimImage);
                canvas.DrawPicture(m_SKSvg.Picture);
            }
            else
            {

            }
            
            
            
            
            //// draw some text
            //var paint = new SKPaint
            //{
            //    Color = SKColors.Black,
            //    IsAntialias = true,
            //    Style = SKPaintStyle.Fill,
            //    TextAlign = SKTextAlign.Center,
            //    TextSize = 24
            //};
            //var coord = new SKPoint(scaledSize.Width / 2, (scaledSize.Height + paint.TextSize) / 2);
            //canvas.DrawText("SkiaSharp", coord, paint);
        }

        private void Tb_NumberOfThreads_OnGotFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Tb_NumberOfThreads_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Tb_NumberOfThreads_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Rb_UserCustomThreads_OnChecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Rb_UseTPLThreads_OnChecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
