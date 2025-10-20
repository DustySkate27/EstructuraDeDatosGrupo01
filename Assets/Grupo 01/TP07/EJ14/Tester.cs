using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    MySetList<int> testList = new MySetList<int>();
    MySetList<int> testList2 = new MySetList<int>();

    int[] nums = { 1, 2, 3, 4 };
    int[] nums2 = {4, 5, 6};

    void Start()
    {
        for (int i = 0; i < nums.Length; i++) 
        { 
            testList.Add(nums[i]);

        }
        for (int i = 0; i < nums2.Length; i++)
        {
            testList2.Add(nums2[i]);

        }
        testList.Show();

      
        Debug.Log(testList.Difference(testList2)._ToString());
    }
}
