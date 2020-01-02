using System;
using System.IO;

namespace Swearsult
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new[] { "helloworld.sw" };

            bool debug = false;

            // Find Flags
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "/d") debug = true;
            }
            // Find Files
            for (int i = 0; i < args.Length; i++)
            {
                if (File.Exists(args[i]))
                {
                    new Interpreter(args[i]).Interpret(debug);
                }
            }

            Console.ReadKey(true);
        }
    }
}
