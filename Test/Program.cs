using System;

namespace Test
{
    public class Program : umesh
    {
        public Program()
        {
            Console.WriteLine("program");
        }

    }

    public class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program pr = new Program();
            Console.ReadKey();
        }


    }
}
