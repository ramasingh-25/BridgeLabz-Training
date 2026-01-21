//using System;

//class Node
//{
//    public char Data;
//    public Node Next;

//    public Node(char data)
//    {
//        Data = data;
//        Next = null;
//    }
//}

//class LinkedList
//{
//    public Node Head;

//    public void Add(char data)
//    {
//        Node newNode = new Node(data);

//        if (Head == null)
//        {
//            Head = newNode;
//            return;
//        }

//        Node temp = Head;
//        while (temp.Next != null)
//            temp = temp.Next;

//        temp.Next = newNode;
//    }

//    public char FindNthFromEnd(int n)
//    {
//        Node first = Head;
//        Node second = Head;

//        for (int i = 0; i < n; i++)
//        {
//            if (first == null)
//                throw new Exception("N is greater than list length");

//            first = first.Next;
//        }

//        while (first != null)
//        {
//            first = first.Next;
//            second = second.Next;
//        }

//        return second.Data;
//    }
//}

//class NthElements
//{
//    static void Main()
//    {
//        LinkedList list = new LinkedList();
//        list.Add('A');
//        list.Add('B');
//        list.Add('C');
//        list.Add('D');
//        list.Add('E');

//        Console.WriteLine(list.FindNthFromEnd(2));
//    }
//}
