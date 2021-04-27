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
        }

        private void btn_Partition_Click(object sender, EventArgs e)
        {
            mainTree.ParitionSpace();
            mainTree.Traverse(mainTree.RootNode, graphics, particlePen);
            for (int i = 0; i < mainTree.AllParticles.Count; i++)
            {
                graphics.DrawEllipse(particlePen, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius1, mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius1, ElipseRadius1 * 2, ElipseRadius1* 2);
                graphics.FillEllipse(particleBrushRed, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius2, mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius2, ElipseRadius2 * 2, ElipseRadius2 * 2);
                graphics.FillEllipse(particleBrushYellow, mainTree.AllParticles[i].CenterPoint.X - ElipseRadius3, mainTree.AllParticles[i].CenterPoint.Y - ElipseRadius3, ElipseRadius3 * 2, ElipseRadius3 * 2);
            }
        }

        private void btn_GenerateParticles_Click(object sender, EventArgs e)
        {
            int particleCount = int.Parse(tb_ParticleCount.Text);
            mainTree.GenerateParticles(particleCount);

            for (int i = 0; i < particleCount; i++)
            {
               graphics.DrawEllipse(particlePen, mainTree.AllParticles[i].CenterPoint.X-ElipseRadius1, mainTree.AllParticles[i].CenterPoint.Y- ElipseRadius1, ElipseRadius1*2, ElipseRadius1 * 2);
               graphics.FillEllipse(particleBrushRed, mainTree.AllParticles[i].CenterPoint.X- ElipseRadius2, mainTree.AllParticles[i].CenterPoint.Y- ElipseRadius2, ElipseRadius2 * 2, ElipseRadius2 * 2);
               graphics.FillEllipse(particleBrushYellow, mainTree.AllParticles[i].CenterPoint.X- ElipseRadius3, mainTree.AllParticles[i].CenterPoint.Y- ElipseRadius3, ElipseRadius3 * 2, ElipseRadius3 * 2);
            }

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            mainTree.ClearParticles();
            graphics.Clear(Color.White);
        }
    }
}
