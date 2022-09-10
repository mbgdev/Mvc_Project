using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time= DateTime.Now.Hour*60+1;

            

            Console.WriteLine(time);
            Console.ReadKey();
        }
    }
}
