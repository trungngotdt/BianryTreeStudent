using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BSTreeGenericClass;

namespace BSTreeStudent
{
    public class Run
    {
        public Run()
        {
            tree = new BSTTree<Student>();
        }

        private BSTTree<Student> tree;

        #region Traversal
        public void TraversalPanel()
        {
            int choice = 0;
            while (choice!=7)
            {
                TraversalMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input,out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            tree.LNR();
                            break;
                        case 2:
                            tree.LRN();
                            break;
                        case 3:
                            tree.NLR();
                            break;
                        case 4:
                            tree.RNL();
                            break;
                        case 5:
                            tree.NRL();
                            break;
                        case 6:
                            tree.RLN();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please try again !");
                    continue;
                }
            }
        }
        public void TraversalMenu()
        {
            Console.WriteLine("1/ LNR \n2/ LRN\n3/ NLR \n4/ RNL \n5/ NRL \n6/ RLN \n7/Exit \nEnter choice:");
        }
        #endregion

        #region Search

        public void SearchPanel()
        {
            int choice = 0;
            while (choice != 8)
            {
                SearchMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            tree.LNR();
                            break;
                        case 2:
                            tree.LRN();
                            break;
                        case 3:
                            tree.NLR();
                            break;
                        case 4:
                            tree.RNL();
                            break;
                        case 5:
                            tree.NRL();
                            break;
                        case 6:
                            tree.RLN();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please try again !");
                    continue;
                }
            }
        }

        public void SearchMenu()
        {
            Console.WriteLine("1/ By ID \n2/By Name \n3/ By Birth day \n4/ By Avg Mark \n5/ By Accumulation Credit " +
                "\n6/ Find Maximum \n7/ Find Minimum \n8/ Exit \nEnter choice :");
        }

        public void SearchByID()
        {
            Console.WriteLine("Enter ID of student :");
            int id = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input,out id))
            {
                var student = tree.FindNode(new Node<Student>(new Student(id, null, DateTime.Now, 0, 0)));
                Console.WriteLine(student.Data.ToString());
                return;
            }
            Console.WriteLine("Please try again !");
            return;
        }
        #endregion

    }
}
