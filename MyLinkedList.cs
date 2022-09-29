using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab1
{
    public class Node<T>
    {
        public T item;
        public Node<T> next;
        public Node()
        {
            this.next = null;
        }
    }

    internal class MyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public MyLinkedList()
        {
            this.Head = null;
        }


        public void AddHead(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.item = item;
            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {
                newNode.next = Head;
                this.Head = newNode;
            }
        }

        public void AddTail(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.item = item;
            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {
                Node<T> temp = this.Head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }
        }

        public void DeleteNode(T item)
        {
            if (this.Head.item.Equals(item))
                Head = Head.next;
            else
            {
                Node<T> temp = Head;
                Node<T> tempPre = Head;
                bool matched = false;
                while (!(matched = temp.item.Equals(item)) && temp.next != null)
                {
                    tempPre = temp;
                    temp = temp.next;
                }
                if (matched)
                    tempPre.next = temp.next;
                else
                    Console.WriteLine("Value not found!");
            }
        }

        public bool SearchNode(T item)
        {
            Node<T> temp = this.Head;
            bool matched = false;
            while (!(matched = temp.item.Equals(item)) && temp.next != null)
                temp = temp.next;
            return matched;

        }
        public void DisplayList()
        {
            Console.WriteLine("Displaying List!");
            Node<T> temp = this.Head;
            while (temp != null)
            {
                Console.WriteLine(temp.item);
                temp = temp.next;
            }
        }
    }
}
