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
        public float BottomLeftCorner { get; }
        public float RightTopCorner { get; }
        public float TotalMass { get; }
        public Point CenterOfMass { get; }

        public Node SeChild { get; set; }
        public Node NeChild { get; set; }
        public Node NwChild { get; set; }
        public Node SwChild { get; set; }

        public bool IsLeaf { get; }
        public bool IsInternal { get; set; }
        public bool IsRoot { get; set; }

        //Function is called if there is more than 1 child in the node;
        void partitionNode()
        {
            SeChild = new Node();
            NeChild = new Node();
            NwChild = new Node();
            SwChild = new Node();
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
