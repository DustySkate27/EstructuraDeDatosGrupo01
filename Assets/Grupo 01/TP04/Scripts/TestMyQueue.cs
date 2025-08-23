using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestMyQueue : MonoBehaviour
{
    private MyQueue<int> queue = new MyQueue<int>();

    public void AddToQueue()
    {
        int randomNum = Random.Range(1, 10);
        queue.Enqueue(randomNum);
        Debug.Log(queue.ToString());
    }

    public void RemoveFromQueue()
    {
        queue.Dequeue();
        Debug.Log(queue.ToString());
    }
}
