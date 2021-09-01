using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text TutorialText;
    void Start()
    {
        TutorialText.gameObject.SetActive(false);
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void OnTutorialButton()
    {
        TutorialText.gameObject.SetActive(true);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
