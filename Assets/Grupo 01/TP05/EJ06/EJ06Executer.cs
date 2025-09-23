using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EJ06Executer : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI resultText;

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
    int baseP = 2;
    #endregion

    char[] frase;
    char[] copy;

    private void Awake()
    {
        inputField.onEndEdit.AddListener(EnterValue);
    }

    public void EnterValue(string value)
    {
        switch (currentFuction)
        {
            case fuction.fibonacci:

                value = value.Trim();
                numberInt = int.Parse(value);
                resultText.text = Fibonacci(numberInt).ToString();

                break;

            case fuction.factorial:

                value = value.Trim();
                numberInt = int.Parse(value);
                resultText.text = Factorial(numberInt).ToString();

                break;

            case fuction.suma:

                value = value.Trim();
                numberInt = int.Parse(value);
                resultText.text = Suma(numberInt).ToString();

                break;

            case fuction.piramide:

                value = value.Trim();
                numberInt = int.Parse(value);
                Piramide(numberInt, baseP);
                resultText.text = line;
                line = null;

                break;

            case fuction.palidromo:
                resultText.text = Palindromo(value).ToString();

                break;

            default:
                Debug.Log("No se ingreso ninguna funcion a realizar");
                break;
        }
    }

    private int Fibonacci(int n)
    {
        if (n == 0 || n == 1) return 1;

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

        else return n - 1 + Suma(n - 1);
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
            baseP = 2;
            return "\nFindePiramide";
        }
        else
        {
            line += "  \n" + new string('x', baseP);
            Debug.Log(line);
            return Piramide(altura - 1, baseP + 2);
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
