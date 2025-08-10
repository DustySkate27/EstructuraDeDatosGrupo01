using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountButton : MonoBehaviour, IButtons
{
    private TP01Execute mainExecuter;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();

        button.onClick.AddListener(OnClickAction);
    }

    public void OnClickAction()
    {
        
    }
}
