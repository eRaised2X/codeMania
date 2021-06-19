//Rextester.Program.Main is the entry point for your code. Don't change it.
//Microsoft (R) Visual C# Compiler version 2.9.0.63208 (958f2354)

//Combination sum

Use n numbers from 1 to 9 (both inclusive) to make a sum k
Example n = 3, k =9
i.e., sum to make is 9 and we can use any 3 distinct numbers from [1,9] .
Like
1, 2 ,6
1,3,5
2, 3,4
3,3,3
Approach : Back-tracking
Solution: Idea is like , from 1 -> call for 2 -> calls 3 --> calls 4 but since base case matches (size == 3) at that time, so it returns.

1-2->  3 then 4 then 5 then 6 then 7 then 8 then 9
then third nesting terminates and reaches to 2nd layer and it becoes 1->3->  4 then 5 then 6.. so on
and then 1->4 --> 5 ..similarly
....
1-->9
..
3->4->    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine("Hello, world!");
            var n = 3;
            var k = 9;
            var sequence = new List<int>();
            F(1, k, sequence);
        }

        public static void F(int start, int sum, List<int> sequence){

            if(sequence.Count() == 3){
                if(sum == 0){
                    Console.WriteLine("This is the one of the required combination.");
                    Console.WriteLine(sequence[0] + ":" + sequence[1] + ":" + sequence[2]);
                }
                return;
            }
            for(int i = start; i <= 9; i++){
                sequence.Add(i);
                F(i+1, sum-i, sequence);
                sequence.RemoveAt(sequence.Count - 1);
            }
        }
    }
}
