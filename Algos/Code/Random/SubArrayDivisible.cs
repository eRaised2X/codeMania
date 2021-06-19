//title: subarray sum divisible by k problem
//short description: given an array of integers A, find the number of subarrays whose sum is divisible by k
//Input: A = [4, 5, 0, -2, -3, 1] and K = 5
//output: 7
//Explanation: [5], [0], [5,0], [-2,-3], [0,-2,-3], [5,0,-,2,-3], [4,5,0,-2,-3,1]

/*Approach:
Use a hashmap/dict to store distinct mod values (mod of cumulative sum by 'k')and their occurrences.
Start from the 0th index, calculate cumulative sum at each index, then calculate mod k of cumulative sum at each index(starting sum=0 from -1 index),
put the mod result in hashmap/dict, if hashmap key already present, then increment the answer by 'value' of that hashkey, also increment hash value for that key by 1 for next cycle.
*/
/*Reasoning: Repeating mod value at an index indicates that k or 2*k or 3*k (that is any divisible by k) sum has been encountered,
from the first occurrence of that mod value to next occurrence. for example, cumulative sum of above example at each index is 4,9,9,7,4,5
and since k = 5
put default entry in hash as key 0 with occurrences = 1, as with no elements the cumulative sum is 0
4 mod 5 = 4 --> add 4 to dict/hash with occurrence = 1 
9 mod 5 = 4 add the occurrence to answer and increment occurrence value by 1
i.e., that means from index = 0 to index 1, something divisible by 5 has shown up, as the remainder is same as that of index 0
proceeding further in cumulative sum array
9 mod 5 = 4 (again), do the same
7 mod 5 = 2 , add 2 in hash with occurrence = 1
4 mod 5 = 4, add the occurrence value to answer and increment occurrence value by 1
5 mod 5 = 0 , add the occurrence value to answer and increment occurrence value by 1, we again count this as repeated bcoz 0 was the mod value even with no elements,
*/

using System;
using System.Linq;
using System.Collections.Generic;

public class SumDivisibleByK
{
  public static void Main(string []args) {

    List<int> inputList = Console.ReadLine().TrimEnd().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
    int k = Convert.ToInt32(Console.ReadLine().TrimEnd());

    int count = 0;
    var dict = new Dictionary<int,int>();

    dict.Add(0,1);

    long cumulativeSum = 0;
    int modValue = 0;
    for(int i = 0; i < inputList.Count; i++)
    {
          cumulativeSum += inputList[i];
          modValue = (int)(cumulativeSum % k);
          if (dict.ContainsKey(modValue))
          {
              count += dict[modValue];
              dict[modValue] = dict[modValue] + 1;
          }
          else
          {
              dict.Add(modValue, 1);
          }
    }

    Console.WriteLine(count);
  }
}
