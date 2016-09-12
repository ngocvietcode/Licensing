﻿using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Licensing.Client
{
    public class FingerPrint
    {
        private static string fingerPrint = string.Empty;

        public static string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                fingerPrint = GetHash("CPU >> " + cpuId() +
                                      //"\nBIOS >> " + biosId() +
                                      "\nBASE >> " + baseId() +
                                      "\nDISK >> " + diskId() +
                                      "\nVIDEO >> " + videoId()
                                      //"\nMAC >> " + macId()
                    );
            }
            return fingerPrint;
        }

        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            var enc = new ASCIIEncoding();
            var bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }

        private static string GetHexString(byte[] bt)
        {
            var s = string.Empty;
            for (var i = 0; i < bt.Length; i++)
            {
                var b = bt[i];
                int n, n1, n2;
                n = b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char) (n2 - 10 + 'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char) (n1 - 10 + 'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1)%2 == 0) s += "-";
            }
            return s;
        }

        #region Original Device ID Getting Code

        private static string identifier
            (string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            var result = "";
            var mc =
                new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }

        private static string identifier(string wmiClass, string wmiProperty)
        {
            var result = "";
            var mc =
                new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }

        private static string cpuId()
        {
            var retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "")
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "")
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "")
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }

                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }

        private static string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
                   + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
                   + identifier("Win32_BIOS", "IdentificationCode")
                   + identifier("Win32_BIOS", "SerialNumber")
                   + identifier("Win32_BIOS", "ReleaseDate")
                   + identifier("Win32_BIOS", "Version");
        }

        private static string diskId()
        {
            return identifier("Win32_DiskDrive", "Model")
                   + identifier("Win32_DiskDrive", "Manufacturer")
                   + identifier("Win32_DiskDrive", "Signature")
                   + identifier("Win32_DiskDrive", "TotalHeads");
        }

        private static string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
                   + identifier("Win32_BaseBoard", "Manufacturer")
                   + identifier("Win32_BaseBoard", "Name")
                   + identifier("Win32_BaseBoard", "SerialNumber");
        }

        private static string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion")
                   + identifier("Win32_VideoController", "Name");
        }

        private static string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration",
                "MACAddress", "IPEnabled");
        }

        #endregion
    }
}