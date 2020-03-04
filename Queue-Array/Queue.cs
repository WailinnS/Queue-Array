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
            tailIndex = 0;
            headIndex = 0;
            Count = 0;
        }

        public void Enqueue(T value)
        {
            if(Count >= data.Length) 
            {
                increaseSize();
            }
            if (Count == 0)
            {
                headIndex = Count;
                tailIndex = headIndex;
            }
            
            data[Count] = value;
            
            tailIndex = Count;

            Count++;
        }
        public T Dequeue()
        {
            T temp = data[headIndex % data.Length - 1];
            headIndex++;
            return temp;
        }
        public void increaseSize()
        {
            T[] temp = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                temp[i] = data[(headIndex + i) % data.Length-1];
            }
            data = temp;
        }
        public void decreaseSize()
        {
            T[] temp = new T[data.Length / 2];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = data[i];
            }
            data = temp;
        }
    }
}
