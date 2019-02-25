using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTree.Core
{
    class Node<T>
    {
        private static int ID = 0;

        public List<Node<T>> children = null;
        public T data;
        public int level;
        private readonly int id;

        public Node(T data)
        {
            id = ID;
            this.data = data;
            children = new List<Node<T>>();
            ID++;
        }

        public Node(Node<T> copy)
        { // TODO Children
            id = ID;
            data = copy.data;
            level = copy.level;
            children = new List<Node<T>>();
            ID++;
        }

        public Node<T> AddChild(T data)
        { // Check this
            Node<T> newChild = new Node<T>(data);
            newChild.SetLevel(level + 1);
            children.Add(newChild);
            return newChild;
        }

        public int GetId()
        {
            return id;
        }

        public void ShowData()
        {
            Console.WriteLine(string.Format("ID: {0} Level: {1}", id, level));
            //Debug.Log(string.Format("ID: {0} Level: {1}", id, level));
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }
    }
}
