﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MLL

{
    public class MyCircularyLinkedList
    {
        private Node headerNode;
        private Node currentNode;
        private Node lastNode;
        


        public MyCircularyLinkedList(GameObject nodeItem)
        {
            headerNode = new Node(nodeItem);
            currentNode = headerNode;
            lastNode = headerNode;
        }


        public bool isNextNodeNull()
        {
            if (currentNode.nextNode != null)
            {
                return false;
            }
            else
            {
                return true;
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

        public void Add(GameObject nodeItem)
        {
            Node newNode = new Node(nodeItem);
            newNode.nextNode = currentNode.nextNode;
            if (newNode.nextNode == null)
            {
                lastNode = newNode;
            }
            else
            {
                currentNode.nextNode.prevNode = newNode;
            }
            newNode.prevNode = currentNode;

            currentNode.nextNode = newNode;
        }

        public void AddPrev(GameObject nodeItem)
        {
            Node newNode = new Node(nodeItem);
            newNode.nextNode = currentNode;
            newNode.prevNode = currentNode.prevNode;
            if (currentNode.prevNode != null)
            {
                currentNode.prevNode.nextNode = newNode;
            }
            else
            {
                headerNode = newNode;
            }
            currentNode.prevNode = newNode;
        }


        public void AddToFirst(GameObject nodeItem)
        {
            Node newFirstNode = new Node(nodeItem);
            newFirstNode.nextNode = headerNode;
            headerNode = newFirstNode;
            newFirstNode.prevNode = null;
        }

        public void RemoveNext()
        {
            Node nodeSkip = currentNode.nextNode;
            if (nodeSkip != null)
            {
                if (currentNode.nextNode.nextNode != null)
                {
                    currentNode.nextNode = currentNode.nextNode.nextNode;
                    currentNode.nextNode.prevNode = currentNode;
                }
                else
                {
                    currentNode.nextNode = null;
                    return;
                }

                nodeSkip.prevNode = null;
                nodeSkip.nextNode = null;
                nodeSkip = null;
            }

        }


        public void RemovePrev()
        {
            Node nodeSkip = currentNode.prevNode;
            if (nodeSkip != null)
            {
                if (currentNode.prevNode.prevNode != null)
                {
                    currentNode.prevNode = currentNode.prevNode.prevNode;
                    currentNode.prevNode.nextNode = currentNode;
                }
                else
                {
                    currentNode.prevNode = null;
                    return;
                }

                nodeSkip.prevNode = null;
                nodeSkip.nextNode = null;
                nodeSkip = null;
            }

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




    public class Node
    {
        public Node nextNode;
        public Node prevNode;

        public GameObject nodeInformation;

        public Node(GameObject nodeInfo)
        {
            nodeInformation = nodeInfo;
            nextNode = null;

        }



    }
}