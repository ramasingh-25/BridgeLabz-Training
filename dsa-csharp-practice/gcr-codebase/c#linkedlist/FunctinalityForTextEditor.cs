//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//    internal class FunctinalityForTextEditor
//    {

//        class TextNode
//        {
//            public string Text;
//            public TextNode Prev;
//            public TextNode Next;


//            //constructor
//            public TextNode(string text)
//            {
//                this.Text = text;
//                this.Prev = null;
//                this.Next = null;
//            }
//        }

//        class TextEditor
//        {
//            private TextNode head;
//            private TextNode tail;
//            private TextNode current;
//            private int size;
//            private const int MAX_SIZE = 10;


//            //Add a new text state at the end of the list every time the user types or performs an action.
//            public void AddState(string text)
//            {
//                TextNode newNode = new TextNode(text);


//                if (current != null && current.Next != null)
//                {
//                    current.Next = null;
//                    tail = current;
//                }

//                if (head == null)
//                {
//                    head = tail = current = newNode;
//                    size = 1;
//                    return;
//                }

//                tail.Next = newNode;
//                newNode.Prev = tail;
//                tail = newNode;
//                current = newNode;
//                size++;


//                if (size > MAX_SIZE)
//                {
//                    head = head.Next;
//                    head.Prev = null;
//                    size--;
//                }
//            }

//            //Implement the undo functionality
//            public void Undo()
//            {
//                if (current != null && current.Prev != null)
//                {
//                    current = current.Prev;
//                    Console.WriteLine("Undo successful.");
//                }
//                else
//                {
//                    Console.WriteLine("Nothing to undo.");
//                }
//            }


//            //Implement the redo functionality 
//            public void Redo()
//            {
//                if (current != null && current.Next != null)
//                {
//                    current = current.Next;
//                    Console.WriteLine("Redo successful.");
//                }
//                else
//                {
//                    Console.WriteLine("Nothing to redo.");
//                }
//            }


//            //Display the current state of the text.
//            public void DisplayCurrent()
//            {
//                if (current != null)
//                    Console.WriteLine("Current Text: " + current.Text);
//                else
//                    Console.WriteLine("Editor is empty.");
//            }
//            public static void Main(string[] args)
//            {
//                TextEditor editor = new TextEditor();

//                editor.AddState("Good");
//                editor.AddState("Good Morning");
//                editor.AddState("Good Morning guyyssss i am Rama!");
//                editor.DisplayCurrent();
//                Console.WriteLine();

//                editor.Undo();
//                editor.DisplayCurrent();
//                Console.WriteLine();

//                editor.Undo();
//                editor.DisplayCurrent();
//                Console.WriteLine();

//                editor.Redo();
//                editor.DisplayCurrent();
//                Console.WriteLine();

//                editor.AddState("Gooooooood Morningggggggg");
//                editor.DisplayCurrent();
//            }
//        }
//    }
//}
