namespace Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class TestDelegates
    {
        private const int ConstPassCount = 10;

        private readonly List<int> sample;
        private readonly Random rnd;

        public TestDelegates()
        {
            this.rnd = new Random();
            this.sample = new List<int>(10000);
            for (int i = 0; i < this.sample.Capacity; i++)
            {
                this.sample.Add(this.rnd.Next(-99, 100));
            }
        }

        public void StartTests()
        {
            TimeSpan[] timeDirect = new TimeSpan[ConstPassCount];

            for (int i = 0; i < ConstPassCount; i++)
            {
                List<int> currentSample = new List<int>(this.sample);
                using (var pfsTest = new PerfomanceTest("Direct method"))
                {
                    this.FindPositive(currentSample);
                    timeDirect[i] = pfsTest.TimerStop();
                }
            }

            Console.WriteLine("Direct method median time: {0}", this.GetMedian(timeDirect));

            for (int i = 0; i < ConstPassCount; i++)
            {
                List<int> currentSample = new List<int>(this.sample);
                using (var pfsTest = new PerfomanceTest("Using delegate method"))
                {
                    this.FindPositiveDelegate(currentSample, this.Selector);
                    timeDirect[i] = pfsTest.TimerStop();
                }
            }

            Console.WriteLine("Using delegate method median time: {0}", this.GetMedian(timeDirect));

            for (int i = 0; i < ConstPassCount; i++)
            {
                List<int> currentSample = new List<int>(this.sample);
                using (var pfsTest = new PerfomanceTest("Anonym method"))
                {
                    this.FindPositiveDelegate(currentSample, delegate(int item) { return item > 0; });
                    timeDirect[i] = pfsTest.TimerStop();
                }
            }

            Console.WriteLine("Using anonym method median time: {0}", this.GetMedian(timeDirect));

            for (int i = 0; i < ConstPassCount; i++)
            {
                List<int> currentSample = new List<int>(this.sample);
                using (var pfsTest = new PerfomanceTest("Lambda method"))
                {
                    this.FindPositiveDelegate(currentSample, item => item > 0);
                    timeDirect[i] = pfsTest.TimerStop();
                }
            }

            Console.WriteLine("Using lambda method median time: {0}", this.GetMedian(timeDirect));

            for (int i = 0; i < ConstPassCount; i++)
            {
                List<int> currentSample = new List<int>(this.sample);
                using (var pfsTest = new PerfomanceTest("LINQ"))
                {
                    this.FindPositiveLINQ(currentSample);
                    timeDirect[i] = pfsTest.TimerStop();
                }
            }

            Console.WriteLine("Using LINQ median time: {0}", this.GetMedian(timeDirect));
        }

        private bool Selector(int item)
        {
            return item > 0;
        }

        private T GetMedian<T>(T[] times)
        {
            Array.Sort(times);
            return times[times.Length / 2];
        }

        private void FindPositive(List<int> arr)
        {
            List<int> result = new List<int>();
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    result.Add(item);
                }
            }
        }

        private void FindPositiveDelegate(List<int> arr, Predicate<int> statement)
        {
            List<int> result = new List<int>();
            foreach (var item in arr)
            {
                if (statement(item))
                {
                    result.Add(item);
                }
            }
        }

        private void FindPositiveLINQ(List<int> arr)
        {
            List<int> result = (from item in arr
                                where item > 0
                                select item)
                                .ToList();
        }
    }
}
