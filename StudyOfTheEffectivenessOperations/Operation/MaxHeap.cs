using System;

public class MaxHeap
{
    private int[] heap;
    private int size;
    private int maxSize;

    public MaxHeap(int maxSize)
    {
        this.maxSize = maxSize;
        size = 0;
        heap = new int[maxSize + 1];
        heap[0] = int.MaxValue;
    }

    private int Parent(int pos)
    {
        return pos / 2;
    }

    private int LeftChild(int pos)
    {
        return (2 * pos);
    }

    private int RightChild(int pos)
    {
        return (2 * pos) + 1;
    }

    private bool IsLeaf(int pos)
    {
        return pos > (size / 2) && pos <= size;
    }

    private void Swap(int fpos, int spos)
    {
        int tmp;
        tmp = heap[fpos];
        heap[fpos] = heap[spos];
        heap[spos] = tmp;
    }

    private void MaxHeapify(int pos)
    {
        if (IsLeaf(pos))
        {
            return;
        }

        if (heap[pos] < heap[LeftChild(pos)] || heap[pos] < heap[RightChild(pos)])
        {
            if (heap[LeftChild(pos)] > heap[RightChild(pos)])
            {
                Swap(pos, LeftChild(pos));
                MaxHeapify(LeftChild(pos));
            }
            else
            {
                Swap(pos, RightChild(pos));
                MaxHeapify(RightChild(pos));
            }
        }
    }

    public void Insert(int element)
    {
        heap[++size] = element;

        int current = size;
        while (heap[current] > heap[Parent(current)])
        {
            Swap(current, Parent(current));
            current = Parent(current);
        }
    }

    public void Print()
    {
        int height = (int)Math.Ceiling(Math.Log(size, 2));
        int maxNodes = (int)Math.Pow(2, height) - 1;
        int currentHeight = 1;
        int levelNodes = 1;
        int nodesPrinted = 0;
        int spaceLength = 4 * (maxNodes / 2);

        for (int i = 1; i <= size; i++)
        {
            if (currentHeight == 1)
            {
                Console.Write(string.Format("{0,4}", heap[i]));
                nodesPrinted++;
                if (nodesPrinted == levelNodes)
                {
                    Console.WriteLine();
                    currentHeight++;
                    nodesPrinted = 0;
                    levelNodes *= 2;
                    spaceLength /= 2;
                }
            }
            else
            {
                int spacesBetweenNodes = spaceLength / levelNodes;
                int spacesBeforeNode = spacesBetweenNodes / 2;
                int spacesAfterNode = spacesBeforeNode + 1;

                Console.Write(string.Format("{0," + spacesBeforeNode + "}", ""));
                Console.Write("__");
                Console.Write(string.Format("{0," + spacesAfterNode + "}", ""));

                nodesPrinted++;
                if (nodesPrinted == levelNodes)
                {
                    Console.WriteLine();
                    currentHeight++;
                    nodesPrinted = 0;
                    levelNodes *= 2;
                    spaceLength /= 2;
                }
            }
        }
    }
}

//class Program
//{
//    static void Main(string[] args)
//    {
//        MaxHeap maxHeap = new MaxHeap(
