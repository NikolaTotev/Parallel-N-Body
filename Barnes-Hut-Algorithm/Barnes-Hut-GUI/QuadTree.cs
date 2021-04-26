using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barnes_Hut_GUI
{
    class QuadTree
    {
        public List<Particle> AllParticles { get; set; }

        public Node RootNode { get; }

        public QuadTree()
        {
            RootNode = new Node();
            RootNode.IsRoot = true;

        }

        public void ParitionSpace()
        {
            foreach (Particle particle in AllParticles)
            {
                RootNode.AddParticle(particle);
            }
        }
        
    }
}
