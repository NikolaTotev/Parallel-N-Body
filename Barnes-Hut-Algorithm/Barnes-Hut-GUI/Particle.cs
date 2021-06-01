using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barnes_Hut_GUI
{
    class Particle
    {
        public PointF CenterPoint { get; set; }
        public PointF OldCenterPoint { get; set; }
        public PointF AccelerationComponents { get; set; }
        public PointF Velocity = new PointF(0, 0);
        public int SimHeight = 737;
        public int SimWidth = 737;
        private int time = 0;

        public float Mass { get; set; }
        public Color ParticleColor { get; }
        public List<ForceVector> ForcesToApply { get; set; }
        public float MaxForce { get; set; }
        public float MinForce { get; set; }
        public float MidForce { get; set; }

        private bool initialMinMaxNotSet = true;

        private readonly object listLock = new object();

        public PointF ResultantVectorStart { get; set; }
        public PointF ResultantVectorEnd { get; set; }
        public PointF AcceleratioNVectorStart;
        public PointF AcceleratioNVectorEnd;

        public Particle()
        {
            ForcesToApply = new List<ForceVector>();
            Mass = 1000;
        }

        public void AddForce(ForceVector force)
        {
            ForceVector currentVector = new ForceVector();
            currentVector = force;

            if (initialMinMaxNotSet)
            {
                MaxForce = force.Magnitude;
                MinForce = force.Magnitude;
                initialMinMaxNotSet = false;
            }
            else
            {
                if (force.Magnitude > MaxForce)
                {
                    MaxForce = force.Magnitude;
                }

                if (force.Magnitude < MinForce)
                {
                    MinForce = force.Magnitude;
                }

                MidForce = (MaxForce - MinForce) / 2;
            }

            //lock (listLock)
            //{
            ForcesToApply.Add(currentVector);
            //}

        }

        public void CalculateResultantForce()
        {
            PointF resultantVectorStart = CenterPoint;
            PointF resultantVectorEnd = CenterPoint;

            foreach (ForceVector forceVector in ForcesToApply)
            {
                forceVector.ShiftEndPoint(resultantVectorEnd);
                resultantVectorEnd = forceVector.ShiftedEnd;
            }

            ResultantVectorStart = resultantVectorStart;
            ResultantVectorEnd = resultantVectorEnd;
        }

        public void GetAccelerationVector()
        {
            float xLen = Math.Abs(ResultantVectorStart.X - ResultantVectorEnd.X);
            float yLen = Math.Abs(ResultantVectorStart.Y - ResultantVectorEnd.Y);

            float xAccel = xLen / Mass;
            float yAccel = yLen / Mass;
            AccelerationComponents = new PointF(xAccel * 10, yAccel * 10f);
        }

        public void MoveParticle()
        {
            OldCenterPoint = CenterPoint;
            GetAccelerationVector();
            time += 1;
            PointF currentCenterPoint = CenterPoint;
            float forceX = (float)(Math.Abs(Velocity.X) * 1 + 0.5 * Math.Abs(AccelerationComponents.X) * 1 * 1);
            float forceY = (float)(Math.Abs(Velocity.Y) * 1 + 0.5 * Math.Abs(AccelerationComponents.Y) * 1 * 1);
            float newCenterX = 0;
            float newCenterY = 0;

            bool negativeX = ResultantVectorEnd.X < ResultantVectorStart.X;
            bool negativeY = ResultantVectorEnd.Y < ResultantVectorStart.Y;

            if (negativeX)
            {
                newCenterX = currentCenterPoint.X - forceX;
                Velocity.X = -AccelerationComponents.X * 1;
            }
            else
            {
                newCenterX = currentCenterPoint.X + forceX;
                Velocity.X = AccelerationComponents.X * 1;
            }

            if (negativeY)
            {
                newCenterY = currentCenterPoint.Y - forceY;
                Velocity.Y = -AccelerationComponents.Y * 1;
            }
            else
            {
                newCenterY = currentCenterPoint.Y + forceY;
                Velocity.Y = AccelerationComponents.Y * 1;
            }

            // Debug.Print($"Velocity: {vel.ToString()} | Acceleration: {simParticle.AccelerationComponents.ToString()} ");




            //if (newCenterX >SimWidth)
            //{
            //    newCenterX = SimWidth;
            //}
            //else if (newCenterX < 0)
            //{
            //    newCenterX = 0;
            //}

            //if (newCenterY > SimHeight)
            //{
            //    newCenterY = SimHeight;
            //}
            //else if (newCenterY < 0)
            //{
            //    newCenterY = 0;
            //}



            CenterPoint = new PointF(newCenterX, newCenterY);


            //if (accelEndX > SimWidth)
            //{
            //    accelEndX = SimWidth - (accelEndX - SimWidth);
            //    Velocity.X = -Velocity.X;
            //}
            //else if (accelEndX < 0)
            //{
            //    accelEndX = Math.Abs(accelEndX);
            //    Velocity.X = -Velocity.X;
            //}

            //if (accelEndY > SimHeight)
            //{
            //    accelEndY = SimHeight - (accelEndY - SimHeight);
            //    Velocity.Y = -Velocity.Y;
            //}
            //else if (accelEndY < 0)
            //{
            //    accelEndY = Math.Abs(accelEndY);
            //    Velocity.Y = -Velocity.Y;
            //}


            //AcceleratioNVectorEnd = new PointF(accelEndX, accelEndY);

            //simParticle.ResultantVectorStart = simVector.Start;
            //simParticle.ResultantVectorEnd = simVector.End;


            Debug.Print($"ForceX: {forceX} || ForceY: {forceY}");
            //Debug.Print($"Center: {simParticle.CenterPoint.ToString()} | Vel: {vel.ToString()} | SimVectEnd: {simVector.Start.ToString()} -> {simVector.End.ToString()}");



            /*
             *
             *function velocity_verlet(pos::Float64, acc::Float64, dt::Float64)
                prev_pos = pos
                time = 0.0
                vel = 0.0

                while (pos > 0.0)
                    time += dt
                    pos += vel * dt + 0.5 * acc * dt * dt;
                    vel += acc * dt;
                end

                return time, vel
                end
             *
            */ //

            ForcesToApply.Clear();


        }
    }
}
