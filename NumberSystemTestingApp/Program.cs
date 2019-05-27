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
            var dllFileName = ConfigurationSettings.AppSettings["DllFile"];

            if (dllFileName == null)
                throw new Exception("Dll file not found");

            var firstNumber = ConfigurationSettings.AppSettings["FirstNumber"];
            var secondNumber = ConfigurationSettings.AppSettings["SecondNumber"];
            var numberSystem = ConfigurationSettings.AppSettings["Type"];
            if (firstNumber == null || secondNumber == null || numberSystem == null)
                throw new Exception("Given data error");

            string fileForLoad = path + dllFileName;
            if (!File.Exists(fileForLoad))
                throw new Exception("File not exists!");

            var myAssembly = Assembly.LoadFile(fileForLoad);
            var serviceType = typeof(INumberSystem);
            var types = myAssembly.GetTypes().ToList();
            var myServiceType = types.Where(w => serviceType.IsAssignableFrom(w)).ToList().FirstOrDefault();
            if (myServiceType == null)
                throw new Exception("Service not found");

            var bin = Activator.CreateInstance(myServiceType) as INumberSystem;
            Console.WriteLine(numberSystem);
            Console.WriteLine(firstNumber+"+"+secondNumber + " = " + bin.Add(firstNumber, secondNumber));
            Console.WriteLine(firstNumber + "*" + secondNumber + " = " + bin.Multiply(firstNumber, secondNumber));
            Console.WriteLine(firstNumber + "-" + secondNumber + " = " + bin.Subtract(firstNumber, secondNumber));
            Console.WriteLine(secondNumber + "-" + firstNumber + " = " + bin.Subtract(secondNumber, firstNumber));
            Console.ReadKey();
        }
    }
}
