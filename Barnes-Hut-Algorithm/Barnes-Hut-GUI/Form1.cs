using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barnes_Hut_GUI
{
    public partial class Form1 : Form
    {
        private QuadTree mainTree;
        private Graphics graphics;
        private Pen particlePen = new Pen(Color.CornflowerBlue);
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
        private AlgToUse alg = AlgToUse.PWI;


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
            mainTree.alg = AlgToUse.PWI;
        }

        private void btn_Partition_Click(object sender, EventArgs e)
        {
            mainTree.ParitionSpace();
            mainTree.Traverse(mainTree.RootNode, graphics, particlePen);
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

        private void btn_GenerateParticles_Click(object sender, EventArgs e)
        {
            int particleCount = int.Parse(tb_ParticleCount.Text);
            mainTree.GenerateParticles(particleCount);

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
            ShowForceVect = cb_ShowEmptyCells.Checked;
            mainTree.ShowForceVect = cb_ShowEmptyCells.Checked;
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

        private void rb_UsePWI_Click(object sender, EventArgs e)
        {

        }
    }
}