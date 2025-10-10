using UnityEngine;

[ExecuteAlways]
public class EJ10Executer : MonoBehaviour
{
    MyABBTree<int> tree = new MyABBTree<int>();
    int[] numbers = new int[] { 10, 5, 11, 3, 6, 7 };
    public bool isRun;

    void Update()
    {
        if (!isRun)
            return;
        isRun = false;

        tree = new MyABBTree<int>();

        foreach (int i in numbers)
        {
            int index = i;
            tree.Insert(index);
        }

        Debug.Log(tree.PreOrder());
    }
}