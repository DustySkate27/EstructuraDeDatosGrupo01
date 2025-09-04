using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    #region piramide
    string line;
    int baseP = 1;
    #endregion

    char[] frase;
    char[] copy;

    public void EnterValue(string value)
    {
        switch (currentFuction)
        {
            case fuction.fibonacci:

                value = value.Trim();
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

    bool Palindromo(string frase)
    {
        char[] characters = frase.ToCharArray();
        char[] copy = new char[characters.Length];
        return recursividadPalindromo(characters,0);

        bool recursividadPalindromo(char[] original, int index)
        {
            if (index == original.Length)
            {
                return original.SequenceEqual(copy);
            }
            else
            {
                copy[index] = original[original.Length - 1 - index];
                return recursividadPalindromo(original, index + 1);
            }
        }
    }

    string Piramide(int altura, int baseP)
    {
        if (altura <= 0)
        {
            baseP = 1;
            return "\nFindePiramide";
        }
        else
        {
            line = new string('x', baseP * 2);              

            return Piramide(altura - 1, baseP + 1);
        }

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
