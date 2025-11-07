using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class EJ15Executer : MonoBehaviour
{
    //Textos de inventarios
    [SerializeField] private TextMeshProUGUI inventoryText1;
    [SerializeField] private TextMeshProUGUI inventoryText2;
    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private RectTransform inventoryTransform1;
    [SerializeField] private RectTransform inventoryTransform2;
    [SerializeField] private RectTransform resultTransform;

    private string textSave;

    public MySetList<Items> player1;
    public MySetList<Items> player2;
    public SimpleList<Items> result;
    public MySetArray<Items> items;
    void Awake()
    {
        player1 = new MySetList<Items>();
        player2 = new MySetList<Items>();
        result = new SimpleList<Items>();
        items = new MySetArray<Items>();
    }
    private void Start()
    {
        InitializeItems(40);
        InitializeInventories(20);
    }

    void InitializeItems(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            items.Add(new Items($"item {i}", Random.Range(0, 100)));
        }
    }
    void InitializeInventories(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            if (Random.Range(0, 9) < 7) 
            {
                player1.Add(items.set[Random.Range(0, items.Cardinality())]);
                

            } 
        }

        for (int i = 0; i < player1.Cardinality(); i++)
        {
            inventoryText1.text += player1.Elements[i] + "\n";
            inventoryTransform1.sizeDelta = new Vector2(inventoryTransform1.sizeDelta.x, inventoryTransform1.sizeDelta.y + 25);
        }


        for (int i = 0; i < quantity; i++)
        {

            if (Random.Range(0, 9) < 7)
            {
                player2.Add(items.set[Random.Range(0, items.Cardinality())]);
                inventoryTransform2.sizeDelta = new Vector2(inventoryTransform2.sizeDelta.x, inventoryTransform2.sizeDelta.y + 25);
            }
        }

        for (int i = 0; i < player2.Cardinality(); i++)
        {
            inventoryText2.text += player2.Elements[i] + "\n";
            inventoryTransform2.sizeDelta = new Vector2(inventoryTransform2.sizeDelta.x, inventoryTransform2.sizeDelta.y + 25);
        }

        for (int i = 0;i < player1.Cardinality() + player2.Cardinality(); i++)
        {
            resultTransform.sizeDelta = new Vector2(resultTransform.sizeDelta.x, resultTransform.sizeDelta.y + 25);
        }

    }


    public void UnionF()
    {
        textSave = null;
        resultText.text = textSave;

        result = new SimpleList<Items>();
        result.AddRange(player1.Union(player2).Elements);

        for (int i = 0;i < result.Count; i++)
        {
            textSave += "Item" + result[i].name + ": " + new string(result[i].price.ToString()) + "\n";
        }

        resultText.text = textSave;
    }

    public void IntersectionF()
    {
        textSave = null;
        resultText.text = textSave;

        result = new SimpleList<Items>();
        result.AddRange(player1.Intersect(player2).Elements);

        for (int i = 0; i < result.Count; i++)
        {
            textSave += "Item" + result[i].name + ": " + new string(result[i].price.ToString()) + "\n";
        }

        resultText.text = textSave;
    }

    public void NotUsed()
    {

        textSave = null;
        resultText.text = textSave;

        result = new SimpleList<Items>();
        result = new SimpleList<Items>();

        Items[] resultAr = items.Difference(player1.Union(player2)).Elements;
        for (int i = 0; i < resultAr.Length; i++)
        {
            result.Add(resultAr[i]);
        }

        for (int i = 0; i < result.Count; i++)
        {
            textSave += "Item" + result[i].name + ": " + new string(result[i].price.ToString()) + "\n";
        }

        resultText.text = textSave;
    }
}