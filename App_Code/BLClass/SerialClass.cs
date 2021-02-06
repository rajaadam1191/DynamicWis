using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Collections;

namespace Lab
{
    public class SerialClass    
    {
        public static string[] Strsplit;
        public static Boolean CheckSerialNoExist()
        {

            try
            {
                //string[] Strsplit;
               // FileStream fs = new FileStream(Application.StartupPath + "/serialNo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
               // FileStream fs = new FileStream(System .Web .HttpContext .Current.Request.PhysicalApplicationPath  + "serialNo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
              //  FileStream fs = new FileStream(Application.StartupPath + "C:\\Program Files\\Common Files\\Microsoft Shared\\DevServer\\9.0\\serialNO.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
              //  Stream str_Stream = fs;
              //  StreamReader str_streamreader = new StreamReader(fs);
                StreamReader reader = File.OpenText("C:\\Program Files\\Common Files\\Microsoft Shared\\DevServer\\9.0\\serialNO.txt");
                if (!reader.EndOfStream)
                {
                 //   string strvalue = str_streamreader.ReadLine();
                  //  Strsplit = strvalue.Split('-');
                }
              //  fs.Close();
               // str_streamreader.Close();
              //  str_Stream.Close();
                Boolean f1;

                if (Strsplit.Length == 0)
                {
                    f1 = false;
                }
                else
                {
                    int systemval;
                    string MACAddress = GetHDDSerialNo();
                    string[] Strsplit1 = MACAddress.Split(':');
                    systemval = Convert.ToInt32(Strsplit1[0], 16) + Convert.ToInt32(Strsplit1[1], 16) + Convert.ToInt32(Strsplit1[2], 16) + Convert.ToInt32(Strsplit1[3], 16);// + Convert.ToInt32(Strsplit1[4], 16) + Convert.ToInt32(Strsplit1[5], 16);
                    int val1, val2, val3, val4;
                    val1 = Convert.ToInt32(Strsplit[0]) - 1947;
                    val2 = Convert.ToInt32(Strsplit[1]) / 9471;
                    val3 = Convert.ToInt32(Strsplit[2]) - 4719;
                    val4 = Convert.ToInt32(Strsplit[3]) / 7194;
                    int dum = (systemval) * 4;
                    Decimal chkval = (val1 + val2 + val3 + val4) / dum;
                    if (chkval == 1)
                    {
                        f1 = true;
                    }
                    else
                    {
                        f1 = false;
                    }
                }
                return f1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }

        }
        public static String PhysicalAddress()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                string MACAddress = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    if (MACAddress == String.Empty) // only return MAC Address from first card  
                    {
                        if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                    }
                    mo.Dispose();
                }

                // MACAddress = MACAddress.Replace(":", "");
                return MACAddress;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static String ProcessorId()
        {
            try
            {
                ManagementObjectCollection mbsList = null;
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
                mbsList = mbs.Get();
                string id = "";
                foreach (ManagementObject mo in mbsList)
                {
                    id = mo["ProcessorID"].ToString();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static String GetHDDSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);

            }
            result = result.Substring(0, 8);
            string input = result;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                    if (i != 0)
                    {
                        sb.Append(':');
                    }
                sb.Append(input[i]);
            }
            result = sb.ToString();
            return result;

        }

    }
}
