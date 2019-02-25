using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTree.Core
{
    class NTree<T>
    {
        private Node<T> root;

        public NTree(Node<T> root)
        {
            this.root = root;
            this.root.SetLevel(0);
        }

        public NTree(T root)
        {
            this.root = new Node<T>(root);
            this.root.SetLevel(0);
        }

        #region Public
        public Node<T> Add(Node<T> root, T child)
        {
            return root.AddChild(child);
        }

        public void Add(Node<T> root, List<T> children)
        {
            foreach (T data in children)
            {
                root.AddChild(data);
            }
        }

        public void AddHierarchy(Node<T> root, List<T> children)
        {
            foreach (T data in children)
            {
                root = root.AddChild(data);
            }
        }

        public void DeleteById(int id)
        {
            if (id < 0)
            {
                return;
            }

            Node<T> found = SearchById(id);

            if (found != null)
            {
                Delete(found);
            }
        }

        public Node<T> GetNodeById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            else
            {
                return SearchById(id);
            }
        }

        public Node<T> Find(T toSearch)
        {
            return SearchBy(toSearch);
        }

        public bool IsEmpty()
        {
            return root.children.Count == 0;
        }

        public bool Contains(T data)
        {
            return SearchBy(data) != null;
        }

        public Node<T> GetRoot()
        {
            return root;
        }

        public List<T> ToList()
        {
            List<Node<T>> result = new List<Node<T>>();
            ToListAux(root, result);
            //ShowTree();
            return result.OrderBy(item => item.level).Select(item => item.data).ToList();
        }
        #endregion

        #region Private
        private Node<T> SearchById(int id)
        {
            return AuxSearchById(root, id);
        }

        private Node<T> SearchBy(T toSearch)
        {
            return AuxSearchBy(root, toSearch);
        }

        private void Delete(Node<T> next)
        {

            /* if(next) {

             }*/

            /*
            if(next.children.Count != 0) {
                foreach (Node<T> node in next.children) {
                    Delete(node);                    
                    //node.father = null;
                    node.children = null;
                }
                
                //next.father.children.Remove(next);
                //next.children.Clear();
                //next.children = null;
                next = null;
            }*/
        }
        #endregion

        #region Helpers
        private Node<T> AuxSearchById(Node<T> next, int id)
        {
            Node<T> found = null;
            if (next.GetId() == id)
            {  // next.GetData().GetId() == id
                return next;
            }
            else if (next.children.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (Node<T> node in next.children)
                {
                    found = AuxSearchById(node, id);
                    if (found != null)
                    {
                        break;
                    }
                }
                return found;
            }
        }

        private Node<T> AuxSearchBy(Node<T> next, T toSearch)
        {
            Node<T> found = null;
            if (next.data.Equals(toSearch))
            {  // next.GetData().GetId() == id
                return next;
            }
            else if (next.children.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (Node<T> node in next.children)
                {
                    found = AuxSearchBy(node, toSearch);
                    if (found != null)
                    {
                        break;
                    }
                }
                return found;
            }
        }
        #endregion

        #region Utils
        public bool ExistById(int id)
        {
            if (id < 0)
            {
                return false;
            }

            Node<T> found = SearchById(id);

            if (found != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowTree()
        { // Temp
            AuxShowTree(root);
        }

        // Preorder iteration
        private void AuxShowTree(Node<T> nextNode)
        {
            nextNode.ShowData();
            if (nextNode.children.Count != 0)
            {
                foreach (Node<T> node in nextNode.children)
                {
                    AuxShowTree(node);
                }
            }
        }

        private void ToListAux(Node<T> root, List<Node<T>> result)
        {
            result.Add(root);
            if (root.children.Count != 0)
            {
                foreach (Node<T> node in root.children)
                {
                    ToListAux(node, result);
                }
            }
        }
        #endregion
    }
}
