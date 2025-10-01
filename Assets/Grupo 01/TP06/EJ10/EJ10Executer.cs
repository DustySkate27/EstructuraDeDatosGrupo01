using UnityEngine;

public class EJ10Executer : MonoBehaviour
{
    MyABBTree<int> tree = new MyABBTree<int>();

    // Start is called before the first frame update
    void Start()
    {
        tree.Insert(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
