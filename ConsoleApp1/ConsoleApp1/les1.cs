using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class les1
    {
        public les1()
        {
            Console.WriteLine("test");
        }
        public void Run()
        {

            Console.WriteLine("push enter");
            while (ConsoleKey.Enter != Console.ReadKey().Key)
            {

                Console.WriteLine("komop dit is geen enter");

            }
        }
    }


}
