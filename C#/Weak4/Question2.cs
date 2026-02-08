using System;
using System.Runtime.InteropServices;
class Program
{
    static readonly bool loginEnabled = true,exportEnabled = false,adminEnabled = true;
    static readonly double loginMinVersion = 1.0,exportMinVersion = 2.0,adminMinVersion = 2.5;

    static void Main(string[] args)
    {
        const double appVersion = 2.0;
        if (loginEnabled)
            if (appVersion >= loginMinVersion)
                Console.WriteLine("Login Available");
            else
                Console.WriteLine("Login Not Available");
        else
            Console.WriteLine("Login Disabled");

        if (exportEnabled)
            if (appVersion >= exportMinVersion)
                Console.WriteLine("Export Available");
            else
                Console.WriteLine("Export Not Available");
        else
            Console.WriteLine("Export Disabled");

        if (adminEnabled)
            if (appVersion >= adminMinVersion)
                Console.WriteLine("Admin Available");
            else
                Console.WriteLine("Admin Not Available");
        else
            Console.WriteLine("Admin Disabled");
    }
}



