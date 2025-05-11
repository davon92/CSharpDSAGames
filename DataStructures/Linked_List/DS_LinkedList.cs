using System.Collections.Generic;
namespace DataStructures
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class DS_LinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public List<T> ToList()
        {
            var list = new List<T>();
            var currentNode = _head;
            while (currentNode != null)
            {
                list.Add(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return list;
        }
        
        public void Add(T item)
        {
            var newNode = new Node<T>{Data=item};
            if (_head == null)
            {
                _head = newNode;
                _tail = _head;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
        }

        public bool Remove(T item)
        {
            Node<T> currentNode = _head;
            Node<T> previousNode = null;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    if (previousNode == null)
                    {
                        _head = currentNode.Next;

                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;

                        if (currentNode == _tail)
                        {
                            _tail = previousNode;
                        }
                    }
                    return true; // Move return OUTSIDE of else block
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        public void RemoveAll(T item)
        {
            Node<T> currentNode = _head;
            Node<T> previousNode = null;
            
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    if (previousNode == null)
                    {
                        _head= currentNode.Next;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;
                    }

                    if (currentNode == _tail)
                    {
                        _tail = previousNode;
                    }
                    currentNode = currentNode.Next;
                }
                else
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
            }
        }

        public bool Find(T item)
        {
            Node<T> currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }
            return false;
        }

        public void InsertAt(int index, T item)
        {
            if (index == 0)
            {
                var newNode = new Node<T> { Data = item };
                newNode.Next = _head;
                _head = newNode;
        
                if (_tail == null) _tail = _head;
        
                return;
            }

            Node<T> currentNode = _head;
            int count = 0;

            while (currentNode != null)
            {
                if (count == index - 1)
                {
                    var newNode = new Node<T> { Data = item };
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;

                    if (newNode.Next == null) _tail = newNode;
            
                    return;
                }

                currentNode = currentNode.Next;
                count++;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
        }

        public void Reverse()
        {
            Node<T> previousNode = null;
            Node<T> currentNode = _head;
            Node<T> nextNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            _tail = _head;
            _head = previousNode;
        }

        public void PrintAll()
        {
            var nextNode = new Node<T>();
            if (_head != null)
            {
                nextNode = _head;
               
                Console.WriteLine(_head.Data);
                    
                while (nextNode.Next != null)
                {
                    nextNode = nextNode.Next;
                    Console.WriteLine(nextNode.Data);
                }
            }
        }

        public int CountNodes()
        {
            var count = 0;
            var currentNode = _head;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }
    }
    


}

