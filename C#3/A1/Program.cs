using System;
using System.Collections.Generic;
using System.Linq;
namespace LIST
{

    internal class Progrem
    {
        public delegate double DeleOne(double t1, double t2);

        class Node<T>
        {
            public Node<T> Next { get; set; }
            public T data { get; set; }
            public Node(T t)
            {
                data = t;
                Next = null;
            }
        }
        class List<T> where T : IComparable
        {
            private Node<T> Head;
            private Node<T> Tail;
            public List()
            {
                Head = Tail = null;
            }
            public Node<T> getHead()
            {
                return Head;
            }
            public void ADD(T t)
            {
                Node<T> node = new Node<T>(t);
                if (Head == null)
                {
                    Head = Tail = node;
                }
                else
                {
                    Tail.Next = node;
                    Tail = node;
                }
            }
            public void ForeachList()
            {
                DeleOne sum = (double t1, double t2) =>
                {
                    return t1 + t2;
                };
                Node<T> head = getHead();
                Node<T> p = head;
                T min = head.data;
                T max = head.data;
                double total = 0;
                while (p != null)
                {
                    if (p.data.CompareTo(max) > 0)
                    {
                        max = p.data;
                    }
                    if (p.data.CompareTo(min) < 0)
                    {
                        min = p.data;
                    }
                    total = sum(total, double.Parse(p.data.ToString()));
                    p = p.Next;
                }
                Console.WriteLine(max.ToString());
                Console.WriteLine(min.ToString());
                Console.WriteLine(total.ToString());
            }
        }
        static void Main(string[] args)
        {
            List<double> list = new List<double>();
            list.ADD(1);
            list.ADD(2);
            list.ForeachList();

        }
    }
}