using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MyLibrary
{
    public class MemoryStatus
    {
        private struct MEMORYSTATUS
        {
            public uint Length;
            public uint MemoryLoad;
            public uint TotalPhys;
            public uint AvailPhys;
            public uint TotalPageFile;
            public uint AvailPageFile;
            public uint TotalVirtual;
            public uint AvailVirtual;
        }

        [DllImport("coredll.dll", EntryPoint = "GlobalMemoryStatus", SetLastError = true)]
        private static extern void GlobalMemoryStatus(ref MEMORYSTATUS lpBuffer);

        /// <summary>
        /// Retrieves information about the system's current available physical memory.
        /// </summary>
        /// <returns>Available memory in mega bytes.</returns>
        public static float GetAvailableMemory()
        {
            MEMORYSTATUS mem = new MEMORYSTATUS();
            GlobalMemoryStatus(ref mem);

            return (float)mem.AvailPhys / 1048576.0f;
        }

        /// <summary>
        /// Retrieves information about the system's current usage of physical memory.
        /// </summary>
        /// <param name="aTotalMem">Total memory in mega bytes.</param>
        /// <param name="anUsedMem">Used memory in mega bytes.</param>
        /// <param name="aFreeMem">Available memory in mega bytes.</param>
        public static void GetAvailableMemory(out float aTotalMem,
               out float anUsedMem, out float aFreeMem)
        {
            MEMORYSTATUS mem = new MEMORYSTATUS();
            GlobalMemoryStatus(ref mem);

            aTotalMem = (float)mem.TotalPhys / 1048576.0f;
            aFreeMem = (float)mem.AvailPhys / 1048576.0f;
            anUsedMem = aTotalMem - aFreeMem;
        }
    }
}
