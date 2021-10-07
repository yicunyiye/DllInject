using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DllInject.process_info;
using NDesk.Options;
using DllInject.public_pro;
using DllInject.dll_inject;

namespace DllInject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var show_help = false;
                var _ListAllProcess = false;
                var _GetProcess = false;
                var _GetModule = false;
                var _Inject = false;
                List<string> _dllpath = new List<string>();
                List<int> _pid = new List<int>();
                List<string> _name = new List<string>();

                OptionSet options = new OptionSet()
            {
                {"h|help","Show Help\n", v => show_help = v != null},
                {"list","List {all} processes\n",v=>_ListAllProcess = v != null},
                {"GetProcess","Get one Process Info(need pid or name)\n",v=>_GetProcess = v != null},
                {"ListModule","Get one Process module(need pid)\n",v=>_GetModule = v != null},
                {"dllinject","inject dll\n", v => _Inject = v != null},
                {"pid=","the {pid} of the process\n",v=>_pid.Add(Convert.ToInt32(v))},
                {"processname=","the {name} of the process\n",v=>_name.Add(v)},
                {"dllpath=","the {dllpath} of needed to injec\n",v=>_dllpath.Add(v)},
            };

                List<string> extra;
                try
                {
                    extra = options.Parse(args);
                    //检测无效参数
                    if (extra.Any())
                    {
                        foreach (var item in extra)
                        {
                            Font.FontRed();
                            Console.WriteLine("unrecognized option: {0}", item);
                            Font.FontNormal();
                        }
                        ShowHelp(options);
                        return;
                    }
                }
                catch (OptionException e)
                {
                    System.Console.Write("DllInject.exe: ");
                    System.Console.WriteLine(e.Message);
                    System.Console.WriteLine("Try `DllInject.exe --help' for more information.");
                    return;
                }

                GetArgsValue.GetPid(_pid);
                GetArgsValue.GetName(_name);
                GetArgsValue.GetDllPath(_dllpath);


                if (show_help)
                {
                    ShowHelp(options);
                }

                if (_ListAllProcess)
                {
                    ProcessInfo.ListAllProcess();
                }

                if (_GetProcess)
                {
                    if (GetArgsValue.pid != -1)
                    {
                        ProcessInfo.PickedProcessInfoBypid(GetArgsValue.pid);
                    }else if (GetArgsValue.processname != "")
                    {
                        ProcessInfo.PickedProcessInfoByname(GetArgsValue.processname);
                    }
                    else
                    {
                        Font.Warning("need pid\n    DllInject.exe --GetProcess --pid 123");
                        Font.Warning("need name\n    DllInject.exe --GetProcess --processname notepad.exe");
                    }
                }
                if (_GetModule)
                {
                    if (GetArgsValue.pid != -1)
                    {
                        ProcessInfo.PickedModuleInfo(GetArgsValue.pid);
                    }
                    else
                    {
                        Font.Warning("need pid\n    DllInject.exe --ListModule --pid 123");;
                    }
                }
                if (_Inject)
                {
                    if(GetArgsValue.pid != -1 && GetArgsValue.dllpath != "")
                    {
                        Inject.InjectDll(GetArgsValue.pid,GetArgsValue.dllpath);
                    }
                    else
                    {
                        Font.Warning("need pid and dllname\n    DllInject.exe --dllinject --dllpath \"c://test.dll\" --pid 123");
                    }
                }

            }
            catch (System.Exception ex)
            {
                Font.Warning("[-] Exception: " + ex.Message);
                return;
            }
        }
        static void ShowHelp(OptionSet p)
        {
            Font.Warning("Usage: DllInject.exe [OPTIONS]");
            Font.Warning("eg:DllInject.exe -h");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(System.Console.Out);
        }
    }
}
