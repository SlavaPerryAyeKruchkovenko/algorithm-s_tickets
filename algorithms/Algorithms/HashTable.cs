using System.Collections;

namespace Algorithms;
using System.Collections.Generic;
using System.Collections;

public class HashTable<TKey, TValue> : IHashTable<TKey,TValue>, IEnumerable<Tuple<TKey, TValue>>
	{
		private readonly LinkedList<Tuple<TKey,TValue>?>[] _map;
		public readonly uint Size;
		public HashTable(uint size)
		{
			_map = new LinkedList<Tuple<TKey, TValue>>[size];
			this.Size = size;
		}
		public int CountOfLongestList()
		{
			var maxCount = 0;
			foreach (var item in _map)
			{
				if (item is not null && item.Count > maxCount)
				{
					maxCount = item.Count;
				}
			}
			return maxCount;
		}
		public int CountOfFewerList()
		{
			var minCount = _map.Where(x=>x is not null).First().Count();
			foreach (var item in _map)
			{
				if (item is not null && item.Count < minCount)
				{
					minCount = item.Count();
				}
			}
			return minCount;
		}
		public float PercentageOfFilling()
		{
			var count = 0f;
			foreach (var item in _map)
			{
				if(item is not null && item.Count > 0)
				{
					count++;
				}
			}
			return count / Size * 100;
		}
		public void Add(TKey key, TValue value)
		{
			if (!Containes(key))
			{
				var list = GetList(key);
				list.AddLast(Tuple.Create(key, value));
			}
			else
			{
				throw new IndexOutOfRangeException("Key is busy");
			}
		}

		public TValue Remove(TKey key)
		{
			if (Containes(key))
			{
				var list = GetList(key);
				var value = Search(key);
				list.Remove(value);
				return value.Item2;
			}
			throw new IndexOutOfRangeException("Invalid key");
		}
		public bool Containes(TKey key)
		{
			var list = GetList(key);
			return list.Any(x => x.Item1?.Equals(key) ?? false);	
		}
		public TValue this[TKey key]
		{
			get => Search(key).Item2;
			set => Add(key, value);
		}
		public Tuple<TKey, TValue> Search(TKey key)
		{
			var list = GetList(key);
			foreach (var nodes in list)
				if (nodes.Item1?.Equals(key) ?? false)
					return nodes;
			throw new IndexOutOfRangeException("Incorrect Key");
		}
		private LinkedList<Tuple<TKey,TValue>> GetList(TKey key)
		{
			var hash = GetHashCode(key);
			if (_map[hash] is null)
				_map[hash] = new LinkedList<Tuple<TKey, TValue>>();
			return _map[hash];
		}
		private int GetHashCode(TKey key)
		{
			double value = key is int key2 ? 0.618033988  * key2 :  0.6180339887 * key.ToString()[0];
			var trunc = Math.Truncate(value);
			var hash = (int)(Size * (value - trunc));
			return hash;
		}
		public IEnumerator<Tuple<TKey, TValue>> GetEnumerator()
		{
			foreach (var list in _map)
			{
				foreach (var node in list??new LinkedList<Tuple<TKey, TValue>?>())
				{
					yield return node;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

public class GoodHashTable<TKey, TValue> : IHashTable<TKey, TValue>, IEnumerable<Tuple<TKey, TValue>>
{
	private int _countOfCollision=0;
	private readonly Tuple<TKey,TValue>?[] _map;
	public readonly uint Size;
	public GoodHashTable(uint size)
	{
		_map = new Tuple<TKey, TValue>[size];
		this.Size = size;
	}
	public float PercentageOfFilling()
	{
		var count = 0f;
		foreach (var item in _map)
		{
			if(item is not null)
			{
				count++;
			}
		}
		return count / Size * 100;
	}
	private int GetHashCode(TKey key)
	{
		if (key != null)
		{
			double value = key is int key2 ? 0.618033988  * key2 :  0.6180339887 * key.ToString()[0];
			var trunc = Math.Truncate(value);
			var hash = (int)(Size * (value - trunc));
			return hash;
		}
		throw new Exception("Key is null");
	}

	public int GetCountOfCollision()
	{
		return _countOfCollision;
	}
	private int GetHelperHashCode(TKey key)
	{
		if (key != null)
		{
			return (int)(key is int key2 ? key2 % Size/2 : key.ToString()[0]% Size/2);
		}
		throw new Exception("Key is null");
	}
	public Tuple<TKey, TValue> Search(TKey key)
	{
		foreach (var item in _map)
		{
			if (item.Item1.Equals(key))
				return item;
		}
		throw new IndexOutOfRangeException("Incorrect Key");
	}

	public void Add(TKey key, TValue value)
	{
		var hash = GetHashCode(key);
		var hash2 = GetHelperHashCode(key);
		for (int index = 0; index < Size; index++)
		{
			int newHash = (int)((hash + index * hash2)%Size);
			if (_map[newHash] == null)
			{
				_map[newHash] = new Tuple<TKey, TValue>(key, value);
				return;
			}
			else
			{
				index++;
				
			}
		}
		_countOfCollision++;
	}

	public TValue Remove(TKey key)
	{
		var item = Search(key);
		var res = item.Item2;
		item = null;
		return res;
	}

	public IEnumerator<Tuple<TKey, TValue>> GetEnumerator()
	{
		foreach (var item in _map)
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
internal interface IHashTable<TKey,TValue>
	{
		Tuple<TKey, TValue> Search(TKey key);
		void Add(TKey key, TValue value);
		TValue Remove(TKey key);
	}