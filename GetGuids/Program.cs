using System;

namespace GetGuids
{
    class Program
    {
        private static int _num;
        static void Main(string[] args)
        {
            Console.WriteLine("How many GUIDs should we generate?");
            var input = Console.ReadLine();
            if (input != null)
            {
                _num = int.Parse(input);
                for (int i = 0; i < _num; i++)
                {
                    var guid = Guid.NewGuid();
                    Console.WriteLine(guid);
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("How many GUIDs should we generate?");
            }
        }
    }
}
