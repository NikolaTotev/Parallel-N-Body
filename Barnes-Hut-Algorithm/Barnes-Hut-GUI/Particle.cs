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
        public Point CenterPoint { get; set; }
        public float Mass { get; }
        public Color ParticleColor { get; }
        public List<ForceVector> ForcesToApply { get; set; }

        public Particle()
        {
            ForcesToApply = new List<ForceVector>();
        }

        public void AddForce(ForceVector force)
        {
            ForceVector currentVector = new ForceVector();
            currentVector = force;
            ForcesToApply.Add(currentVector);
        }

        public void CalculateResultantForce()
        {
            ForceVector resultantForceVector = new ForceVector();
            resultantForceVector.Start = ForcesToApply[0].Start;


            Point currentVectorEndpoint = new Point();
            Point currentStartPoint = ForcesToApply[0].End;

            for (int i = 1; i < ForcesToApply.Count; i++)
            {
                currentVectorEndpoint.X = currentStartPoint.X + (int)ForcesToApply[i].xLen*ForcesToApply[i].DirectionHorizontal;
                currentVectorEndpoint.Y = currentStartPoint.Y + (int)ForcesToApply[i].yLen*ForcesToApply[i].DirectionVertical;
                currentStartPoint = currentVectorEndpoint;
            }

            resultantForceVector.End = currentVectorEndpoint;
        }
    }
}
