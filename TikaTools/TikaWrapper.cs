using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BHannemann.TikaTools{
    
    /// <summary>
    /// Contains methods for running the Apache Tika tool from the command line.
    /// Note that a modern JVM (1.5+) must be installed and included in the system path.
    /// </summary>
    public class TikaWrapper {

        private string tikaPath;

        /// <summary>
        /// Initialize a new TikaWrapper provided the path to the Tika .jar file.
        /// </summary>
        /// <param name="tikaPath"></param>
        public TikaWrapper(string tikaPath) {
            this.tikaPath = tikaPath;
        }

        /// <summary>
        /// Extract text and/or metadata from a file using Tika.
        /// </summary>
        /// <param name="file">The file from which to extract information.</param>
        /// <param name="textOnly">Extract text only, no metadata.</param>
        /// <returns>The extracted information.</returns>
        public string Extract(FileInfo file, bool textOnly) {
            if (file == null) return String.Empty;

            return Extract(file.FullName, textOnly);
        }

        /// <summary>
        /// Extract text and/or metadata from a file using Tika.
        /// </summary>
        /// <param name="filePath">The path to a file from which to extract information.</param>
        /// <param name="textOnly">Extract text only, no metadata.</param>
        /// <returns>The extracted information.</returns>
        public string Extract(string filePath, bool textOnly) {
            if (String.IsNullOrEmpty(filePath)) return String.Empty;

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "java";

            StringBuilder args = new StringBuilder();
            args.Append("-jar \""+tikaPath+"\"");
            if (textOnly)
                args.Append(" -t ");
            args.Append("\""+filePath+"\"");

            start.Arguments = args.ToString();
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start)) {
                using (StreamReader reader = process.StandardOutput) {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        /// <summary>
        /// Extract text and/or metadata from a file using Tika.
        /// </summary>
        /// <param name="file">The file from which to extract information.</param>
        /// <param name="textOnly">Extract text only, no metadata.</param>
        /// <returns>The extracted information.</returns>
        public string Extract(byte[] file, bool textOnly) {
            if (file.Length == 0) return String.Empty;

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "java";

            StringBuilder args = new StringBuilder();
            args.Append("-jar \""+tikaPath+"\"");
            if (textOnly)
                args.Append(" -t");

            start.Arguments = args.ToString();
            start.UseShellExecute = false;
            start.RedirectStandardInput = true;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start)) {
                using (StreamWriter writer = process.StandardInput) {
                    writer.BaseStream.Write(file, 0, file.Length);
                }

                using (StreamReader reader = process.StandardOutput) {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
