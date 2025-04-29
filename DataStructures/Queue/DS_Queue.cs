namespace DataStructures
{
    public class DS_Queue<T>
    {
        private List<T> _items = new List<T>();

        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var dequeuedItem = _items[0];
            _items.RemoveAt(0);
            return dequeuedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[0];
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }
    }
}