using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Barnes_Hut_GUI
{
    enum AlgToUse
    {
        BH, PWI, PBH
    }

    class QuadTree
    {
        public List<Particle> AllParticles { get; set; }

        public Node RootNode { get; set; }
        private const float G = 9.8f;
        public float theta = 0.5f;

        public bool ShowTree { get; set; }
        public bool ShowEmptyCells { get; set; }
        public bool ShowForceVect { get; set; }

        public bool ShowGrouping { get; set; }
        public AlgToUse alg { get; set; }




        public QuadTree()
        {
            PointF bottomLeft = new Point(0, 737);
            PointF topRight = new Point(737, 0);
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

        public void PairWiseForceCalculation()
        {
            if (AllParticles.Count > 100)
            {
                return;
            }

            for (int i = 0; i < AllParticles.Count; i++)
            {
                for (int j = 0; j < AllParticles.Count; j++)
                {
                    if (j != i)
                    {
                        List<float> distanceInfo = CalculateDistanceToNode(AllParticles[i], AllParticles[j].CenterPoint);
                        float forceVecMag = CalculateForces(distanceInfo[0], AllParticles[i].Mass, AllParticles[j].Mass);
                        AllParticles[i].AddForce(new ForceVector(AllParticles[i].CenterPoint, AllParticles[j].CenterPoint, forceVecMag, distanceInfo[1], distanceInfo[2]));
                    }
                }
            }
        }

        public void VisualizeForceVectors(int particleNumber, Graphics currenctGraphics, Pen minPen, Pen midPen, Pen maxPen)
        {

            for (int i = 0; i < AllParticles[particleNumber].ForcesToApply.Count; i++)
            {
                float forceVecMag = AllParticles[particleNumber].ForcesToApply[i].Magnitude;
                PointF forceVectStart = AllParticles[particleNumber].ForcesToApply[i].Start;
                PointF forceVectEnd = AllParticles[particleNumber].ForcesToApply[i].End;

                if (forceVecMag == AllParticles[particleNumber].MinForce)
                {
                    currenctGraphics.DrawLine(minPen, forceVectStart, forceVectEnd);
                }
                else if (forceVecMag == AllParticles[particleNumber].MaxForce)
                {
                    currenctGraphics.DrawLine(maxPen, forceVectStart, forceVectEnd);
                }
                else { currenctGraphics.DrawLine(midPen, forceVectStart, forceVectEnd); }
            }
        }

        public void BHAlg()
        {
            foreach (Particle particle in AllParticles)
            {
                ForceTraversal(particle, RootNode);
            }
        }

        public void SingleBHStep(int targetParticle)
        {
            ForceTraversal(AllParticles[targetParticle], RootNode);
        }

        public void ForceTraversal(Particle currentParticle, Node startNode)
        {
            List<float> distanceToNodeInfo = new List<float>();

            if (startNode.nodeParticles.Count == 1)
            {
                distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.nodeParticles[0].CenterPoint);
            }
            else
            {
                distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.centerOfMass);
            }

            //if (startNode.IsLeaf)
            //{
            //    distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.nodeParticles[0].CenterPoint);

            //}
            //else
            //{
            //    distanceToNodeInfo = CalculateDistanceToNode(currentParticle, startNode.centerOfMass);
            //}


            if (LengthIsOverDouble(startNode.SideLength, distanceToNodeInfo[0]) || startNode.nodeParticles.Count == 1)
            {

                float force = CalculateForces(distanceToNodeInfo[0], currentParticle.Mass, startNode.TotalMass);
                ForceVector forceVect = new ForceVector(currentParticle.CenterPoint,startNode.centerOfMass ,mag: distanceToNodeInfo[0], sinAng: distanceToNodeInfo[1], cosAng: distanceToNodeInfo[2]);
                if (startNode.nodeParticles.Count == 1)
                { 
                    forceVect = new ForceVector(currentParticle.CenterPoint, startNode.nodeParticles[0].CenterPoint, mag: distanceToNodeInfo[0], sinAng: distanceToNodeInfo[1], cosAng: distanceToNodeInfo[2]);
                } 
                currentParticle.ForcesToApply.Add(forceVect);
            }
            else
            {
                ForceTraversal(currentParticle, startNode.SeChild);
                ForceTraversal(currentParticle, startNode.NeChild);
                ForceTraversal(currentParticle, startNode.NwChild);
                ForceTraversal(currentParticle, startNode.SwChild);
            }
        }

        float CalculateForces(float distance, float particleMass, float nodeMass)
        {
            float totalMass = particleMass * nodeMass;
            return G * totalMass / (float)Math.Pow(distance, 2);
        }

        bool LengthIsOverDouble(float nodeSideLength, float distanceToNode)
        {

            return distanceToNode * theta < nodeSideLength;
        }

        public List<float> CalculateDistanceToNode(Particle targetParticle, PointF targetPoint)
        {
            float sideA = targetPoint.X - targetParticle.CenterPoint.X;
            float sideB = targetPoint.Y - targetParticle.CenterPoint.Y;
            float distance = (float)Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            float angleSin = sideB / distance;
            float angleCos = sideA / distance;
            return new List<float>() { distance, angleSin, angleCos };
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
