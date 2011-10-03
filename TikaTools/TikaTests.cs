using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace BHannemann.TikaTools {

    [TestFixture]
    public class TikaTests {
        TikaWrapper wrapper;
        FileInfo[] files;

        [SetUp]
        public void Init() {
            wrapper = new TikaWrapper(@"..\..\tika-app-0.10.jar");

            DirectoryInfo d = new DirectoryInfo(@"..\..\Documents");
            files = d.GetFiles();
        }

        [Test]
        public void Extract() {
            foreach (FileInfo f in files) {
                Console.WriteLine("Verifying " + f.FullName);
                Assert.True(wrapper.Extract(f, true).Contains("The quick brown fox jumps over a lazy dog."));
            }
        }

    }
}
