namespace HashTables
{
    public class HashTable
    {
        private readonly byte _maxSize = 255;
        private Dictionary<int, List<Item>> _items = null;
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items?.ToList()?.AsReadOnly();

        public HashTable()
        {
            _items = new Dictionary<int, List<Item>>(_maxSize);
        }

        public void Insert(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentOutOfRangeException(nameof(key));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            var item = new Item(key, value);
            var hash = GetHash(item.Key);

            List<Item> hashTableItems = null;
            if (_items.ContainsKey(hash))
            {
                var oldElementWithKey = hashTableItems.SingleOrDefault(i=>i.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    throw new ArgumentNullException("Хеш таблица уже содержит элемент с таким ключом",nameof(key));
                }

                _items[hash].Add(item);
            }
            else
            {
                hashTableItems=new List<Item> { item };
                _items.Add(hash, hashTableItems);
            }
        }

        public void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentOutOfRangeException(nameof(key));
            }

            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return;
            }
            var hashTableItems = _items[hash];
            var item = hashTableItems.SingleOrDefault(i => i.Key == key);
            if (item != null)
            {
                hashTableItems.Remove(item);
            }
        }

        public string Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentOutOfRangeException(nameof(key));
            }

            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return null;
            }
            var hashTableItems = _items[hash];
            if (hashTableItems != null)
            {
                var item = hashTableItems.SingleOrDefault(i => i.Key == key);
                if (item != null)
                {
                    return item.Value;
                }
            }

            return null;
        }

        private int GetHash(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length > _maxSize)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var hash = value.Length;
            return hash;
        }
    }
}