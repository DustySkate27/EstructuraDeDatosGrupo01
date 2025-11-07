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
    [SerializeField] private TextMeshProUGUI outputText;

    [SerializeField] private Button breadthSearchButton;
    [SerializeField] private GameObject nodePrefab;

    [SerializeField] private float areaX;
    [SerializeField] private float areaY;

    MyList<GameObject> visualTree = new MyList<GameObject>();

    MyABBTree<int> tree;

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
        int num = int.Parse(value);
        tree.Insert(num);
    }

    public void GetHeight(string value)
    {
        int num = int.Parse(value);
        TreeNode<int> node = tree.TrackNodeByValue(num, tree.Root);
        heightText.text = tree.GetNodeHeight(node).ToString();
    }

    public void PreOrder()
    {
        outputText.text = "Order Output: ";
        SimpleList<TreeNode<int>> list = tree.PreOrder();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
            outputText.text +=  list[i].value.ToString() + ", " ;
        }
    }
    public void InOrder()
    {
        outputText.text = "Order Output: ";
        SimpleList<TreeNode<int>> list = tree.InOrder();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
            outputText.text += list[i].value.ToString() + ", ";
        }
    }
    public void PostOrder()
    {
        outputText.text = "Order Output: ";
        SimpleList<TreeNode<int>> list = tree.PostOrder();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
            outputText.text += list[i].value.ToString() + ", ";
        }
    }
   
    public void GetBalanceFactor(string value)
    {
        int num = int.Parse(value);
        TreeNode<int> node = tree.TrackNodeByValue(num, tree.Root);
        balanceText.text = tree.NodeBalanceFactor(node).ToString();
    }

    public void GetBreadthSearch()
    {
          outputText.text = "Order Output: ";
        SimpleList<TreeNode<int>> list = tree.BreadthSearch();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
            outputText.text += list[i].value.ToString() + ", ";
        }

        //tree.BreadthSearch();
    }

    public void ShowTree(TreeNode<int> node, Vector2 pos, float depth)
    {
        if (node == null) return;

        GameObject newNode = Instantiate(nodePrefab, pos, Quaternion.identity);
        visualTree.Add(newNode);
        newNode.GetComponentInChildren<TextMeshProUGUI>().text = node.value.ToString();

        if (node.left != null) ShowTree(node.left, pos + new Vector2( -areaX / (depth + 1.5f), areaY), depth + 1f);

        if (node.right != null) ShowTree(node.right, pos + (new Vector2(areaX / (depth + 1.5f), areaY)), depth + 1f);
    }

    public void DrawTree()
    {
        ShowTree(tree.Root, transform.position, 0);
    }

    public void ClearTree()
    {
        for (int i = 0; i < visualTree.Counter; i++)
        {
            GameObject.Destroy(visualTree[i]);
        }
        visualTree.Clear();
        tree = new MyABBTree<int>();
    }
}
