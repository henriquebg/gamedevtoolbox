using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OriOpaStudio.Utilities
{
	[Serializable]
	public class CircularList<T>
	{
		[SerializeField] private List<T> _elements;
		private int _currentIndex;

		public CircularList(T[] elements)
		{
			_elements = elements.ToList();
			_currentIndex = 0;
		}

		public T Next 
		{ 
			get 
			{
				_currentIndex++;
				_currentIndex = _currentIndex < _elements.Count ? _currentIndex : 0;

				return _elements[_currentIndex];
			} 
		}

		public T First
		{
			get
			{
				return _elements[0];
			}
		}

		public int Size
		{
			get
			{
				return _elements.Count;
			}
		}

		public bool IsAtBeginning
		{
			get
			{
				return _currentIndex == 0;
			}
		}

		public bool IsAtEnd
		{
			get
			{
				return _currentIndex == _elements.Count - 1;
			}
		}

		public void Add(T item)
		{
			_elements.Add(item);
		}

		public void Remove (T item)
		{
			_elements.Remove(item);
		}
	}
}