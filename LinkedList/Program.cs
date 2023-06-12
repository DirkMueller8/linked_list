using System;

namespace LinkedList
{
    // Software for a linked list implementation, where the last element
    // is appended to the end of the list (tail), without having to run 
    // through it from the head. This was a task as part of the C# developer
    // line at Fernakademie Klett
    //
    // Dirk Mueller
    // June 2023
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

        // Create a new list element and replace next - which is currently null -
        // by the new element, and return this element:
        public listElement AppendElement(string newContent)
        {
            next = new listElement();
            next.SetData(newContent);

            // The new list element was created in next. Thereby next is the end 
            // of the list, and can be returned:
            return next;
        }

        // Create a new list element and replace the first one by the new element
        // , and return this element:
        public listElement MakeElementHead(string newContent, listElement headOfList)
        {

            // Create a new list element:
            listElement firstOfList = new listElement();

            // Make current head element to next of new element
            firstOfList.next = headOfList;

            firstOfList.SetDataWithoutNext(newContent);

            // Move the head to point to the new Node */
            //head = new_node;
            //headOfList = firstOfList;
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
            string inputString;
            string inputElement;
            bool endProcess = false;

            listElement headOfList = new listElement();

            headOfList.SetData("Element 1");

            // Set the new instance to the head of the list, so that the tail can be defined:
            listElement tailOfList = headOfList;

            // Append element to the end of the list. With each append the 
            // instance tailOfList is set to the newly formed list element: 
            for (int element = 2; element < 4; element++)
                tailOfList = tailOfList.AppendElement("Element " + element);

            headOfList.PrintToScreen();

            while (!endProcess)
            {
                Console.WriteLine("\nPlease select: 'a' for append, 'h' for make it head, 'x' for abort");
                inputString = Console.ReadLine();
                switch (inputString)
                {
                    case "a":
                        Console.WriteLine("Give a new element number for appending: ");
                        inputElement = Console.ReadLine();

                        // append the new list element and determine the end of the list:
                        tailOfList = tailOfList.AppendElement("Element " + inputElement);

                        // append the new list element:
                        Console.WriteLine("\nPrinting the linked list after appending:");
                        headOfList.PrintToScreen();
                        break;

                    case "h":
                        Console.WriteLine("Give a new element number for beginning: ");
                        inputElement = Console.ReadLine();

                        // Append the new list element and determine the end of the list:
                        headOfList = headOfList.MakeElementHead("Element " + inputElement, headOfList);

                        // Append the new list element:
                        Console.WriteLine("\nPrinting the linked list after pushing to head:");
                        headOfList.PrintToScreen();
                        break;

                    case "x":
                        endProcess = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}