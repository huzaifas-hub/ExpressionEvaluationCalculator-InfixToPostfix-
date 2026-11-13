using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace expressionEvaluator
{
   public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node (T data)
        {
            Data = data;
            Next = null;
        }

    }
    public class Stack<T>
    {
        private Node<T> top;
        private int count;
        public Stack()
        {
            top = null;
            count = 0;
        }
        public bool IsEmpty()
        {
         return top == null;
        }
        public int Count
        {
           get { return count; }
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
            count++;
        }
        public T Pop()
        {
          if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot pop because the stack is empty.");
            }
            else
            {
                T poppedData = top.Data;
                top = top.Next;
                count--;
                return poppedData;
            }
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek the stack is empty.");
            }
           return top.Data;
        }


    }

  
}