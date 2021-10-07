using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DllInject.public_pro
{
    class GetArgsValue
    {
        public static int pid = -1;
        public static string processname = "";
        public static string dllpath = "";
        public static void GetPid(List<int> param = null)
        {
            foreach(int p in param)
            {
                pid = p;
            }
        }

        public static void GetName(List<string> param = null)
        {
            foreach (string p in param)
            {
                processname = p;
            }
        }

        public static void GetDllPath(List<string> param = null)
        {
            foreach (string p in param)
            {
                dllpath = p;
            }
        }
    }
}
