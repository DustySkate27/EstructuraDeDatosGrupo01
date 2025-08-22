using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveTime = 0.15f;
    private float currentTime = 0f;

    private Vector2 targetPosition;
    private float inputX, inputY;
    private bool isMoving;

    private bool playerTurn = true;
    private Vector2 originalPosition;

    private MyQueue<Vector2> queue = new MyQueue<Vector2>();

    private void Awake()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (playerTurn)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");

            if ((inputX != 0 || inputY != 0) && !isMoving && Input.anyKeyDown)
            {
                CalculateTargetPosition();
                StartCoroutine(Move());
            }
        }
        else
        {
            transform.position = originalPosition;
            ReplayMovements();
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        float timeElapsed = 0f;
        Vector2 startPosition = transform.position;

        while (timeElapsed < moveTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / moveTime);
            timeElapsed += Time.deltaTime;

            yield return null;  
        }

        queue.Enqueue(targetPosition);
        //Debug.Log(queue.ToString());

        transform.position = targetPosition;
        isMoving = false;
    }

    private void CalculateTargetPosition()
    {
        if (inputX == 1)
        {
            targetPosition = (Vector2)transform.position + Vector2.right;
        }
        else if (inputX == -1)
        {
            targetPosition = (Vector2)transform.position + Vector2.left;
        }
        else if(inputY == 1)
        {
            targetPosition = (Vector2)transform.position + Vector2.up;
        }
        else if (inputY == -1)
        {
            targetPosition = (Vector2)transform.position + Vector2.down;
        }
    }

    private void ReplayMovements()
    {
        for (int i = 0; i <= queue.Count; i++)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= moveTime)
            {
                //transform.position = queue.Dequeue();
                currentTime = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, 0.15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("meta"))
        {
            if (playerTurn)
            {
                playerTurn = false;
                Debug.Log(originalPosition);
            }
            else
            {
                playerTurn = true;
            }
        }
    }
}
