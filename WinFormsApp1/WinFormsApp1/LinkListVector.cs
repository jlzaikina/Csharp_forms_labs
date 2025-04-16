using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class LinkListVector : IVectorable
    {
        public Node begin;
        public class Node
        {
            public Node next = null;
            double element;

            public double Element
            {
                get { return element; }
                set { element = value; }
            }
            public Node()
            {

            }
            public Node(int element, Node next)
            {
                this.element = element;
                this.next = next;
            }
        }
        public int Length
        {
            get
            {
                int n = 0;
                Node node = begin;
                while (node != null)
                {
                    node = node.next;
                    n++;
                }
                return n;
            }
        }
        public LinkListVector(int i)
        {
            if (i > 0)
            {
                begin = new Node();
                Node b = begin;
                for (int z = 1; z < i; z++)
                {
                    b.next = new Node();
                    b = b.next;
                }
            }
            else
            {
                throw new Exception("Недопустимая длина");
            }
        }
        public LinkListVector()
        {
            begin = new Node();
            Node b = begin;
            for (int i = 1; i < 6; i++)
            {
                b.next = new Node();
                b = b.next;
            }
        }
        public double this[int i]
        {
            get
            {
                Node b = begin;
                if (i > 0 && i <= Length)
                {
                    for (int j = 1; j < i; j++)
                    {
                        b = b.next;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                return b.Element;
            }
            set
            {
                Node b = begin;
                for (int j = 0; j < i; j++)
                {
                    b = b.next;
                }
                b.Element = value;
            }
        }
        public double GetNorm()
        {
            double mod = 0;
            Node b = begin;
            while (b != null)
            {
                mod = mod + Math.Pow(b.Element, 2);
                b = b.next;
            }
            mod = Math.Sqrt(mod);
            return mod;
        }
        public override string ToString()
        {
            Node node = begin;
            string str = " ";
            while (node != null)
            {
                str = str + node.Element + "\t";
                node = node.next;
            }
            return str;
        }
        public override bool Equals(object obj)
        {
            if (ToString() == obj.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public int CompareTo(Object obj)
        {
            IVectorable v = obj as IVectorable;
            if (v != null)
            {
                if (v.Length < Length)
                    return -1;
                else if (v.Length > Length)
                    return 1;
                else return 0;
            }
            else
                throw new Exception();
        }
        public object Clone()
        {
            LinkListVector l = new LinkListVector(this.Length);
            int i = 0;
            for (Node node = begin; node != null; node = node.next)
            {
                l[i] = node.Element;
                i++;
            }
            return l;

        }
    }
}
