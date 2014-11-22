using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Core.Native.Kernel32
{
    internal class ProcessHandler
    {
        public List<PROCESSENTRY32> GetProcesses()
        {
            var handleToSnapshot = IntPtr.Zero;
            var procEntryList = new List<PROCESSENTRY32>();
            try
            {
                var procEntry = new PROCESSENTRY32();
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
                handleToSnapshot = Api.CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);
                if (Api.Process32First(handleToSnapshot, ref procEntry))
                {
                    procEntryList.Add(procEntry);
                    while (Api.Process32Next(handleToSnapshot, ref procEntry))
                    {
                        procEntryList.Add(procEntry);
                    }
                }
                else
                {
                    throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
                }
            }
            catch
            {
                //TODO: Log error
            }
            finally
            {
                Api.CloseHandle(handleToSnapshot);
            }

            return procEntryList;
        }
    }
}
