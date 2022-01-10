using System;

namespace Arraytest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] reading = new int[] { 4, 9, 1, 0, 21, 12 };
            Console.WriteLine("속성: Rank={0}, Length={1}", reading.Rank, reading.Length);
            // reading의 차원 수와 길이를 반환함
            Console.Write("Clear 메소드: ");
            Array.Clear(reading, 0, 5); // 배열 요소를 0부터 시작하여 5개의 요소를 초기화 시킴
            // Array.Clear(요소를 지울 배열, 시작 인덱스, 지울 요소수);
            Array.ForEach<int>(reading, new Action<int>(ShowValue));
            // 해당 배열의 각 요소를 가지고 동작(ShowValue)를 수행함
            // Array.ForEach<데이터타입>(동작을 수행할 배열, new Action<데이터타입>(액션);
            Console.WriteLine();
            Console.Write("Resize 메소드: ");
            Array.Resize(ref reading, reading.Length + 3);
            // reading 배열의 길이를 3만큼 늘림, Array.Resize(배열의 주소값, 새 배열의 크기);
            Array.ForEach<int>(reading, new Action<int>(ShowValue));
            Console.WriteLine();
            Console.WriteLine("indexOf 메소드: {0}", Array.IndexOf(reading, 12));
            // 배열에서 12란 값을 가지고 있는 요소의 인덱스를 반환함
            // Array.IndexOf(배열, 찾고자 하는 값);
        }
        static void ShowValue(int value) // 동작, value를 받아 그 value를 출력시킴
        {
            Console.Write("{0} ", value);
        }
    }
}
