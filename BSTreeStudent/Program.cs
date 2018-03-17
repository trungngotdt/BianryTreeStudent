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
        
        private static int size = 20;
        public static  List<T> GetRandomData<T>(int size)
        {
            var list = Builder<T>.CreateListOfSize(size).Build().ToList();

            return list;
        }

        public static List<Student> GetData(int size)
        {
            Random random = new Random();
            var list = GetRandomData<Student>(size);
            Parallel.ForEach(list, (item) =>
            {
                item.Id = item.Id - random.Next(-size, size) / 2 + random.Next(-size, size) + random.Next(-size, size) * 2;
                float mark = (random.Next(0, 10) / 1.0f) + 10.0f / (random.Next(0, 99) * 1.0f);
                item.AvgMark = float.Parse(String.Format("{0:0.00}", mark));
            });
            return list;
        }
        static void Main(string[] args)
        {
            
            BSTTree<Student> tree = new BSTTree<Student>();
            Run run = new Run(tree);
            run.MainPanel();
            Console.ReadLine();

        }
        
    }
}
