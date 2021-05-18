
namespace Barnes_Hut_GUI
{
    partial class ChartWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chart_ExecTime = new LiveCharts.WinForms.CartesianChart();
            this.btn_SaveChart = new System.Windows.Forms.Button();
            this.chart_ThreadComparison = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // chart_ExecTime
            // 
            this.chart_ExecTime.Location = new System.Drawing.Point(12, 12);
            this.chart_ExecTime.Name = "chart_ExecTime";
            this.chart_ExecTime.Size = new System.Drawing.Size(567, 289);
            this.chart_ExecTime.TabIndex = 0;
            this.chart_ExecTime.Text = "cartesianChart1";
            // 
            // btn_SaveChart
            // 
            this.btn_SaveChart.Location = new System.Drawing.Point(279, 672);
            this.btn_SaveChart.Name = "btn_SaveChart";
            this.btn_SaveChart.Size = new System.Drawing.Size(92, 23);
            this.btn_SaveChart.TabIndex = 1;
            this.btn_SaveChart.Text = "Save as";
            this.btn_SaveChart.UseVisualStyleBackColor = true;
            this.btn_SaveChart.Click += new System.EventHandler(this.btn_SaveChart_Click);
            // 
            // chart_ThreadComparison
            // 
            this.chart_ThreadComparison.Location = new System.Drawing.Point(12, 337);
            this.chart_ThreadComparison.Name = "chart_ThreadComparison";
            this.chart_ThreadComparison.Size = new System.Drawing.Size(567, 296);
            this.chart_ThreadComparison.TabIndex = 2;
            this.chart_ThreadComparison.Text = "chart_Parallelism";
            // 
            // ChartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 732);
            this.Controls.Add(this.chart_ThreadComparison);
            this.Controls.Add(this.btn_SaveChart);
            this.Controls.Add(this.chart_ExecTime);
            this.Name = "ChartWindow";
            this.Text = "ChartWindow";
            this.Load += new System.EventHandler(this.ChartWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart chart_ExecTime;
        private System.Windows.Forms.Button btn_SaveChart;
        private LiveCharts.WinForms.CartesianChart chart_ThreadComparison;
    }
}