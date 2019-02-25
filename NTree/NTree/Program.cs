using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTree.Core;

namespace NTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Node arrel
            Node<int> nodeArrel = new Node<int>(0);

            // Arbre 
            NTree<int> nTree = new NTree<int>(nodeArrel);

            // Modificacions al arbre
            nTree.Add(nodeArrel, 1);

            // Mostra contingut
            nTree.ShowTree();

            Console.ReadLine();
        }
    }
}
