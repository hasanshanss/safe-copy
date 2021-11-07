using System;
using System.Text;

namespace SafeCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the SafeCopy App made by Hasan Shans!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPlease, enter the source directory:");
            string source = Console.ReadLine();

            Console.WriteLine("\nPlease, enter the target directory:");
            string target = Console.ReadLine();

            Console.WriteLine("\nCopying has been started...");

            try
            {
                new RemoveAndCopyService(source, target).RemoveAndCopy();
            }catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.Read();
            }
            

            Console.ReadLine();
        }
    }
}
