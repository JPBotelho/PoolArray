using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolArray<T> : IEnumerable
{
	private T[] values;

	private int index;

	public PoolArray (int capacity)
	{
		values = new T[capacity];
	} 

	public int Capacity //Max number of items in the inner arrays
	{
		get { return values.Length; }
	}

	public int Index //Current index
	{
		get { return index; }
	}

	public void Add(T value)
	{
		if (index == values.Length) //Reset the index back to 0
		{
			index = 0;
		}
		values[index++] = value;
	}

	public void Clear()
	{
		for (int i = 0; i < values.Length; i++)
		{
			values[i] = default(T);
		}
	}

	public T this[int index]
	{
		get
		{
			if (index < 0 || index >= this.index)
			{
				throw new System.ArgumentException("Index out of range");
			}
			return values[index];
		}
	}

	public T[] ToArray()
	{
		return values;
	}

	public List<T> ToList()
	{
		return new List<T>(values);
	}

	//IEnumerator interface
	public IEnumerator GetEnumerator()
	{
		T[] realValues = new T[values.Length];
		System.Array.Copy(values,realValues, values.Length);
		return realValues.GetEnumerator();
	}
}
