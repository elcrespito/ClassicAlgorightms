using System;

namespace ClassicAlgorightms.Sorting
{
    public abstract class Sorting
    {
        public abstract void Sort(IComparable[] a);

        protected bool less(IComparable v, IComparable w)
        {     
            return v.CompareTo(w) < 0;
        }          
           
        protected void exch(IComparable[] a, int i, int j)
        {
            IComparable t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        protected void show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();
        }

        public bool isSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (less(a[i], a[i - 1])) return false;
            }

            return true;
        }
    }
}
