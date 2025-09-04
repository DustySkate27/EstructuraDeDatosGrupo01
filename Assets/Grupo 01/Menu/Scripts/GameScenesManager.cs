using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : MonoBehaviour
{
    public int sceneCount;
    public static GameScenesManager Instance;
   
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        sceneCount = 0;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(sceneCount < 6)
            {
                sceneCount++;
                LoadGameScene(sceneCount);
            }else
            {
                sceneCount = 1;
                LoadGameScene(sceneCount);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (sceneCount > 1)
            {
                sceneCount--;
                LoadGameScene(sceneCount);
            }
            else
            {
                sceneCount = 6;
                LoadGameScene(sceneCount);
            }
           
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SceneButtonClick(int sceneName)
    {
        sceneCount = sceneName;
       LoadGameScene(sceneName);
    }

    public void LoadGameScene(int sceneName) 
    {
        SceneManager.LoadScene("EJ0" + sceneName.ToString());
    }

}
