﻿using System;
using NUnit.Framework;
using BSTreeStudent;
using BSTreeGenericClass;
using FizzWare.NBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBSTreeStudent
{
    [TestFixture]
    public class TestBSTreeLibrary
    {
        BSTTree<Student> tree;
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
                item.AvgMark = random.Next(0, 10) / 1.0f;
            });
            return list;
        }
        [SetUp]
        public void SetUp()
        {

            tree = new BSTTree<Student>();
            listStu = GetData(size);
        }

        [Test]
        public void AddTest()
        {
            tree.AddRange(listStu.ToArray());
            tree.Insert(null);
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
            Assert.AreEqual(tree.GetMin(tree.root.Right).Data, (succ as Node<Student>).Data);
            Assert.AreEqual(tree.GetMax(tree.root.Left).Data, (prec as Node< Student>).Data);
        }

        [Test]
        public void RemoveTest()
        {
            tree.AddRange(listStu.ToArray());
            var check= tree.Remove(listStu[10]);
            Assert.IsTrue(check);
            Assert.IsFalse(tree.Contains(listStu[10]));
        }

        [Test]
        public void FindParentTest()
        {
            tree.AddRange(listStu.ToArray());
            var parent = tree.FindParent(listStu[10]);
            Assert.AreEqual(parent.Item2 > 0 ? parent.Item1.Right.Data : parent.Item1.Left.Data, listStu[10]);
        }
    }
}