using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSTreeGenericClass;
using System.Text.RegularExpressions;

namespace BSTreeStudent
{
    class Program
    {
        class Stu:IComparable
        {
            private int id;
            private int mark;

            public int Id { get => id; set => id = value; }
            public int Mark { get => mark; set => mark = value; }

            public int CompareTo(object obj)
            {
                try
                {
                    var node = obj as Stu;
                    return this.Id.CompareTo(node.Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        static void Main(string[] args)
        {
            //TraversalMenu();
            var stu1 = new Student(51503000, "A", DateTime.Now, 0, 0);
            //var stu1 = new Student(51503000, "A", DateTime.Now, 0, 0);
            int j = 0;
            Console.WriteLine("Nhap");
            string a = Console.ReadLine();
            Regex regex = new Regex("[0-9]+");
            Match match = regex.Match(a);
            //var d = DateTime.ParseExact(a, "dd-MM-yyyy",null);
            Console.WriteLine("end");
            Console.ReadLine();
            
        }

        public void MainMenu()
        {
            
        }

        public static void TraversalMenu()
        {
            Console.WriteLine("1/ LNR \n2/ LRN\n3/ NLR \n4/ RNL \n5/ NRL \n6/ RLN \n7/Exit \nEnter choice:");
        }

        static List<Stu> GetList()
        {
            List<Stu> list = new List<Stu>();
            Parallel.For(0, 500000, i => { });
            Parallel.For(-5000, 0, j => {  list.Add(new Stu() { Id = j, Mark = j });});
            return list;

        }

        static async void ListkAsync()
        { BSTTree<Stu> tree = new BSTTree<Stu>();
            Stu stua = null;
            Console.WriteLine("B");
            List<int> list = new List<int>();
            Console.WriteLine("C");
            await Task.WhenAll(new Task[] { listAsync(list) });
            //list = await listAsync();
            Console.WriteLine(list.Count);
            Console.WriteLine("D");
            Console.WriteLine("A");
            Stu stu = new Stu();
            Console.ReadLine();
        }

        static async Task<List<int>> listAsync(List<int> list)
        {
            
            Task task = Task.Factory.StartNew(()=>{
                for (int i = 0; i < 50; i++)
                {
                    list.Add(i);
                }
            });
            await Task.WhenAll(new Task[] { task });
            return list;
        }
    }
}
