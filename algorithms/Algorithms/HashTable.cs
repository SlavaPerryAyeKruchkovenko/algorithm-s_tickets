using System.Collections;

namespace Algorithms;
using System.Collections.Generic;
using System.Collections;
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