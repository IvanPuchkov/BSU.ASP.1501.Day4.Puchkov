using System;

namespace BubbleSorter
{
    public class BubbleSorter
    {
        
        void Swap(ref int index1, ref int index2)
        {
            int c = index1;
            index1 = index2;
            index2 = c;
        }

        void Swap(ref int[] a, ref int[] b)
        {
            int[] c = a;
            a = b;
            b = c;
        }

        

        public void Sort(int[][] array, ISorterType sorterTypeObject)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (sorterTypeObject==null)
                throw new ArgumentNullException();
            int[] subArray = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {

                if (array[i] == null)
                    subArray[i] = int.MaxValue;
                else
                {
                    subArray[i] = sorterTypeObject.CalculateFaktor(array[i]);
                }
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1; j++)
                {
                    if (sorterTypeObject.AscendingOrder ? subArray[j] > subArray[j + 1] : subArray[j] < subArray[j + 1])
                    {
                        Swap(ref subArray[j], ref subArray[j + 1]);
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

    }
}
