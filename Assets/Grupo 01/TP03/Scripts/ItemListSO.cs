using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemListSO", menuName = "ScriptableObject/ItemListSO")]
public class ItemListSO : ScriptableObject
{
  public ItemSO[] itemList;

    private void OnValidate()
    {
        if (itemList == null) return;
    }
}
