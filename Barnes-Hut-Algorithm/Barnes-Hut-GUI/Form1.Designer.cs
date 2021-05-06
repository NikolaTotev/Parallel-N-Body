
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
            this.p_SimulationArea = new System.Windows.Forms.Panel();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_CalcForces = new System.Windows.Forms.Button();
            this.tb_TargetParcielNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ShowResForce = new System.Windows.Forms.CheckBox();
            this.rb_ParlBH = new System.Windows.Forms.RadioButton();
            this.cb_ShowGrouping = new System.Windows.Forms.CheckBox();
            this.p_ForcePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.p_TreePanel = new Barnes_Hut_GUI.TransparentPanel();
            this.SuspendLayout();
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
            this.cb_ForceVect.Location = new System.Drawing.Point(824, 516);
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
            this.rb_UsePWI.Click += new System.EventHandler(this.rb_UsePWI_Click);
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
            this.tb_Theta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Simulate Timestep";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(786, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Timesteps to Simulate";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(789, 326);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 15;
            // 
            // btn_CalcForces
            // 
            this.btn_CalcForces.Location = new System.Drawing.Point(824, 585);
            this.btn_CalcForces.Name = "btn_CalcForces";
            this.btn_CalcForces.Size = new System.Drawing.Size(131, 23);
            this.btn_CalcForces.TabIndex = 17;
            this.btn_CalcForces.Text = "Calculate Forces";
            this.btn_CalcForces.UseVisualStyleBackColor = true;
            // 
            // tb_TargetParcielNum
            // 
            this.tb_TargetParcielNum.Location = new System.Drawing.Point(824, 490);
            this.tb_TargetParcielNum.Name = "tb_TargetParcielNum";
            this.tb_TargetParcielNum.Size = new System.Drawing.Size(122, 20);
            this.tb_TargetParcielNum.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(823, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Target Particle";
            // 
            // cb_ShowResForce
            // 
            this.cb_ShowResForce.AutoSize = true;
            this.cb_ShowResForce.Location = new System.Drawing.Point(824, 539);
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
            this.cb_ShowGrouping.Location = new System.Drawing.Point(824, 562);
            this.cb_ShowGrouping.Name = "cb_ShowGrouping";
            this.cb_ShowGrouping.Size = new System.Drawing.Size(99, 17);
            this.cb_ShowGrouping.TabIndex = 22;
            this.cb_ShowGrouping.Text = "Show Grouping";
            this.cb_ShowGrouping.UseVisualStyleBackColor = true;
            // 
            // p_ForcePanel
            // 
            this.p_ForcePanel.Location = new System.Drawing.Point(12, 12);
            this.p_ForcePanel.Name = "p_ForcePanel";
            this.p_ForcePanel.Opacity = 0;
            this.p_ForcePanel.Size = new System.Drawing.Size(737, 737);
            this.p_ForcePanel.TabIndex = 24;
            // 
            // p_TreePanel
            // 
            this.p_TreePanel.Location = new System.Drawing.Point(12, 12);
            this.p_TreePanel.Name = "p_TreePanel";
            this.p_TreePanel.Opacity = 0;
            this.p_TreePanel.Size = new System.Drawing.Size(737, 737);
            this.p_TreePanel.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.p_TreePanel);
            this.Controls.Add(this.p_ForcePanel);
            this.Controls.Add(this.cb_ShowGrouping);
            this.Controls.Add(this.rb_ParlBH);
            this.Controls.Add(this.cb_ShowResForce);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_TargetParcielNum);
            this.Controls.Add(this.btn_CalcForces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_SimulationArea;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_CalcForces;
        private System.Windows.Forms.TextBox tb_TargetParcielNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_ShowResForce;
        private System.Windows.Forms.RadioButton rb_ParlBH;
        private System.Windows.Forms.CheckBox cb_ShowGrouping;
        private TransparentPanel p_ForcePanel;
        private TransparentPanel p_TreePanel;
    }
}

