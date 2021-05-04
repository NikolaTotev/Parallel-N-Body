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
        public Point Start { get; set; }
        public Point End { get; set;  }
        public float Magnitude { get; set; }
        public int Angle { get; set; }

        public float xLen { get; set; }
        public float yLen { get; set; }

        // + Positive, - Negative
        public int DirectionHorizontal { get; set; }

        public int DirectionVertical { get; set; }

    }
}
