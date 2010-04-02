using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommandLineConsole.Misc
{
    /*
    * These part of code comes from Josh's Blog, Detailed CPU Info in C# (CSharp)
    * http://joshfinlay.blogspot.com/2009/02/detailed-cpu-info-in-c-csharp.html
    */

    public class CPUInfo
    {
        private static string id = String.Empty;
        private static string manufacturer = String.Empty;
        private static string descr = String.Empty;
        private static string name = String.Empty;
        private static string socket = String.Empty;
        private static int familyId = -1;
        private static string family = String.Empty;
        private static int archId = -1;
        private static string arch = String.Empty;
        private static int speed = 0;
        private static int l2CacheSize = 0;
        private static int l3CacheSize = 0;
        private static int cores = 0;
        private static int load = 0;
        private static int fSBClock = 0;

        // architecture mappings
        private const int ARCH_X86 = 0;
        private const int ARCH_MIPS = 1;
        private const int ARCH_ALPHA = 2;
        private const int ARCH_PPC = 3;
        private const int ARCH_IA64 = 6;
        private const int ARCH_X64 = 9;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public string Descr
        {
            get { return descr; }
            set { descr = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        public int FamilyId
        {
            get { return familyId; }
            set { familyId = value; }
        }

        public string Family
        {
            get { return  CPUInfo.Family2String(familyId); }
        }

        public int ArchId
        {
            get { return archId; }
            set { archId = value; }
        }

        public string Arch
        {
            get { return CPUInfo.ArchID2String(archId); }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int L2CacheSize
        {
            get { return l2CacheSize; }
            set { l2CacheSize = value; }
        }

        public int L3CacheSize
        {
            get { return l3CacheSize; }
            set { l3CacheSize = value; }
        }

        public int Cores
        {
            get { return cores; }
            set { cores = value; }
        }

        public int Load
        {
            get { return load; }
            set { load = value; }
        }

        public int FSBClock
        {
            get { return fSBClock; }
            set { fSBClock = value; }
        }

        
        public static string ArchID2String(int aID)
        {
            string ArchStr = "";
            switch (aID)
            {
                case ARCH_X86:
                    ArchStr = "x86";
                    break;
                case ARCH_MIPS:
                    ArchStr = "MIPS";
                    break;
                case ARCH_ALPHA:
                    ArchStr = "Alpha";
                    break;
                case ARCH_PPC:
                    ArchStr = "PowerPC";
                    break;
                case ARCH_IA64:
                    ArchStr = "Intel Itanium Processor Family (IPF)";
                    break;
                case ARCH_X64:
                    ArchStr = "x64";
                    break;
                default:
                    ArchStr = "Unknown";
                    break;
            }
            return ArchStr;
        }

        public static string Family2String(int fID)
        {
            string fStr = "";
            switch (fID)
            {
                case 1:
                    fStr = "Other";
                    break;
                case 2:
                    fStr = "Unknown";
                    break;
                case 3:
                    fStr = "8086";
                    break;
                case 4:
                    fStr = "80286";
                    break;
                case 5:
                    fStr = "Intel386™ Processor";
                    break;
                case 6:
                    fStr = "Intel486™ Processor";
                    break;
                case 7:
                    fStr = "8087";
                    break;
                case 8:
                    fStr = "80287";
                    break;
                case 9:
                    fStr = "80387";
                    break;
                case 10:
                    fStr = "80487";
                    break;
                case 11:
                    fStr = "Pentium";
                    break;
                case 12:
                    fStr = "Pentium Pro";
                    break;
                case 13:
                    fStr = "Pentium II";
                    break;
                case 14:
                    fStr = "Pentium Processor with MMX™ Technology";
                    break;
                case 15:
                    fStr = "Celeron™";
                    break;
                case 16:
                    fStr = "Pentium II Xeon™";
                    break;
                case 17:
                    fStr = "Pentium III";
                    break;
                case 18:
                    fStr = "M1";
                    break;
                case 19:
                    fStr = "M2";
                    break;
                case 24:
                    fStr = "AMD Duron™ Processor";
                    break;
                case 25:
                    fStr = "K5 Family";
                    break;
                case 26:
                    fStr = "K6 Family";
                    break;
                case 27:
                    fStr = "K6-2";
                    break;
                case 28:
                    fStr = "K6-3";
                    break;
                case 29:
                    fStr = "AMD Athlon™ Processor";
                    break;
                case 30:
                    fStr = "AMD2900";
                    break;
                case 31:
                    fStr = "K6-2+";
                    break;
                case 32:
                    fStr = "Power PC";
                    break;
                case 33:
                    fStr = "Power PC 601";
                    break;
                case 34:
                    fStr = "Power PC 603";
                    break;
                case 35:
                    fStr = "Power PC 603+";
                    break;
                case 36:
                    fStr = "Power PC 604";
                    break;
                case 37:
                    fStr = "Power PC 620";
                    break;
                case 38:
                    fStr = "Power PC X704";
                    break;
                case 39:
                    fStr = "Power PC 750";
                    break;
                case 130:
                    fStr = "Itanium™ Processor";
                    break;
                case 131:
                    fStr = "AMD Athlon™ 64 Processor";
                    break;
                case 132:
                    fStr = "AMD Opteron™ Processor";
                    break;
                case 176:
                    fStr = "Pentium III Xeon™ Processor";
                    break;
                case 177:
                    fStr = "Pentium III Processor with Intel SpeedStep™ Technology";
                    break;
                case 178:
                    fStr = "Pentium 4";
                    break;
                case 179:
                    fStr = "Intel Xeon™";
                    break;
                case 180:
                    fStr = "AS400";
                    break;
                case 181:
                    fStr = "Intel Xeon™ Processor MP";
                    break;
                case 182:
                    fStr = "AMD Athlon™ XP";
                    break;
                case 183:
                    fStr = "AMD Athlon™ MP";
                    break;
                case 184:
                    fStr = "Intel Itanium 2";
                    break;
                case 185:
                    fStr = "Intel Pentium M Processor";
                    break;
                case 190:
                    fStr = "K7";
                    break;
                case 201:
                    fStr = "G4";
                    break;
                case 202:
                    fStr = "G5";
                    break;
                case 203:
                    fStr = "G6";
                    break;
                case 250:
                    fStr = "i860";
                    break;
                case 251:
                    fStr = "i960";
                    break;
                default:
                    fStr = "Unknown/Unsupported";
                    break;
            }
            return fStr;
        }
    }
}
