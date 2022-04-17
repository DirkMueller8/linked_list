using System;

namespace LinkedList
{
    class listElement
    {
        static int position = 0;
        // Software for a linked list implementation, where the last element
        // is appended to the end of the list (tail), without having to rund 
        // through it from the head. This was a task as part of the C# developer
        // line at Fernakademie Klett
        // Dirk Mueller,
        // Oct 2019
        // Extended: April 2022
        //
        string content;
        listElement next;
        public void SetData(string newContent)
        {
            content = newContent;
            next = null;
        }

        // The Append method requires a return typ of listElement, so that it can 
        // return the most recently defined list element to Main():
        public listElement AppendElement(string newContent)
        {
            next = new listElement();
            next.SetData(newContent);

            // The new list element was created in next. Thereby next is the end 
            // of the list, and can be returned:
            return next;
        }

        public void PrintToScreen()
        {
            Console.WriteLine($"Position {position}: {content}");
            if (next != null)
            {
                position++;
                next.PrintToScreen();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            listElement headOfList = new listElement();
            // Instantiate the tail of the list:
            listElement tailOfList = new listElement();

            headOfList.SetData("Element 1");

            // Set the new instance to the head of the list, so that the tail 
            // can be defined:

            tailOfList = headOfList;

            // Append element to the end of the list. With each append the 
            // instance tailOfList is set to the newly formed list element, 
            // by means of returning the value:
             
            for (int element = 2; element < 5; element++)
                tailOfList = tailOfList.AppendElement("Element " + element);

            headOfList.PrintToScreen();

            string inputString;
            do
            {
                Console.WriteLine("Give a new element number ('x' to abort): ");
                inputString = Console.ReadLine();

                // Append the new list element and determine the end of the list:
                tailOfList = tailOfList.AppendElement("Element " + inputString);

                Console.WriteLine("Tail of list after appending:");
                tailOfList.PrintToScreen();

                // Append the new list element:
                Console.WriteLine("Print from head of list after appending:");
                headOfList.PrintToScreen();
            }
            while (inputString.ToLower() != "x");
        }
    }
}