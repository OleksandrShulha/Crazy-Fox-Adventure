using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject AboutScreen, HomeScreen, HeroPanel;
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void AboutOn()
    {
        AboutScreen.SetActive(true);
        HomeScreen.SetActive(false);
        HeroPanel.SetActive(false);
    }

    public void HomeOn()
    {
        AboutScreen.SetActive(false);
        HomeScreen.SetActive(true);
        HeroPanel.SetActive(true);
    }
}
