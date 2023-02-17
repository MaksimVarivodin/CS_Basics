using System.Reflection.Metadata;

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

        // copy-constructor
        public JaggedArray(JaggedArray arr) {

            arr.Empty();
            Array = new int[arr.Array.Length][];
            for (int i = 0; i < arr.Array.Length; i++)
            {
                arr.Empty(i);
                Array[i] = new int[arr.Array[i].Length];
                for (int j = 0; j < arr.Array[i].Length; j++)
                {
                    Array[i][j] = arr.Array[i][j];
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
            if (Array == null ||  Array[line].Length == 0)
            {

                throw new Exception("Array-Line Pointer Empty");

            }
            else
            {

                return false;

            }
        }

        // clears the array
        public void Clear() { 
        
            Array = null;   
        
        }

        // clears the chosen line of the array
        public void Clear(int line) {
            Empty();
            Empty(line);
            Array[line] = null;

        }



        // checking if sum of a line is bigger than the sum of b
        private bool Bigger(ref int[] a, ref int[] b)
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
            return sum1 > sum2;
        }

        // checking if sum of a line is smaller than the sum of b
        private bool Smaller(ref int[] a, ref int[] b)
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

        // swaps 2 lines in array
        private void Swap(int line1, int line2)
        {
            if (!(Empty() || Empty(line1) || Empty(line2)))
            {
                int[] buffer = Array[line1];
                Array[line1] = Array[line2];
                Array[line2] = buffer;
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
                int buffer = Array[line][i]< 0? Array[line][i] * (-1): Array[line][i];
                if (buffer % 2 == 1)
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
                int buffer = Array[line][i] < 0 ? Array[line][i] * (-1) : Array[line][i];
                if (buffer % 2 == 0)
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

            for (int i = 0; i < Array.Length; i++)
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
            bool changed = false;
            for (int i = 0; i < Array.Length; i++)
            {
                int bufferSum = 0;

                for (int j = 0; j < Array[i].Length; j++)
                {

                    bufferSum += Array[i][j];

                }

                if (changed)
                {
                    // saving maximum sum value and index
                    if (bufferSum > sum)
                    {

                        sum = bufferSum;

                        index = i;

                    }


                }
                else {
                    sum = bufferSum;
                    changed = true;
                }

            }
            
            return index;
                
        }

        // adds a line consisting of 0
        public ref int[] Add(int line) {

            int[][] arr = new int[Array.Length + 1][];
            for (int i = 0; i < Array.Length; i++)
            {
                if (i < line) 
                {
                    arr[i] = Array[i];
                } 
                else if (i > line) 
                {
                    arr[i + 1] = Array[i];
                }
                else 
                {
                    var rand = new Random();
                    arr[i] = new int[rand.Next(1, 11)];
                }
                
            }
            Array = arr;
            return ref Array[line];

        }

        // deletes a line 
        public void Delete (int line)
        {
            int[][] arr = new int[Array.Length + 1][];
            for (int i = 0; i < Array.Length; i++)
            {
                if (i < line)
                {
                    arr[i] = Array[i];
                }
                else if (i > line)
                {
                    arr[i + 1] = Array[i];
                }

            }
            Array = arr;
        }

        // sorts the array
        public void Sort(bool ascending)
        {
            for (int i = 0; i < Array.Length; i++) 
            {
                for (int j = Array.Length - 1; j > i; j--) 
                {
                    if (Bigger(ref Array[j - 1], ref Array[j])== ascending) {
                        Swap(j - 1, j);
                    }
                }
            }
        }

        // prints the array
        public void Print()
        {
            for (int i = 0; i < Array.Length - 1; i++) 
            {
                Print(i);
                Console.WriteLine(",");
            }
            Print(Array.Length - 1);
            Console.WriteLine(".");
        }

        // prints line from array
        public void Print(int line) 
        {
            Console.Write("[ ");
            int end = Array[line].Length - 1;
            for (int i = 0; i < end; i++) 
            {
                Console.Write(Array[line][i].ToString() + ", ");
            }
            Console.Write(Array[line][end].ToString() + " ]");
        }
        
    }
    
    public class JaggedArrayClient {
        // delegates to save and use methods by index
        public delegate void TwoArgumentDelegate(JaggedArray arr, int number);
        public delegate void OneArgumentDelegate(JaggedArray arr);
        // arrays keeping methods of working with JaggedArray
        public OneArgumentDelegate[] oneArgsFunctions;
        public TwoArgumentDelegate[] twoArgsFunctions;

        // constructor
        public JaggedArrayClient() {

            oneArgsFunctions = new OneArgumentDelegate[]
            {
                ShowMaximumLine,
                DeleteMaximumLine,
                ShowMinimumLine,
                DeleteMinimumLine,
                ShowAscending,
                ShowDescending
            };
            twoArgsFunctions = new TwoArgumentDelegate[]
            {
                ShowByAspect, 
                DeleteByAspect, 
                Addline, 
                FillMirror
            };
        
        }

        // switch to check line by the chosen aspect
        private bool Aspect(JaggedArray arr, int number, int line) { 
        
            switch (number)
            {
                case 1:     return arr.NotEvenLine(line);
                case 2:     return arr.EvenLine(line);    
                case 3:     return arr.NullLine(line);                    
                case 4:     return arr.MirrorLine(line);
                case 5:     return arr.SumEven(line);                    
                case 6:     return arr.PositiveLine(line);
                case 7:     return arr.NegativeLine(line);
                default:    return false;
            }

        }

        // method which prints all of the aspects to the console
        public void ShowAspects()
        {
            string[] aspects = {
            "NotEvenLine",
            "EvenLine",
            "NullLine",
            "MirrorLine",
            "SumEven",
            "PositiveLine",
            "NegativeLine"
            };
            
            for(int i = 0;i < aspects.Length; i++)
            {
                Console.WriteLine((i+ 1).ToString() + " -> " + aspects[i]);
            }

        }
        


        // shows maximum line in the array
        public void ShowMaximumLine(JaggedArray arr) { 
        
            arr.Empty();

            arr.Print(arr.MaximumSum());

        
        }

        // deletes maximum line in the array
        public void DeleteMaximumLine(JaggedArray arr) {

            arr.Empty();
            int line = arr.MaximumSum();
            arr.Delete(line);
            Console.WriteLine("Deleted line #" + (line).ToString());
        }


        // shows minimum line in the array
        public void ShowMinimumLine(JaggedArray arr) {

            arr.Empty();

            arr.Print(arr.MinimalSum());

        }

        // deletes minimum line in the array
        public void DeleteMinimumLine(JaggedArray arr)
        {

            arr.Empty();
            int line = arr.MinimalSum();           
            arr.Delete(line);
            Console.WriteLine("Deleted line #" + (line).ToString());
        }


        // shows array in the ascending order
        public void ShowAscending(JaggedArray arr)
        {
            arr.Empty();
            JaggedArray buffer = new JaggedArray(arr);
            buffer.Sort(true);
            buffer.Print();
        }

        // shows array in descending order
        public void ShowDescending(JaggedArray arr)
        {
            arr.Empty();
            JaggedArray b = new JaggedArray(arr);
            b.Sort(false);
            b.Print();
        }



        // prints the lines found by the chosen aspect
        public void ShowByAspect(JaggedArray arr, int number)
        {

            arr.Empty();

            for (int i = 0; i < arr.Array.Length; i++)
                if (Aspect(arr, number, i))
                { 
                    arr.Print(i); 
                    Console.WriteLine();
                }

        }

        // deletes the lines found by the chosen aspect
        public void DeleteByAspect(JaggedArray arr, int number)
        {
            arr.Empty();
            int end = arr.Array.Length;
            for (int i = 0; i < end; i++)
                if (Aspect(arr, number, i))
                {
                    arr.Delete(i);
                    Console.WriteLine("Deleted line #"+ (i).ToString());
                    i--;
                    end--;
                }


        }

        // adds line of zeros
        public void Addline(JaggedArray arr, int line) {
            arr.Empty();

            arr.Add(line);
        }
        
        // clears existing line, fills with the same line + line vice versa
        public void FillMirror(JaggedArray arr, int line) {
            arr.Empty();

            arr.Empty(line);

            var buffer = arr.Array[line];
            int i = 0,
                end = buffer.Length * 2;
            arr.Array[line] = new int[end];

            for (; i < end / 2; i++) {
                arr.Array[line][i] = buffer[i];
            }
            for(;i< end; i++) {
                arr.Array[line][i] = buffer[end/2 - i];
            }
        }

    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // filling array
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
            // filling options
            string[] options = new string[] 
            {
                // 1 arg
                "ShowMaximumLine",
                "DeleteMaximumLine",
                "ShowMinimumLine",
                "DeleteMinimumLine",
                "ShowAscending",
                "ShowDescending",
                // 2 args
                "ShowByAspect",
                "DeleteByAspect",
                "Addline",
                "FillMirror", 
                // else
                "Print"
            };

            for(; ; )
            {
                // clearing console
                Console.Clear();
                // showing jagged array options
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1).ToString() + " -> " + options[i]);
                }
                // entering option
                int end = 1;
                string? buffer = Console.ReadLine();
                end = int.Parse(buffer);
                // going to method 
                Console.Clear();
                // ending
                if (end == 0)
                {
                    Console.WriteLine("Program ended");
                    break;
                }
                // working
                else if (end <= options.Length + 1)
                {
                    JaggedArrayClient cl = new JaggedArrayClient();
                    if (end <= 10) {
                        // 1 arg methods
                        if (end <= 6) {
                            Console.WriteLine(options[end - 1] + ":");
                            cl.oneArgsFunctions[end - 1](jagged);

                        }
                        // 2 arg methods
                        else
                        {
                            int aspect = 0;
                            cl.ShowAspects();
                            Console.Write("Enter chosen aspect: ");
                            aspect = int.Parse(Console.ReadLine());
                            // can be mistakes with misprints and string values,
                            // but won't pay attention to this in this project
                            cl.twoArgsFunctions[end - 1 - cl.oneArgsFunctions.Length](jagged, aspect);
                        }
                    
                    }
                    // no arg methods
                    else {
                        switch (end)
                        {
                            case 11:
                                jagged.Print();
                                break;
                        }
                    }                   
                    
                }
                // misprints
                else {
                    Console.WriteLine("Wrong number");
                }
                // waiting
                Console.ReadKey();
            }
        }
    }
}