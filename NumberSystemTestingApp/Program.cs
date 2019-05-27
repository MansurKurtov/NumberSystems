using CoreNumberSystem;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Configuration;

namespace NumberSystemTestingApp
{
    class Program
    {
        //private const string numberSystemName = "DecimalNumberSystem.dll";
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + @"\";
            string dllFileName = ConfigurationSettings.AppSettings["DllFile"];
            string fileForLoad = path + dllFileName;
            if (!File.Exists(fileForLoad))
                throw new Exception("File not exists!");

            var myAssembly = Assembly.LoadFile(fileForLoad);
            var serviceType = typeof(INumberSystem);
            var types = myAssembly.GetTypes().ToList();
            var myServiceType = types.Where(w => serviceType.IsAssignableFrom(w)).ToList().FirstOrDefault();
            if (myServiceType == null)
                throw new Exception("Service not found");

            INumberSystem bin = Activator.CreateInstance(myServiceType) as INumberSystem;

            Console.WriteLine(bin.Add("101", "11"));
            Console.ReadLine();
        }
    }
}
