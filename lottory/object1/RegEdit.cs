using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.object1
{
    public class RegEdit
    {
        RegistryKey myKey;
        public RegEdit()
        {
            myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\SophiaSoft\\Lottory", true);
            //if (myKey == null)
            //{
            //    Registry.LocalMachine.CreateSubKey("SOFTWARE\\SophiaSoft\\Lottory");
            //    myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\SophiaSoft\\Lottory", true);
            //}
        }
        public void setClearInput(String value)
        {
            myKey.SetValue("ClearInput", value, RegistryValueKind.String);
        }
        public String getClearInput()
        {
            if (myKey.GetValue("ClearInput") == null)
            {
                myKey.SetValue("ClearInput", "", RegistryValueKind.String);
            }
            return myKey.GetValue("ClearInput").ToString();
        }

        public void setConnectServer(String value)
        {
            myKey.SetValue("ConnectServer", value, RegistryValueKind.String);
        }
        public String getConnectServer()
        {
            if (myKey.GetValue("ConnectServer") == null)
            {
                myKey.SetValue("ConnectServer", "", RegistryValueKind.String);
            }
            return myKey.GetValue("ConnectServer").ToString();
        }
        public void setPassword(String value)
        {
            myKey.SetValue("Password", value, RegistryValueKind.String);
        }
        public String getPassword()
        {
            if (myKey.GetValue("Password") == null)
            {
                myKey.SetValue("Password", "", RegistryValueKind.String);
            }
            return myKey.GetValue("Password").ToString();
        }
        public void setServerIP(String value)
        {
            myKey.SetValue("ServerIP", value, RegistryValueKind.String);
        }
        public String getServerIP()
        {
            if (myKey.GetValue("ServerIP") == null)
            {
                myKey.SetValue("ServerIP", "", RegistryValueKind.String);
            }
            return myKey.GetValue("ServerIP").ToString();
        }
        public void setUsername(String value)
        {
            myKey.SetValue("Username", value, RegistryValueKind.String);
        }
        public String getUsername()
        {
            if (myKey.GetValue("Username") == null)
            {
                myKey.SetValue("Username", "", RegistryValueKind.String);
            }
            return myKey.GetValue("Username").ToString();
        }
    }
}
