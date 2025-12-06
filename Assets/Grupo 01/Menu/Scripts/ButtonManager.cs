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
    [SerializeField] private Button scene7;
    [SerializeField] private Button scene8;
    [SerializeField] private Button scene9;
    [SerializeField] private Button scene10;
    [SerializeField] private Button scene11;

    private void Awake()
    {
        scene1.onClick.AddListener(callScene1);
        scene2.onClick.AddListener(callScene2);
        scene3.onClick.AddListener(callScene3);
        scene4.onClick.AddListener(callScene4);
        scene5.onClick.AddListener(callScene5);
        scene6.onClick.AddListener(callScene6);
        scene7.onClick.AddListener(callScene7);
        scene8.onClick.AddListener(callScene8);
        scene9.onClick.AddListener(callScene9);
        scene10.onClick.AddListener(callScene10);
        scene11.onClick.AddListener(callScene11);
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
    public void callScene7()
    {
        GameScenesManager.Instance.LoadGameScene(7);
    }
    public void callScene8()
    {
        GameScenesManager.Instance.LoadGameScene(8);
    }
    public void callScene9()
    {
        GameScenesManager.Instance.LoadGameScene(9);
    }
    public void callScene10()
    {
        GameScenesManager.Instance.LoadGameScene(10);
    }
    public void callScene11()
    {
        GameScenesManager.Instance.LoadGameScene(11);
    }

}
