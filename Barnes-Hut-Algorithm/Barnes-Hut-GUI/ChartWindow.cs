using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Wpf;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace Barnes_Hut_GUI
{
    public partial class ChartWindow : Form
    {
        private List<string> xAxisLabels;
        private List<string> yAxisLabels;
        private List<int> pwiExecValues;
        private List<int> ppwiExecValues;
        private List<int> bhExecValues;
        private List<int> pbhExecValues;
        private List<int> threadCountComparison;
        private List<string> threadCounts;
        private int maxParticles;
        private int minParticles;

        public ChartWindow(List<string> xAxisL, List<int> tcc, List<string> tCounts, List<int> pwiVals,
            List<int> ppwiVals, List<int> bhVals, List<int> pbhVals, int minParticles, int maxParticles)
        {
            InitializeComponent();
            xAxisLabels = xAxisL;
            pwiExecValues = pwiVals;
            ppwiExecValues = ppwiVals;
            bhExecValues = bhVals;
            pbhExecValues = pbhVals;
            threadCountComparison = tcc;
            threadCounts = tCounts;

            chart_ThreadComparison.AxisX.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Thread Count",
                Labels = threadCounts
            });

            chart_ThreadComparison.AxisY.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Level of Parallelism",
            });


            chart_ExecTime.AxisX.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Particle Count",
                Labels = xAxisLabels
            });

            chart_ExecTime.AxisY.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Execution Time",
            });

            chart_ExecTime.LegendLocation = LiveCharts.LegendLocation.Bottom;
            chart_ThreadComparison.LegendLocation = LiveCharts.LegendLocation.Bottom;

            chart_ExecTime.Series.Clear();
            chart_ThreadComparison.Series.Clear();
            SeriesCollection execTimes = new SeriesCollection();
            SeriesCollection parlComp = new SeriesCollection();
            //execTimes.Add(new LineSeries()
            //{
            //    Title = "PWI",
            //    Values = new ChartValues<int>(pwiExecValues),
            //    PointGeometry = DefaultGeometries.Circle

            //});
            //execTimes.Add(new LineSeries()
            //{
            //    Title = "PPWI",
            //    Values = new ChartValues<int>(ppwiExecValues),
            //    PointGeometry = DefaultGeometries.Square
            //});
            execTimes.Add(new LineSeries()
            {
                Title = "BH",
                Values = new ChartValues<int>(bhExecValues),
                PointGeometry = DefaultGeometries.Diamond
            });
            execTimes.Add(new LineSeries()
            {
                Title = "PBH",
                Values = new ChartValues<int>(pbhExecValues),
                PointGeometry = DefaultGeometries.Triangle,
            });
            chart_ExecTime.Series = execTimes;

            List<float> parlLevels = new List<float>();


            for (int i = 0; i < threadCountComparison.Count; i++)
            {
                float p = threadCountComparison[0] / threadCountComparison[i];
                float pm1 = 1 - p;
                float pover = p / float.Parse(threadCounts[i]);
                float speedup = 1 / (pm1 + pover);
                parlLevels.Add(speedup);
            }

            parlComp.Add(new LineSeries()
            {
                Title = "Level of Parallelism",
                Values = new ChartValues<float>(parlLevels),
                PointGeometry = DefaultGeometries.Circle
            });

            chart_ThreadComparison.Series = parlComp;
        }

        private void ChartWindow_Load(object sender, EventArgs e)
        {
        }

        private void btn_SaveChart_Click(object sender, EventArgs e)
        {
            SaveToPng(chart_ExecTime,
                $"D:\\Documents\\Project Files\\N-Body\\Parallel-N-Body\\PerformanceLogs\\{DateTime.Now}_{minParticles}_{maxParticles}_execData.png");
        }

        public void SaveToPng(CartesianChart chart, string fileName)
        {
            Bitmap bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(fileName, ImageFormat.Png);
        }
    }
}