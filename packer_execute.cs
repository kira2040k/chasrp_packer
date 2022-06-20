using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Diagnostics;

namespace exeproxy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bytes_here
            int number;
            for (int i = 0; i < bytes.Length; i++) {
                    number = Int16.Parse(bytes[i].ToString());
                    bytes[i] = Convert.ToByte(number);
                
            }

            Assembly assembly = Assembly.Load(bytes);
            assembly.EntryPoint.Invoke(null, new object[] { new string[0] });
        }
    }
}