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

        public List<Particle> nodeParticles { get; set; }
        public PointF BottomLeftCorner { get; set; }
        public PointF TopRightCorner { get; set; }
        public float TotalMass { get; set; }

        public float SideLength { get; }

        public Node SeChild { get; set; }
        public Node NeChild { get; set; }
        public Node NwChild { get; set; }
        public Node SwChild { get; set; }

        public bool IsLeaf { get; set; }
        public bool IsInternal { get; set; }
        public bool IsRoot { get; set; }

        public bool IsPartitioned { get; set; }

        public PointF centerOfMass { get; set; }

        public float totalWeight = 0;

        public float topCenterOfMassCoefX = 0;
        public float topCenterOfMassCoefY = 0;

        public Node(PointF trc, PointF blc)
        {
            TopRightCorner = trc;
            BottomLeftCorner = blc;
            SideLength = TopRightCorner.X - BottomLeftCorner.X;
            nodeParticles = new List<Particle>();
            IsInternal = false;
            IsLeaf = true;
        }


        //Function is called if there is more than 1 child in the node;
        void partitionNode()
        {
            double halfOfSideLength = SideLength / 2;
            PointF SETopRight = new PointF(TopRightCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            PointF SEBottomLeft = new PointF((int)halfOfSideLength + BottomLeftCorner.X, BottomLeftCorner.Y);
            SeChild = new Node(SETopRight, SEBottomLeft);

            PointF NETopRight = new PointF(TopRightCorner.X, TopRightCorner.Y);
            PointF NEBottomLeft = new PointF((int)halfOfSideLength + BottomLeftCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            NeChild = new Node(NETopRight, NEBottomLeft);

            PointF NWTopRight = new PointF((int)halfOfSideLength + BottomLeftCorner.X, TopRightCorner.Y);
            PointF NWBottomLeft = new PointF(BottomLeftCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            NwChild = new Node(NWTopRight, NWBottomLeft);

            PointF SWTopRight = new PointF((int)halfOfSideLength + BottomLeftCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            PointF SWBottomLeft = new PointF(BottomLeftCorner.X, BottomLeftCorner.Y);
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
            CalculateCenterOfMass(particleToAdd);

            if (nodeParticles.Count > 1 && !IsPartitioned)
            {
                partitionNode();
                IsInternal = true;
                IsLeaf = false;
                IsPartitioned = true;
            }
         

            if (IsInternal && IsPartitioned)
            {
                parentQuadrant particleQuadrant = determineQuadrant(particleToAdd);
                AddParticleToChild(particleQuadrant, particleToAdd);
            }
        }

        public void CalculateCenterOfMass(Particle newParticle)
        {
            totalWeight += newParticle.Mass;
            topCenterOfMassCoefX += (newParticle.CenterPoint.X * newParticle.Mass);
            topCenterOfMassCoefX += (newParticle.CenterPoint.Y * newParticle.Mass);

            double xCOM = topCenterOfMassCoefX / totalWeight;
            double yCOM = topCenterOfMassCoefY / totalWeight;

            centerOfMass= new Point((int)xCOM, (int)yCOM);

        }

        parentQuadrant determineQuadrant(Particle particle)
        {
            parentQuadrant quadrant = parentQuadrant.SE;

            float halfOfSide = SideLength / 2;
            float xMiddle = BottomLeftCorner.X + halfOfSide;
            float yMiddle = TopRightCorner.Y +  halfOfSide;

            if (particle.CenterPoint.X >= xMiddle)
            {
                //if (xMiddle - particle.CenterPoint.X <= 3)
                //{
                //    particle.CenterPoint = new Point(particle.CenterPoint.X + 3, particle.CenterPoint.Y);
                //}

                if (particle.CenterPoint.Y <= yMiddle)
                {
                    quadrant = parentQuadrant.NE;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X - 3, particle.CenterPoint.Y);
                    //}
                }

                if (particle.CenterPoint.Y > yMiddle)
                {
                    quadrant = parentQuadrant.SE;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X + 3, particle.CenterPoint.Y);
                    //}
                }

               
            }

            if (particle.CenterPoint.X < xMiddle)
            {
                //if (xMiddle - particle.CenterPoint.X <= 3)
                //{
                //    particle.CenterPoint = new Point(particle.CenterPoint.X - 3, particle.CenterPoint.Y);
                //}

                if (particle.CenterPoint.Y <= yMiddle)
                {
                    quadrant = parentQuadrant.NW;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X - 3, particle.CenterPoint.Y);
                    //}
                }

                if (particle.CenterPoint.Y > yMiddle)
                {
                    quadrant = parentQuadrant.SW;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X + 3, particle.CenterPoint.Y);
                    //}
                }
            }
            return quadrant;
        }

    }
}
