using System;
using System.Collections.Generic;
using System.Linq;

namespace _29_30.Scripts.Inventory
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        private int _maxSize;
        
        public Inventory(int maxSize)
        {
            if (maxSize < 1)
                throw new ArgumentOutOfRangeException(nameof(maxSize), "Max size must be greater than zero.");
            
            _maxSize = maxSize;
        }
        
        public bool IsNotFull => _items.Count < _maxSize;
        public int Count => _items.Count;
        public int MaxSize => _maxSize;

        public void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!IsNotFull)
                throw new InvalidOperationException("Inventory is full.");

            _items.Add(item);
        }

        public IEnumerable<IGrouping<string, Item>> SeeAllItems() => _items.GroupBy(item => item.Name);

        public List<Item> GetItemsBy(string name, int count)
        {
            List<Item> getItems = new();
            
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Item name cannot be null or empty.", nameof(name));

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero.");

            List<Item> matchingItems = _items.Where(item => item.Name == name).Take(count).ToList();
            
            if (matchingItems.Count < count)
                throw new InvalidOperationException(
                    $"Not enough items named '{name}'. Requested: {count}, available: {matchingItems.Count}.");
            
            foreach (Item item in matchingItems)
            {
                _items.Remove(item);
            }

            return matchingItems;
        }
    }
    
    public class Item
    {
        public string Name { get; }

        public Item(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}