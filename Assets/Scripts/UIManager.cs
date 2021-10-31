using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadFirstLevel()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Level1Scence");
        
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("StarScence");
    }

     public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(GameObject.FindWithTag("QuitButton").GetComponent<Button>() != null){
        Button button = GameObject.FindWithTag("QuitButton").GetComponent<Button>();
        button.onClick.AddListener(() => QuitGame());
        }    
          
    }
}
