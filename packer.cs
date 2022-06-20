using System;
using System.IO;
using System.Reflection;
using System.Text;
namespace exeproxy

{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: exeproxy <exe>");
                Environment.Exit(1);
            }
            string exe = args[0];
            byte[] bytes = File.ReadAllBytes(exe);
            Console.WriteLine();
            File.WriteAllText("tmp.tmp", "");
            File.AppendAllText("tmp.tmp", "byte[] bytes = new byte[" + bytes.Length + "]{");
            byte[] new_byte = new byte[bytes.Length];
            string data = "";
            int number = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
               
                    number = Int16.Parse(bytes[i].ToString());
                    data += number.ToString() + ",";
               }
            data = data + "} ;";
            File.AppendAllText("tmp.tmp",data.Replace(",}",("}")));
            string read_packer_file = File.ReadAllText("packer_execute.cs");
            string shellcode = File.ReadAllText("tmp.tmp");
            read_packer_file = read_packer_file.Replace("bytes_here", shellcode);
            File.WriteAllText("packer_execute2.cs", read_packer_file);
            Console.WriteLine("packed");
            // var sb = new StringBuilder("new byte[] { ");
            //foreach (var b in bytes)
            //{
            //    sb.Append(b + ",0x");
            //}
            //sb.Append("}");
            //Console.WriteLine(sb.ToString());

            //file = file.Replace("bytes_here", sb.ToString());
            //File.WriteAllText("packer_execute2.cs", file);
            //Assembly assembly = Assembly.Load();
            //assembly.EntryPoint.Invoke(null, new object[] { new string[0] });
        }
        
    }
}