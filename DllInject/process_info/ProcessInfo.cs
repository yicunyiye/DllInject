using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDesk.Options;
using DllInject.public_pro;
using System.Diagnostics;

namespace DllInject.process_info
{
    class ProcessInfo
    {
        public static void ListAllProcess()
        {
            Font.InfoFonts("List All Processes...");
            Process[] procs = Process.GetProcesses();
            foreach (Process proc in procs)
            {
                try
                {
                    Console.WriteLine("[+]Name:" + proc.ProcessName);
                    Console.WriteLine("Path:" + proc.MainModule.FileName);
                    Console.WriteLine("ID:" + proc.Id);
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine();
                    continue;
                }
            }
        }
        public static void PickedProcessInfoBypid(int pid)
        {
            Process pickedproc = Process.GetProcessById(pid);
            Console.WriteLine("[+]Name:" + pickedproc.ProcessName);
            Console.WriteLine("Path:" + pickedproc.MainModule.FileName);
            Console.WriteLine("ID:" + pickedproc.Id);
            Console.WriteLine();
        }
        public static void PickedProcessInfoByname(string name)
        {
            Process[] procs = Process.GetProcesses();
            string targetname = "";
            foreach (Process proc in procs)
            {
                try
                {
                    if (proc.MainModule.FileName.Contains(name) || proc.ProcessName.Contains(name))
                    {
                        targetname = proc.ProcessName;
                        Console.WriteLine("[+]Name:" + targetname);
                        Console.WriteLine("Path:" + proc.MainModule.FileName);
                        Console.WriteLine("ID:" + proc.Id);
                        Console.WriteLine();
                    }
                }
                catch
                {
                    continue;
                }
            }
            if(targetname == "")
            {
                Font.Warning("[-]process " + name + " not found");
                Font.InfoFonts("可以尝试去掉后缀,例如calc.exe去掉.exe查询");
            }
        }

        public static void PickedModuleInfo(int pid)
        {
            Process pickedproc = Process.GetProcessById(pid);
            ProcessModuleCollection myProcessModuleCollection = pickedproc.Modules;
            Font.InfoFonts("Loaded Modules by " + pickedproc.MainModule.FileName);
            for(int i = 0; i < myProcessModuleCollection.Count; i++)
            {
                ProcessModule myProcessModule = myProcessModuleCollection[i];
                Console.WriteLine(myProcessModule);
            }
        }
    }
}
