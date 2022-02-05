using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class PriorityQueue
    {
        private List<int> heap;
        private Func<int, int, bool> Comparator;
        public PriorityQueue(Func<int, int, bool> comparator)
        {
            heap = new List<int>();
            Comparator = comparator;
        }

        public int Size()
        {
            return heap.Count;
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        public int Peek()
        {
            return heap[0];
        }

        public int Push(int val)
        {
            try
            {
                heap.Add(val);
                RebuildHeapForPush();
            }
            catch (Exception)
            {
                Console.WriteLine("Could nott add ");
            }
            return Size();
        }

        public int Pop()
        {
            int valToReturn = Peek(); ;
            int lastVal = heap[Size() - 1];
            heap.RemoveAt(Size() - 1);
            if (Size() > 0)
            {
                heap.RemoveAt(0);
                heap.Insert(0, lastVal);
                RebuildHeapForPop();
            }
            return valToReturn;
        }

        private void RebuildHeapForPop()
        {
            int parentIndex = 0;
            int leftChildIndex = parentIndex * 2 + 1;
            int rightChildIndex = parentIndex * 2 + 2;

            while (leftChildIndex < heap.Count || rightChildIndex < heap.Count)
            {
                if (Comparator(heap[leftChildIndex], heap[parentIndex]) && (rightChildIndex >= heap.Count || Comparator(heap[leftChildIndex], heap[rightChildIndex])))
                {
                    Swap(leftChildIndex, parentIndex);
                    parentIndex = leftChildIndex;
                }
                else if (rightChildIndex < heap.Count && Comparator(heap[rightChildIndex], heap[parentIndex]) && Comparator(heap[rightChildIndex], heap[leftChildIndex]))
                {
                    Swap(rightChildIndex, parentIndex);
                    parentIndex = rightChildIndex;
                }
                else
                {
                    break;
                }

                leftChildIndex = parentIndex * 2 + 1;
                rightChildIndex = parentIndex * 2 + 2;
            }
        }

        private void RebuildHeapForPush()
        {
            int childIndex = heap.Count - 1;
            int parentIndex = (int)Math.Floor((decimal)(childIndex - 1) / 2);
            while (parentIndex >= 0 && Comparator(heap[childIndex], heap[parentIndex]))
            {
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
                parentIndex = (int)Math.Floor((decimal)(childIndex - 1) / 2);
            }
        }

        private void Swap(int childIndex, int parentIndex)
        {
            int tmp = heap[parentIndex];
            heap[parentIndex] = heap[childIndex];
            heap[childIndex] = tmp;
        }

        public void Print()
        {
            Console.WriteLine();
            foreach (var item in heap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
