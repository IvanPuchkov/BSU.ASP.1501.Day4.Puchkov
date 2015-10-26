namespace BubbleSorter
{
    public interface ISorterType
    {
        bool AscendingOrder { get; set; }
        int CalculateFaktor(int[] vektor);
    }
}
