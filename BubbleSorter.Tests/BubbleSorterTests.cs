using System;
using NUnit.Framework;

namespace BubbleSorter.Tests
{
    [TestFixture]
    public class BubbleSorterTests
    {

        public class SumSorter:ISorterType
        {
            public bool AscendingOrder { get; set; }

            public SumSorter(bool ascendingOrder)
            {
                AscendingOrder = ascendingOrder;
            }

            public int CalculateFaktor(int[] vektor)
            {
                int sum = 0;
                foreach (var value in vektor)
                {
                    sum += value;
                }
                return sum;
            }
        }

        public class AbsMaxSorter : ISorterType
        {
            public bool AscendingOrder { get; set; }

            public AbsMaxSorter(bool ascendingOrder)
            {
                AscendingOrder = ascendingOrder;
            }

            public int CalculateFaktor(int[] vektor)
            {
                int max = Math.Abs(vektor[0]);
                for (int i = 1; i < vektor.Length; i++)
                {
                    if (Math.Abs(vektor[i]) > max)
                        max = Math.Abs(vektor[i]);
                }
                return max;

            }
        }

        private int[][] GetTestJaggedArray()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = null;
            jaggedArray[1] = new int[] { 0, 5, 10, 3 };
            jaggedArray[2] = new int[] { 4, 1, 2, 3 };
            jaggedArray[3] = new int[] { 5, 1 };
            return jaggedArray;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Sort_By_Absolute_Max_Element_Tests(bool ascendingOrder)
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = null;
            jaggedArray[1] = new int[] { 0, 5, 10, 3 };
            jaggedArray[2] = new int[] { 4, 1, 2, 3 };
            jaggedArray[3] = new int[] { 5, 1 };
            int[][] resultArray=new int[4][];
            if (ascendingOrder)
            {
                resultArray[0] = jaggedArray[2];
                resultArray[1] = jaggedArray[3];
                resultArray[2] = jaggedArray[1];
                resultArray[3] = jaggedArray[0];
            }
            else
            {
                resultArray[0] = jaggedArray[0];
                resultArray[1] = jaggedArray[1];
                resultArray[2] = jaggedArray[3];
                resultArray[3] = jaggedArray[2];

            }
            BubbleSorter bs = new BubbleSorter();
            bs.Sort(jaggedArray,new AbsMaxSorter(ascendingOrder));
            Assert.AreEqual(jaggedArray,resultArray);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Sort_By_Row_Sum_Tests(bool ascendingOrder)
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = null;
            jaggedArray[1] = new int[] { 0, 5, 10, 3 };
            jaggedArray[2] = new int[] { 4, 1, 2, 3 };
            jaggedArray[3] = new int[] { 5, 1 };
            int[][] resultArray = new int[4][];
            if (ascendingOrder)
            {
                resultArray[0] = jaggedArray[3];
                resultArray[1] = jaggedArray[2];
                resultArray[2] = jaggedArray[1];
                resultArray[3] = jaggedArray[0];
            }
            else
            {
                resultArray[0] = jaggedArray[0];
                resultArray[1] = jaggedArray[1];
                resultArray[2] = jaggedArray[2];
                resultArray[3] = jaggedArray[3];

            }
            BubbleSorter bs = new BubbleSorter();
            bs.Sort(jaggedArray, new SumSorter(ascendingOrder));
            Assert.AreEqual(jaggedArray, resultArray);
        }

        [TestCase(1, ExpectedException=typeof(ArgumentNullException))]
        [TestCase(2, ExpectedException = typeof(ArgumentNullException))]
        public void Exceprion_Tests(int testNum)
        {
            BubbleSorter bs=new BubbleSorter();
            ISorterType sorterTypeObject = null;
            int[][] array=null;
            switch (testNum)
            {
                case 1:
                    sorterTypeObject=new AbsMaxSorter(true);
                    break;
                case 2:
                    array=new int[4][];
                    break;
            }
            bs.Sort(array,sorterTypeObject);
        }
    }
}
