using System;

namespace BitOperatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 참고: 16진수 활용 예
            const int WINDOW = 0x0001;                  // bit 00000001
            const int FULLSCREEN = 0x0002;              // bit 00000010
            const int FLAG1 = 0x0004;                   // bit 00000100
            const int FLAG2 = 0x0008;                   // bit 00001000
            const int FLAG3 = 0x0010;                   // bit 00010000
            const int FLAG4 = 0x0020;                   // bit 00100000

            int mode = WINDOW | FULLSCREEN | FLAG3;     // bit 00010011

            if ((mode & FULLSCREEN) > 0)
            {
                Console.WriteLine("Full Screen 으로 띄워라.");
            }
        }
    }
}
