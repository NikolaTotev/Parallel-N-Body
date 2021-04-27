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
            Point bottomLeft = new Point(0, 737);
            Point topRight = new Point(737, 0);
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
                currenctGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.TopRightCorner.X - nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y - nextNode.BottomLeftCorner.Y);
                return;
            }

            currenctGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.TopRightCorner.X - nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y - nextNode.BottomLeftCorner.Y);

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

            List<Point> testPoints = new List<Point>()
            {
                new Point(91, 398),
                new Point(620, 337),
                new Point(493, 502),
                new Point(590, 600),
                new Point(291, 21)
        };
            for (int i = 0; i < particleCount; i++)
            {
                Particle newParticle = new Particle();
                //Point particleCenter = new Point(rand.Next(0, 738), rand.Next(0, 738));
                newParticle.CenterPoint = testPoints[i];
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
