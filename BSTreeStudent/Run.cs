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
        public Run(BSTTree<Student> tree)
        {
            this.tree = tree;
        }
        private BSTTree<Student> tree;

        private void MainMenu()
        {
            Console.WriteLine("1/ Traversal \n2/ Search \n3/ Insert \n4/ Remove \n5/ Get Predecessor and Get Successorr \n6/ Update " +
                "\n7/ Exit \n Enter your choice :");
        }

        public void MainPanel()
        {
            int choice = 0;
            while (choice != 7)
            {
                MainMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            TraversalPanel();
                            break;
                        case 2:
                            SearchPanel();
                            break;
                        case 3:
                            InsertPanel();
                            break;
                        case 4:
                            RemovePanel();
                            break;
                        case 5:
                            PredeSuccessorPanel();
                            break;
                        case 6:
                            UpdatePanel();
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

        #region Traversal
        private void TraversalPanel()
        {
            int choice = 0;
            while (choice != 7)
            {
                TraversalMenu();
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
                            Console.WriteLine("Please try again !");
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
        private void TraversalMenu()
        {
            Console.WriteLine("1/ LNR \n2/ LRN\n3/ NLR \n4/ RNL \n5/ NRL \n6/ RLN \n7/Exit \nEnter choice:");
        }
        #endregion

        #region Search

        private void SearchPanel()
        {
            int choice = 0;
            while (choice != 8)
            {
                string inp = null;
                SearchMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            SearchByID();
                            break;
                        case 2:
                            Console.WriteLine("Enter name of student :");
                            inp = Console.ReadLine();
                            SearchBy("Name", inp);
                            break;
                        case 3:
                            Console.WriteLine($"Enter birth day (format {DateTime.Now.ToString("MM/dd/yyyy")}):");
                            inp = Console.ReadLine();
                            SearchBy("BirthDay", inp, isDate: true);
                            break;
                        case 4:
                            Console.WriteLine("Enter mark of student :");
                            inp = Console.ReadLine();
                            SearchBy("AvgMark", inp, isNumber: true);
                            break;
                        case 5:
                            Console.WriteLine("Enter AccumulationCredit of student :");
                            inp = Console.ReadLine();
                            SearchBy("AccumulationCredit", inp, isNumber: true);
                            break;
                        case 6:
                            Console.WriteLine(tree.GetMax().Data.ToString());
                            break;
                        case 7:
                            Console.WriteLine(tree.GetMin().Data.ToString());
                            break;
                        default:
                            Console.WriteLine("Please try again !");
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

        private void SearchMenu()
        {
            Console.WriteLine("1/ By ID \n2/ By Name \n3/ By Birth day \n4/ By Avg Mark \n5/ By Accumulation Credit " +
                "\n6/ Find Maximum \n7/ Find Minimum \n8/ Exit \nEnter choice :");
        }

        private void SearchByID()
        {
            Console.WriteLine("Enter ID of student :");
            int id = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out id))
            {
                var student = tree.FindNode(new Node<Student>(new Student(id, null, DateTime.Now, 0, 0)));
                Console.WriteLine(student.Data.ToString());
                return;
            }
            Console.WriteLine("Please try again !");
            return;
        }

        private void SearchBy(string propertyName, string input, bool isNumber = false, bool isDate = false)
        {
            float num = 0;
            DateTime date = DateTime.Now;
            var checkDate = isDate ? DateTime.TryParse(input, out date) : true;
            var checkNumber = isNumber ? float.TryParse(input, out num) : true;
            if ((isNumber && !checkNumber) || (isDate && !checkDate))
            {
                Console.WriteLine("Please try again !");
                return;
            }
            input = isDate ? date.ToString() : input;
            input = isNumber ? num.ToString() : input;
            var list = tree.ToList().Where(p => p.GetType().GetProperty(propertyName).GetValue(p, null).ToString().Equals(input));
            if (list.Count() == 0)
            {
                Console.WriteLine("Empty");
                return;
            }
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
        #endregion

        #region Insert
        private void InsertMenu()
        {
            Console.WriteLine("1/ Insert a student\n2/ ??? \n3/ Exit \n Enter your choice :");
        }

        private void InsertPanel()
        {
            int choice = 0;
            while (choice != 3)
            {
                string inp = null;
                InsertMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InsertAElement();
                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("Please try again !");
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

        private void InsertAElement()
        {
            Console.WriteLine("Enter ID of student :");
            string StrId = Console.ReadLine();
            var checkId = int.TryParse(StrId, out int id);
            if (!checkId)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            Console.WriteLine("Enter name of student :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Avg Mark of student :");
            string Avg = Console.ReadLine();
            var checkMark = float.TryParse(Avg, out float avgMark);
            if (!checkMark)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            Console.WriteLine("Enter Accumulation Credit of student :");
            string accCredit = Console.ReadLine();
            //int.Parse( Console.ReadLine());
            var checkCredit = int.TryParse(accCredit, out int accumulationCredit);
            if (!checkCredit)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            Console.WriteLine($"Enter Birth Day of student (format {DateTime.Now.ToString("MM / dd / yyyy")}):");
            string birthDay = Console.ReadLine();
            var checkDate = DateTime.TryParse(birthDay, out DateTime date);
            if (!checkDate)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            var student = new Student(id, name, date, avgMark, accumulationCredit);
            tree.Insert(new Node<Student>(student));
        }
        #endregion

        #region Remove

        private void RemoveMenu()
        {
            Console.WriteLine("1/ Remove a student\n2/ ???\n3/ Exit \n Enter your choice :");
        }

        private void RemovePanel()
        {
            int choice = 0;
            while (choice != 3)
            {
                string inp = null;
                InsertMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RemoveAElement();
                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("Please try again !");
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

        private void RemoveAElement()
        {
            Console.WriteLine("Enter ID of student :");
            string StrId = Console.ReadLine();
            var checkId = int.TryParse(StrId, out int id);
            if (!checkId)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            Console.WriteLine("Enter name of student :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Avg Mark of student :");
            string Avg = Console.ReadLine();
            var checkMark = float.TryParse(Avg, out float avgMark);
            if (!checkMark)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            Console.WriteLine("Enter Accumulation Credit of student :");
            string accCredit = Console.ReadLine();
            var checkCredit = int.TryParse(accCredit, out int accumulationCredit);
            if (!checkCredit)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            Console.WriteLine($"Enter Birth Day of student (format {DateTime.Now.ToString("MM / dd / yyyy")}):");
            string birthDay = Console.ReadLine();
            var checkDate = DateTime.TryParse(birthDay, out DateTime date);
            if (!checkDate)
            {
                Console.WriteLine("Please try again !");
                return;
            }
            var student = new Student(id, name, date, avgMark, accumulationCredit);
            tree.Remove(new Node<Student>(student));
        }

        #endregion

        #region GetPredecessorAndGetSuccessor

        private void PredeSuccessorMenu()
        {
            Console.WriteLine("1/ Get Predecessor \n2/ GetSuccessor \n3/ Exit \n Enter your choice :");
        }

        private void PredeSuccessorPanel()
        {
            int choice = 0;
            while (choice != 3)
            {
                PredeSuccessorMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine((tree.Predecessor() as Node<Student>).Data.ToString());
                            break;
                        case 2:
                            Console.WriteLine((tree.Successor() as Node<Student>).Data.ToString());
                            break;
                        default:
                            break;
                    }
                }
                else
                {

                }
            }
        }

        #endregion

        #region Update

        private void UpdatePanel()
        {
            int choice = 0;
            while (choice != 8)
            {
                Node<Student> node = null;
                string inp = null;
                UpdateMenu();
                string input = Console.ReadLine();
                while (node==null)
                {
                     node=FindStudent();
                }
                //Console.WriteLine("Old data of student");
                //Console.WriteLine(node.Data.ToString());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name of student :");
                        inp = Console.ReadLine();
                        UpdateWith("Name", inp, node);
                        break;
                    case 2:
                        Console.WriteLine($"Enter birth day (format {DateTime.Now.ToString("MM/dd/yyyy")}):");
                        inp = Console.ReadLine();
                        UpdateWith("BirthDay", inp, node);
                        break;
                    case 3:
                        Console.WriteLine("Enter mark of student :");
                        inp = Console.ReadLine();
                        UpdateWith("AvgMark", inp, node);
                        break;
                    case 4:
                        Console.WriteLine("Enter AccumulationCredit of student :");
                        inp = Console.ReadLine();
                        UpdateWith("AccumulationCredit", inp, node);
                        break;
                    default:
                        Console.WriteLine("Please try again !");
                        break;
                }
            }
        }

        private void UpdateMenu()
        {
            Console.WriteLine("1/ Update Name \n2/ Birth Day \n3/ Avg Mark \n4/ Accumulation Credit \n5/ Exit \n Enter your choice :");
        }

        private Node<Student> FindStudent()
        {
            Console.WriteLine("Enter ID of student :");
            int id = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out id))
            {
                var student = tree.FindNode(new Node<Student>(new Student(id, null, DateTime.Now, 0, 0)));
                Console.WriteLine(student.Data.ToString());
                return student;
            }
            Console.WriteLine("Please try again !");
            return null;

        }

        private void UpdateWith(string propertyName,string data,Node<Student> node)
        {
            object value;
            if (propertyName.Equals("Name"))
            {
                value = data;
            }
            else if(propertyName.Equals("AvgMark"))
            {
                if (!float.TryParse(data, out float avg))
                {
                    Console.WriteLine("Please try again !");
                    return;
                }
                value = avg;
            }
            else if(propertyName.Equals("AccumulationCredit"))
            {
                if (!int.TryParse(data,out int credit))
                {
                    Console.WriteLine("Please try again !");
                    return;
                }
                value = credit;
            }
            else if(propertyName.Equals("BirthDay"))
            {
                if (!DateTime.TryParse(data,out DateTime date))
                {
                    Console.WriteLine("Please try again !");
                    return;
                }
                value = date;
            }
            else
            {
                Console.WriteLine("Please try again !");
                return;
            }
            var propInfo = node.Data.GetType().GetProperty(propertyName);
            propInfo.SetValue(node.Data,Convert.ChangeType( value,propInfo.PropertyType),null);//.GetValue(node.Data, null)="";
        }
        #endregion

    }
}
