using System;

namespace PNB_Lib
{
    public class SimFrameCompleteArgs : EventArgs
    {
        private TimeSpan m_ExecTime;
        private int m_FrameNumber;

        public SimFrameCompleteArgs(TimeSpan execTime, int frameNumber)
        {
            m_ExecTime = execTime;
            m_FrameNumber = frameNumber;
        }

        public TimeSpan GetExecTime()
        {
            return m_ExecTime;
        }

        public int GetFrameNumber()
        {
            return m_FrameNumber;
        }
    }
}