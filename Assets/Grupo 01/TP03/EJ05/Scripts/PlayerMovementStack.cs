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

    private Vector2 originalPosition;

    private MyStack<Vector2> stack = new MyStack<Vector2>();

    private void Awake()
    {
        originalPosition = transform.position;
        stack.Push(transform.position);
    }

    private void Update()
    {
        /*
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if ((inputX != 0 || inputY != 0) && !isMoving && Input.anyKeyDown)
        {
            CalculateTargetPosition();
            StartCoroutine(Move());
        }
        */
        
        //Reemplazar lo que esta comentado por una version igualmente hardcodeada pero con GetKeyDown
        CalculateTargetPosition();

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

        stack.Push(targetPosition);
        Debug.Log(stack.ToString());

        transform.position = targetPosition;
        isMoving = false;
    }

    private void CalculateTargetPosition()
    {
        //crear Vector3
        //Cambiar por getkeydown derecha
        if (inputX == 1)
        {
            //x = 1
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

        //normalizar vector al final
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
