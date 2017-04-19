using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour {

    public Button yourButton;

    void Start()
    {
        yourButton = GetComponent<Button>();
        Time.timeScale = 1;
        yourButton.onClick.AddListener(TaskOnClick);
  
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
