using BasicLogger;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shortcut_creator
{
    class Files
    {
       
        static DateTime date = DateTime.Now;
        static List<FileInfo> listofexe = new List<FileInfo>();
        static Logger log;
        static string temp = "hello";
        public static void Copy(string sourceDirectory, string targetDirectory,string logloc)
        {
            log = new Logger(logloc + "\\" + "out.txt", date.ToString());
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);
            CopyAll(diSource, diTarget);

        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {

                if (fi.Extension == ".exe" && !fi.FullName.Contains("unins") &&
                !fi.FullName.Contains("Unins") &&
                 !fi.FullName.Contains("CrashReportClient") &&
                 !fi.FullName.Contains("UnityCrashHandler64") &&
                 !fi.FullName.Contains("Crash"))
                {
                    temp = "the type is" + fi.Extension;
                    log.Information(temp);
                    Console.WriteLine(temp);
                    listofexe.Add(fi);
                    CreateShortcut(fi, target.FullName);
                }



                //fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);

            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target;
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }


        }
        public static void show()
        {
            foreach (FileInfo ff in listofexe)
            {
                temp = "Filename: " + ff.FullName;
                log.Information(temp);
                Console.WriteLine(temp);
            }
            temp = "total files with exe extension are: " + listofexe.Count;
            log.Information(temp);
            Console.WriteLine(temp);
        }
        public static void CreateShortcut(FileInfo fi,string output)
        {

            WshShell shell = new WshShell();
            string shortcutAddress = fi.FullName;
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut
                (output+"\\" + fi.Name.Substring(0, Convert.ToInt32(fi.Name.Length - 4)) + ".lnk");
            shortcut.Description = fi.Name;
            shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = shortcutAddress;
            shortcut.Save();
            temp = "Created Shortcut at: " + output+"\\" + fi.Name.Substring(0, Convert.ToInt32(fi.Name.Length - 4))+ ".lnk";
            log.Information(temp);
            Console.WriteLine(temp);
        }
    }
}

