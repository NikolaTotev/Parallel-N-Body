using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace PNB_Lib
{
    public class TestResult
    {
        public int TestNumber { get; set; }
        public int ThreadCount { get; set; }
        public ThreadMode tC { get; set; }
        public InteractionAlgorithm alg { get; set; }
        public double Theta { get; set; }
        public int ParticleCount { get; set; }
        public int RepeatFactor { get; set; }
        public List<double> execTimes { get; set; }
        public List<double> Sp { get; set; }
        public List<double> Ep { get; set; }

        public string etStr { get; set; }
        public string spStr { get; set; }
        public string epStr { get; set; }

        public TestResult(int testNumber, int threadCount, ThreadMode tC, int particleCount, int repeatFactor, List<double> execTimes, List<double> sp, List<double> ep, InteractionAlgorithm interactionAlg, double theta)
        {
            TestNumber = testNumber;
            ThreadCount = threadCount;
            this.tC = tC;
            ParticleCount = particleCount;
            RepeatFactor = repeatFactor;
            this.execTimes = execTimes;
            Sp = sp;
            Ep = ep;

            Theta = theta;
            alg = interactionAlg;

            StringBuilder etBuilder = new StringBuilder();
            StringBuilder spBuilder = new StringBuilder();
            StringBuilder epBuilder = new StringBuilder();
            etBuilder.Append("ExecTimes:");
            spBuilder.Append("ParlLevels:");
            epBuilder.Append("EffLevels:");
            for (int i = 0; i < execTimes.Count; i++)
            {
                etBuilder.Append($"{i + 1} {execTimes[i]} \n");
                spBuilder.Append($"{i + 1} {Sp[i]} \n");
                epBuilder.Append($"{i + 1} {Ep[i]} \n");
            }

            etStr = etBuilder.ToString();
            spStr = spBuilder.ToString();
            epStr = epBuilder.ToString();
        }



    }
}