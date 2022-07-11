using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject AboutScreen, HomeScreen, HeroPanel, ChooseLvl, StorePanel;
    public Button[] lvls;
    public Text coinText;

    private void Start()
    {
    HomeOn();


     if (PlayerPrefs.HasKey("lvl"))
            for (int i=0; i < lvls.Length; i++)
            {
                if (i <= PlayerPrefs.GetInt("lvl"))
                    lvls[i].interactable = true;
                else
                {
                   lvls[i].interactable = false;
                   lvls[i].GetComponentInChildren<Text>().text = "";
                }
            }
     else
        {
            for (int i = 1; i < lvls.Length; i++)
            {
                lvls[i].interactable = false;
                lvls[i].GetComponentInChildren<Text>().text = "";
            }

        }
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("coin"))
            coinText.text = PlayerPrefs.GetInt("coin").ToString();
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void AboutOn()
    {
        AboutScreen.SetActive(true);
        HomeScreen.SetActive(false);
        HeroPanel.SetActive(false);
        ChooseLvl.SetActive(false);
        StorePanel.SetActive(false);
    }

    public void HomeOn()
    {
        AboutScreen.SetActive(false);
        HomeScreen.SetActive(true);
        HeroPanel.SetActive(true);
        ChooseLvl.SetActive(false);
        StorePanel.SetActive(false);

    }

    public void ChooseLvlOn()
    {
        AboutScreen.SetActive(false);
        HomeScreen.SetActive(false);
        HeroPanel.SetActive(false);
        ChooseLvl.SetActive(true);
        StorePanel.SetActive(false);

    }

    public void StorePanelOn()
    {
        AboutScreen.SetActive(false);
        HomeScreen.SetActive(false);
        HeroPanel.SetActive(false);
        ChooseLvl.SetActive(false);
        StorePanel.SetActive(true);

    }

    public void DelKeys()
    {
        PlayerPrefs.DeleteAll();
    }


}
