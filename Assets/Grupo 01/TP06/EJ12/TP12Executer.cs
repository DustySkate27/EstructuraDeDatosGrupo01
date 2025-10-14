using Unity.VisualScripting;
using UnityEngine;

[ExecuteAlways]
public class TP12Executer : MonoBehaviour
{
    AVLTree<int> tree = new AVLTree<int>();
    public bool isRun;

    void Update()
    {
        if (!isRun)
            return;
        isRun = false;

        tree = new AVLTree<int>();

        for (int i = 0; i < 100; i++)
        {
            int number = Random.Range(0, 1001);
            tree.InsertN(number);
        }

        Debug.Log(tree.PostOrder());
    }
}