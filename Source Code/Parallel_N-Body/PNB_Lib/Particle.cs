using System;
using System.Collections.Generic;
using System.Drawing;

namespace PNB_Lib
{
    public class Particle
    {

        public PointF CenterPoint { get; set; }
        public PointF OldCenterPoint { get; set; }

        public PointF Velocity = new PointF(0, 0);

        public PointF AccelerationComponents = new PointF(0f, 0f);
        public PointF VelocityComponents = new PointF(0, 0);

        private float time = 0;
        public Color particleColor;

        public float Mass { get; set; }

        public Color ParticleColor { get; }

        private readonly object accelLock = new object();


        public Particle()
        {
        
            Mass = 1000;
        }

        public void ApplyAcceleration(float valueX, float valueY)
        {
            lock (accelLock)
            {
                AccelerationComponents.X += valueX;
                AccelerationComponents.Y += valueY;
            }
        }

    }
}