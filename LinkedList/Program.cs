using System;

namespace LinkedList
{
    // Software for a linked list implementation, where the user can apply various options
    // to change the linked list (appending, pushing, inserting)
    //
    // Dirk Mueller, 14 June 2023

    internal class listElement
    {
        // Have the list element contain the content and a pointer to the next element:
        private static int position = 0;

        private string content;
        private listElement next;

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

        // Create a new list element and replace next - which is currently null - by the new
        // element, and return this element:
        public listElement AppendElement(string newContent)
        {
            next = new listElement();
            next.SetData(newContent);

            // The new list element was assigned next. Thereby next is the end of the list, and can
            // be returned:
            return next;
        }

        // Create a new list element and replace the first one of the existing list by the new
        // element and return this element:
        public listElement MakeElementHead(string newContent, listElement headOfList)
        {
            int counter = 1;
            listElement runningElement = new listElement();
            runningElement = headOfList;
            do
            {
                counter++;
                runningElement = runningElement.next;
        }

        // Create a new list element and replace the nth element with the new element:
        public void InsertElementToPositionN(listElement head, string newContent, int n)
        {
            listElement newElement = new listElement();
            newElement.SetDataWithoutNext(newContent);

            listElement runningElement = head;

            for (int i = 0; ; i++)
            {
                // When reaching the position in the existing list just left to the desired
                // position, do the inserting and wiring:
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

    internal class Program
    {
        private static void Main(string[] args)
        {
            string whichSelection;
            string inputElement;
            string intInput;
            bool endProcess = false;
            int n;

            listElement headOfList = new listElement();

            headOfList.SetData("Element 1");

            // Set the new instance to the head of the list, so that the tail can be defined:
            listElement tailOfList = headOfList;

            // Append element to the end of the list. With each append the instance tailOfList is
            // set to the newly formed list element:
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
                        intInput = Console.ReadLine();

                        if (int.TryParse(intInput, out n))
                        {
                            n = Convert.ToInt32(intInput);
                        }
                        else
                        {
                            Console.WriteLine("Not an integer. Please try again");
                            break;
                        }

                        if (n > headOfList.HowManyElements(headOfList) || n < 0)
                        {
                            Console.WriteLine("Position you gave is outside the linked list");
                            break;
                        }

                        // Use the existing linked list and insert new element to position n, shift
                        // all the others right to it by one position and rewire:
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
            }
            Console.WriteLine($"\nThere are now {headOfList.HowManyElements(headOfList)} elements in the linked list");
        }
    }
}