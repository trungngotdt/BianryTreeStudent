using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTreeGenericClass
{
    public static class BSTTreeExtension
    {
        private static void ToList<T>(this BSTTree<T> tree, Node<T> node, List<T> list) where T : class, IComparable, new()
        {
            if (node == null)
            {
                return;
            }
            ToList(tree, node.Left, list);
            list.Add(node.Data);
            ToList(tree, node.Right, list);
        }

        /// <summary>
        /// A List with element from minimum to maximum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this BSTTree<T> tree) where T : class, IComparable, new()
        {
            List<T> list = new List<T>();
            ToList(tree, tree.root, list);
            return list;
        }
    }
}
