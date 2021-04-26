using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barnes_Hut_GUI
{
    class Node
    {
        public enum parentQuadrant
        {
            SE, NE, SW, NW
        }
        List<Particle> nodeParticles;
        public Point BottomLeftCorner { get; set; }
        public Point TopRightCorner { get; set; }
        public float TotalMass { get; set; }
        public Point CenterOfMass { get; set; }

        public float SideLength { get; }

        public Node SeChild { get; set; }
        public Node NeChild { get; set; }
        public Node NwChild { get; set; }
        public Node SwChild { get; set; }

        public bool IsLeaf { get; }
        public bool IsInternal { get; set; }
        public bool IsRoot { get; set; }

        public Node(Point trc, Point blc)
        {
            TopRightCorner = trc;
            BottomLeftCorner = blc;
        }

        //Function is called if there is more than 1 child in the node;
        void partitionNode()
        {
            Point SETopRight  = new Point(TopRightCorner.X, TopRightCorner.Y/2);
            Point SEBottomLeft = new Point(TopRightCorner.X/2, BottomLeftCorner.Y);
            SeChild = new Node(SETopRight, SEBottomLeft);

            Point NETopRight = new Point(TopRightCorner.X, TopRightCorner.Y);
            Point NEBottomLeft = new Point(TopRightCorner.X / 2, TopRightCorner.Y/2);
            NeChild = new Node(NETopRight, NEBottomLeft);

            Point NWTopRight = new Point(TopRightCorner.X/2, TopRightCorner.Y);
            Point NWBottomLeft = new Point(BottomLeftCorner.X, TopRightCorner.Y/2);
            NwChild = new Node(NWTopRight, NWBottomLeft);

            Point SWTopRight = new Point(TopRightCorner.X/2, TopRightCorner.Y / 2);
            Point SWBottomLeft = new Point(BottomLeftCorner.X, BottomLeftCorner.Y);
            SwChild = new Node(SWTopRight, SWBottomLeft);
            parentQuadrant firstParticleQuadrant = determineQuadrant(nodeParticles[0]);
            AddParticleToChild(firstParticleQuadrant, nodeParticles[0]);

        }

        public void AddParticleToChild(parentQuadrant quadrant, Particle particle)
        {
            switch (quadrant)
            {
                case parentQuadrant.SE:
                    SeChild.AddParticle(particle);
                    break;
                case parentQuadrant.NE:
                    NeChild.AddParticle(particle);
                    break;
                case parentQuadrant.SW:
                    SwChild.AddParticle(particle);
                    break;
                case parentQuadrant.NW:
                    NwChild.AddParticle(particle);
                    break;
                default:
                    return;
            }
        }

        public void AddParticle(Particle particleToAdd)
        {
            nodeParticles.Add(particleToAdd);

            if (nodeParticles.Count > 1)
            {
                partitionNode();
                IsInternal = true;
            }

            if (IsInternal)
            {
                parentQuadrant particleQuadrant = determineQuadrant(particleToAdd);
                AddParticleToChild(particleQuadrant, particleToAdd);
            }
        }

        parentQuadrant determineQuadrant(Particle particle)
        {
            parentQuadrant quadrant = parentQuadrant.SE;

            return quadrant;
        }

    }
}
