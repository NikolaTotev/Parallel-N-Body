using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNB_Lib
{
    public enum threadMode
    {
        customThreads,
        tplThreads

    };

    public enum AlgToUse
    {
        PWI, BH
    }


    public class ProgramManager
    {
        public int SimSpaceXLen { get; set; }
        public int SimSpaceYLen { get; set; }
        public QuadTree QuadTree { get; }

        public ProgramManager(int simXLen, int simYLen )
        {
            SimSpaceXLen = simXLen;
            SimSpaceYLen = simYLen;
            QuadTree = new QuadTree();
        }

        
    }
}
