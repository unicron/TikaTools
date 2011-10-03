using System;
using System.IO;

namespace BHannemann.TikaTools {
    class Program {
        static void Main(string[] args) {

            TikaWrapper tika = new TikaWrapper(@"..\..\tika-app-0.10.jar");
            string result = tika.Extract(File.ReadAllBytes(@"..\..\Documents\Tika.docx"), true);
            Console.WriteLine(result);


            Console.ReadLine();
        }
    }
}