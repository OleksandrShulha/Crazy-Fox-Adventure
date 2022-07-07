using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AnimationState(1);
        }
    }

    public void AnimationState(int animParam)
    {
        anim.SetInteger("state", animParam);
        Invoke("OpenScene", 3f);
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(0);
    }

}
