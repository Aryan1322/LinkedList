using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MCLL;


public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyCircularyLinkedList list = new MyCircularyLinkedList(new GameObject("first"));
        list.AddPrev(new GameObject("before first"));

        list.Add(new GameObject("test1"));
        list.MoveToNext();
        list.AddPrev(new GameObject("test2"));
        list.MoveToPrev();
        list.Add(new GameObject("test3"));
        list.Add(new GameObject("test4"));

        PrintEveryNode(list);
    }
    public void PrintEveryNode(MyCircularyLinkedList list)
    {
        list.ResetToHeader();
        do
        {
            Debug.Log(list.GetCurrent().name);
            list.MoveToNext();

        } while (!list.isCurrentNodeHeader());
    }
    // Update is called once per frame
    void Update()
    {

    }
}
