using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barnes_Hut_GUI
{
    class ForceVector
    {
        public PointF Start { get; set; }
        public PointF End { get; set;  }
        public PointF EffectorCOM { get; set;  }
        public float Magnitude { get; set; }
        public float sinAngle { get; set; }
        public float cosAngle { get; set; }

        public float xLen { get; set; }
        public float yLen { get; set; }

        // + Positive, - Negative
        public int DirectionHorizontal { get; set; }

        public int DirectionVertical { get; set; }
        public ForceVector(PointF sPoint = default, PointF effector = default, float mag = 0, float sinAng = 0, float cosAng = 0)

        {
            Start = sPoint;
            Magnitude = mag;
            sinAngle = sinAng;
            cosAngle = cosAng;
            EffectorCOM = effector;
            calculateEndPoint();
            calculateDirections();

        }

        void calculateDirections()
        {

        }

        void calculateEndPoint()
        {
            xLen = cosAngle * Magnitude;
            yLen = sinAngle * Magnitude;
            End = new PointF(Start.X+xLen, Start.Y+yLen);
        }
    }
}
