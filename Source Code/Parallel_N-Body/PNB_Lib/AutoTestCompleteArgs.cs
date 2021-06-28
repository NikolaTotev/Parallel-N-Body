using System.Collections.Generic;

namespace PNB_Lib
{
    public class AutoTestCompleteArgs
    {
        private List<double> m_ParallelismLevels;
        private List<double> m_ExecTimes;

        public AutoTestCompleteArgs(List<double> parallelismLevels, List<double>execTimes)
        {
            m_ParallelismLevels = parallelismLevels;
            m_ExecTimes = execTimes;
        }

        public List<double> GetParlLevels()
        {
            return m_ParallelismLevels;
        }

        public List<double> GetExecTimes()
        {
            return m_ExecTimes;
        }
    }
}