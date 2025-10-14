using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP13Executer : MonoBehaviour
{
    AVLTree<int> tree = new AVLTree<int>();
    public bool isRun;
    private bool doOnce = true;

    private void Start()
    {
        tree = new AVLTree<int>();
    }

    void Update()
    {
        if (doOnce)
        { 
            for (int i = 0; i < 100; i++)
            {
                int number = Random.Range(0, 1001);

                if (tree.Root == null)
                    tree.InsertN(number);
                if (number != tree.TrackNodeByValue(number, tree.Root).value)
                    tree.InsertN(number);
                else
                    i--;
            }

            Debug.Log(tree.PostOrder());
            doOnce = false;
        }
    }
}
