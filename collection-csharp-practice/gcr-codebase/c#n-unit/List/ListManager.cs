using System.Collections.Generic;

namespace Calculator
{
    // Handles list operations
    public class ListManager
    {
        // Adds element to list
        public void AddElement(List<int> list, int element)
        {
            list.Add(element);
        }

        // Removes element from list
        public void RemoveElement(List<int> list, int element)
        {
            list.Remove(element);
        }

        // Returns size of list
        public int GetSize(List<int> list)
        {
            return list.Count;
        }
    }
}
