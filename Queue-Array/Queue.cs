using System;
using System.Collections.Generic;
using System.Text;

namespace Queue_Array
{
    public class Queue<T>
    {
        public int Count { get; private set; }
        private T[] data;
        private int headIndex;
        private int tailIndex;

        public Queue()
        {
            data = new T[5];
            tailIndex = -1;
            headIndex = -1;
            Count = 0;
        }

        public bool IsEmpty() => Count == 0;
        public void Clear()
        {
            data = new T[5];
        }
        public T Peek()
        {
            return data[headIndex];
        }
        public void Enqueue(T value)
        {
            if(Count >= data.Length) 
            {
                reSize(data.Length * 2);
            }
            if (Count == 0)
            {
                headIndex = 0;
                tailIndex = headIndex;
            }
            
            data[Count] = value;
            
            tailIndex = Count;

            Count++;
        }
        public T Dequeue()
        {
            if(Count <= data.Length / 4)
            {
                reSize(data.Length / 2);
            }
            T temp = data[headIndex % data.Length];
            headIndex++;
            Count--;
            return temp;
        }
        public void reSize(int length)
        {
            T[] temp = new T[length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = data[(headIndex + i) % data.Length];
            }
            headIndex = 0;
            data = temp;
        }
      
    }
}
