// "static void main" must be defined in a public class.
public class Main {
    public static void main(String[] args) {
        System.out.println("Hello World!");

        Node head = CreateList();
        PrintList(head);
        Node newHead = ReverseList(head);
        System.out.println("After reverse!");
        PrintList(newHead);
    }

    //stub to create a hardcoded list
    public static Node CreateList(){
        Node head = new Node(1);
        head.next = new Node(2);
        head.next.next = new Node(3);
        head.next.next.next = new Node(4);

        return head;
    }

    //stub to print the list
    public static void PrintList(Node head){
        Node temp = head;
        while(temp != null){
            System.out.println(temp.value);
            temp = temp.next;
        }
    }

    //stub to reverse and return the new head pointer
    public static Node ReverseList(Node head){
        // if only one elem or zero elem
        if(head == null || head.next == null){
            return head;
        }

        Node prev = null;
        Node curr = head;
        Node next = curr.next;

        while(curr != null){
            curr.next = prev; //link current node backward
            prev = curr; //adjust prev to forward it to curr
            curr = next; // adjust curr to forward it to next

            // adjust next, just checking curr is not on null already to prevent NPE
            next = (curr != null) ? curr.next : null;
        }

        //finally the prev node is the one which is pointing to correct new head.

        // note the below line would not work as there is no pass by ref in Java,
        // and original head will keep pointing to the old one :(, hence return the new head to caller
        //head = prev; // hence would not affect head

        return prev;
    }
}

//Linked list node
class Node{
    int value;
    Node next;

    Node(int val){
        this.value = val;
    }
}
