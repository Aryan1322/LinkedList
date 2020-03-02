using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MCLL
{
    public class MyCircularyLinkedList
    {
        private NodeCircular headerNode;
        private NodeCircular currentNode;




        public MyCircularyLinkedList(GameObject nodeItem)
        {
            headerNode = new NodeCircular(nodeItem);
            currentNode = headerNode;



            currentNode.nextNode = currentNode;
            currentNode.prevNode = currentNode;


        }

        public bool isCurrentNodeHeader()
        {
            if(headerNode == null)
            {
                return true;
            }
            else
            {

                return headerNode == currentNode;

            }
          
        }


        public GameObject PeekNext()
        {
            if (currentNode.nextNode != null)
            {
                return currentNode.nextNode.nodeInformation;
            }
            else
            {
                return null;
            }
        }

        public GameObject PeekPrev()
        {
            if (currentNode.prevNode != null)
            {
                return currentNode.prevNode.nodeInformation;
            }
            else
            {
                return null;
            }
        }
        public void ResetToHeader()
        {
            currentNode = headerNode;
        }
        //hw
        //check if current/header is null
        //create node that links to itself, set current and header to new node
        public void Add(GameObject nodeItem)
        {
            NodeCircular newNode = new NodeCircular(nodeItem);
            newNode.nextNode = currentNode.nextNode;
            if (newNode.nextNode != null)
            {
                currentNode.nextNode.prevNode = newNode;
            }
            newNode.prevNode = currentNode;

            currentNode.nextNode = newNode;
        }

        public void AddPrev(GameObject nodeItem)
        {
            NodeCircular newNode = new NodeCircular(nodeItem);
            newNode.nextNode = currentNode;
            newNode.prevNode = currentNode.prevNode;
            if (currentNode.prevNode != null)
            {
                currentNode.prevNode.nextNode = newNode;
            }

            currentNode.prevNode = newNode;
        }


        /*public void AddToFirst(GameObject nodeItem)
        {
            NodeCircular newFirstNode = new NodeCircular(nodeItem);
            newFirstNode.nextNode = headerNode;
            headerNode = newFirstNode;
            newFirstNode.prevNode = null;
        }*/

        public void RemoveNext()
        {
            if (currentNode == null)
            {
                return;
            }
            if (currentNode.nextNode == headerNode)
            {
                headerNode = currentNode;
            }
            if(currentNode.nextNode == currentNode)
            {
                currentNode = null;
                headerNode = null;
                return;
            }
            NodeCircular nodeSkip = currentNode.nextNode;
            if (nodeSkip != null)
            {

                if (currentNode.nextNode.nextNode != null)
                {
                    currentNode.nextNode = currentNode.nextNode.nextNode;
                    currentNode.nextNode.prevNode = currentNode;
                }



                nodeSkip.prevNode = null;
                nodeSkip.nextNode = null;
                nodeSkip = null;
            }

        }


        public void RemovePrev()
        {

            // check for null
            if (currentNode == null)
            {
                return;
            }
            //change header
            if (currentNode.prevNode == headerNode)
            {
                headerNode = currentNode;
            }
            if (currentNode.nextNode == currentNode)
            {
                currentNode = null;
                headerNode = null;
                return;
            }

            // remove perviuse node
            NodeCircular nodeSkip = currentNode.prevNode;
            if (nodeSkip != null)
            {

                currentNode.prevNode = currentNode.prevNode.prevNode;
                currentNode.prevNode.nextNode = currentNode;
            }
            nodeSkip.prevNode = null;
            nodeSkip.nextNode = null;
            nodeSkip = null;

        }


        public bool MoveToNext()
        {
            if (currentNode.nextNode != null)
            {
                currentNode = currentNode.nextNode;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveToPrev()
        {
            if (currentNode.prevNode != null)
            {
                currentNode = currentNode.prevNode;
                return true;
            }
            else
            {
                return false;
            }


        }

        public GameObject GetCurrent()
        {
            return currentNode.nodeInformation;
        }
    }




    public class NodeCircular
    {
        public NodeCircular nextNode;
        public NodeCircular prevNode;

        public GameObject nodeInformation;

        public NodeCircular(GameObject nodeInfo)
        {
            nodeInformation = nodeInfo;
            nextNode = null;

        }



    }


}