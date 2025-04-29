namespace DataStructures
{
    public class DS_Stack<T>
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;

        public void Push(T item)
        {
            _items.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new System.Exception("Stack is Empty");
            }
            var storedItem = _items[Count - 1];
            _items.RemoveAt(_items.Count-1);
            return storedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new System.Exception("Stack is Empty");
            }
            return _items[Count - 1];
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }
    }
}
