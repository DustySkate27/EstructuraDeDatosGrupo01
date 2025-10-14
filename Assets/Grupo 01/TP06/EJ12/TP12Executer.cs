using UnityEngine;

[ExecuteAlways]
public class TP12Executer : MonoBehaviour
{
    AVLTree<int> tree = new AVLTree<int>();
    int[] numbers = new int[] { 5, 2, 3};
    public bool isRun;

    void Update()
    {
        if (!isRun)
            return;
        isRun = false;

        tree = new AVLTree<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            tree.Insert(numbers[i]);
        }
    }
}