//title: sort array with just 0s 1s and 2s
//short description: given an array of integers 0,1,2, sort them such that 0s comes first then 1s and then 2s
//Input: A = [2, 0, 0, 1, 2, 0, 1, 2]
//output: [0, 0, 0, 1, 1, 2, 2, 2]
//Explanation:
/*Approach:TODO
*/
/*Reasoning:
*/

public class SortZeroesAndOnes
{
  public static void Main(string[] args)
      {
          var arr = Console.ReadLine().TrimEnd().Split(' ').Select(x => Convert.ToInt32(x)).ToList().ToArray();

          //start from beginning
          var start = 0;
          //fast forward till you have all zeroes(already in correct positions, ie., left hand part of array)
          while(start < arr.Length && arr[start] == 0){
            start++;
          }

          //iterate from last and if 0 is found, send it to correct index in left part.
          var end = arr.Length - 1;
          var temp = 0;
          //only do till you ended up on the sorted zeroes in left, keep shrinking the array from right to left
          while(end > start)
          {
            // if 0 found take to correct place
            if(arr[end] == 0){
              temp = arr[start];
              arr[start] = arr[end];
              arr[end] = temp;
              start++;
            }
            //keep coming to left one by one searching for zeroes
            end--;
          }

          //setting 'end' to last non two value
          end = arr.Length -1;
          while(end >= 0 && arr[end] == 2){
            end--;
          }

          //starting from sorted 0's next index and checking if element is 2 , take it to its right pos, i.e end
          while(start < end)
          {
            //if element is 2 take to right index in right side
            if(arr[start] == 2){
              temp = arr[start];
              arr[start] = arr[end];
              arr[end] = temp;
              end--;
            }
            //move to next element to check now
            start++;
          }

          //printing resulted array
          foreach(var item in arr){
              Console.WriteLine(item);
          }
      }
}
