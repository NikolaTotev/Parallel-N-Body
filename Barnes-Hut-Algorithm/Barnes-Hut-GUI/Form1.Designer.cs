
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.p_TreePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.p_ForcePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.btn_AutoTest = new System.Windows.Forms.Button();
            this.tb_AutoIncValue = new System.Windows.Forms.TextBox();
            this.tb_AutoIncStart = new System.Windows.Forms.TextBox();
            this.tb_AutoIncEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_AutoProgress = new System.Windows.Forms.Label();
            this.l_Status = new System.Windows.Forms.Label();
            this.dia_SaveLocation = new System.Windows.Forms.SaveFileDialog();
            this.p_ExecMetrics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_ParticleCount
            // 
            this.tb_ParticleCount.Location = new System.Drawing.Point(882, 47);
            this.tb_ParticleCount.Name = "tb_ParticleCount";
            this.tb_ParticleCount.Size = new System.Drawing.Size(219, 20);
            this.tb_ParticleCount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(786, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of bodies";
            // 
            // btn_Partition
            // 
            this.btn_Partition.Location = new System.Drawing.Point(987, 98);
            this.btn_Partition.Name = "btn_Partition";
            this.btn_Partition.Size = new System.Drawing.Size(75, 23);
            this.btn_Partition.TabIndex = 2;
            this.btn_Partition.Text = "Partition";
            this.btn_Partition.UseVisualStyleBackColor = true;
            this.btn_Partition.Click += new System.EventHandler(this.btn_Partition_Click);
            // 
            // btn_GenerateParticles
            // 
            this.btn_GenerateParticles.Location = new System.Drawing.Point(851, 98);
            this.btn_GenerateParticles.Name = "btn_GenerateParticles";
            this.btn_GenerateParticles.Size = new System.Drawing.Size(120, 23);
            this.btn_GenerateParticles.TabIndex = 3;
            this.btn_GenerateParticles.Text = "Generate Particles";
            this.btn_GenerateParticles.UseVisualStyleBackColor = true;
            this.btn_GenerateParticles.Click += new System.EventHandler(this.btn_GenerateParticles_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(851, 127);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // cb_ForceVect
            // 
            this.cb_ForceVect.AutoSize = true;
            this.cb_ForceVect.Location = new System.Drawing.Point(789, 434);
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
            this.rb_UsePWI.Location = new System.Drawing.Point(987, 186);
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
            this.rb_UseBH.Location = new System.Drawing.Point(987, 209);
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
            this.cb_TreeOutline.Location = new System.Drawing.Point(846, 186);
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
            this.cb_ShowEmptyCells.Location = new System.Drawing.Point(846, 209);
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
            this.label2.Location = new System.Drawing.Point(946, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Theta";
            // 
            // tb_Theta
            // 
            this.tb_Theta.Location = new System.Drawing.Point(987, 130);
            this.tb_Theta.Name = "tb_Theta";
            this.tb_Theta.Size = new System.Drawing.Size(75, 20);
            this.tb_Theta.TabIndex = 12;
            this.tb_Theta.Text = "2";
            this.tb_Theta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(956, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Simulate Timestep";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(953, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Timesteps to Simulate";
            // 
            // tb_TimeStepSim
            // 
            this.tb_TimeStepSim.Location = new System.Drawing.Point(956, 352);
            this.tb_TimeStepSim.Name = "tb_TimeStepSim";
            this.tb_TimeStepSim.Size = new System.Drawing.Size(175, 20);
            this.tb_TimeStepSim.TabIndex = 15;
            // 
            // btn_CalcForces
            // 
            this.btn_CalcForces.Location = new System.Drawing.Point(789, 503);
            this.btn_CalcForces.Name = "btn_CalcForces";
            this.btn_CalcForces.Size = new System.Drawing.Size(131, 23);
            this.btn_CalcForces.TabIndex = 17;
            this.btn_CalcForces.Text = "Calculate Forces";
            this.btn_CalcForces.UseVisualStyleBackColor = true;
            this.btn_CalcForces.Click += new System.EventHandler(this.btn_CalcForces_Click);
            // 
            // tb_TargetParticleNum
            // 
            this.tb_TargetParticleNum.Location = new System.Drawing.Point(789, 408);
            this.tb_TargetParticleNum.Name = "tb_TargetParticleNum";
            this.tb_TargetParticleNum.Size = new System.Drawing.Size(122, 20);
            this.tb_TargetParticleNum.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(788, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Target Particle";
            // 
            // cb_ShowResForce
            // 
            this.cb_ShowResForce.AutoSize = true;
            this.cb_ShowResForce.Location = new System.Drawing.Point(789, 457);
            this.cb_ShowResForce.Name = "cb_ShowResForce";
            this.cb_ShowResForce.Size = new System.Drawing.Size(131, 17);
            this.cb_ShowResForce.TabIndex = 20;
            this.cb_ShowResForce.Text = "Show Resultant Force";
            this.cb_ShowResForce.UseVisualStyleBackColor = true;
            // 
            // rb_ParlBH
            // 
            this.rb_ParlBH.AutoSize = true;
            this.rb_ParlBH.Location = new System.Drawing.Point(987, 232);
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
            this.cb_ShowGrouping.Location = new System.Drawing.Point(789, 480);
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
            this.iL_ExecMetrics.Location = new System.Drawing.Point(12, 11);
            this.iL_ExecMetrics.Name = "iL_ExecMetrics";
            this.iL_ExecMetrics.Size = new System.Drawing.Size(91, 13);
            this.iL_ExecMetrics.TabIndex = 26;
            this.iL_ExecMetrics.Text = "Execution Metrics";
            // 
            // iL_Start
            // 
            this.iL_Start.AutoSize = true;
            this.iL_Start.Location = new System.Drawing.Point(17, 55);
            this.iL_Start.Name = "iL_Start";
            this.iL_Start.Size = new System.Drawing.Size(32, 13);
            this.iL_Start.TabIndex = 27;
            this.iL_Start.Text = "Start:";
            // 
            // iL_End
            // 
            this.iL_End.AutoSize = true;
            this.iL_End.Location = new System.Drawing.Point(17, 75);
            this.iL_End.Name = "iL_End";
            this.iL_End.Size = new System.Drawing.Size(29, 13);
            this.iL_End.TabIndex = 28;
            this.iL_End.Text = "End:";
            // 
            // iL_Total
            // 
            this.iL_Total.AutoSize = true;
            this.iL_Total.Location = new System.Drawing.Point(17, 97);
            this.iL_Total.Name = "iL_Total";
            this.iL_Total.Size = new System.Drawing.Size(34, 13);
            this.iL_Total.TabIndex = 29;
            this.iL_Total.Text = "Total:";
            // 
            // p_ExecMetrics
            // 
            this.p_ExecMetrics.BackColor = System.Drawing.Color.White;
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
            this.p_ExecMetrics.Controls.Add(this.iL_ExecMetrics);
            this.p_ExecMetrics.Location = new System.Drawing.Point(789, 555);
            this.p_ExecMetrics.Name = "p_ExecMetrics";
            this.p_ExecMetrics.Size = new System.Drawing.Size(376, 194);
            this.p_ExecMetrics.TabIndex = 30;
            // 
            // l_BHParlTimeValue
            // 
            this.l_BHParlTimeValue.AutoSize = true;
            this.l_BHParlTimeValue.Location = new System.Drawing.Point(158, 164);
            this.l_BHParlTimeValue.Name = "l_BHParlTimeValue";
            this.l_BHParlTimeValue.Size = new System.Drawing.Size(27, 13);
            this.l_BHParlTimeValue.TabIndex = 40;
            this.l_BHParlTimeValue.Text = "N/A";
            // 
            // l_BHSingleStepTimeValue
            // 
            this.l_BHSingleStepTimeValue.AutoSize = true;
            this.l_BHSingleStepTimeValue.Location = new System.Drawing.Point(158, 142);
            this.l_BHSingleStepTimeValue.Name = "l_BHSingleStepTimeValue";
            this.l_BHSingleStepTimeValue.Size = new System.Drawing.Size(27, 13);
            this.l_BHSingleStepTimeValue.TabIndex = 39;
            this.l_BHSingleStepTimeValue.Text = "N/A";
            // 
            // l_PWITimeValue
            // 
            this.l_PWITimeValue.AutoSize = true;
            this.l_PWITimeValue.Location = new System.Drawing.Point(158, 120);
            this.l_PWITimeValue.Name = "l_PWITimeValue";
            this.l_PWITimeValue.Size = new System.Drawing.Size(27, 13);
            this.l_PWITimeValue.TabIndex = 38;
            this.l_PWITimeValue.Text = "N/A";
            // 
            // l_TotalTimeValue
            // 
            this.l_TotalTimeValue.AutoSize = true;
            this.l_TotalTimeValue.Location = new System.Drawing.Point(107, 97);
            this.l_TotalTimeValue.Name = "l_TotalTimeValue";
            this.l_TotalTimeValue.Size = new System.Drawing.Size(13, 13);
            this.l_TotalTimeValue.TabIndex = 37;
            this.l_TotalTimeValue.Text = "0";
            // 
            // l_EndTimeValue
            // 
            this.l_EndTimeValue.AutoSize = true;
            this.l_EndTimeValue.Location = new System.Drawing.Point(105, 75);
            this.l_EndTimeValue.Name = "l_EndTimeValue";
            this.l_EndTimeValue.Size = new System.Drawing.Size(13, 13);
            this.l_EndTimeValue.TabIndex = 36;
            this.l_EndTimeValue.Text = "0";
            // 
            // l_StartTimeValue
            // 
            this.l_StartTimeValue.AutoSize = true;
            this.l_StartTimeValue.Location = new System.Drawing.Point(105, 55);
            this.l_StartTimeValue.Name = "l_StartTimeValue";
            this.l_StartTimeValue.Size = new System.Drawing.Size(13, 13);
            this.l_StartTimeValue.TabIndex = 35;
            this.l_StartTimeValue.Text = "0";
            // 
            // iL_BHParlSingleStep
            // 
            this.iL_BHParlSingleStep.AutoSize = true;
            this.iL_BHParlSingleStep.Location = new System.Drawing.Point(20, 164);
            this.iL_BHParlSingleStep.Name = "iL_BHParlSingleStep";
            this.iL_BHParlSingleStep.Size = new System.Drawing.Size(100, 13);
            this.iL_BHParlSingleStep.TabIndex = 34;
            this.iL_BHParlSingleStep.Text = "BH Parl Single Step";
            // 
            // iL_BHSingleStep
            // 
            this.iL_BHSingleStep.AutoSize = true;
            this.iL_BHSingleStep.Location = new System.Drawing.Point(18, 142);
            this.iL_BHSingleStep.Name = "iL_BHSingleStep";
            this.iL_BHSingleStep.Size = new System.Drawing.Size(79, 13);
            this.iL_BHSingleStep.TabIndex = 33;
            this.iL_BHSingleStep.Text = "BH Single Step";
            // 
            // iL_PWI
            // 
            this.iL_PWI.AutoSize = true;
            this.iL_PWI.Location = new System.Drawing.Point(17, 120);
            this.iL_PWI.Name = "iL_PWI";
            this.iL_PWI.Size = new System.Drawing.Size(28, 13);
            this.iL_PWI.TabIndex = 32;
            this.iL_PWI.Text = "PWI";
            // 
            // iL_lastRun
            // 
            this.iL_lastRun.AutoSize = true;
            this.iL_lastRun.Location = new System.Drawing.Point(16, 35);
            this.iL_lastRun.Name = "iL_lastRun";
            this.iL_lastRun.Size = new System.Drawing.Size(50, 13);
            this.iL_lastRun.TabIndex = 31;
            this.iL_lastRun.Text = "Last Run";
            // 
            // cb_DrawGraphics
            // 
            this.cb_DrawGraphics.AutoSize = true;
            this.cb_DrawGraphics.Location = new System.Drawing.Point(846, 232);
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
            this.l_Progress.Location = new System.Drawing.Point(996, 434);
            this.l_Progress.Name = "l_Progress";
            this.l_Progress.Size = new System.Drawing.Size(35, 13);
            this.l_Progress.TabIndex = 32;
            this.l_Progress.Text = "Theta";
            // 
            // btn_Gen100PlusParticles
            // 
            this.btn_Gen100PlusParticles.Location = new System.Drawing.Point(1107, 45);
            this.btn_Gen100PlusParticles.Name = "btn_Gen100PlusParticles";
            this.btn_Gen100PlusParticles.Size = new System.Drawing.Size(56, 23);
            this.btn_Gen100PlusParticles.TabIndex = 33;
            this.btn_Gen100PlusParticles.Text = "+100";
            this.btn_Gen100PlusParticles.UseVisualStyleBackColor = true;
            this.btn_Gen100PlusParticles.Click += new System.EventHandler(this.btn_Gen100PlusParticles_Click);
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
            // btn_AutoTest
            // 
            this.btn_AutoTest.Location = new System.Drawing.Point(789, 274);
            this.btn_AutoTest.Name = "btn_AutoTest";
            this.btn_AutoTest.Size = new System.Drawing.Size(56, 23);
            this.btn_AutoTest.TabIndex = 34;
            this.btn_AutoTest.Text = "Auto";
            this.btn_AutoTest.UseVisualStyleBackColor = true;
            this.btn_AutoTest.Click += new System.EventHandler(this.btn_AutoTest_Click);
            // 
            // tb_AutoIncValue
            // 
            this.tb_AutoIncValue.Location = new System.Drawing.Point(851, 276);
            this.tb_AutoIncValue.Name = "tb_AutoIncValue";
            this.tb_AutoIncValue.Size = new System.Drawing.Size(69, 20);
            this.tb_AutoIncValue.TabIndex = 35;
            this.tb_AutoIncValue.Text = "100";
            // 
            // tb_AutoIncStart
            // 
            this.tb_AutoIncStart.Location = new System.Drawing.Point(958, 276);
            this.tb_AutoIncStart.Name = "tb_AutoIncStart";
            this.tb_AutoIncStart.Size = new System.Drawing.Size(69, 20);
            this.tb_AutoIncStart.TabIndex = 36;
            this.tb_AutoIncStart.Text = "100";
            // 
            // tb_AutoIncEnd
            // 
            this.tb_AutoIncEnd.Location = new System.Drawing.Point(1062, 276);
            this.tb_AutoIncEnd.Name = "tb_AutoIncEnd";
            this.tb_AutoIncEnd.Size = new System.Drawing.Size(69, 20);
            this.tb_AutoIncEnd.TabIndex = 37;
            this.tb_AutoIncEnd.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1027, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "End";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(929, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Start";
            // 
            // l_AutoProgress
            // 
            this.l_AutoProgress.AutoSize = true;
            this.l_AutoProgress.Location = new System.Drawing.Point(788, 300);
            this.l_AutoProgress.Name = "l_AutoProgress";
            this.l_AutoProgress.Size = new System.Drawing.Size(51, 13);
            this.l_AutoProgress.TabIndex = 40;
            this.l_AutoProgress.Text = "Progress:";
            // 
            // l_Status
            // 
            this.l_Status.AutoSize = true;
            this.l_Status.Location = new System.Drawing.Point(789, 313);
            this.l_Status.Name = "l_Status";
            this.l_Status.Size = new System.Drawing.Size(40, 13);
            this.l_Status.TabIndex = 41;
            this.l_Status.Text = "Status:";
            // 
            // dia_SaveLocation
            // 
            this.dia_SaveLocation.InitialDirectory = "D:\\Documents\\Project Files\\N-Body\\Parallel-N-Body\\PerformanceLogs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.l_Status);
            this.Controls.Add(this.l_AutoProgress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_AutoIncEnd);
            this.Controls.Add(this.tb_AutoIncStart);
            this.Controls.Add(this.tb_AutoIncValue);
            this.Controls.Add(this.btn_AutoTest);
            this.Controls.Add(this.btn_Gen100PlusParticles);
            this.Controls.Add(this.l_Progress);
            this.Controls.Add(this.cb_DrawGraphics);
            this.Controls.Add(this.p_TreePanel);
            this.Controls.Add(this.p_ForcePanel);
            this.Controls.Add(this.cb_ShowGrouping);
            this.Controls.Add(this.rb_ParlBH);
            this.Controls.Add(this.cb_ShowResForce);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_TargetParticleNum);
            this.Controls.Add(this.btn_CalcForces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_TimeStepSim);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Theta);
            this.Controls.Add(this.cb_ShowEmptyCells);
            this.Controls.Add(this.cb_TreeOutline);
            this.Controls.Add(this.rb_UseBH);
            this.Controls.Add(this.rb_UsePWI);
            this.Controls.Add(this.cb_ForceVect);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_GenerateParticles);
            this.Controls.Add(this.btn_Partition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ParticleCount);
            this.Controls.Add(this.p_SimulationArea);
            this.Controls.Add(this.p_ExecMetrics);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.p_ExecMetrics.ResumeLayout(false);
            this.p_ExecMetrics.PerformLayout();
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
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Button btn_AutoTest;
        private System.Windows.Forms.TextBox tb_AutoIncValue;
        private System.Windows.Forms.TextBox tb_AutoIncStart;
        private System.Windows.Forms.TextBox tb_AutoIncEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_AutoProgress;
        private System.Windows.Forms.Label l_Status;
        private System.Windows.Forms.SaveFileDialog dia_SaveLocation;
    }
}

