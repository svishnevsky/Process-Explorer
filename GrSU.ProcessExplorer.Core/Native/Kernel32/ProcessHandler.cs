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
        private const uint TerminateProcess = 0x1;

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

        public PROCESSENTRY32? GetProcess(uint pid)
        {
            var handleToSnapshot = IntPtr.Zero;
            var procEntry = new PROCESSENTRY32();
            try
            {
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
                handleToSnapshot = Api.CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);
                if (Api.Process32First(handleToSnapshot, ref procEntry))
                {
                    if (procEntry.th32ProcessID != pid)
                    {
                        while (procEntry.th32ProcessID != pid && Api.Process32Next(handleToSnapshot, ref procEntry))
                        {
                        }
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

            return procEntry.th32ProcessID == pid ? (PROCESSENTRY32?)procEntry : null;
        }
        
        public void KillProcess(uint pid)
        {
            var hProcess = IntPtr.Zero;
            try
            {
                hProcess = Api.OpenProcess(TerminateProcess, false, (int)pid);
                if (hProcess == IntPtr.Zero)
                {
                    //throw new Win32Exception(Marshal.GetLastWin32Error()); // Если KIS, то Access denied.
                }
                else if (!Api.TerminateProcess(hProcess, 0))
                {
                    //throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            catch(Exception e){
                //TODO: Log error
            }
            finally
            {
                if (hProcess != IntPtr.Zero)
                {
                    Api.CloseHandle(hProcess);
                }
            }
        }
    }
}
