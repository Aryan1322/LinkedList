using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestlinkList : MonoBehaviour
{
    public GameObject testGameobject;
    public GameObject testGameobject2;
    MyLinkedList myList;
    // Start is called before the first frame update
    void Start()
    {
        myList = new MyLinkedList(testGameobject);
        myList.Add(testGameobject2);
        myList.RemoveNext();
        myList.MoveToNext();
        GameObject CurentGo = myList.GetCurrent();
        CurentGo.GetComponent<Renderer>().material.color = Color.green;
    }

  
}
