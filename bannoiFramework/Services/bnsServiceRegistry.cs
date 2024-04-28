using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bannoiFramework.Services
{
    public class registryValuesList
    {
        public string KEYNAME{get;set;}
        public string KEYVALUE{get;set;}
    }

    public class bnsServiceRegistry
    {
        public bnsServiceRegistry()
        {

        }

        public static void writeCurrentUser(string keyName,string keyValue, string value)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + keyName);
                key.SetValue(keyValue, value);
                key.Close();
            }
            catch { throw; }
        }

        public static void writeCurrentUser(string keyName,List<registryValuesList> values)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + keyName);
                foreach (var keyValue in values)
                {
                    key.SetValue(keyValue.KEYNAME, keyValue.KEYVALUE);
                }
                key.Close();
            }
            catch { throw; }
        }

        public static void readCurrentUser(string keyName, ref List<registryValuesList> values)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + keyName);
                if (key != null)
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        values[i].KEYVALUE = Convert.ToString(key.GetValue(values[i].KEYNAME));
                    }

                    key.Close();
                }
            }
            catch { throw; }
        }

        public static string readCurrentUser(string keyName,string keyValue)
        {
            string Res = null;
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + keyName);
                if (key != null)
                {
                    Res = Convert.ToString(key.GetValue(keyValue));
                    key.Close();
                }
            }
            catch { throw; }
            return Res;
        }

        public static string removeCurrentUser(string keyName, string keyValue)
        {
            string Res = null;
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + keyName);
                if (key != null)
                {
                    key.DeleteValue(keyValue);
                    key.Close();
                }
            }
            catch { throw; }
            return Res;
        }
    }
}
