using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Math;

namespace Barnes_Hut_GUI
{
    class QuadTree
    {
        public List<Particle> AllParticles { get; set; }

        public Node RootNode { get; set; }
        private const float G = 9.8f;

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
                currenctGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength, nextNode.SideLength);
                return;
            }

            if (nextNode.nodeParticles.Count == 0)
            {
                currenctGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength, nextNode.SideLength);
                currenctGraphics.FillRectangle(Brushes.IndianRed, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength - 10, nextNode.SideLength - 10);
            }
            else
            {
                currenctGraphics.DrawRectangle(rectPen, nextNode.BottomLeftCorner.X, nextNode.TopRightCorner.Y, nextNode.SideLength, nextNode.SideLength);
            }



            Traverse(nextNode.SeChild, currenctGraphics, rectPen);
            Traverse(nextNode.NeChild, currenctGraphics, rectPen);
            Traverse(nextNode.NwChild, currenctGraphics, rectPen);
            Traverse(nextNode.SwChild, currenctGraphics, rectPen);

        }

        float CalculateForces(float distance, float particleMass, float nodeMass)
        {
            float totalMass = particleMass * nodeMass;
            return G * totalMass/ (float)Math.Pow(distance, 2);
        }

        bool LengthIsOverDouble(float nodeSideLength, float distanceToNode)
        {

            return distanceToNode > nodeSideLength * 2;
        }

        public float CalculateDistanceToNode(Particle targetParticle, Node targetNode)
        {
            float sideA = Math.Abs(targetNode.CenterOfMass.X - targetParticle.CenterPoint.X);
            float sideB = Math.Abs(targetNode.CenterOfMass.Y - targetParticle.CenterPoint.Y);
            float distance = (float)Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return distance;
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
                new Point(91, 395),
                new Point(98, 400),
                new Point(110, 405),
                new Point(114, 395),
                new Point(105, 395)
        };
            for (int i = 0; i < particleCount; i++)
            {
                Particle newParticle = new Particle();
                Point particleCenter = new Point(rand.Next(5, 730), rand.Next(5, 730));
                //newParticle.CenterPoint = testPoints[i];
                newParticle.CenterPoint = particleCenter;
                AllParticles.Add(newParticle);
            }
        }



        public void ClearParticles()
        {
            AllParticles.Clear();
            Point bottomLeft = new Point(0, 737);
            Point topRight = new Point(737, 0);
            RootNode = new Node(topRight, bottomLeft);
            RootNode.IsRoot = true;
        }
    }
}
