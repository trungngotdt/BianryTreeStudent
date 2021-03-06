﻿
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace BSTreeStudent
{
    public class RunMain
    {
        
        public List<T> GetRandomData<T>(int size)
        {
            var list = Builder<T>.CreateListOfSize(size).Build().ToList();

            return list;
        }

        public List<Student> GetData(int size)
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

        public RunMain()
        {

        }

        private void Locator(bool isBST)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (SimpleIoc.Default.IsRegistered<ITree<Student>>())
            {
                SimpleIoc.Default.Unregister<ITree<Student>>();
            }
            if (isBST)
            {
                SimpleIoc.Default.Register<ITree<Student>, BSTTree<Student>>();
            }
            else
            {                
                SimpleIoc.Default.Register<ITree<Student>, AVLTree<Student>>();
            }

            SimpleIoc.Default.Register<RunTree>();
        }

        public void RunMainMenu()
        {
            
            int choice = 0;
            while (choice != 3)
            {
                Console.WriteLine("1/ BST \n2/ AVL");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Locator(true);
                            var run = ServiceLocator.Current.GetInstance<RunTree>();
                            run.MainPanel();
                            break;
                        case 2:
                            Locator(false);
                            var runAvl = ServiceLocator.Current.GetInstance<RunTree>();
                            runAvl.MainPanel();
                            break;
                        case 3:
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
    }
}
