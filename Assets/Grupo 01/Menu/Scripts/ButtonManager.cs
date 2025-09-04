using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button scene1;
    [SerializeField] private Button scene2;
    [SerializeField] private Button scene3;
    [SerializeField] private Button scene4;
    [SerializeField] private Button scene5;
    [SerializeField] private Button scene6;

    private void Awake()
    {
        scene1.onClick.AddListener(callScene1);
        scene2.onClick.AddListener(callScene2);
        scene3.onClick.AddListener(callScene3);
        scene4.onClick.AddListener(callScene4);
        scene5.onClick.AddListener(callScene5);
        scene6.onClick.AddListener(callScene6);
    }

    public void callScene1()
    {
        GameScenesManager.Instance.LoadGameScene(1);
    }
    public void callScene2()
    {
        GameScenesManager.Instance.LoadGameScene(2);
    }
    public void callScene3()
    {
        GameScenesManager.Instance.LoadGameScene(3);
    }
    public void callScene4()
    {
        GameScenesManager.Instance.LoadGameScene(4);
    }
    public void callScene5()
    {
        GameScenesManager.Instance.LoadGameScene(5);
    }
    public void callScene6()
    {
        GameScenesManager.Instance.LoadGameScene(6);
    }
}
