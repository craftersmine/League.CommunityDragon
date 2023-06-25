using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public class ItemsCollection : IReadOnlyCollection<Item>
    {
        private readonly List<Item> _itemsInternal = new List<Item>();

        public Item this[int id]
        {
            get
            {
                Item? item = _itemsInternal.FirstOrDefault(i => i.Id == id);
                if (item is not null) return item;

                throw new KeyNotFoundException("Unable to find item with ID: " + id);
            }
        }

        public Item this[string name]
        {
            get
            {
                Item? item = _itemsInternal.FirstOrDefault(i => i.Name.Trim() == name);
                if (item is not null) return item;

                throw new KeyNotFoundException("Unable to find item with name: " + name);
            }
        }

        internal ItemsCollection(Item[]? items)
        {
            if (items is not null)
                _itemsInternal.AddRange(items);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _itemsInternal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _itemsInternal.Count;
    }
}
