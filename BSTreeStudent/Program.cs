using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSTreeGenericClass;
using System.Text.RegularExpressions;
using FizzWare.NBuilder;

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
            //TraversalMenu();
            BSTTree<Student> tree = new BSTTree<Student>();
            Run run = new Run(tree);

            var listStu = GetData(size);
            tree.AddRange(listStu.ToArray());
            run.MainPanel();
            Console.ReadLine();

        }

        public void MainMenu()
        {
            var stu1 = new Student(51503000, "A", DateTime.Now, 0, 0);
            //var stu1 = new Student(51503000, "A", DateTime.Now, 0, 0);
            int j = 0;
            Console.WriteLine("Nhap");
            string a = Console.ReadLine();
            Regex regex = new Regex("[0-9]+");
            Match match = regex.Match(a);
            //var d = DateTime.ParseExact(a, "dd-MM-yyyy",null);
            Console.WriteLine("end");

        }

        public static void TraversalMenu()
        {
            Console.WriteLine("1/ LNR \n2/ LRN\n3/ NLR \n4/ RNL \n5/ NRL \n6/ RLN \n7/Exit \nEnter choice:");
        }
        
    }
}
