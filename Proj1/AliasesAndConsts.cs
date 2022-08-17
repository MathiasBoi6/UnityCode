using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MapSelection  {
    public (int, int)? value = null;
}


public class PathSortedList {
    private List<int> listInt = new List<int>();
    private List<Node> listNode = new List<Node>();
    public PathSortedList()
    {

    }

    public void AddNode(int key, Node node)
    {
        int index = listInt.BinarySearch(key);

        if (index < 0)
        {
            index = ~index;
        }

        /*Debug.Log("-----Before:-----");
        foreach(int keys in listInt)
        {
            Debug.Log(keys);
        }*/
        listInt.Insert(index, key);
        listNode.Insert(index, node);
        /*Debug.Log("-----After:-----");
        foreach (int keys in listInt)
        {
            Debug.Log(keys);
        }*/
    }

    public Node Pop()
    {
        if(listNode.Count > 0)
        {
            Node node = listNode[0];
            Debug.Log("Dist popped = " + listInt[0]);
            listInt.RemoveAt(0);
            listNode.RemoveAt(0);
            return node;
        }
        else
        {
            return null;
        }
    }
}







///FUCK THE PEOPLE WHO MADE SORTEDLIST
/// <summary>
/// Comparer for comparing two keys, handling equality as beeing greater
/// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class DuplicateKeyComparer<TKey>
                :
             IComparer<TKey> where TKey : IComparable
{
    #region IComparer<TKey> Members

    public int Compare(TKey x, TKey y)
    {
        int result = x.CompareTo(y);

        if (result == 0)
            return 1; // Handle equality as being greater. Note: this will break Remove(key) or
        else          // IndexOfKey(key) since the comparer never returns 0 to signal key equality
            return result;
    }

    #endregion
}
