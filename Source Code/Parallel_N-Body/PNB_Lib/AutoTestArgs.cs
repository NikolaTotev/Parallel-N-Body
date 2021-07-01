using System;
using System.Collections.Generic;

namespace PNB_Lib
{
    public class AutoTestStepCompleteArgs : EventArgs
    {
        private int m_CurrentThreadCount;
        private int m_TotalThreadCount;
        private TimeSpan m_ElapsedTime;
        private double m_LastThreadExecTime;

        public AutoTestStepCompleteArgs(int currentThreadCount, int totalThreadCount, TimeSpan elapsedTime, double lastExecTime)
        {
            m_CurrentThreadCount = currentThreadCount;
            m_TotalThreadCount = totalThreadCount;
            m_ElapsedTime = elapsedTime;
            m_LastThreadExecTime = lastExecTime;
        }

        public int GetCurrentThreadCount()
        {
            return m_CurrentThreadCount;
        }

        public int GetTotalThreadCount()
        {
            return m_TotalThreadCount;
        }

        public TimeSpan GetElapsedTime()
        {
            return m_ElapsedTime;
        }

        public double GetLastThreadExecTime()
        {
            return m_LastThreadExecTime;
        }
    }


    public class AutoTestCompleteArgs : EventArgs
    {
        private List<double> m_ExecTimes;
        private List<double> m_ParallelismLevels;
        private List<double> m_EffectivenessLevels;
        private int m_ParticleCount;
        private int m_TestNumber;
        

        public AutoTestCompleteArgs(List<double> parallelismLevels, List<double> execTimes, List<double> effectivenessLevels, int particleCount, int testNum)
        {
            m_ParallelismLevels = parallelismLevels;
            m_EffectivenessLevels = effectivenessLevels;
            m_ExecTimes = execTimes;
            m_ParticleCount = particleCount;
            m_TestNumber = testNum;
        }
        public List<double> GetExecTimes()
        {
            return m_ExecTimes;
        }

        public List<double> GetParlLevels()
        {
            return m_ParallelismLevels;
        }

        public List<double> GetEffectivenessLevels()
        {
            return m_EffectivenessLevels;
        }

        public int GetPartCount()
        {
            return m_ParticleCount;
        }

        public int GetTestNumber()
        {
            return m_TestNumber;
        }
    }
}