using BSTreeStudent;
using FizzWare.NBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace TestBSTreeStudent
{
    [TestFixture]
    public class TestAVLTreeClass
    {
        AVLTree<Student> tree;
        List<Student> listStu;
        private int size = 20;
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

        [SetUp]
        public void SetUp()
        {

            tree = new AVLTree<Student>();
            listStu = GetData(size);
        }

        [Test]
        public void AddTest()
        {
            List<Node<Student>> listStudent = new List<Node<Student>>();
            foreach (var item in listStu)
            {
                listStudent.Add(new Node<Student>(item));
            }
            tree.AddRange(listStudent.ToArray());
            Student student = null;
            tree.Insert(student);
            tree.Insert(new Node<Student>(listStu[10]));
            Assert.IsTrue(tree.ToList().Count <= listStu.Count);
            Assert.NotNull(tree.root);
        }

        [Test]
        public void FindNodeTest()
        {
            tree.AddRange(listStu.ToArray());
            var list = tree.ToList();
            Parallel.ForEach(list, (item) =>
            {
                Assert.NotNull(tree.FindNode(item));
            });
            var node = new Node<Student>();
            node = null;
            Assert.Null(tree.FindNode(node));
            Assert.Null(tree.FindNode(new Student(-size * 20, "A", DateTime.Now, 1.0f, 0)));
        }

        [Test]
        public void ToListTest()
        {
            tree.AddRange(listStu.ToArray());
            var list = tree.ToList();
            Assert.IsTrue(list.Count >= 0);
        }

        [Test]
        public void ContainsTest()
        {
            tree.AddRange(listStu.ToArray());
            var list = tree.ToList();
            Parallel.ForEach(list, (item) =>
            {
                Assert.NotNull(listStu.Where(p => p.Id == item.Id));
            });
        }

        [Test]
        public void MaxMinTest()
        {
            tree.AddRange(listStu.ToArray());
            var max = tree.GetMax();
            var min = tree.GetMin();
            Assert.AreEqual(max.Data, listStu.Max());
            Assert.AreEqual(min.Data, listStu.Min());
        }

        [Test]
        public void PredecessorSuccessorTest()
        {
            tree.AddRange(listStu.ToArray());
            var prec = tree.Predecessor();
            var succ = tree.Successor();
            var min = tree.GetMin(tree.root.Right).Data;
            var max = tree.GetMax(tree.root.Left).Data;
            Assert.AreEqual(min, (succ as Node<Student>).Data);
            Assert.AreEqual(max, (prec as Node<Student>).Data);
        }

        [Test]
        public void RemoveTest()
        {
            tree.AddRange(listStu.ToArray());
            Assert.IsTrue(tree.ToList().Count <= listStu.Count);
            Student stu = null;
            var list = new List<Student>(tree.ToList());
            foreach (var item in list)
            {

                var check = tree.Remove(item);
                var checkContains = tree.Contains(new Node<Student>( item));
                Assert.IsFalse(checkContains);
            }
        }

        [Test]
        public void RemovRangeeTest()
        {
            tree.AddRange(listStu.ToArray());
            Assert.IsTrue(tree.ToList().Count <= listStu.Count);
            Student stu = null;
            var list = new List<Student>(tree.ToList());
            List<Node<Student>> listStudent = new List<Node<Student>>();
            foreach (var item in list)
            {
                listStudent.Add(new Node<Student>( item));
            }

            tree.RemoveRange(listStudent.ToArray());
        }


        [Test]
        public void RemoveMin()
        {
            tree.AddRange(listStu.ToArray());
            var min = tree.GetMin();
            var Removemin = tree.RemoveMin();
            var checkRemove = tree.Contains(new Node<Student>(min));
            Assert.IsFalse(checkRemove);
        }

        [Test]
        public void FindParentTest()
        {
            tree.AddRange(listStu.ToArray());
            var parent = tree.FindParent(listStu[10]);
            Assert.AreEqual(parent.Item2 > 0 ? parent.Item1.Right.Data : parent.Item1.Left.Data, listStu[10]);
        }

        [Test]
        public void TraTraversal()
        {
            int bug = 0;
            try
            {
                tree.AddRange(listStu.ToArray());
                tree.LNR();
                tree.LRN();
                tree.NLR();
                tree.NRL();
                tree.RLN();
                tree.RNL();
            }
            catch (Exception ex)
            {
                if (ex!=null)
                {
                    bug++;
                }
            }
            finally
            {
                Assert.AreEqual(0, bug);
            }
        }
    }
}
