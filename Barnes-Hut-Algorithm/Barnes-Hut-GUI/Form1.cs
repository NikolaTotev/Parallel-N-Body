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

        public Form1()
        {
            InitializeComponent();
            mainTree = new QuadTree();
            graphics = p_SimulationArea.CreateGraphics();
        }

        private void btn_Partition_Click(object sender, EventArgs e)
        {
            mainTree.ParitionSpace();
            mainTree.Traverse(mainTree.RootNode,graphics, particlePen);
        }

        private void btn_GenerateParticles_Click(object sender, EventArgs e)
        {
            int particleCount = int.Parse(tb_ParticleCount.Text);
            mainTree.GenerateParticles(particleCount);

            foreach (Particle particle in mainTree.AllParticles)
            {
                graphics.FillEllipse(particleBrush, particle.CenterPoint.X, particle.CenterPoint.Y, 5, 5);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            mainTree.ClearParticles();
            graphics.Clear(Color.White);
        }
    }
}
