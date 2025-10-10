using UnityEngine;

[ExecuteAlways]
public class TP12Executer : MonoBehaviour
{
    AVLTree<int> tree = new AVLTree<int>();
    int[] numbers = new int[] { 1, 2, 3};
    public bool isRun;

    void Update()
    {
        if (!isRun)
            return;
        isRun = false;

        tree = new AVLTree<int>();

        foreach (int i in numbers)
        {
            int index = i;
            tree.aVLTree.Insert(index);
        }
        tree.Balance(1);
    }
}