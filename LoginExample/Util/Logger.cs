using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace LoginExample.Util
{
    public class Logger
    {
        public static void WriteInfo(object message) {
            Write("INFO", message);
        }

        public static void WriteError(object message) {
            Write("ERROR", message);
        }

        private static void Write(string type, object message) {
            string path = $"{HostingEnvironment.ApplicationPhysicalPath}app.log";
            string cabeceraLog = $"\n[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {type}\n";
           
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(cabeceraLog);
                sw.WriteLine(message.ToString());
            }
        }
    }
}