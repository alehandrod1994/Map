using System;
using System.Collections.Generic;

namespace Map
{
    public class Sorter<T> where T : IComparable
    {
        public Sorter() { }

        public Sorter(IEnumerable<T> items)
        {
            Items.AddRange(items);
        }

        public int SwapCount { get; protected set; } = 0;
        public int ComparisonCount { get; protected set; } = 0;
        public List<T> Items { get; set; } = new List<T>();

        private int Compare(T a, T b)
        {
            ComparisonCount++;
            return a.CompareTo(b);
        }

        private void Swap(int positionA, int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                var temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;

                SwapCount++;
            }
        }

        public void BubbleSort()
        {
            var count = Items.Count;

            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < count - j - 1; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];

                    if (Compare(a, b) == 1)
                    {
                        Swap(i, i + 1);
                    }
                }
            }
        }

        public void CocktailSort()
        {
            int left = 0;
            int right = Items.Count - 1;

            while (left < right)
            {
                var sc = SwapCount;

                for (int i = left; i < right; i++)
                {
                    if (Compare(Items[i], Items[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                    }
                }
                right--;

                if (sc == SwapCount)
                {
                    break;
                }

                for (int i = right; i > left; i--)
                {
                    if (Compare(Items[i], Items[i - 1]) == -1)
                    {
                        Swap(i, i - 1);
                    }
                }
                left++;

                if (sc == SwapCount)
                {
                    break;
                }
            }
        }

        public void InsertSort()
        {
            for (int i = 1; i < Items.Count; i++)
            {
                var temp = Items[i];
                var j = i;

                while (j > 0 && Compare(temp, Items[j - 1]) == -1)
                {
                    Swap(j, j - 1);
                    j--;
                }

                Items[j] = temp;
            }
        }

        public void ShellSort()
        {
            var step = Items.Count / 2;

            while (step > 0)
            {
                for (int i = step; i < Items.Count; i++)
                {
                    int j = i;
                    while (j >= step && Compare(Items[j - step], Items[j]) == 1)
                    {
                        Swap(j - step, j);
                        j -= step;
                    }
                }

                step /= 2;
            }
        }       
    }
}
