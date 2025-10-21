using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJ15Executer : MonoBehaviour
{
    public MySetList<Items> player1;
    public MySetList<Items> player2;
    public MySetList<Items> result;
    public MySetArray<Items> items;
    void Awake()
    {
        player1 = new MySetList<Items>();
        player2 = new MySetList<Items>();
        result = new MySetList<Items>();
        items = new MySetArray<Items>();
    }
    private void Start()
    {
        InitializeItems(40);
        InitializeInventories(20);
        Debug.Log(Union().ToString());
        Debug.Log(Intersection().ToString());
        NotUsed();
        Debug.Log(result.ToString());
    }
    // Update is called once per frame
    void Update()
    {

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
            if (Random.Range(0, 9) < 7) player1.Add(items.set[Random.Range(0, items.Cardinality())]);
        }
        for (int i = 0; i < quantity; i++)
        {
            if (Random.Range(0, 9) < 7) player2.Add(items.set[Random.Range(0, items.Cardinality())]);
        }
    }

    MySet<Items> Union()
    {
        return player1.Union(player2);
    }

    MySet<Items> Intersection()
    {
        return player1.Intersect(player2);
    }

    void NotUsed()
    {
        Items[] resultAr = items.Difference(Union()).Elements();

        for (int i = 0; i < resultAr.Length; i++)
        {
            result.Add(resultAr[i]);
        }
    }
}