using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVS2GIT
{
    class Perform
    {
        string logPath, logName, blobname, dumpname, user, cvsDir, gitDir, command;                

        public Perform(Form1 control)
        {
            logPath = @"C:\temp\";
            logName = "cvs2gitlog.txt";
            Directory.CreateDirectory(logPath);
            logPath += logName;
            File.CreateText(logPath).Dispose();

            blobname = "gblob.dat";
            dumpname = "gdump.dat";
            cvsDir = control.textBox1.Text;
            user = control.textBox2.Text;
            gitDir = control.textBox3.Text;

            command = string.Format(@"python cvs2svn-2.4.0\cvs2git --blobfile={0} --dumpfile={1} --username={2} {3} --use-external-blob-generator"
                                    blobname, dumpname, user, cvsDir);

        }

        private bool doCMD(string cmd, string product, string action)
        {
            ProcessStartInfo sinfo = new ProcessStartInfo();
            sinfo.FileName = @"C:\Windows\System32\cmd.exe";
            sinfo.RedirectStandardOutput = true;
            sinfo.RedirectStandardError = true;
            sinfo.RedirectStandardInput = true;
            sinfo.UseShellExecute = false;

            Process exec = new Process();
            exec.StartInfo = sinfo;
            exec.Start();
            exec.StandardInput.WriteLine(cmd);
            exec.StandardInput.WriteLine("exit");

            StreamReader reader = exec.StandardOutput;
            string strOutput = reader.ReadToEnd();
            using (StreamWriter file =
                new StreamWriter(logPath, true))
            {
                file.Write(strOutput);
            }
            exec.WaitForExit();

            if (exec.ExitCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
