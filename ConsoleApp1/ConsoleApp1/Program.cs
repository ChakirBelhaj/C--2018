﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // runs main
        static void Main(string[] args)
        {       
            Menu menu = new Menu();
            Class1 test  = new Class1();
            Matrixx matrixx = new Matrixx();
            matrixx.Main();
            menu.Run();
        }
    }
}
