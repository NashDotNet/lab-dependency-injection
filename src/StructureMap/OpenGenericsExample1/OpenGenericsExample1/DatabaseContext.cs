using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenGenericsExample2
{
	class DatabaseContext : IDatabaseContext
	{
		readonly IDictionary<Type, IList<object>> _store = new Dictionary<Type, IList<object>>();

		public IEnumerable<T> Query<T>()
		{
			if (!_store.ContainsKey(typeof (T)))
			{
				return null;
			}

			return _store[typeof (T)].Cast<T>();
		}

		public void AddItem<T>(T item)
		{
			IList<object> items;

			if (_store.ContainsKey(typeof (T)))
			{
				items = _store[typeof (T)];
			}
			else
			{
				items = new List<object>();
				_store.Add(typeof (T), items);
			}

			items.Add(item);
		}
	}
}