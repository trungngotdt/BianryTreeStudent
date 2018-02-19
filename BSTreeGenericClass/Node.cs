using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTreeGenericClass
{
    public class Node<T> :IComparable where T : class,
        IComparable, new()
    {
        private T data;
        private Node<T> left;
        private Node<T> right;
        
        public T Data { get => data; set => data = value; }
        public Node<T> Left { get => left; set => left = value; }
        public Node<T> Right { get => right; set => right = value; }

        public Node()
        {
            this.data = null;
            this.left = null;
            this.right = null;
        }

        public Node(T data, Node<T> nodeChild, Node<T> nodeChild2)
        {
            this.Data = data;
            
            if (nodeChild.CompareTo(this) == 0)
            {
                this.Left = nodeChild;
                this.Right = null;
            }
            else if(nodeChild2.CompareTo(this)==0)
            {
                this.Left = nodeChild;
            }
            else if (nodeChild < this)
            {
                this.Left = nodeChild;
                this.Right = nodeChild2;
            }
            else if (nodeChild > this)
            {
                this.Left = nodeChild2;
                this.Right = nodeChild;
            }
        }

        public Node(T data,Node<T> node)
        {
            this.Data = data;
            if (node>this)
            {
                this.Right = node;
                this.Left = null;
            }
            else if(node<this)
            {
                this.Left = node;
                this.Right = null;
            }
        }

        public Node(T data)
        {
            this.Data = data;
            this.Left = null;// Letf is DBNull ? (T)dbNull : default(T);
            this.Right = null;
        }


        public Node(T data, int size)
        {
            this.Data = data;
            this.Left = null;// Letf is DBNull ? (T)dbNull : default(T);
            this.Right = null;
        }

        public Node(Node<T> node)
        {
            this.Data = node.Data;
            this.Left = node.Left;
            this.Right = node.Right;
        }

        public int CompareTo(object obj)
        {
            try
            {
                Node<T> node = obj as Node<T>;
                return this.Data.CompareTo(node.Data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
        public static bool operator <(Node<T> node, Node<T> node2)
        {
            return node.Data.CompareTo(node2.Data) < 0;
        }
        public static bool operator >(Node<T> node, Node<T> node2)
        {
            return node.Data.CompareTo(node2.Data) > 0;
        }
    }
}
