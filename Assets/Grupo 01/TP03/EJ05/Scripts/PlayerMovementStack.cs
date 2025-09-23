using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovementStack : MonoBehaviour
{
    private float moveTime = 0.15f;

    private Vector2 targetPosition;
    private float inputX, inputY;
    private bool isMoving;

    private MyStack<Vector2> stack = new MyStack<Vector2>();

    private void Update()
    {
        
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if ((inputX != 0 || inputY != 0) && !isMoving && Input.anyKeyDown)
        {
            CalculateTargetPosition();
            StartCoroutine(Move());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GoBack();
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

        stack.Push(startPosition);
        transform.position = targetPosition;
        Debug.Log(stack.ToString());

        isMoving = false;
    }

    private void CalculateTargetPosition()
    {
        targetPosition.x = transform.position.x + inputX;
        targetPosition.y = transform.position.y + inputY;
    }

    private void GoBack()
    {

        if (stack.TryPop(out targetPosition))
        {
            transform.position = targetPosition;
            Debug.Log(stack.ToString());
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, 0.15f);
    }

}  
