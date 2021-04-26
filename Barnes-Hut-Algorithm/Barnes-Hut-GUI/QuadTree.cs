using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barnes_Hut_GUI
{
    class QuadTree
    {
        public List<Particle> AllParticles { get; set; }

        public Node RootNode { get; set; }

        public QuadTree()
        {
            Point bottomLeft = new Point(0, 0);
            Point topRight = new Point(737, 737);
            RootNode = new Node(topRight, bottomLeft);
            RootNode.IsRoot = true;
            AllParticles = new List<Particle>();

        }


        public void Traverse(Node nextNode, Graphics currenctGraphics, Pen rectPen)
        {
            if (nextNode == null)
            {
                return;
            }

            if (nextNode.IsLeaf)
            {
                return;
            }
            else
            {
                currenctGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.TopRightCorner.X - nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y - nextNode.BottomLeftCorner.Y);
            }

            currenctGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.TopRightCorner.X-nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y - nextNode.BottomLeftCorner.Y);

            Traverse(nextNode.SeChild, currenctGraphics, rectPen);
            Traverse(nextNode.NeChild, currenctGraphics, rectPen);
            Traverse(nextNode.NwChild, currenctGraphics, rectPen);
            Traverse(nextNode.SwChild, currenctGraphics, rectPen);
        }


        public void ParitionSpace()
        {
            foreach (Particle particle in AllParticles)
            {
                RootNode.AddParticle(particle);
            }
        }

        public void GenerateParticles(int particleCount)
        {
            Random rand = new Random();
            for (int i = 0; i < particleCount; i++)
            {
                Particle newParticle = new Particle();
                Point particleCenter = new Point(rand.Next(0, 738), rand.Next(0, 738));
                newParticle.CenterPoint = particleCenter;
                AllParticles.Add(newParticle);
            }
        }



        public void ClearParticles()
        {
            AllParticles.Clear();
            Point bottomLeft = new Point(0, 0);
            Point topRight = new Point(737, 737);
            RootNode = new Node(topRight, bottomLeft);
            RootNode.IsRoot = true;
        }
    }
}
