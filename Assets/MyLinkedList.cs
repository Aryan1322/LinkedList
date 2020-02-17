using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLinkedList
{
    Node HeaderNode;
    Node CurrentNode;
    Node LastNode;

    public MyLinkedList(GameObject d)
    {
        HeaderNode = new Node(d);


        CurrentNode = HeaderNode;
        LastNode = HeaderNode;
    }
    public void Add(GameObject d)
    {
        Node newNode = new Node(d);
        newNode.nextNode = CurrentNode.nextNode;
        CurrentNode.nextNode = newNode;
    }
    public void AddFirst(GameObject d)
    {
        Node newNode = new Node(d);
        newNode.nextNode = HeaderNode.nextNode;
        HeaderNode.nextNode = newNode;
    }
    public void RemoveNext()
    {
        Node skipNode = CurrentNode.nextNode;
        //Current.nextNode = Current.nextNode.nextNode;
        skipNode = null;
    }
    public void LastNodes(GameObject d)
    {

        Node newNode = new Node(d);
        if (CurrentNode.nextNode == null)
        {
            newNode = LastNode;
        }
        CurrentNode.nextNode = newNode;
    }
    public void MoveToNext()
    {

        if (CurrentNode.nextNode != null)
        {
            CurrentNode = CurrentNode.nextNode;
        }
    }
    public GameObject GetCurrent()
    {
        return CurrentNode.data;

    }
}
public class Node
{
    public GameObject data;
    public Node nextNode;

    public Node(GameObject d)
    {
        data = d;
        nextNode = null;
    }

}