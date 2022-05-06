class FlippingMatrix
{

    /*
     * Complete the 'flippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int flippingMatrix(List<List<int>> matrix)
    {
        int sum = 0;
        int total = matrix.Count;

        return matrix.SelectMany(s => s).OrderByDescending(o => o).Take(4).Sum();
        //return sum;
    }

}

class FlippingMatrixSolution
{
    public static void Main(string[] args)
    {
        List<List<int>> matrix = new List<List<int>>();

        matrix.Add(new List<int> { 107, 54, 128, 15 });
        matrix.Add(new List<int> { 12, 75, 110, 138 });
        matrix.Add(new List<int> { 100, 96, 34, 85 });
        matrix.Add(new List<int> { 75, 15, 28, 112 });

        Console.Write(FlippingMatrix.flippingMatrix(matrix));
    }
}
