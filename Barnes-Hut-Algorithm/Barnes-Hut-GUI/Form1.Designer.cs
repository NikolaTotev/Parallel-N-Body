
namespace Barnes_Hut_GUI
{
    partial class Form1
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
            this.tb_ParticleCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Partition = new System.Windows.Forms.Button();
            this.btn_GenerateParticles = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.cb_ForceVect = new System.Windows.Forms.CheckBox();
            this.rb_UsePWI = new System.Windows.Forms.RadioButton();
            this.rb_UseBH = new System.Windows.Forms.RadioButton();
            this.cb_TreeOutline = new System.Windows.Forms.CheckBox();
            this.cb_ShowEmptyCells = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Theta = new System.Windows.Forms.TextBox();
            this.btn_Simulate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_TimeStepSim = new System.Windows.Forms.TextBox();
            this.btn_CalcForces = new System.Windows.Forms.Button();
            this.tb_TargetParticleNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ShowResForce = new System.Windows.Forms.CheckBox();
            this.rb_ParlBH = new System.Windows.Forms.RadioButton();
            this.cb_ShowGrouping = new System.Windows.Forms.CheckBox();
            this.p_SimulationArea = new System.Windows.Forms.Panel();
            this.iL_ExecMetrics = new System.Windows.Forms.Label();
            this.iL_Start = new System.Windows.Forms.Label();
            this.iL_End = new System.Windows.Forms.Label();
            this.iL_Total = new System.Windows.Forms.Label();
            this.p_ExecMetrics = new System.Windows.Forms.Panel();
            this.l_PPWITimeValue = new System.Windows.Forms.Label();
            this.iL_PPWI = new System.Windows.Forms.Label();
            this.l_BHParlTimeValue = new System.Windows.Forms.Label();
            this.l_BHSingleStepTimeValue = new System.Windows.Forms.Label();
            this.l_PWITimeValue = new System.Windows.Forms.Label();
            this.l_TotalTimeValue = new System.Windows.Forms.Label();
            this.l_EndTimeValue = new System.Windows.Forms.Label();
            this.l_StartTimeValue = new System.Windows.Forms.Label();
            this.iL_BHParlSingleStep = new System.Windows.Forms.Label();
            this.iL_BHSingleStep = new System.Windows.Forms.Label();
            this.iL_PWI = new System.Windows.Forms.Label();
            this.iL_lastRun = new System.Windows.Forms.Label();
            this.cb_DrawGraphics = new System.Windows.Forms.CheckBox();
            this.l_Progress = new System.Windows.Forms.Label();
            this.btn_Gen100PlusParticles = new System.Windows.Forms.Button();
            this.dia_SaveLocation = new System.Windows.Forms.SaveFileDialog();
            this.rb_ParallelPWI = new System.Windows.Forms.RadioButton();
            this.chart_ThreadComparison = new LiveCharts.WinForms.CartesianChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tb_AutoIncValue = new System.Windows.Forms.TextBox();
            this.tb_AutoIncStart = new System.Windows.Forms.TextBox();
            this.tb_AutoIncEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_AutoProgress = new System.Windows.Forms.Label();
            this.l_Status = new System.Windows.Forms.Label();
            this.btn_AutoTest = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.p_TreePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.p_ForcePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.p_ExecMetrics.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_ParticleCount
            // 
            this.tb_ParticleCount.Location = new System.Drawing.Point(12, 29);
            this.tb_ParticleCount.Name = "tb_ParticleCount";
            this.tb_ParticleCount.Size = new System.Drawing.Size(106, 20);
            this.tb_ParticleCount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of particles";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_Partition
            // 
            this.btn_Partition.BackColor = System.Drawing.Color.Purple;
            this.btn_Partition.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Partition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Partition.Location = new System.Drawing.Point(19, 43);
            this.btn_Partition.Name = "btn_Partition";
            this.btn_Partition.Size = new System.Drawing.Size(130, 23);
            this.btn_Partition.TabIndex = 2;
            this.btn_Partition.Text = "Partition";
            this.btn_Partition.UseVisualStyleBackColor = false;
            this.btn_Partition.Click += new System.EventHandler(this.btn_Partition_Click);
            // 
            // btn_GenerateParticles
            // 
            this.btn_GenerateParticles.BackColor = System.Drawing.Color.Purple;
            this.btn_GenerateParticles.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerateParticles.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_GenerateParticles.Location = new System.Drawing.Point(19, 76);
            this.btn_GenerateParticles.Name = "btn_GenerateParticles";
            this.btn_GenerateParticles.Size = new System.Drawing.Size(130, 23);
            this.btn_GenerateParticles.TabIndex = 3;
            this.btn_GenerateParticles.Text = "Generate Particles";
            this.btn_GenerateParticles.UseVisualStyleBackColor = false;
            this.btn_GenerateParticles.Click += new System.EventHandler(this.btn_GenerateParticles_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.Purple;
            this.btn_Reset.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Reset.Location = new System.Drawing.Point(20, 10);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(129, 23);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // cb_ForceVect
            // 
            this.cb_ForceVect.AutoSize = true;
            this.cb_ForceVect.Location = new System.Drawing.Point(15, 55);
            this.cb_ForceVect.Name = "cb_ForceVect";
            this.cb_ForceVect.Size = new System.Drawing.Size(122, 17);
            this.cb_ForceVect.TabIndex = 5;
            this.cb_ForceVect.Text = "Show Force Vectors";
            this.cb_ForceVect.UseVisualStyleBackColor = true;
            this.cb_ForceVect.CheckedChanged += new System.EventHandler(this.cb_ForceVect_CheckedChanged);
            // 
            // rb_UsePWI
            // 
            this.rb_UsePWI.AutoSize = true;
            this.rb_UsePWI.Location = new System.Drawing.Point(12, 15);
            this.rb_UsePWI.Name = "rb_UsePWI";
            this.rb_UsePWI.Size = new System.Drawing.Size(144, 17);
            this.rb_UsePWI.TabIndex = 8;
            this.rb_UsePWI.TabStop = true;
            this.rb_UsePWI.Text = "Use Pairwise Interactions";
            this.rb_UsePWI.UseVisualStyleBackColor = true;
            this.rb_UsePWI.CheckedChanged += new System.EventHandler(this.rb_UsePWI_CheckedChanged);
            // 
            // rb_UseBH
            // 
            this.rb_UseBH.AutoSize = true;
            this.rb_UseBH.Location = new System.Drawing.Point(12, 59);
            this.rb_UseBH.Name = "rb_UseBH";
            this.rb_UseBH.Size = new System.Drawing.Size(62, 17);
            this.rb_UseBH.TabIndex = 9;
            this.rb_UseBH.TabStop = true;
            this.rb_UseBH.Text = "Use BH";
            this.rb_UseBH.UseVisualStyleBackColor = true;
            this.rb_UseBH.CheckedChanged += new System.EventHandler(this.rb_UseBH_CheckedChanged);
            // 
            // cb_TreeOutline
            // 
            this.cb_TreeOutline.AutoSize = true;
            this.cb_TreeOutline.Location = new System.Drawing.Point(12, 17);
            this.cb_TreeOutline.Name = "cb_TreeOutline";
            this.cb_TreeOutline.Size = new System.Drawing.Size(114, 17);
            this.cb_TreeOutline.TabIndex = 10;
            this.cb_TreeOutline.Text = "Show Tree Outline";
            this.cb_TreeOutline.UseVisualStyleBackColor = true;
            this.cb_TreeOutline.CheckedChanged += new System.EventHandler(this.cb_TreeOutline_CheckedChanged);
            // 
            // cb_ShowEmptyCells
            // 
            this.cb_ShowEmptyCells.AutoSize = true;
            this.cb_ShowEmptyCells.Location = new System.Drawing.Point(12, 40);
            this.cb_ShowEmptyCells.Name = "cb_ShowEmptyCells";
            this.cb_ShowEmptyCells.Size = new System.Drawing.Size(109, 17);
            this.cb_ShowEmptyCells.TabIndex = 11;
            this.cb_ShowEmptyCells.Text = "Show Empty cells";
            this.cb_ShowEmptyCells.UseVisualStyleBackColor = true;
            this.cb_ShowEmptyCells.CheckedChanged += new System.EventHandler(this.cb_ShowEmptyCells_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Theta";
            // 
            // tb_Theta
            // 
            this.tb_Theta.Location = new System.Drawing.Point(12, 68);
            this.tb_Theta.Name = "tb_Theta";
            this.tb_Theta.Size = new System.Drawing.Size(75, 20);
            this.tb_Theta.TabIndex = 12;
            this.tb_Theta.Text = "2";
            this.tb_Theta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_Simulate
            // 
            this.btn_Simulate.BackColor = System.Drawing.Color.Purple;
            this.btn_Simulate.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Simulate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Simulate.Location = new System.Drawing.Point(15, 54);
            this.btn_Simulate.Name = "btn_Simulate";
            this.btn_Simulate.Size = new System.Drawing.Size(75, 23);
            this.btn_Simulate.TabIndex = 14;
            this.btn_Simulate.Text = "Simulate Timestep";
            this.btn_Simulate.UseVisualStyleBackColor = false;
            this.btn_Simulate.Click += new System.EventHandler(this.btn_Simulate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Timesteps to Simulate";
            // 
            // tb_TimeStepSim
            // 
            this.tb_TimeStepSim.Location = new System.Drawing.Point(15, 30);
            this.tb_TimeStepSim.Name = "tb_TimeStepSim";
            this.tb_TimeStepSim.Size = new System.Drawing.Size(175, 20);
            this.tb_TimeStepSim.TabIndex = 15;
            // 
            // btn_CalcForces
            // 
            this.btn_CalcForces.BackColor = System.Drawing.Color.Purple;
            this.btn_CalcForces.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcForces.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_CalcForces.Location = new System.Drawing.Point(15, 124);
            this.btn_CalcForces.Name = "btn_CalcForces";
            this.btn_CalcForces.Size = new System.Drawing.Size(131, 23);
            this.btn_CalcForces.TabIndex = 17;
            this.btn_CalcForces.Text = "Calculate Forces";
            this.btn_CalcForces.UseVisualStyleBackColor = false;
            this.btn_CalcForces.Click += new System.EventHandler(this.btn_CalcForces_Click);
            // 
            // tb_TargetParticleNum
            // 
            this.tb_TargetParticleNum.Location = new System.Drawing.Point(15, 29);
            this.tb_TargetParticleNum.Name = "tb_TargetParticleNum";
            this.tb_TargetParticleNum.Size = new System.Drawing.Size(122, 20);
            this.tb_TargetParticleNum.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Target Particle";
            // 
            // cb_ShowResForce
            // 
            this.cb_ShowResForce.AutoSize = true;
            this.cb_ShowResForce.Location = new System.Drawing.Point(15, 78);
            this.cb_ShowResForce.Name = "cb_ShowResForce";
            this.cb_ShowResForce.Size = new System.Drawing.Size(131, 17);
            this.cb_ShowResForce.TabIndex = 20;
            this.cb_ShowResForce.Text = "Show Resultant Force";
            this.cb_ShowResForce.UseVisualStyleBackColor = true;
            // 
            // rb_ParlBH
            // 
            this.rb_ParlBH.AutoSize = true;
            this.rb_ParlBH.Location = new System.Drawing.Point(12, 82);
            this.rb_ParlBH.Name = "rb_ParlBH";
            this.rb_ParlBH.Size = new System.Drawing.Size(99, 17);
            this.rb_ParlBH.TabIndex = 21;
            this.rb_ParlBH.TabStop = true;
            this.rb_ParlBH.Text = "Use Parallel BH";
            this.rb_ParlBH.UseVisualStyleBackColor = true;
            this.rb_ParlBH.CheckedChanged += new System.EventHandler(this.rb_ParlBH_CheckedChanged);
            // 
            // cb_ShowGrouping
            // 
            this.cb_ShowGrouping.AutoSize = true;
            this.cb_ShowGrouping.Location = new System.Drawing.Point(15, 101);
            this.cb_ShowGrouping.Name = "cb_ShowGrouping";
            this.cb_ShowGrouping.Size = new System.Drawing.Size(99, 17);
            this.cb_ShowGrouping.TabIndex = 22;
            this.cb_ShowGrouping.Text = "Show Grouping";
            this.cb_ShowGrouping.UseVisualStyleBackColor = true;
            this.cb_ShowGrouping.CheckedChanged += new System.EventHandler(this.cb_ShowGrouping_CheckedChanged);
            // 
            // p_SimulationArea
            // 
            this.p_SimulationArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p_SimulationArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_SimulationArea.Location = new System.Drawing.Point(12, 12);
            this.p_SimulationArea.Name = "p_SimulationArea";
            this.p_SimulationArea.Size = new System.Drawing.Size(737, 737);
            this.p_SimulationArea.TabIndex = 0;
            // 
            // iL_ExecMetrics
            // 
            this.iL_ExecMetrics.AutoSize = true;
            this.iL_ExecMetrics.Location = new System.Drawing.Point(777, 529);
            this.iL_ExecMetrics.Name = "iL_ExecMetrics";
            this.iL_ExecMetrics.Size = new System.Drawing.Size(91, 13);
            this.iL_ExecMetrics.TabIndex = 26;
            this.iL_ExecMetrics.Text = "Execution Metrics";
            // 
            // iL_Start
            // 
            this.iL_Start.AutoSize = true;
            this.iL_Start.Location = new System.Drawing.Point(17, 30);
            this.iL_Start.Name = "iL_Start";
            this.iL_Start.Size = new System.Drawing.Size(32, 13);
            this.iL_Start.TabIndex = 27;
            this.iL_Start.Text = "Start:";
            // 
            // iL_End
            // 
            this.iL_End.AutoSize = true;
            this.iL_End.Location = new System.Drawing.Point(17, 50);
            this.iL_End.Name = "iL_End";
            this.iL_End.Size = new System.Drawing.Size(29, 13);
            this.iL_End.TabIndex = 28;
            this.iL_End.Text = "End:";
            // 
            // iL_Total
            // 
            this.iL_Total.AutoSize = true;
            this.iL_Total.Location = new System.Drawing.Point(17, 72);
            this.iL_Total.Name = "iL_Total";
            this.iL_Total.Size = new System.Drawing.Size(34, 13);
            this.iL_Total.TabIndex = 29;
            this.iL_Total.Text = "Total:";
            // 
            // p_ExecMetrics
            // 
            this.p_ExecMetrics.BackColor = System.Drawing.Color.White;
            this.p_ExecMetrics.Controls.Add(this.checkBox1);
            this.p_ExecMetrics.Controls.Add(this.l_PPWITimeValue);
            this.p_ExecMetrics.Controls.Add(this.iL_PPWI);
            this.p_ExecMetrics.Controls.Add(this.l_BHParlTimeValue);
            this.p_ExecMetrics.Controls.Add(this.l_BHSingleStepTimeValue);
            this.p_ExecMetrics.Controls.Add(this.l_PWITimeValue);
            this.p_ExecMetrics.Controls.Add(this.l_TotalTimeValue);
            this.p_ExecMetrics.Controls.Add(this.l_EndTimeValue);
            this.p_ExecMetrics.Controls.Add(this.l_StartTimeValue);
            this.p_ExecMetrics.Controls.Add(this.iL_BHParlSingleStep);
            this.p_ExecMetrics.Controls.Add(this.iL_BHSingleStep);
            this.p_ExecMetrics.Controls.Add(this.iL_PWI);
            this.p_ExecMetrics.Controls.Add(this.iL_Total);
            this.p_ExecMetrics.Controls.Add(this.iL_lastRun);
            this.p_ExecMetrics.Controls.Add(this.iL_End);
            this.p_ExecMetrics.Controls.Add(this.iL_Start);
            this.p_ExecMetrics.Location = new System.Drawing.Point(776, 545);
            this.p_ExecMetrics.Name = "p_ExecMetrics";
            this.p_ExecMetrics.Size = new System.Drawing.Size(376, 204);
            this.p_ExecMetrics.TabIndex = 30;
            // 
            // l_PPWITimeValue
            // 
            this.l_PPWITimeValue.AutoSize = true;
            this.l_PPWITimeValue.Location = new System.Drawing.Point(158, 116);
            this.l_PPWITimeValue.Name = "l_PPWITimeValue";
            this.l_PPWITimeValue.Size = new System.Drawing.Size(27, 13);
            this.l_PPWITimeValue.TabIndex = 42;
            this.l_PPWITimeValue.Text = "N/A";
            // 
            // iL_PPWI
            // 
            this.iL_PPWI.AutoSize = true;
            this.iL_PPWI.Location = new System.Drawing.Point(17, 116);
            this.iL_PPWI.Name = "iL_PPWI";
            this.iL_PPWI.Size = new System.Drawing.Size(35, 13);
            this.iL_PPWI.TabIndex = 41;
            this.iL_PPWI.Text = "PPWI";
            // 
            // l_BHParlTimeValue
            // 
            this.l_BHParlTimeValue.AutoSize = true;
            this.l_BHParlTimeValue.Location = new System.Drawing.Point(158, 160);
            this.l_BHParlTimeValue.Name = "l_BHParlTimeValue";
            this.l_BHParlTimeValue.Size = new System.Drawing.Size(27, 13);
            this.l_BHParlTimeValue.TabIndex = 40;
            this.l_BHParlTimeValue.Text = "N/A";
            // 
            // l_BHSingleStepTimeValue
            // 
            this.l_BHSingleStepTimeValue.AutoSize = true;
            this.l_BHSingleStepTimeValue.Location = new System.Drawing.Point(158, 138);
            this.l_BHSingleStepTimeValue.Name = "l_BHSingleStepTimeValue";
            this.l_BHSingleStepTimeValue.Size = new System.Drawing.Size(27, 13);
            this.l_BHSingleStepTimeValue.TabIndex = 39;
            this.l_BHSingleStepTimeValue.Text = "N/A";
            // 
            // l_PWITimeValue
            // 
            this.l_PWITimeValue.AutoSize = true;
            this.l_PWITimeValue.Location = new System.Drawing.Point(158, 95);
            this.l_PWITimeValue.Name = "l_PWITimeValue";
            this.l_PWITimeValue.Size = new System.Drawing.Size(27, 13);
            this.l_PWITimeValue.TabIndex = 38;
            this.l_PWITimeValue.Text = "N/A";
            // 
            // l_TotalTimeValue
            // 
            this.l_TotalTimeValue.AutoSize = true;
            this.l_TotalTimeValue.Location = new System.Drawing.Point(107, 72);
            this.l_TotalTimeValue.Name = "l_TotalTimeValue";
            this.l_TotalTimeValue.Size = new System.Drawing.Size(13, 13);
            this.l_TotalTimeValue.TabIndex = 37;
            this.l_TotalTimeValue.Text = "0";
            // 
            // l_EndTimeValue
            // 
            this.l_EndTimeValue.AutoSize = true;
            this.l_EndTimeValue.Location = new System.Drawing.Point(105, 50);
            this.l_EndTimeValue.Name = "l_EndTimeValue";
            this.l_EndTimeValue.Size = new System.Drawing.Size(13, 13);
            this.l_EndTimeValue.TabIndex = 36;
            this.l_EndTimeValue.Text = "0";
            // 
            // l_StartTimeValue
            // 
            this.l_StartTimeValue.AutoSize = true;
            this.l_StartTimeValue.Location = new System.Drawing.Point(105, 30);
            this.l_StartTimeValue.Name = "l_StartTimeValue";
            this.l_StartTimeValue.Size = new System.Drawing.Size(13, 13);
            this.l_StartTimeValue.TabIndex = 35;
            this.l_StartTimeValue.Text = "0";
            // 
            // iL_BHParlSingleStep
            // 
            this.iL_BHParlSingleStep.AutoSize = true;
            this.iL_BHParlSingleStep.Location = new System.Drawing.Point(16, 160);
            this.iL_BHParlSingleStep.Name = "iL_BHParlSingleStep";
            this.iL_BHParlSingleStep.Size = new System.Drawing.Size(100, 13);
            this.iL_BHParlSingleStep.TabIndex = 34;
            this.iL_BHParlSingleStep.Text = "BH Parl Single Step";
            // 
            // iL_BHSingleStep
            // 
            this.iL_BHSingleStep.AutoSize = true;
            this.iL_BHSingleStep.Location = new System.Drawing.Point(18, 138);
            this.iL_BHSingleStep.Name = "iL_BHSingleStep";
            this.iL_BHSingleStep.Size = new System.Drawing.Size(79, 13);
            this.iL_BHSingleStep.TabIndex = 33;
            this.iL_BHSingleStep.Text = "BH Single Step";
            // 
            // iL_PWI
            // 
            this.iL_PWI.AutoSize = true;
            this.iL_PWI.Location = new System.Drawing.Point(17, 95);
            this.iL_PWI.Name = "iL_PWI";
            this.iL_PWI.Size = new System.Drawing.Size(28, 13);
            this.iL_PWI.TabIndex = 32;
            this.iL_PWI.Text = "PWI";
            // 
            // iL_lastRun
            // 
            this.iL_lastRun.AutoSize = true;
            this.iL_lastRun.Location = new System.Drawing.Point(16, 10);
            this.iL_lastRun.Name = "iL_lastRun";
            this.iL_lastRun.Size = new System.Drawing.Size(50, 13);
            this.iL_lastRun.TabIndex = 31;
            this.iL_lastRun.Text = "Last Run";
            // 
            // cb_DrawGraphics
            // 
            this.cb_DrawGraphics.AutoSize = true;
            this.cb_DrawGraphics.Location = new System.Drawing.Point(12, 63);
            this.cb_DrawGraphics.Name = "cb_DrawGraphics";
            this.cb_DrawGraphics.Size = new System.Drawing.Size(96, 17);
            this.cb_DrawGraphics.TabIndex = 31;
            this.cb_DrawGraphics.Text = "Draw Graphics";
            this.cb_DrawGraphics.UseVisualStyleBackColor = true;
            this.cb_DrawGraphics.CheckedChanged += new System.EventHandler(this.cb_DrawGraphics_CheckedChanged);
            // 
            // l_Progress
            // 
            this.l_Progress.AutoSize = true;
            this.l_Progress.Location = new System.Drawing.Point(1071, 518);
            this.l_Progress.Name = "l_Progress";
            this.l_Progress.Size = new System.Drawing.Size(35, 13);
            this.l_Progress.TabIndex = 32;
            this.l_Progress.Text = "Theta";
            // 
            // btn_Gen100PlusParticles
            // 
            this.btn_Gen100PlusParticles.BackColor = System.Drawing.Color.Purple;
            this.btn_Gen100PlusParticles.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gen100PlusParticles.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Gen100PlusParticles.Location = new System.Drawing.Point(128, 27);
            this.btn_Gen100PlusParticles.Name = "btn_Gen100PlusParticles";
            this.btn_Gen100PlusParticles.Size = new System.Drawing.Size(56, 23);
            this.btn_Gen100PlusParticles.TabIndex = 33;
            this.btn_Gen100PlusParticles.Text = "+100";
            this.btn_Gen100PlusParticles.UseVisualStyleBackColor = false;
            this.btn_Gen100PlusParticles.Click += new System.EventHandler(this.btn_Gen100PlusParticles_Click);
            // 
            // dia_SaveLocation
            // 
            this.dia_SaveLocation.InitialDirectory = "D:\\Documents\\Project Files\\N-Body\\Parallel-N-Body\\PerformanceLogs";
            // 
            // rb_ParallelPWI
            // 
            this.rb_ParallelPWI.AutoSize = true;
            this.rb_ParallelPWI.Location = new System.Drawing.Point(12, 38);
            this.rb_ParallelPWI.Name = "rb_ParallelPWI";
            this.rb_ParallelPWI.Size = new System.Drawing.Size(181, 17);
            this.rb_ParallelPWI.TabIndex = 42;
            this.rb_ParallelPWI.TabStop = true;
            this.rb_ParallelPWI.Text = "Use Parallel Pairwise Interactions";
            this.rb_ParallelPWI.UseVisualStyleBackColor = true;
            this.rb_ParallelPWI.CheckedChanged += new System.EventHandler(this.rb_ParallelPWI_CheckedChanged);
            // 
            // chart_ThreadComparison
            // 
            this.chart_ThreadComparison.Location = new System.Drawing.Point(41, 774);
            this.chart_ThreadComparison.Name = "chart_ThreadComparison";
            this.chart_ThreadComparison.Size = new System.Drawing.Size(117, 39);
            this.chart_ThreadComparison.TabIndex = 43;
            this.chart_ThreadComparison.Text = "chart_Parallelism";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(776, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 275);
            this.panel1.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(773, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Manual Controls";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.rb_ParallelPWI);
            this.panel2.Controls.Add(this.rb_UsePWI);
            this.panel2.Controls.Add(this.rb_UseBH);
            this.panel2.Controls.Add(this.rb_ParlBH);
            this.panel2.Location = new System.Drawing.Point(18, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 108);
            this.panel2.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Algorithm Selection";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.cb_ShowEmptyCells);
            this.panel3.Controls.Add(this.cb_DrawGraphics);
            this.panel3.Controls.Add(this.cb_TreeOutline);
            this.panel3.Location = new System.Drawing.Point(241, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 97);
            this.panel3.TabIndex = 47;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Visualization Options";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.tb_ParticleCount);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btn_Gen100PlusParticles);
            this.panel4.Controls.Add(this.tb_Theta);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(19, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 97);
            this.panel4.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Initialization";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.btn_GenerateParticles);
            this.panel5.Controls.Add(this.btn_Partition);
            this.panel5.Controls.Add(this.btn_Reset);
            this.panel5.Location = new System.Drawing.Point(241, 153);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(167, 108);
            this.panel5.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "Action Buttons";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(773, 311);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Auto Controls";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.radioButton1);
            this.panel8.Controls.Add(this.radioButton2);
            this.panel8.Controls.Add(this.label15);
            this.panel8.Controls.Add(this.textBox1);
            this.panel8.Location = new System.Drawing.Point(776, 451);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(427, 64);
            this.panel8.TabIndex = 48;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // tb_AutoIncValue
            // 
            this.tb_AutoIncValue.Location = new System.Drawing.Point(198, 23);
            this.tb_AutoIncValue.Name = "tb_AutoIncValue";
            this.tb_AutoIncValue.Size = new System.Drawing.Size(82, 20);
            this.tb_AutoIncValue.TabIndex = 35;
            this.tb_AutoIncValue.Text = "100";
            // 
            // tb_AutoIncStart
            // 
            this.tb_AutoIncStart.Location = new System.Drawing.Point(16, 23);
            this.tb_AutoIncStart.Name = "tb_AutoIncStart";
            this.tb_AutoIncStart.Size = new System.Drawing.Size(82, 20);
            this.tb_AutoIncStart.TabIndex = 36;
            this.tb_AutoIncStart.Text = "100";
            // 
            // tb_AutoIncEnd
            // 
            this.tb_AutoIncEnd.Location = new System.Drawing.Point(107, 23);
            this.tb_AutoIncEnd.Name = "tb_AutoIncEnd";
            this.tb_AutoIncEnd.Size = new System.Drawing.Size(82, 20);
            this.tb_AutoIncEnd.TabIndex = 37;
            this.tb_AutoIncEnd.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "End";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Start";
            // 
            // l_AutoProgress
            // 
            this.l_AutoProgress.AutoSize = true;
            this.l_AutoProgress.Location = new System.Drawing.Point(217, 53);
            this.l_AutoProgress.Name = "l_AutoProgress";
            this.l_AutoProgress.Size = new System.Drawing.Size(51, 13);
            this.l_AutoProgress.TabIndex = 40;
            this.l_AutoProgress.Text = "Progress:";
            // 
            // l_Status
            // 
            this.l_Status.AutoSize = true;
            this.l_Status.Location = new System.Drawing.Point(218, 71);
            this.l_Status.Name = "l_Status";
            this.l_Status.Size = new System.Drawing.Size(40, 13);
            this.l_Status.TabIndex = 41;
            this.l_Status.Text = "Status:";
            // 
            // btn_AutoTest
            // 
            this.btn_AutoTest.BackColor = System.Drawing.Color.Purple;
            this.btn_AutoTest.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AutoTest.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_AutoTest.Location = new System.Drawing.Point(288, 21);
            this.btn_AutoTest.Name = "btn_AutoTest";
            this.btn_AutoTest.Size = new System.Drawing.Size(127, 23);
            this.btn_AutoTest.TabIndex = 34;
            this.btn_AutoTest.Text = "Auto";
            this.btn_AutoTest.UseVisualStyleBackColor = false;
            this.btn_AutoTest.Click += new System.EventHandler(this.btn_AutoTest_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(198, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Inc";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.radioButton5);
            this.panel7.Controls.Add(this.radioButton4);
            this.panel7.Controls.Add(this.radioButton3);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.btn_AutoTest);
            this.panel7.Controls.Add(this.l_Status);
            this.panel7.Controls.Add(this.l_AutoProgress);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.tb_AutoIncEnd);
            this.panel7.Controls.Add(this.tb_AutoIncStart);
            this.panel7.Controls.Add(this.tb_AutoIncValue);
            this.panel7.Location = new System.Drawing.Point(776, 327);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(427, 99);
            this.panel7.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(774, 435);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Thread Controls";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Max Threads";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 43;
            this.textBox1.Text = "1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(280, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 17);
            this.radioButton1.TabIndex = 44;
            this.radioButton1.Text = "TPL Threads";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.White;
            this.radioButton2.Checked = true;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.radioButton2.Location = new System.Drawing.Point(174, 28);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 17);
            this.radioButton2.TabIndex = 43;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Custom Threads";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 49);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(130, 17);
            this.radioButton3.TabIndex = 45;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "SF Perf + Thread Test";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(16, 72);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(97, 17);
            this.radioButton4.TabIndex = 46;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Thread Testing";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(112, 72);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(101, 17);
            this.radioButton5.TabIndex = 47;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "SF Performance";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.cb_ShowResForce);
            this.panel6.Controls.Add(this.cb_ForceVect);
            this.panel6.Controls.Add(this.btn_CalcForces);
            this.panel6.Controls.Add(this.tb_TargetParticleNum);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.cb_ShowGrouping);
            this.panel6.Location = new System.Drawing.Point(1218, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 275);
            this.panel6.TabIndex = 50;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1215, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Single Particle Diagnostics";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.label18);
            this.panel9.Controls.Add(this.textBox2);
            this.panel9.Controls.Add(this.tb_TimeStepSim);
            this.panel9.Controls.Add(this.btn_Simulate);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Location = new System.Drawing.Point(1218, 330);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 184);
            this.panel9.TabIndex = 52;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1215, 314);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "Simulation Options";
            // 
            // p_TreePanel
            // 
            this.p_TreePanel.Location = new System.Drawing.Point(12, 12);
            this.p_TreePanel.Name = "p_TreePanel";
            this.p_TreePanel.Opacity = 0;
            this.p_TreePanel.Size = new System.Drawing.Size(737, 737);
            this.p_TreePanel.TabIndex = 25;
            // 
            // p_ForcePanel
            // 
            this.p_ForcePanel.Location = new System.Drawing.Point(12, 12);
            this.p_ForcePanel.Name = "p_ForcePanel";
            this.p_ForcePanel.Opacity = 0;
            this.p_ForcePanel.Size = new System.Drawing.Size(737, 737);
            this.p_ForcePanel.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(17, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 20);
            this.textBox2.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 89);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Save Directory";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 179);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Show exec metrics";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1452, 1103);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart_ThreadComparison);
            this.Controls.Add(this.l_Progress);
            this.Controls.Add(this.p_TreePanel);
            this.Controls.Add(this.p_ForcePanel);
            this.Controls.Add(this.iL_ExecMetrics);
            this.Controls.Add(this.p_SimulationArea);
            this.Controls.Add(this.p_ExecMetrics);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.p_ExecMetrics.ResumeLayout(false);
            this.p_ExecMetrics.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_ParticleCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Partition;
        private System.Windows.Forms.Button btn_GenerateParticles;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.CheckBox cb_ForceVect;
        private System.Windows.Forms.RadioButton rb_UsePWI;
        private System.Windows.Forms.RadioButton rb_UseBH;
        private System.Windows.Forms.CheckBox cb_TreeOutline;
        private System.Windows.Forms.CheckBox cb_ShowEmptyCells;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Theta;
        private System.Windows.Forms.Button btn_Simulate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_TimeStepSim;
        private System.Windows.Forms.Button btn_CalcForces;
        private System.Windows.Forms.TextBox tb_TargetParticleNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_ShowResForce;
        private System.Windows.Forms.RadioButton rb_ParlBH;
        private System.Windows.Forms.CheckBox cb_ShowGrouping;
        private TransparentPanel p_ForcePanel;
        private TransparentPanel p_TreePanel;
        private System.Windows.Forms.Panel p_SimulationArea;
        private System.Windows.Forms.Label iL_ExecMetrics;
        private System.Windows.Forms.Label iL_Start;
        private System.Windows.Forms.Label iL_End;
        private System.Windows.Forms.Label iL_Total;
        private System.Windows.Forms.Panel p_ExecMetrics;
        private System.Windows.Forms.Label iL_lastRun;
        private System.Windows.Forms.Label l_BHParlTimeValue;
        private System.Windows.Forms.Label l_BHSingleStepTimeValue;
        private System.Windows.Forms.Label l_PWITimeValue;
        private System.Windows.Forms.Label l_TotalTimeValue;
        private System.Windows.Forms.Label l_EndTimeValue;
        private System.Windows.Forms.Label l_StartTimeValue;
        private System.Windows.Forms.Label iL_BHParlSingleStep;
        private System.Windows.Forms.Label iL_BHSingleStep;
        private System.Windows.Forms.Label iL_PWI;
        private System.Windows.Forms.CheckBox cb_DrawGraphics;
        private System.Windows.Forms.Label l_Progress;
        private System.Windows.Forms.Button btn_Gen100PlusParticles;
        private System.Windows.Forms.SaveFileDialog dia_SaveLocation;
        private System.Windows.Forms.RadioButton rb_ParallelPWI;
        private System.Windows.Forms.Label l_PPWITimeValue;
        private System.Windows.Forms.Label iL_PPWI;
        private LiveCharts.WinForms.CartesianChart chart_ThreadComparison;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tb_AutoIncValue;
        private System.Windows.Forms.TextBox tb_AutoIncStart;
        private System.Windows.Forms.TextBox tb_AutoIncEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_AutoProgress;
        private System.Windows.Forms.Label l_Status;
        private System.Windows.Forms.Button btn_AutoTest;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox2;
    }
}

