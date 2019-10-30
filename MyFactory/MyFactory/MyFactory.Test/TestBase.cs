using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace MyFactory.Test
{
    [TestFixture]
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        private Stopwatch Stopwatch { get; set; }

        [OneTimeSetUp]
        public void Initialization()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
        }

        [TearDown]
        public void End()
        {
            Stopwatch.Stop();           
            string filename = TestContext.CurrentContext.TestDirectory + "/TestsPerformance.txt";
            string text = null;
            if (!File.Exists(filename))
                text = "Unit Test run on " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine;
            text += TestContext.CurrentContext.Test + "" + this.Stopwatch.Elapsed.ToString(@"mm\:ss\.fffffff",null) + Environment.NewLine;           
            File.AppendAllText(filename, text);
        }
    }
}
