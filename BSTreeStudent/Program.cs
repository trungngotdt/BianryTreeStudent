using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using FizzWare.NBuilder;
using LinqToExcel;
using Tree;

namespace BSTreeStudent
{
    class Program
    {        
        static void Main(string[] args)
        {

            RunMain main = new RunMain();
            main.RunMainMenu();
            Console.ReadLine();

        }
        
    }
}
