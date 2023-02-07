namespace JaggedArrray
{

    public class JaggedArray
    {
        // field containing info
        public int[][]? Array;

        // constructor
        public JaggedArray(int[][]? array)
        {
            Array = array;
            if (!Empty()) {
                for (int ind = 0; ind < Array.Length; ind++)
                {
                    Empty(ind);
                }
            }

            
            
        }
        
        // checking if array is empty
        public bool Empty()
        {

            if (Array == null)
            {

                throw new Exception("Array Pointer Empty");

            }
            else
            {

                return false;

            }

        }

        // cheching if a line in an array is empty
        public bool Empty(int line) 
        {
            if (Array == null ||  Array[line] == null)
            {

                throw new Exception("Array-Line Pointer Empty");

            }
            else
            {

                return false;

            }
        }

        // checking if sum of a line is even
        public bool SumEven(int line)
        {           
            int countNotEven = 0;
            for (int i = Array[line].Length - 1; i >= 0; i--)
            {
                if (Array[line][i] % 2 == 1)
                {
                    countNotEven++;
                }
            }
            return countNotEven % 2 == 0;
            
        }

        // checking if all elements of a line are even
        public bool EvenLine(int line)
        { 
            for (int i = Array[line].Length - 1; i >= 0; i--)
            {
                if (Array[line][i] % 2 == 1)
                {
                    return false;
                }
            }
            return true;
        }

        // checking if all elements of a line are not even
        public bool NotEvenLine(int line)
        {
     
            for (int i = Array[line].Length - 1; i >= 0; i--)
            {
                if (Array[line][i] % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        

        }

        // checking if the line consists of zeros only
        public bool NullLine(int line) {
            for (int i = Array[line].Length - 1; i >= 0; i--)
            {
                if (Array[line][i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        // checking if the line could we read equally from right-left and vice versa
        public bool MirrorLine(int line)
        {

            int length = Array[line].Length,
                end = length / 2;
            for (int i = 0; i < end ; i++)
            {
                if (Array[line][i]!= Array[line][length - i - 1]) 
                { 
                
                    return false;

                }
            }
            return true;
        }

        // checking if the line consists only of elements bigger than zero
        public bool PositiveLine(int line) 
        {

            for (int i = 0; i < Array[line].Length; i++)
            {
                if (Array[line][i]< 0) 
                { 

                    return false;

                }
            }
            return true;
        }

        // checking if the line consists only of elements smaller than zero
        public bool NegativeLine(int line)
        {
            for (int i = 0; i < Array[line].Length; i++)
            {
                if (Array[line][i] > 0)
                {

                    return false;

                }
            }
            return true;
        }

        // returns index of a line containing a minimal sum in array
        public int MinimalSum() 
        {
            int sum = 0,
                index = 0;

            for (int i = Array.Length - 1; i >= 0; i--)
            {
                int bufferSum = 0;

                for (int j = 0; j < Array[i].Length; j++)
                {

                    bufferSum += Array[i][j];

                }

                switch (index)
                {
                    case 0:
                        sum = bufferSum;
                        break;

                    default:
                        // saving minimum sum value and index
                        if (bufferSum < sum)
                        {

                            sum = bufferSum;

                            index = i;

                        }
                        break;

                }

            }

            return index;

        }

        // returns index of a line containing a maximum sum in array
        public int MaximumSum()
        {
            int sum = 0,
                index = 0;

            for (int i = Array.Length - 1; i >= 0; i--)
            {
                int bufferSum = 0;

                for (int j = 0; j < Array[i].Length; j++)
                {

                    bufferSum += Array[i][j];

                }
                
                switch (index){
                    case 0:
                        sum = bufferSum;
                        break;

                    default:
                        // saving maximum sum value and index
                        if (bufferSum > sum)
                        {
                        
                            sum = bufferSum;

                            index = i;

                        }
                        break;                        

                }

            }
            
            return index;
                
        }
        
        // checking if sum of a line is bigger than the sum of be
        public bool Bigger(ref int[] a, ref int[] b) {
            int sum1 = 0,
                sum2 = 0; 
            for (int i = 0; i < a.Length; i++)
            {
                sum1 += a[i];   
            }
            for (int i = 0; i < b.Length; i++)
            {
                sum2+= b[i];
            }
            return sum1 > sum2;            
        }

        // checking if sum of a line is smaller than the sum of be
        public bool Smaller(ref int[] a, ref int[] b)
        {
            int sum1 = 0,
                sum2 = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum1 += a[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                sum2 += b[i];
            }
            return sum1 < sum2;
        }

        // adds a line consisting of 0
        public ref int[] Add(int line) {

            int[][] arr = new int[Array.Length + 1, ];
            for (int i = 0; i < Array.Length; i++)
            { 
            switch i:
                case i < line:
                    arr[i] = Array[i];
                    break;
                case i > line:
                    arr[i + 1] = Array[i];
                    break;
                default:
                    var rand = new Random();
                    arr[i] = new int[rand.Next(1, 11)];
                    break;
            }
            Array = arr;
            return ref Array[line];

        }
        // deletes a line 
        public 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            JaggedArray jagged = new JaggedArray(
                                 new int[][] 
                                 {
                                 new int[] { 1, 3, 5, 7, 9 },
                                 new int[] { 0, 2, 4, 6 },
                                 new int[] { 11, 22 }, 
                                 new int[] { 0, 0}, 
                                 new int[] { -1, -2, -3, -4, -5 },
                                 new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 }
                                 });

            Console.WriteLine("Hello, World!");
        }
    }
}