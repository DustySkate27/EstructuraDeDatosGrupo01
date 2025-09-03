using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EJ06Executer : MonoBehaviour
{
    public enum fuction
    {
        fibonacci,
        factorial,
        suma,
        piramide,
        palidromo
    }

    int numberInt;

    private fuction currentFuction;

    public void EnterValue(string value)
    {
        switch (currentFuction)
        {
            case fuction.fibonacci:

                numberInt = int.Parse(value);
                Fibonacci(numberInt);
                Debug.Log(numberInt);

                break;

            case fuction.factorial:

                numberInt = int.Parse(value);
                Factorial(numberInt);
                Debug.Log(numberInt);

                break;

            case fuction.suma:

                numberInt = int.Parse(value);
                Suma(numberInt);
                Debug.Log(numberInt);

                break;

            case fuction.piramide:
                break;

            case fuction.palidromo:
                break;

            default:
                Debug.Log("No se ingreso ninguna fucion a realizar");
                break;
        }
    }

    private int Fibonacci(int n)
    {
        if (n == 0) return 1;
        if (n == 1) return 1;

        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    private int Factorial(int n)
    {
        if (n == 0|| n == 1) return 1;

        else return n * Factorial(n - 1);
    }

    private int Suma(int n)
    {
        if (n == 0) return 0;

        else return n + Suma(n - 1);
    }








    //Set Enum
    public void SetFibonacci()
    {
        currentFuction = fuction.fibonacci;
    }

    public void SetFactorial()
    {
        currentFuction = fuction.factorial;
    }

    public void SetSuma()
    {
        currentFuction = fuction.suma;
    }

    public void SetPiramide()
    {
        currentFuction = fuction.piramide;
    }

    public void SetPalidromo()
    {
        currentFuction = fuction.palidromo;
    }
}
