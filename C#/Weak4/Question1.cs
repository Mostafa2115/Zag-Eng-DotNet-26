using System;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {
        string runtimeVersion = Environment.Version.ToString();
        string os = RuntimeInformation.OSDescription;
        string architecture = RuntimeInformation.OSArchitecture.ToString();
        string framework = RuntimeInformation.FrameworkDescription;
        Console.WriteLine("Runtime Version: " + runtimeVersion);
        Console.WriteLine("Operating System: " + os);
        Console.WriteLine("CPU Architecture: " + architecture);
        Console.WriteLine("Framework: " + framework);
        switch (framework)
        {
            case string r when r.Contains(".NET") && !r.Contains("Framework"):
                Console.WriteLine("Modern .NET Runtime");
                break;

            default:
                Console.WriteLine("Legacy Runtime");
                break;
        }
    }
}
