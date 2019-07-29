namespace Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    internal class PerfomanceTest : IDisposable
    {
        private Stopwatch time;
        private int collectCount;
        private string text;

        public PerfomanceTest(string text)
        {
            this.text = text;
            Prepare();
            this.collectCount = GC.CollectionCount(0);

            this.time = Stopwatch.StartNew();
        }
    
        void IDisposable.Dispose()
        {
        }

        public TimeSpan TimerStop()
        {
            this.time.Stop();
            return this.time.Elapsed;
        }

        private static void Prepare()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
