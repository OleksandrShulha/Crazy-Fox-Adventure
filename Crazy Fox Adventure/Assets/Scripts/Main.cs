using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Playr playr;
    public Text coinText;
    public Image[] hearts;
    public Sprite isLife, noLife, falseLife;
    int maxPlayrHp;
    public GameObject pouseScreen;

    private void Start()
    {
        maxPlayrHp = playr.GetMaxPlayrHealth();
    }

    private void Update()
    {
        UIHPBar();
    }


    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SetCoinTextOnGameUI(int coinLVL)
    {
        coinText.text = coinLVL.ToString();
    }

    void UIHPBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i > maxPlayrHp - 1)
                hearts[i].sprite = falseLife;
            else
            {
                if (playr.CurentPlayrHealth() > i)
                    hearts[i].sprite = isLife;
                else
                    hearts[i].sprite = noLife;
            }
        }
    }

    public void PouseOn()
    {
        Time.timeScale = 0f;
        playr.enabled = false;
        pouseScreen.SetActive(true);

    }

    public void PouseOff()
    {
        Time.timeScale = 1f;
        playr.enabled = true;
        pouseScreen.SetActive(false);
    }


}
