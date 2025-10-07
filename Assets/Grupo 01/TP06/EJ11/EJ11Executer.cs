using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SimpleListLibrary;

public class EJ11Executer : MonoBehaviour
{
    [Header("Ingresa valor")]
    [SerializeField] private TMP_InputField inputFieldInsert;

    [Header("Devolver Height")]
    [SerializeField] private TMP_InputField getHeight;

    [Header("Devolver Orden")]
    [SerializeField] private Button preOrder;
    [SerializeField] private Button inOrder;
    [SerializeField] private Button postOrder;

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
        tree = new MyABBTree<int>();

        inputFieldInsert.onEndEdit.AddListener(AddValue);

        getHeight.onEndEdit.AddListener(GetHeight);

        preOrder.onClick.AddListener(PreOrder);
        inOrder.onClick.AddListener(InOrder);
        postOrder.onClick.AddListener(PostOrder);

        getBalanceFactor.onEndEdit.AddListener(GetBalanceFactor);

        breadthSearchButton.onClick.AddListener(GetBreadthSearch);

    }

    public void AddValue(string value)
    {
        tree.Insert(value);
    }

    public void GetHeight(string value)
    {
        heightText.text = tree.GetHeight(value).ToString();
    }

    public void PreOrder()
    {
        SimpleList<TreeNode<int>> list = tree.PreOrder();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }
    public void InOrder()
    {
        SimpleList<TreeNode<int>> list = tree.InOrder();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }
    public void PostOrder()
    {
        SimpleList<TreeNode<int>> list = tree.PostOrder();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }
   
    public void GetBalanceFactor(int value)
    {
        balanceText.text = tree.BalanceFactor(value).ToString();
    }

    public void GetBreadthSearch()
    {
        tree.BreadthSearch();
    }

}
