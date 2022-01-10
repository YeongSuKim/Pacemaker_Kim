using System;

namespace Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 020;
            int c = 0x20;

            const int TRAINING = 0x0001;        //bit 00000001
            const int FULLSCREEN = 0x0002;      //bit 00000010
            const int FLAG1 = 0x0004;           //bit 00000100
            const int FLAG2 = 0x0008;           //bit 00001000
            const int FLAG3 = 0x0010;           //bit 00010000
            const int FLAG4 = 0x0020;           //bit 00100000

            int mode = TRAINING | FULLSCREEN | FLAG3;
            int temp = mode & FULLSCREEN;

            Console.WriteLine("Hello World!");
            Console.WriteLine(String.Format("{0}, {1}, {2}", a, b, c));

            if(temp != 0)
            {}
        }
    }
}
