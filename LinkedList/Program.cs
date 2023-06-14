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
        // have the list element contain the content and a pointer to the next element:
        static int position = 0;
        string content;
        listElement next;

        // Add new content and intialize its pointer to the still non-existing next element:
        public void SetData(string newContent)
        {
            content = newContent;
            next = null;
        }

        // Do the same as in SetData, but without adding a pointer:
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

            // The new list element was assigned next. Thereby next is the end 
            // of the list, and can be returned:
            return next;
        }

        // Create a new list element and replace the first one of the existing
        // list by the new element and return this element:
        public listElement MakeElementHead(string newContent, listElement headOfList)
        {

            // Create a new list element:
            listElement firstOfList = new listElement();

            // Make current head element to next of the new head element:
            firstOfList.next = headOfList;
            // Insert data:
            firstOfList.SetDataWithoutNext(newContent);

            return firstOfList;
        }

        // Create a new list element and replace the nth element with the new element:
        public void InsertElementToPositionN(listElement head, string newContent, int n)
        {
            listElement newElement = new listElement();
            newElement.SetDataWithoutNext(newContent);

            listElement runningElement = head;

            for (int i = 0; ; i++)
            {
                // When reaching the position in the existing list just left
                // to the desired position, do the inserting and wiring:
                if (i == (n - 1))
                {
                    // Point the new element to the next element of the existing list:
                    newElement.next = runningElement.next;

                    // Have the previous list element of the existing list point to the
                    // new element:
                    runningElement.next = newElement;
                    break;
                }
                // Move on one element to the right:
                runningElement = runningElement.next;
            }
        }

        //
        public int HowManyElements(listElement headOfList)
        {
            int counter = 1;
            listElement runningElement = new listElement();
            runningElement = headOfList;
            do
            {
                counter++;
                runningElement = runningElement.next;
            }
            while (runningElement.next != null);
            return counter;
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
            string whichSelection;
            string inputElement;
            bool endProcess = false;
            int n;

            listElement headOfList = new listElement();

            headOfList.SetData("Element 1");

            // Set the new instance to the head of the list, so that the tail can be defined:
            listElement tailOfList = headOfList;

            // Append element to the end of the list. With each append the 
            // instance tailOfList is set to the newly formed list element: 
            for (int element = 2; element < 4; element++)
                tailOfList = tailOfList.AppendElement("Element " + element);

            // Show situation at start:
            headOfList.PrintToScreen();

            while (!endProcess)
            {
                Console.WriteLine("\nPlease select: 'a' for append, 'h' for make it head, 'n' for insert at position n, 'x' for abort");
                whichSelection = Console.ReadLine();
                switch (whichSelection)
                {
                    case "a":
                        Console.WriteLine("Give a new element number for appending: ");
                        inputElement = Console.ReadLine();

                        // Append the new list element and determine the end of the list:
                        tailOfList = tailOfList.AppendElement("Element " + inputElement);

                        Console.WriteLine("\nPrinting the linked list after appending:");
                        headOfList.PrintToScreen();
                        break;

                    case "h":
                        Console.WriteLine("Give a new element number for beginning: ");
                        inputElement = Console.ReadLine();

                        // Place the new list element to the beginning of the list:
                        headOfList = headOfList.MakeElementHead("Element " + inputElement, headOfList);

                        Console.WriteLine("\nPrinting the linked list after pushing to head:");
                        headOfList.PrintToScreen();
                        break;

                    case "n":
                        Console.WriteLine("Give a new element number: ");
                        inputElement = Console.ReadLine();

                        Console.WriteLine("Give the position n where to insert new element to: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        
                        // Use the existing linked list and insert new element to position n,
                        // shift all the others right to it by one position and rewire:
                        headOfList.InsertElementToPositionN(headOfList, "Element " + inputElement, n);

                        Console.WriteLine("\nPrinting the linked list after placing in position n:");
                        headOfList.PrintToScreen();
                        break;

                    case "x":
                        endProcess = true;
                        break;

                    default:
                        break;
                }
                Console.WriteLine($"There are now {headOfList.HowManyElements(headOfList)} elements in the linked list");
            }
        }
    }
}