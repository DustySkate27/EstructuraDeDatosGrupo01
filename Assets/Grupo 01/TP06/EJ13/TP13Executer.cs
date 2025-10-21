using SimpleListLibrary;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TP13Executer : MonoBehaviour
{
    AVLTree<int> tree = new AVLTree<int>();

    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private RectTransform contentTransform;

    private string result;
    private int currentPlayer = 0;
    private SimpleList<int> checkerList = new SimpleList<int>();
    private Vector2 saveSizes;

    private void Start()
    {
        tree = new AVLTree<int>();
        saveSizes = contentTransform.sizeDelta;
    }

    public void PreOrder()
    {
        contentTransform.sizeDelta = saveSizes;

        ValueChecker();

        currentPlayer = 0;
        SimpleList<TreeNode<int>> list = tree.PreOrder();

        for (int i = 0; i < list.Count; i++)
        {
            result += "Player" + currentPlayer + ": " + new string(list[i].value.ToString()) + "\n";
            contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, contentTransform.sizeDelta.y + 22);
            currentPlayer++;

        }

        Debug.Log(tree.PreOrder());
        resultText.text = result;

        result = null;
        list.Clear();
        checkerList.Clear();
        tree = new AVLTree<int>();
    }

    public void InOrder()
    {
        contentTransform.sizeDelta = saveSizes;

        ValueChecker();

        currentPlayer = 0;
        SimpleList<TreeNode<int>> list = tree.InOrder();

        for (int i = 0; i < list.Count; i++)
        {
            result += "Player" + currentPlayer + ": " + new string(list[i].value.ToString()) + "\n";
            contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, contentTransform.sizeDelta.y + 22);
            currentPlayer++;

        }

        Debug.Log(tree.InOrder());
        resultText.text = result;

        result = null;
        list.Clear();
        checkerList.Clear();
        tree = new AVLTree<int>();
    }

    public void PostOrder()
    {
        contentTransform.sizeDelta = saveSizes;

        ValueChecker();

        currentPlayer = 0;
        SimpleList<TreeNode<int>> list = tree.PostOrder();

        for (int i = 0; i < list.Count; i++)
        {
            result += "Player" + currentPlayer + ": " + new string(list[i].value.ToString()) + "\n";
            contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, contentTransform.sizeDelta.y + 22);
            currentPlayer++;

        }

        Debug.Log(tree.PostOrder());
        resultText.text = result;

        result = null;
        list.Clear();
        checkerList.Clear();
        tree = new AVLTree<int>();

    }

    public void LevelOrder()
    {
        contentTransform.sizeDelta = saveSizes;

        ValueChecker();

        currentPlayer = 0;
        SimpleList<TreeNode<int>> list = tree.BreadthSearch();

        for (int i = 0; i < list.Count; i++)
        {
            result += "Player" + currentPlayer + ": " + new string(list[i].value.ToString()) + "\n";
            contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, contentTransform.sizeDelta.y + 22);
            currentPlayer++;

        }

        Debug.Log(tree.PostOrder());
        resultText.text = result;

        result = null;
        list.Clear();
        checkerList.Clear();
        tree = new AVLTree<int>();

    }

    public void ValueChecker()
    {
        int number = Random.Range(0, 1001);
        checkerList.Add(number);
        tree.InsertN(number);

        for (int i = 0; i < 100; i++)
        {
            number = Random.Range(0, 1001);

            for (int j = 0; j < checkerList.Count; j++)
            {
                if (number == checkerList[j])
                {
                    i--;
                    Debug.Log("volvi");
                    break;
                }
            }

            checkerList.Add(number);
            tree.InsertN(number);
        }
    }
}
