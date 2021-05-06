using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barnes_Hut_GUI
{
    class Particle
    {
        public PointF CenterPoint { get; set; }
        public float Mass { get; set; }
        public Color ParticleColor { get; }
        public List<ForceVector> ForcesToApply { get; set; }
        public float MaxForce { get; set; }
        public float MinForce { get; set; }
        public float MidForce { get; set; }

        private bool initialMinMaxNotSet = true;


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

            ForcesToApply.Add(currentVector);
        }

        public void CalculateResultantForce()
        {
            ForceVector resultantForceVector = new ForceVector();
            resultantForceVector.Start = ForcesToApply[0].Start;


            PointF currentVectorEndpoint = new Point();
            PointF currentStartPoint = ForcesToApply[0].End;

            for (int i = 1; i < ForcesToApply.Count; i++)
            {
                currentVectorEndpoint.X = currentStartPoint.X + (int)ForcesToApply[i].xLen * ForcesToApply[i].DirectionHorizontal;
                currentVectorEndpoint.Y = currentStartPoint.Y + (int)ForcesToApply[i].yLen * ForcesToApply[i].DirectionVertical;
                currentStartPoint = currentVectorEndpoint;
            }

            resultantForceVector.End = currentVectorEndpoint;
        }
    }
}
