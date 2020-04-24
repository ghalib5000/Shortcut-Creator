using System;

namespace Shortcut_creator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter main folder");
            string location = Console.ReadLine();
            Console.WriteLine("enter Output Location folder");
            string output_location = Console.ReadLine();
            Console.WriteLine("enter Log Location folder");
            string logloc = Console.ReadLine();
            //string output_location = @"D:/New Folder12/shortcut folders/shortcuts/output/";
            //string logloc = @"D:/New Folder12/shortcut folders/shortcuts/";
            Files.Copy(location,output_location,logloc);
            Files.show();

        }

       
        
    }
}
