using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.Operation.BidirectionaListOperation
{
    public class Node
    {
        public int value;
        public Node next;
        public Node prev;

        public Node(int val)
        {
            value = val;
            next = null;
            prev = null;
        }
    }

    public class BidirectionaListOperation
    {
        private Node head;
        private Node tail;
        private int count;
        private Random random;

        public BidirectionaListOperation()
        {
            head = null;
            tail = null;
            count = 0;
            random = new Random();
            Run();
        }

        public void Run()
        {

            for (int i = 0; i < 50; i++)
            {
                int number = random.Next(0, 100001);
                AddToEnd(number);
            }

            Node current = head;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
        }
        public void AddToBeginning(int number)
        {
            Node newNode = new Node(number);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            count++;
        }

        public void AddToEnd(int number)
        {
            Node newNode = new Node(number);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            count++;
        }

        public void AddAtRandom(int number)
        {
            int index = random.Next(0, count + 1);
            if (index == 0)
            {
                AddToBeginning(number);
            }
            else if (index == count)
            {
                AddToEnd(number);
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                Node newNode = new Node(number);
                newNode.next = current.next;
                newNode.prev = current;
                current.next.prev = newNode;
                current.next = newNode;
                count++;
            }
        }

        public void RemoveFromBeginning()
        {
            if (head == null)
            {
                return;
            }
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
                head.prev = null;
            }
            count--;
        }

        public void RemoveFromEnd()
        {
            if (tail == null)
            {
                return;
            }
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            count--;
        }

        public void RemoveAtRandom()
        {
            int index = random.Next(0, count);
            if (index == 0)
            {
                RemoveFromBeginning();
            }
            else if (index == count - 1)
            {
                RemoveFromEnd();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                current.prev.next = current.next;
                current.next.prev = current.prev;
                count--;
            }
        }
    }

}
