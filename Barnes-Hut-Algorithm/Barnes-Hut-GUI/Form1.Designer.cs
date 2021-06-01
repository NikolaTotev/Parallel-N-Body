
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
            this.l_TimeStepsToSim = new System.Windows.Forms.Label();
            this.tb_TimeStepSim = new System.Windows.Forms.TextBox();
            this.btn_CalcForces = new System.Windows.Forms.Button();
            this.tb_TargetParticleNum = new System.Windows.Forms.TextBox();
            this.l_TgtParticle = new System.Windows.Forms.Label();
            this.cb_ShowResForce = new System.Windows.Forms.CheckBox();
            this.rb_ParlBH = new System.Windows.Forms.RadioButton();
            this.cb_ShowGrouping = new System.Windows.Forms.CheckBox();
            this.p_SimulationArea = new System.Windows.Forms.Panel();
            this.iL_ExecMetrics = new System.Windows.Forms.Label();
            this.iL_Start = new System.Windows.Forms.Label();
            this.iL_End = new System.Windows.Forms.Label();
            this.iL_Total = new System.Windows.Forms.Label();
            this.p_ExecMetrics = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.p_ManualControls = new System.Windows.Forms.Panel();
            this.l_ActionBtns = new System.Windows.Forms.Label();
            this.p_ActionButtons = new System.Windows.Forms.Panel();
            this.l_init = new System.Windows.Forms.Label();
            this.p_Initialization = new System.Windows.Forms.Panel();
            this.cb_UseStaticPoints = new System.Windows.Forms.CheckBox();
            this.l_VisOpts = new System.Windows.Forms.Label();
            this.p_Visualization = new System.Windows.Forms.Panel();
            this.l_AlgSelection = new System.Windows.Forms.Label();
            this.p_AlgSelection = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.l_AutoControls = new System.Windows.Forms.Label();
            this.p_ThreadControls = new System.Windows.Forms.Panel();
            this.rb_TPLThreads = new System.Windows.Forms.RadioButton();
            this.rb_CustomThreads = new System.Windows.Forms.RadioButton();
            this.l_MaxThreads = new System.Windows.Forms.Label();
            this.tb_MaxThreads = new System.Windows.Forms.TextBox();
            this.tb_AutoIncValue = new System.Windows.Forms.TextBox();
            this.tb_AutoIncStart = new System.Windows.Forms.TextBox();
            this.tb_AutoIncEnd = new System.Windows.Forms.TextBox();
            this.l_AutoEnd = new System.Windows.Forms.Label();
            this.l_AutoStart = new System.Windows.Forms.Label();
            this.l_AutoProgress = new System.Windows.Forms.Label();
            this.l_Status = new System.Windows.Forms.Label();
            this.btn_AutoTest = new System.Windows.Forms.Button();
            this.l_AutoInc = new System.Windows.Forms.Label();
            this.p_AutoControls = new System.Windows.Forms.Panel();
            this.rb_SFPerformance = new System.Windows.Forms.RadioButton();
            this.rb_ThreadTesting = new System.Windows.Forms.RadioButton();
            this.rb_SFandTT = new System.Windows.Forms.RadioButton();
            this.l_ThreadControls = new System.Windows.Forms.Label();
            this.p_SingleParticleDiagnostics = new System.Windows.Forms.Panel();
            this.cb_ShowShiftedVect = new System.Windows.Forms.CheckBox();
            this.cb_ShowCOG = new System.Windows.Forms.CheckBox();
            this.l_SimDiagnostics = new System.Windows.Forms.Label();
            this.p_SimOptions = new System.Windows.Forms.Panel();
            this.btn_AnimationTest = new System.Windows.Forms.Button();
            this.l_saveDirectory = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.l_SimOpts = new System.Windows.Forms.Label();
            this.chart_ExecTime = new LiveCharts.WinForms.CartesianChart();
            this.btn_SaveExecGraph = new System.Windows.Forms.Button();
            this.btn_SaveThreadComp = new System.Windows.Forms.Button();
            this.pb_AnimationTest = new System.Windows.Forms.PictureBox();
            this.p_TreePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.p_ForcePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.p_ExecMetrics.SuspendLayout();
            this.p_ManualControls.SuspendLayout();
            this.p_ActionButtons.SuspendLayout();
            this.p_Initialization.SuspendLayout();
            this.p_Visualization.SuspendLayout();
            this.p_AlgSelection.SuspendLayout();
            this.p_ThreadControls.SuspendLayout();
            this.p_AutoControls.SuspendLayout();
            this.p_SingleParticleDiagnostics.SuspendLayout();
            this.p_SimOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AnimationTest)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_ParticleCount
            // 
            this.tb_ParticleCount.Location = new System.Drawing.Point(12, 29);
            this.tb_ParticleCount.Name = "tb_ParticleCount";
            this.tb_ParticleCount.Size = new System.Drawing.Size(106, 20);
            this.tb_ParticleCount.TabIndex = 0;
            this.tb_ParticleCount.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of particles";
            // 
            // btn_Partition
            // 
            this.btn_Partition.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            this.btn_GenerateParticles.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            this.btn_Reset.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            this.cb_ForceVect.Checked = true;
            this.cb_ForceVect.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.cb_TreeOutline.Checked = true;
            this.cb_TreeOutline.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // 
            // btn_Simulate
            // 
            this.btn_Simulate.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            // l_TimeStepsToSim
            // 
            this.l_TimeStepsToSim.AutoSize = true;
            this.l_TimeStepsToSim.Location = new System.Drawing.Point(12, 14);
            this.l_TimeStepsToSim.Name = "l_TimeStepsToSim";
            this.l_TimeStepsToSim.Size = new System.Drawing.Size(110, 13);
            this.l_TimeStepsToSim.TabIndex = 16;
            this.l_TimeStepsToSim.Text = "Timesteps to Simulate";
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
            this.btn_CalcForces.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_CalcForces.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcForces.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_CalcForces.Location = new System.Drawing.Point(15, 170);
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
            this.tb_TargetParticleNum.Text = "1";
            // 
            // l_TgtParticle
            // 
            this.l_TgtParticle.AutoSize = true;
            this.l_TgtParticle.Location = new System.Drawing.Point(14, 13);
            this.l_TgtParticle.Name = "l_TgtParticle";
            this.l_TgtParticle.Size = new System.Drawing.Size(76, 13);
            this.l_TgtParticle.TabIndex = 19;
            this.l_TgtParticle.Text = "Target Particle";
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
            this.cb_ShowResForce.CheckedChanged += new System.EventHandler(this.cb_ShowResForce_CheckedChanged);
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
            this.cb_ShowGrouping.Checked = true;
            this.cb_ShowGrouping.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ShowGrouping.Location = new System.Drawing.Point(15, 124);
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
            this.p_ExecMetrics.BackColor = System.Drawing.Color.Bisque;
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
            this.cb_DrawGraphics.Checked = true;
            this.cb_DrawGraphics.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.btn_Gen100PlusParticles.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            this.chart_ThreadComparison.Location = new System.Drawing.Point(12, 764);
            this.chart_ThreadComparison.Name = "chart_ThreadComparison";
            this.chart_ThreadComparison.Size = new System.Drawing.Size(737, 277);
            this.chart_ThreadComparison.TabIndex = 43;
            this.chart_ThreadComparison.Text = "chart_Parallelism";
            // 
            // p_ManualControls
            // 
            this.p_ManualControls.BackColor = System.Drawing.Color.Bisque;
            this.p_ManualControls.Controls.Add(this.l_ActionBtns);
            this.p_ManualControls.Controls.Add(this.p_ActionButtons);
            this.p_ManualControls.Controls.Add(this.l_init);
            this.p_ManualControls.Controls.Add(this.p_Initialization);
            this.p_ManualControls.Controls.Add(this.l_VisOpts);
            this.p_ManualControls.Controls.Add(this.p_Visualization);
            this.p_ManualControls.Controls.Add(this.l_AlgSelection);
            this.p_ManualControls.Controls.Add(this.p_AlgSelection);
            this.p_ManualControls.Location = new System.Drawing.Point(776, 28);
            this.p_ManualControls.Name = "p_ManualControls";
            this.p_ManualControls.Size = new System.Drawing.Size(427, 275);
            this.p_ManualControls.TabIndex = 44;
            // 
            // l_ActionBtns
            // 
            this.l_ActionBtns.AutoSize = true;
            this.l_ActionBtns.Location = new System.Drawing.Point(238, 137);
            this.l_ActionBtns.Name = "l_ActionBtns";
            this.l_ActionBtns.Size = new System.Drawing.Size(76, 13);
            this.l_ActionBtns.TabIndex = 52;
            this.l_ActionBtns.Text = "Action Buttons";
            // 
            // p_ActionButtons
            // 
            this.p_ActionButtons.BackColor = System.Drawing.Color.White;
            this.p_ActionButtons.Controls.Add(this.btn_GenerateParticles);
            this.p_ActionButtons.Controls.Add(this.btn_Partition);
            this.p_ActionButtons.Controls.Add(this.btn_Reset);
            this.p_ActionButtons.Location = new System.Drawing.Point(241, 153);
            this.p_ActionButtons.Name = "p_ActionButtons";
            this.p_ActionButtons.Size = new System.Drawing.Size(167, 108);
            this.p_ActionButtons.TabIndex = 51;
            // 
            // l_init
            // 
            this.l_init.AutoSize = true;
            this.l_init.Location = new System.Drawing.Point(20, 11);
            this.l_init.Name = "l_init";
            this.l_init.Size = new System.Drawing.Size(61, 13);
            this.l_init.TabIndex = 50;
            this.l_init.Text = "Initialization";
            // 
            // p_Initialization
            // 
            this.p_Initialization.BackColor = System.Drawing.Color.White;
            this.p_Initialization.Controls.Add(this.cb_UseStaticPoints);
            this.p_Initialization.Controls.Add(this.tb_ParticleCount);
            this.p_Initialization.Controls.Add(this.label1);
            this.p_Initialization.Controls.Add(this.btn_Gen100PlusParticles);
            this.p_Initialization.Controls.Add(this.tb_Theta);
            this.p_Initialization.Controls.Add(this.label2);
            this.p_Initialization.Location = new System.Drawing.Point(19, 27);
            this.p_Initialization.Name = "p_Initialization";
            this.p_Initialization.Size = new System.Drawing.Size(207, 97);
            this.p_Initialization.TabIndex = 49;
            // 
            // cb_UseStaticPoints
            // 
            this.cb_UseStaticPoints.AutoSize = true;
            this.cb_UseStaticPoints.Location = new System.Drawing.Point(93, 70);
            this.cb_UseStaticPoints.Name = "cb_UseStaticPoints";
            this.cb_UseStaticPoints.Size = new System.Drawing.Size(107, 17);
            this.cb_UseStaticPoints.TabIndex = 32;
            this.cb_UseStaticPoints.Text = "Use Static Points";
            this.cb_UseStaticPoints.UseVisualStyleBackColor = true;
            // 
            // l_VisOpts
            // 
            this.l_VisOpts.AutoSize = true;
            this.l_VisOpts.Location = new System.Drawing.Point(238, 11);
            this.l_VisOpts.Name = "l_VisOpts";
            this.l_VisOpts.Size = new System.Drawing.Size(104, 13);
            this.l_VisOpts.TabIndex = 48;
            this.l_VisOpts.Text = "Visualization Options";
            // 
            // p_Visualization
            // 
            this.p_Visualization.BackColor = System.Drawing.Color.White;
            this.p_Visualization.Controls.Add(this.cb_ShowEmptyCells);
            this.p_Visualization.Controls.Add(this.cb_DrawGraphics);
            this.p_Visualization.Controls.Add(this.cb_TreeOutline);
            this.p_Visualization.Location = new System.Drawing.Point(241, 27);
            this.p_Visualization.Name = "p_Visualization";
            this.p_Visualization.Size = new System.Drawing.Size(168, 97);
            this.p_Visualization.TabIndex = 47;
            // 
            // l_AlgSelection
            // 
            this.l_AlgSelection.AutoSize = true;
            this.l_AlgSelection.Location = new System.Drawing.Point(16, 137);
            this.l_AlgSelection.Name = "l_AlgSelection";
            this.l_AlgSelection.Size = new System.Drawing.Size(97, 13);
            this.l_AlgSelection.TabIndex = 46;
            this.l_AlgSelection.Text = "Algorithm Selection";
            // 
            // p_AlgSelection
            // 
            this.p_AlgSelection.BackColor = System.Drawing.Color.White;
            this.p_AlgSelection.Controls.Add(this.rb_ParallelPWI);
            this.p_AlgSelection.Controls.Add(this.rb_UsePWI);
            this.p_AlgSelection.Controls.Add(this.rb_UseBH);
            this.p_AlgSelection.Controls.Add(this.rb_ParlBH);
            this.p_AlgSelection.Location = new System.Drawing.Point(18, 153);
            this.p_AlgSelection.Name = "p_AlgSelection";
            this.p_AlgSelection.Size = new System.Drawing.Size(208, 108);
            this.p_AlgSelection.TabIndex = 4;
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
            // l_AutoControls
            // 
            this.l_AutoControls.AutoSize = true;
            this.l_AutoControls.Location = new System.Drawing.Point(773, 311);
            this.l_AutoControls.Name = "l_AutoControls";
            this.l_AutoControls.Size = new System.Drawing.Size(70, 13);
            this.l_AutoControls.TabIndex = 47;
            this.l_AutoControls.Text = "Auto Controls";
            // 
            // p_ThreadControls
            // 
            this.p_ThreadControls.BackColor = System.Drawing.Color.Bisque;
            this.p_ThreadControls.Controls.Add(this.rb_TPLThreads);
            this.p_ThreadControls.Controls.Add(this.rb_CustomThreads);
            this.p_ThreadControls.Controls.Add(this.l_MaxThreads);
            this.p_ThreadControls.Controls.Add(this.tb_MaxThreads);
            this.p_ThreadControls.Location = new System.Drawing.Point(776, 451);
            this.p_ThreadControls.Name = "p_ThreadControls";
            this.p_ThreadControls.Size = new System.Drawing.Size(427, 64);
            this.p_ThreadControls.TabIndex = 48;
            // 
            // rb_TPLThreads
            // 
            this.rb_TPLThreads.AutoSize = true;
            this.rb_TPLThreads.Checked = true;
            this.rb_TPLThreads.Location = new System.Drawing.Point(280, 28);
            this.rb_TPLThreads.Name = "rb_TPLThreads";
            this.rb_TPLThreads.Size = new System.Drawing.Size(87, 17);
            this.rb_TPLThreads.TabIndex = 44;
            this.rb_TPLThreads.TabStop = true;
            this.rb_TPLThreads.Text = "TPL Threads";
            this.rb_TPLThreads.UseVisualStyleBackColor = true;
            this.rb_TPLThreads.CheckedChanged += new System.EventHandler(this.rb_TPLThreads_CheckedChanged);
            // 
            // rb_CustomThreads
            // 
            this.rb_CustomThreads.AutoSize = true;
            this.rb_CustomThreads.BackColor = System.Drawing.Color.Transparent;
            this.rb_CustomThreads.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rb_CustomThreads.Location = new System.Drawing.Point(174, 28);
            this.rb_CustomThreads.Name = "rb_CustomThreads";
            this.rb_CustomThreads.Size = new System.Drawing.Size(102, 17);
            this.rb_CustomThreads.TabIndex = 43;
            this.rb_CustomThreads.Text = "Custom Threads";
            this.rb_CustomThreads.UseVisualStyleBackColor = false;
            this.rb_CustomThreads.CheckedChanged += new System.EventHandler(this.rb_CustomThreads_CheckedChanged);
            // 
            // l_MaxThreads
            // 
            this.l_MaxThreads.AutoSize = true;
            this.l_MaxThreads.Location = new System.Drawing.Point(12, 11);
            this.l_MaxThreads.Name = "l_MaxThreads";
            this.l_MaxThreads.Size = new System.Drawing.Size(69, 13);
            this.l_MaxThreads.TabIndex = 44;
            this.l_MaxThreads.Text = "Max Threads";
            // 
            // tb_MaxThreads
            // 
            this.tb_MaxThreads.Location = new System.Drawing.Point(12, 27);
            this.tb_MaxThreads.Name = "tb_MaxThreads";
            this.tb_MaxThreads.Size = new System.Drawing.Size(156, 20);
            this.tb_MaxThreads.TabIndex = 43;
            this.tb_MaxThreads.Text = "12";
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
            // l_AutoEnd
            // 
            this.l_AutoEnd.AutoSize = true;
            this.l_AutoEnd.Location = new System.Drawing.Point(104, 9);
            this.l_AutoEnd.Name = "l_AutoEnd";
            this.l_AutoEnd.Size = new System.Drawing.Size(26, 13);
            this.l_AutoEnd.TabIndex = 38;
            this.l_AutoEnd.Text = "End";
            // 
            // l_AutoStart
            // 
            this.l_AutoStart.AutoSize = true;
            this.l_AutoStart.Location = new System.Drawing.Point(13, 9);
            this.l_AutoStart.Name = "l_AutoStart";
            this.l_AutoStart.Size = new System.Drawing.Size(29, 13);
            this.l_AutoStart.TabIndex = 39;
            this.l_AutoStart.Text = "Start";
            // 
            // l_AutoProgress
            // 
            this.l_AutoProgress.AutoSize = true;
            this.l_AutoProgress.Location = new System.Drawing.Point(152, 51);
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
            this.btn_AutoTest.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            // l_AutoInc
            // 
            this.l_AutoInc.AutoSize = true;
            this.l_AutoInc.Location = new System.Drawing.Point(198, 9);
            this.l_AutoInc.Name = "l_AutoInc";
            this.l_AutoInc.Size = new System.Drawing.Size(22, 13);
            this.l_AutoInc.TabIndex = 42;
            this.l_AutoInc.Text = "Inc";
            // 
            // p_AutoControls
            // 
            this.p_AutoControls.BackColor = System.Drawing.Color.Bisque;
            this.p_AutoControls.Controls.Add(this.rb_SFPerformance);
            this.p_AutoControls.Controls.Add(this.rb_ThreadTesting);
            this.p_AutoControls.Controls.Add(this.rb_SFandTT);
            this.p_AutoControls.Controls.Add(this.l_AutoInc);
            this.p_AutoControls.Controls.Add(this.btn_AutoTest);
            this.p_AutoControls.Controls.Add(this.l_Status);
            this.p_AutoControls.Controls.Add(this.l_AutoProgress);
            this.p_AutoControls.Controls.Add(this.l_AutoStart);
            this.p_AutoControls.Controls.Add(this.l_AutoEnd);
            this.p_AutoControls.Controls.Add(this.tb_AutoIncEnd);
            this.p_AutoControls.Controls.Add(this.tb_AutoIncStart);
            this.p_AutoControls.Controls.Add(this.tb_AutoIncValue);
            this.p_AutoControls.Location = new System.Drawing.Point(776, 327);
            this.p_AutoControls.Name = "p_AutoControls";
            this.p_AutoControls.Size = new System.Drawing.Size(427, 99);
            this.p_AutoControls.TabIndex = 43;
            // 
            // rb_SFPerformance
            // 
            this.rb_SFPerformance.AutoSize = true;
            this.rb_SFPerformance.Location = new System.Drawing.Point(112, 72);
            this.rb_SFPerformance.Name = "rb_SFPerformance";
            this.rb_SFPerformance.Size = new System.Drawing.Size(101, 17);
            this.rb_SFPerformance.TabIndex = 47;
            this.rb_SFPerformance.Text = "SF Performance";
            this.rb_SFPerformance.UseVisualStyleBackColor = true;
            this.rb_SFPerformance.CheckedChanged += new System.EventHandler(this.rb_SFPerformance_CheckedChanged);
            // 
            // rb_ThreadTesting
            // 
            this.rb_ThreadTesting.AutoSize = true;
            this.rb_ThreadTesting.Checked = true;
            this.rb_ThreadTesting.Location = new System.Drawing.Point(16, 72);
            this.rb_ThreadTesting.Name = "rb_ThreadTesting";
            this.rb_ThreadTesting.Size = new System.Drawing.Size(97, 17);
            this.rb_ThreadTesting.TabIndex = 46;
            this.rb_ThreadTesting.TabStop = true;
            this.rb_ThreadTesting.Text = "Thread Testing";
            this.rb_ThreadTesting.UseVisualStyleBackColor = true;
            this.rb_ThreadTesting.CheckedChanged += new System.EventHandler(this.rb_ThreadTesting_CheckedChanged);
            // 
            // rb_SFandTT
            // 
            this.rb_SFandTT.AutoSize = true;
            this.rb_SFandTT.Location = new System.Drawing.Point(16, 49);
            this.rb_SFandTT.Name = "rb_SFandTT";
            this.rb_SFandTT.Size = new System.Drawing.Size(130, 17);
            this.rb_SFandTT.TabIndex = 45;
            this.rb_SFandTT.Text = "SF Perf + Thread Test";
            this.rb_SFandTT.UseVisualStyleBackColor = true;
            this.rb_SFandTT.CheckedChanged += new System.EventHandler(this.rb_SFandTT_CheckedChanged);
            // 
            // l_ThreadControls
            // 
            this.l_ThreadControls.AutoSize = true;
            this.l_ThreadControls.Location = new System.Drawing.Point(774, 435);
            this.l_ThreadControls.Name = "l_ThreadControls";
            this.l_ThreadControls.Size = new System.Drawing.Size(82, 13);
            this.l_ThreadControls.TabIndex = 49;
            this.l_ThreadControls.Text = "Thread Controls";
            // 
            // p_SingleParticleDiagnostics
            // 
            this.p_SingleParticleDiagnostics.BackColor = System.Drawing.Color.Bisque;
            this.p_SingleParticleDiagnostics.Controls.Add(this.cb_ShowShiftedVect);
            this.p_SingleParticleDiagnostics.Controls.Add(this.cb_ShowCOG);
            this.p_SingleParticleDiagnostics.Controls.Add(this.cb_ShowResForce);
            this.p_SingleParticleDiagnostics.Controls.Add(this.cb_ForceVect);
            this.p_SingleParticleDiagnostics.Controls.Add(this.btn_CalcForces);
            this.p_SingleParticleDiagnostics.Controls.Add(this.tb_TargetParticleNum);
            this.p_SingleParticleDiagnostics.Controls.Add(this.l_TgtParticle);
            this.p_SingleParticleDiagnostics.Controls.Add(this.cb_ShowGrouping);
            this.p_SingleParticleDiagnostics.Location = new System.Drawing.Point(1218, 28);
            this.p_SingleParticleDiagnostics.Name = "p_SingleParticleDiagnostics";
            this.p_SingleParticleDiagnostics.Size = new System.Drawing.Size(200, 275);
            this.p_SingleParticleDiagnostics.TabIndex = 50;
            // 
            // cb_ShowShiftedVect
            // 
            this.cb_ShowShiftedVect.AutoSize = true;
            this.cb_ShowShiftedVect.Location = new System.Drawing.Point(15, 101);
            this.cb_ShowShiftedVect.Name = "cb_ShowShiftedVect";
            this.cb_ShowShiftedVect.Size = new System.Drawing.Size(128, 17);
            this.cb_ShowShiftedVect.TabIndex = 24;
            this.cb_ShowShiftedVect.Text = "Show Shifted Vectors";
            this.cb_ShowShiftedVect.UseVisualStyleBackColor = true;
            this.cb_ShowShiftedVect.CheckedChanged += new System.EventHandler(this.cb_ShowShiftedVect_CheckedChanged);
            // 
            // cb_ShowCOG
            // 
            this.cb_ShowCOG.AutoSize = true;
            this.cb_ShowCOG.Checked = true;
            this.cb_ShowCOG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ShowCOG.Location = new System.Drawing.Point(15, 147);
            this.cb_ShowCOG.Name = "cb_ShowCOG";
            this.cb_ShowCOG.Size = new System.Drawing.Size(79, 17);
            this.cb_ShowCOG.TabIndex = 23;
            this.cb_ShowCOG.Text = "Show COG";
            this.cb_ShowCOG.UseVisualStyleBackColor = true;
            this.cb_ShowCOG.CheckedChanged += new System.EventHandler(this.cb_ShowCOG_CheckedChanged);
            // 
            // l_SimDiagnostics
            // 
            this.l_SimDiagnostics.AutoSize = true;
            this.l_SimDiagnostics.Location = new System.Drawing.Point(1215, 12);
            this.l_SimDiagnostics.Name = "l_SimDiagnostics";
            this.l_SimDiagnostics.Size = new System.Drawing.Size(132, 13);
            this.l_SimDiagnostics.TabIndex = 51;
            this.l_SimDiagnostics.Text = "Single Particle Diagnostics";
            // 
            // p_SimOptions
            // 
            this.p_SimOptions.BackColor = System.Drawing.Color.Bisque;
            this.p_SimOptions.Controls.Add(this.btn_AnimationTest);
            this.p_SimOptions.Controls.Add(this.l_saveDirectory);
            this.p_SimOptions.Controls.Add(this.textBox2);
            this.p_SimOptions.Controls.Add(this.tb_TimeStepSim);
            this.p_SimOptions.Controls.Add(this.btn_Simulate);
            this.p_SimOptions.Controls.Add(this.l_TimeStepsToSim);
            this.p_SimOptions.Location = new System.Drawing.Point(1218, 330);
            this.p_SimOptions.Name = "p_SimOptions";
            this.p_SimOptions.Size = new System.Drawing.Size(200, 184);
            this.p_SimOptions.TabIndex = 52;
            // 
            // btn_AnimationTest
            // 
            this.btn_AnimationTest.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_AnimationTest.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AnimationTest.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_AnimationTest.Location = new System.Drawing.Point(47, 148);
            this.btn_AnimationTest.Name = "btn_AnimationTest";
            this.btn_AnimationTest.Size = new System.Drawing.Size(132, 23);
            this.btn_AnimationTest.TabIndex = 19;
            this.btn_AnimationTest.Text = "Test Animation";
            this.btn_AnimationTest.UseVisualStyleBackColor = false;
            this.btn_AnimationTest.Click += new System.EventHandler(this.btn_AnimationTest_Click);
            // 
            // l_saveDirectory
            // 
            this.l_saveDirectory.AutoSize = true;
            this.l_saveDirectory.Location = new System.Drawing.Point(14, 89);
            this.l_saveDirectory.Name = "l_saveDirectory";
            this.l_saveDirectory.Size = new System.Drawing.Size(77, 13);
            this.l_saveDirectory.TabIndex = 18;
            this.l_saveDirectory.Text = "Save Directory";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 20);
            this.textBox2.TabIndex = 17;
            // 
            // l_SimOpts
            // 
            this.l_SimOpts.AutoSize = true;
            this.l_SimOpts.Location = new System.Drawing.Point(1215, 314);
            this.l_SimOpts.Name = "l_SimOpts";
            this.l_SimOpts.Size = new System.Drawing.Size(94, 13);
            this.l_SimOpts.TabIndex = 53;
            this.l_SimOpts.Text = "Simulation Options";
            // 
            // chart_ExecTime
            // 
            this.chart_ExecTime.Location = new System.Drawing.Point(776, 764);
            this.chart_ExecTime.Name = "chart_ExecTime";
            this.chart_ExecTime.Size = new System.Drawing.Size(661, 277);
            this.chart_ExecTime.TabIndex = 54;
            this.chart_ExecTime.Text = "chart_Parallelism";
            // 
            // btn_SaveExecGraph
            // 
            this.btn_SaveExecGraph.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_SaveExecGraph.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveExecGraph.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SaveExecGraph.Location = new System.Drawing.Point(1362, 1047);
            this.btn_SaveExecGraph.Name = "btn_SaveExecGraph";
            this.btn_SaveExecGraph.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveExecGraph.TabIndex = 19;
            this.btn_SaveExecGraph.Text = "Save";
            this.btn_SaveExecGraph.UseVisualStyleBackColor = false;
            this.btn_SaveExecGraph.Click += new System.EventHandler(this.btn_SaveExecGraph_Click);
            // 
            // btn_SaveThreadComp
            // 
            this.btn_SaveThreadComp.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_SaveThreadComp.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveThreadComp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SaveThreadComp.Location = new System.Drawing.Point(674, 1047);
            this.btn_SaveThreadComp.Name = "btn_SaveThreadComp";
            this.btn_SaveThreadComp.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveThreadComp.TabIndex = 55;
            this.btn_SaveThreadComp.Text = "Save";
            this.btn_SaveThreadComp.UseVisualStyleBackColor = false;
            this.btn_SaveThreadComp.Click += new System.EventHandler(this.btn_SaveThreadComp_Click);
            // 
            // pb_AnimationTest
            // 
            this.pb_AnimationTest.BackColor = System.Drawing.Color.Gainsboro;
            this.pb_AnimationTest.Location = new System.Drawing.Point(1167, 545);
            this.pb_AnimationTest.Name = "pb_AnimationTest";
            this.pb_AnimationTest.Size = new System.Drawing.Size(251, 204);
            this.pb_AnimationTest.TabIndex = 56;
            this.pb_AnimationTest.TabStop = false;
            this.pb_AnimationTest.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_AnimationTest_Paint);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1452, 1084);
            this.Controls.Add(this.pb_AnimationTest);
            this.Controls.Add(this.btn_SaveThreadComp);
            this.Controls.Add(this.btn_SaveExecGraph);
            this.Controls.Add(this.chart_ExecTime);
            this.Controls.Add(this.l_SimOpts);
            this.Controls.Add(this.p_SimOptions);
            this.Controls.Add(this.l_SimDiagnostics);
            this.Controls.Add(this.p_SingleParticleDiagnostics);
            this.Controls.Add(this.l_ThreadControls);
            this.Controls.Add(this.p_ThreadControls);
            this.Controls.Add(this.l_AutoControls);
            this.Controls.Add(this.p_AutoControls);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart_ThreadComparison);
            this.Controls.Add(this.l_Progress);
            this.Controls.Add(this.p_TreePanel);
            this.Controls.Add(this.p_ForcePanel);
            this.Controls.Add(this.iL_ExecMetrics);
            this.Controls.Add(this.p_SimulationArea);
            this.Controls.Add(this.p_ExecMetrics);
            this.Controls.Add(this.p_ManualControls);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.p_ExecMetrics.ResumeLayout(false);
            this.p_ExecMetrics.PerformLayout();
            this.p_ManualControls.ResumeLayout(false);
            this.p_ManualControls.PerformLayout();
            this.p_ActionButtons.ResumeLayout(false);
            this.p_Initialization.ResumeLayout(false);
            this.p_Initialization.PerformLayout();
            this.p_Visualization.ResumeLayout(false);
            this.p_Visualization.PerformLayout();
            this.p_AlgSelection.ResumeLayout(false);
            this.p_AlgSelection.PerformLayout();
            this.p_ThreadControls.ResumeLayout(false);
            this.p_ThreadControls.PerformLayout();
            this.p_AutoControls.ResumeLayout(false);
            this.p_AutoControls.PerformLayout();
            this.p_SingleParticleDiagnostics.ResumeLayout(false);
            this.p_SingleParticleDiagnostics.PerformLayout();
            this.p_SimOptions.ResumeLayout(false);
            this.p_SimOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AnimationTest)).EndInit();
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
        private System.Windows.Forms.Label l_TimeStepsToSim;
        private System.Windows.Forms.TextBox tb_TimeStepSim;
        private System.Windows.Forms.Button btn_CalcForces;
        private System.Windows.Forms.TextBox tb_TargetParticleNum;
        private System.Windows.Forms.Label l_TgtParticle;
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
        private System.Windows.Forms.Panel p_ManualControls;
        private System.Windows.Forms.Label l_VisOpts;
        private System.Windows.Forms.Panel p_Visualization;
        private System.Windows.Forms.Label l_AlgSelection;
        private System.Windows.Forms.Panel p_AlgSelection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel p_Initialization;
        private System.Windows.Forms.Panel p_ActionButtons;
        private System.Windows.Forms.Label l_init;
        private System.Windows.Forms.Label l_ActionBtns;
        private System.Windows.Forms.Label l_AutoControls;
        private System.Windows.Forms.Panel p_ThreadControls;
        private System.Windows.Forms.RadioButton rb_TPLThreads;
        private System.Windows.Forms.RadioButton rb_CustomThreads;
        private System.Windows.Forms.Label l_MaxThreads;
        private System.Windows.Forms.TextBox tb_MaxThreads;
        private System.Windows.Forms.TextBox tb_AutoIncValue;
        private System.Windows.Forms.TextBox tb_AutoIncStart;
        private System.Windows.Forms.TextBox tb_AutoIncEnd;
        private System.Windows.Forms.Label l_AutoEnd;
        private System.Windows.Forms.Label l_AutoStart;
        private System.Windows.Forms.Label l_AutoProgress;
        private System.Windows.Forms.Label l_Status;
        private System.Windows.Forms.Button btn_AutoTest;
        private System.Windows.Forms.Label l_AutoInc;
        private System.Windows.Forms.Panel p_AutoControls;
        private System.Windows.Forms.Label l_ThreadControls;
        private System.Windows.Forms.RadioButton rb_SFandTT;
        private System.Windows.Forms.RadioButton rb_SFPerformance;
        private System.Windows.Forms.RadioButton rb_ThreadTesting;
        private System.Windows.Forms.Panel p_SingleParticleDiagnostics;
        private System.Windows.Forms.Label l_SimDiagnostics;
        private System.Windows.Forms.Panel p_SimOptions;
        private System.Windows.Forms.Label l_SimOpts;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label l_saveDirectory;
        private System.Windows.Forms.TextBox textBox2;
        private LiveCharts.WinForms.CartesianChart chart_ExecTime;
        private System.Windows.Forms.Button btn_SaveExecGraph;
        private System.Windows.Forms.Button btn_SaveThreadComp;
        private System.Windows.Forms.CheckBox cb_ShowCOG;
        private System.Windows.Forms.CheckBox cb_ShowShiftedVect;
        private System.Windows.Forms.CheckBox cb_UseStaticPoints;
        private System.Windows.Forms.Button btn_AnimationTest;
        private System.Windows.Forms.PictureBox pb_AnimationTest;
    }
}

