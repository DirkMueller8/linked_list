using System;
using System.Xml.Linq;

namespace LinkedList
{
    // Software for a linked list implementation, where the last element
    // is appended to the end of the list (tail), without having to run 
    // through it from the head. This was a task as part of the C# developer
    // line at Fernakademie Klett
    //
    // Dirk Mueller
    // Oct 2019
    // Extended: April 2022
    //

    class listElement
    {
        static int position = 0;
        string content;
        listElement next;
        public void SetData(string newContent)
        {
            content = newContent;
            next = null;
        }
        public void SetDataWithoutNext(string newContent)
        {
            content = newContent;
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
        public listElement MakeElementHead(string newContent, listElement headOfList)
        {
            /* 1 & 2: Allocate the Node &
                    //Put in the data*/
            //Node new_node = new Node(new_data);
            listElement firstOfList = new listElement();

            /* 3. Make next of new Node as head */
            //new_node.next = head;
            firstOfList.next = headOfList;

            firstOfList.SetDataWithoutNext(newContent);

            /* 4. Move the head to point to new Node */
            //head = new_node;
            headOfList = firstOfList;
            return firstOfList;
        }

        public void PrintToScreen()
        {
            Console.WriteLine($"Position {position}: {content}");
            if (next != null)
            {
                position++;
                next.PrintToScreen();
            }
            position = 0;
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
            string inputElement;
            bool endProcess = false;
            while (!endProcess)
            {
                Console.WriteLine("Select from the following: 'a' for append, 'h' for make it head, 'x' for abort");
                inputString = Console.ReadLine();
                switch (inputString)
                {
                    case "a":
                        Console.WriteLine("give a new element number for appending ('x' to abort): ");
                        inputElement = Console.ReadLine();

                        // append the new list element and determine the end of the list:
                        tailOfList = tailOfList.AppendElement("element " + inputElement);

                        // append the new list element:
                        Console.WriteLine("\nprint from head of list after appending:");
                        headOfList.PrintToScreen();
                        break;

                    case "h":
                        Console.WriteLine("Give a new element number for beginning ('x' to abort): ");
                        inputElement = Console.ReadLine();

                        // Append the new list element and determine the end of the list:
                        headOfList = headOfList.MakeElementHead("Element " + inputElement, headOfList);

                        // Append the new list element:
                        Console.WriteLine("\nPrint from new head of list after appending:");
                        headOfList.PrintToScreen();
                        break;

                    case "x":
                        endProcess = true;
                        break;
                }
            }
        }
    }
}