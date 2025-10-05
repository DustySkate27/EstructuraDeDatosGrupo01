using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EJ11Executer : MonoBehaviour
{
    [Header("Ingresa valor")]
    [SerializeField] private TMP_InputField inputFieldInsert;

    [Header("Devolver Height")]
    [SerializeField] private TMP_InputField getHeightPreOrder;
    [SerializeField] private TMP_InputField getHeightInOrder;
    [SerializeField] private TMP_InputField getHeightPostOrder;

    [Header("Balance Factor")]
    [SerializeField] private TMP_InputField getBalanceFactor;

    [Header("Mostrar resultados")]
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI heightText;
    [SerializeField] private TextMeshProUGUI balanceText;

    [SerializeField] private Button breadthSearchButton;

    MyABBTree<string> tree;

    // Start is called before the first frame update
    void Start()
    {
        tree = new MyABBTree<string>();

        inputFieldInsert.onEndEdit.AddListener(AddValue);

        getHeightPreOrder.onEndEdit.AddListener(GetPreOrder);
        getHeightInOrder.onEndEdit.AddListener(GetInOrder);
        getHeightPostOrder.onEndEdit.AddListener(GetPostOrder);

        getBalanceFactor.onEndEdit.AddListener(GetBalnceFactor);

        breadthSearchButton.onClick.AddListener(GetBreadthSearch);

    }

    public void AddValue(string value)
    {
        tree.Insert(value);
    }

    public void GetPreOrder(string value)
    {
        heightText.text = tree.PreOrderGetHeight(value).ToString();
    }

    public void GetInOrder (string value)
    {
        heightText.text = tree.InOrderGetHeight(value).ToString();
    }

    public void GetPostOrder(string value)
    {
        heightText.text = tree.PostOrderGetHeight(value).ToString();
    }

    public void GetBalnceFactor(string value)
    {
        balanceText.text = tree.BalanceFactor(value).ToString();
    }

    public void GetBreadthSearch()
    {
        tree.BreadthSearch();
    }

}
