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
   
        [SetUp]
        public void Initialization()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
        }

        [TearDown]
        public void End()
        {         
            Stopwatch.Stop();
            string filename = TestContext.TestDirectory + "/TestsPerformance.txt";
            string text = "";        
            if (!File.Exists(filename))
                text = "Unit Test run on " + DateTime.Now.ToShortDateString() + " "
                            + DateTime.Now.ToShortTimeString() + Environment.NewLine;
            text += TestContext.Test + " " + this.Stopwatch.Elapsed.ToString(@"mm\:ss\.fffffff", null);
            text += " ";
            File.AppendAllText(filename, text);     
        }
    }
}
