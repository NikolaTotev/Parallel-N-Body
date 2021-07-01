using System.Security.Permissions;

namespace PNB_Lib
{
    public class TestResult
    {
        public int TestNumber { get; set; }
        public int ThreadCount { get; set; }
        public ThreadMode tC { get; set; }
        public int ParticleCount { get; set; }
        public int RepeatFactor { get; set; }
        public double T11 { get; set; }
        public double T12 { get; set; }
        public double T13 { get; set; }
        public double T1min { get; set; }
        public double TP1 { get; set; }
        public double TP2 { get; set; }
        public double TP3 { get; set; }
        public double TPmin { get; set; }
        public double Sp { get; set; }
        public double Ep { get; set; }

    }
}