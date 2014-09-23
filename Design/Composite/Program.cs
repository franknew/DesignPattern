using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = InitTree();
            tree.Print();

            Console.ReadLine();
        }

        private static Tree InitTree()
        {
            Tree tree = new Tree("root");

            Tree subTree = new Tree("subtree");

            Tree subsubTree = new Tree("subsubTree");
            subsubTree.Add(new Leaf("subsubleaf1"));

            subTree.Add(new Leaf("subleaf1"));
            subTree.Add(new Leaf("subleaf2"));
            subTree.Add(subsubTree);

            tree.Add(new Leaf("leaf1"));
            tree.Add(new Leaf("leaf2"));
            tree.Add(subTree);
            tree.Add(new Leaf("leaf3"));
            return tree;
        }
    }

    public abstract class Node
    {
        public Node(string name)
        {
            this.name = name;
        }

        public List<Node> _tree = new List<Node>();

        public abstract void Print(string level);

        public string name;
    }

    public class Tree : Node
    {

        public Tree(string name)
            : base(name)
        {
            this.name = name;
        }

        public void Add(Node node)
        {
            _tree.Add(node);
        }

        public void Remove(Node node)
        {
            _tree.Remove(node);
        }

        public void Remove(string name)
        {
            _tree.ForEach(t =>
            {
                if (t.name == name)
                {
                    _tree.Remove(t);
                    return;
                }
            });
        }

        public override void Print(string level)
        {
            Console.WriteLine("tree name:{0}{1}", level, this.name);
            _tree.ForEach(t =>
            {
                t.Print(" " + level);
            });
        }

        public void Print()
        {
            this.Print("");
        }
    }

    public class Leaf : Node
    {
        public Leaf(string name)
            : base(name)
        {
            this.name = name;
        }

        public override void Print(string level)
        {
            Console.WriteLine("leaf name:{0}{1}", level, this.name);
        }
    }
}
