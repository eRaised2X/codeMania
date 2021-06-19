// "static void main" must be defined in a public class.
public class Main {
    public static void main(String[] args) {
        System.out.println("Finding 3rd maximum distinct number, if 3 distinct elem do not meaning there can't be a 3rd maximum elem hence print no such element exists");

        int []arr = new int[] {1,2,3,3,2,1,4,5,2}; //should print 3
        //int []arr = new int[] {1,2,1,2,1,2,2}; //should print 'no such elem'
        //int []arr = new int[] {-1,0,1,2,1,-2,2}; //should print 0
        //int []arr = new int[] {0,2}; //should print 'no such elem'
        printThirdMax(arr);
    }

    //stub to print 3rd max elem if exists else print no such elem
    public static void printThirdMax(int []arr){
        if(arr.length < 3){
            System.out.println("no such elem");
            return;
        }

        //just assume 3 elem as firstInAscOrder, secondInAscOrder, thirdInAscOrder
        //such that firstInAscOrder > secondInAscOrder > thirdInAscOrder

        int firstInAscOrder = Integer.MIN_VALUE; // initialized to min possible
        int secondInAscOrder = Integer.MIN_VALUE;
        int thirdInAscOrder = Integer.MIN_VALUE;

        for(int i = 0; i < arr.length; i++){
            if(arr[i] > thirdInAscOrder){
                //if curr elem is > than 3rd means bigger than all else too hence shift all to left
                //and insert curr to right most
                firstInAscOrder = secondInAscOrder;
                secondInAscOrder = thirdInAscOrder;
                thirdInAscOrder = arr[i];
            }
            else if(arr[i] > secondInAscOrder){
                //if curr elem > second, shift left from thereon
                if(arr[i] != thirdInAscOrder){
                    //note: this nested != check is to ensure duplicate elem is not pushed in
                    firstInAscOrder = secondInAscOrder;
                    secondInAscOrder = arr[i];
                }
            }
            else if(arr[i] > firstInAscOrder){
                //if curr elem is just > first elem
                if(arr[i] != secondInAscOrder){
                    //note: this nested != check is to ensure duplicate elem is not pushed in
                    firstInAscOrder = arr[i];
                }
            }
        }

        //by now our elements would be firstInAscOrder > secondInAscOrder > thirdInAscOrder

        //after above loop if firstInAscOrder is still Integer.MIN_VALUE,
        // that means we could not get 3 distinct, and min of the 3 elem is still MinValue
        if(firstInAscOrder == Integer.MIN_VALUE){
            System.out.println("no such elem");
        }
        else{
            System.out.println(firstInAscOrder);
        }
    }
}
