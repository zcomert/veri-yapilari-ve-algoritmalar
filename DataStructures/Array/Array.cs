namespace Array;
using System;
using System.Collections;
using System.Collections.Generic;

    public partial class Array<T> : IEnumerable<T>
    {
        // Object
        // Type : Array
        private T[] _InnerArray; // null
        private int index = 0;
        public int Count => index;  // Dizi kaç eleman var?
        public int Capacity => _InnerArray.Length;


        public Array(int size = 4)
        {
            _InnerArray = new T[4]; // Block allocation
        }

        public Array(params T[] init)
        {
            var newArray = new T[init.Length];
            System.Array.Copy(init, newArray, init.Length);
            _InnerArray = newArray;
        }

        public void Add(T item)
        {
            if (index == _InnerArray.Length)
            {
                DoubleArray(_InnerArray);
            }

            _InnerArray[index] = item;
            index++;
        }

        private void DoubleArray(T[] array)
        {
            var newArray = new T[array.Length * 2];
            System.Array.Copy(array, newArray, array.Length);
            _InnerArray = newArray;
        }

        /// <summary>
        /// Week 1
        /// </summary>
        /// <param name="position"></param>
        /// <returns>
        ///     Verilen pozisyonda bulunan elemanı geri döndürür.
        ///     Eğer pozisyon sınırlar dışındaysa IndexOutOfRangeException hata fırlatır.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public T GetItem(int position)
        {
            // throw new NotImplementedException();
            if (position < 0 || position >= _InnerArray.Length)
                throw new IndexOutOfRangeException();
            return _InnerArray[position];
        }


        /// <summary>
        /// Week 2 - Implematation 1
        /// SetItem içerisinde verilen pozisyon değeri aralık dışarısında ise hata fırlatılmalı.
        /// Exception() // IndexOutOfRangeException()
        /// </summary>
        /// <param name="position"></param>
        /// <param name="item"></param>
        public void SetItem(int position, T item)
        {
            if (position < 0 || position >= _InnerArray.Length)
                throw new IndexOutOfRangeException();
            _InnerArray[position] = item;
        }

        /// <summary>
        /// Week 2 - Implementation 2 
        /// Remove işleminde girilen pozisyondaki eleman çıkarılmalıdır.
        /// Çıkarma işleminden sonra eleman geri döndürülmelidir.
        /// Çıkarılan elemanın yerine diğerleri kaydırılmalıdır.
        /// </summary>
        /// <param name="position"></param>
        /// <exception cref="NotImplementedException"></exception>
        public T RemoveItem(int position)
        {
            var item = GetItem(position);
            SetItem(position, default);
            for (int i = position; i < Count - 1; i++)
            {
                // _InnerArray[i] = _InnerArray[i + 1];
                Swap(i, i + 1);
            }
            index--;
            if (index == _InnerArray.Length / 2)
            {
                var newArray = new T[_InnerArray.Length / 2];
                System.Array.Copy(_InnerArray, newArray, newArray.Length);
                _InnerArray = newArray;
            }
            return item;

        }

        /// <summary>
        ///  Week - 1 Implementation 2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void Swap(int p1, int p2)
        {
            var temp = _InnerArray[p1];
            _InnerArray[p1] = _InnerArray[p2];
            _InnerArray[p2] = temp;
        }

        /// <summary>
        /// Week - 1 Implementation 3
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Find(T item)
        {
            for (int i = 0; i < _InnerArray.Length; i++)
            {
                if (item.Equals(_InnerArray[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Week 2 - Implementation 3
        /// Verilen değer aralındaki elemanlar kopyalanmalıdır.
        /// Geri dönüş değeri dizidir.
        /// Verilen pozisyon bilgileri kontrol edilmelidir.
        /// </summary>
        /// <returns></returns>
        public T[] Copy(int v1, int v2)
        {
            var newArray = new T[v2]; // v2 - v1
            int j = 0;
            for (int i = v1; i < v2; i++)
            {
                newArray[j] = GetItem(i); // Object
                j++;
            }

            return newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(_InnerArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T GetValue(int index)
        {
            if (!(index >= 0 && index < _InnerArray.Length))
                throw new ArgumentOutOfRangeException();
            return _InnerArray[index];
        }

        public void SetValue(T value, int index)
        {
            if (!(index >= 0 && index < _InnerArray.Length))
                throw new ArgumentOutOfRangeException();
            if (value == null)
                throw new ArgumentNullException();
            _InnerArray[index] = value;
        }
    }

    public class ArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] _array;
        private int index;

        public ArrayEnumerator(T[] array)
        {
            _array = array;
            index = -1;
        }
        public T Current => _array[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _array = null;
        }

        public bool MoveNext()
        {
            if (index < _array.Length - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }