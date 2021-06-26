using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Math;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PNB_Lib
{
    public class QuadTree
    {

        private List<Particle> m_Particles;
        private int m_SimSpaceXLen;
        private int m_SimSpaceYLen;
        private Node m_RootNode;
        private bool[,] m_ParticleMap;
        private float m_Theta = 2f;
        private float m_G = (float)(6.67408 * Pow(10, -7));
        private float m_Softening = 0.8f;
        private Stopwatch m_Sw;
        private float m_Dt = 0.5f;
        private float time = 0;
        private float m_Boost = 3000;

        public QuadTree(int simSpaceX, int simSpaceY)
        {
            m_Particles = new List<Particle>();
            m_SimSpaceXLen = simSpaceX;
            m_SimSpaceYLen = simSpaceY;
            m_ParticleMap = new bool[m_SimSpaceXLen,m_SimSpaceYLen];
            m_Sw = new Stopwatch();
        }


        public void Simulate(int framesToSimulate)
        {

        }


        public void FirstSimulationStep(Particle currentParticle)
        {
            currentParticle.VelocityComponents.X += m_Boost* currentParticle.AccelerationComponents.X * m_Dt/ 2;
            currentParticle.VelocityComponents.Y += m_Boost * currentParticle.AccelerationComponents.Y * m_Dt / 2;

            PointF newCenter = currentParticle.CenterPoint;

            newCenter.X += currentParticle.VelocityComponents.X * m_Dt;
            newCenter.Y += currentParticle.VelocityComponents.Y * m_Dt;
            
            currentParticle.CenterPoint = newCenter;

            if (currentParticle.CenterPoint.X > m_SimSpaceXLen)
            {
                currentParticle.VelocityComponents.X = -currentParticle.VelocityComponents.X;
            }
            else if (currentParticle.CenterPoint.X < 0)
            {
                currentParticle.VelocityComponents.X = -currentParticle.VelocityComponents.X;
            }

            if (currentParticle.CenterPoint.Y > m_SimSpaceYLen)
            {
                currentParticle.VelocityComponents.Y = -currentParticle.VelocityComponents.Y;
            }
            else if (currentParticle.CenterPoint.Y < 0)
            {
                currentParticle.VelocityComponents.Y = -currentParticle.VelocityComponents.Y;
            }
        }

        public void SecondSimulationStep(Particle currentParticle)
        {
            currentParticle.VelocityComponents.X += m_Boost * currentParticle.AccelerationComponents.X * m_Dt / 2;
            currentParticle.VelocityComponents.Y += m_Boost * currentParticle.AccelerationComponents.Y * m_Dt/ 2;
        }

        public TimeSpan PairwiseForceCalculation(bool isParalell, int threadCount = 1)
        {
            float diffX = 0;
            float diffY = 0;
            float inv_r2 = 0;

            foreach (Particle currentParticle in m_Particles)
            {
                currentParticle.AccelerationComponents.X = 0;
                currentParticle.AccelerationComponents.Y = 0;
            }

            switch (isParalell)
            {
                case true:
                    m_Sw.Reset();
                    m_Sw.Start();
                    Parallel.ForEach(m_Particles, new ParallelOptions { MaxDegreeOfParallelism = threadCount },
                        currentParticle =>
                        {
                            for (int j = 0; j < m_Particles.Count; j++)
                            {
                                if (m_Particles[j] != currentParticle)
                                {
                                    ParticleToParticleForceCalculation(currentParticle, m_Particles[j]);
                                }
                            }
                        });
                    m_Sw.Stop();
                    break;
                case false:
                    m_Sw.Reset();
                    m_Sw.Start();
                    foreach (Particle currentParticle in m_Particles)
                    {
                        currentParticle.AccelerationComponents.X = 0;
                        currentParticle.AccelerationComponents.Y = 0;

                        for (int j = 0; j < m_Particles.Count; j++)
                        {
                            if (m_Particles[j] != currentParticle)
                            {
                                ParticleToParticleForceCalculation(currentParticle, m_Particles[j]);
                            }

                        }
                    }
                    m_Sw.Stop();
                    break;
            }

            return m_Sw.Elapsed;
        }

        public void BarnesHutForceCalculation()
        {
            //TODO Implement BH Force Calculation Function
        }

        public void ParticleToParticleForceCalculation(Particle targetParticle, Particle effector)
        {
            List<float> distanceInfo =
                CalculateDistanceBetweenPoints(targetParticle.CenterPoint, effector.CenterPoint);
   
            float diffXT = distanceInfo[3]; // AllParticles[j].CenterPoint.X - currentParticle.CenterPoint.X;
            float diffYT = distanceInfo[4]; // AllParticles[j].CenterPoint.Y - currentParticle.CenterPoint.Y;

            float inv_r2t = (float)Pow((Pow(diffXT, 2) + Pow(diffYT, 2) + Pow(m_Softening, 2)), -1.5);

            float xVal = m_G * (diffXT * inv_r2t) * effector.Mass;
            float yVal = m_G * (diffYT * inv_r2t) * effector.Mass;
            targetParticle.ApplyAcceleration(xVal, yVal);
        }

        public void ParticleToNodeForceCalculation(Particle currentParticle, Node currentNode)
        {
            //TODO Implement Particle -> Node interaction
        }
        

        public List<float> CalculateDistanceBetweenPoints(PointF firstPoint, PointF secondPoint)
        {
            float diffX = firstPoint.X - secondPoint.X; //equiv of diffX
            float diffY = firstPoint.Y - secondPoint.Y; //equiv of diffY
            float distance = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            float angleSin = diffY / distance;
            float angleCos = diffX / distance;
            return new List<float>() { distance, angleSin, angleCos, diffX, diffY };
        }

        /// <summary>
        /// Calculate the gravitational forces on a particle based on the particle mass, the node its interacting with and the distance between them.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="particleMass"></param>
        /// <param name="nodeMass"></param>
        /// <returns></returns>
        float GravitationalForceCalculation(float distance, float particleMass, float nodeMass)
        {
            float totalMass = particleMass * nodeMass;
            return m_G * totalMass / (float)Math.Pow(distance, 2);
        }


        public bool IsDistanceOverDoubleSideLenght(float nodeSideLength, float distanceToNode)
        {
            return distanceToNode > nodeSideLength * m_Theta;
        }


        public void ResetTree()
        {
            m_Particles.Clear();
            ResetRootNode();
        }

        public void ResetRootNode()
        {
            m_RootNode = null;
            PointF bottomLeft = new Point(0, 737);
            PointF topRight = new Point(737, 0);
            m_RootNode = new Node(topRight, bottomLeft);
            m_RootNode.IsRoot = true;
        }
        
        
    }
}