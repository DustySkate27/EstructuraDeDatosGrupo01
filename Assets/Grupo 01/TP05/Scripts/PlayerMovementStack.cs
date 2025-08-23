using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovementStack : MonoBehaviour
{
    private float moveTime = 0.15f;
    private float waitTime = 0;

    private Vector2 targetPosition;
    private float inputX, inputY;
    private bool isMoving;

    private Vector2 originalPosition;

    private MyStack<Vector2> stack = new MyStack<Vector2>();

    private void Awake()
    {
        originalPosition = transform.position;
        stack.Push(transform.position);
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if ((inputX != 0 || inputY != 0) && !isMoving && Input.anyKeyDown)
        {
            CalculateTargetPosition();
            StartCoroutine(Move());
        }

        if (Input.GetKey(KeyCode.Z))
        {
            GoBack();
        }

        waitTime += Time.deltaTime;
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

        stack.Push(targetPosition);
        Debug.Log(stack.ToString());

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
        else if (inputY == 1)
        {
            targetPosition = (Vector2)transform.position + Vector2.up;
        }
        else if (inputY == -1)
        {
            targetPosition = (Vector2)transform.position + Vector2.down;
        }
    }

    private void GoBack()
    {
        if (waitTime > 0.2)
        {
            if (stack.TryPop(out targetPosition) && stack.Count != 0)
            {
                transform.position = targetPosition;
                Debug.Log(stack.ToString());
                waitTime = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, 0.15f);
    }

}  
