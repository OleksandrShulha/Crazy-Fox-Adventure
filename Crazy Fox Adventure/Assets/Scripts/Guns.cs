using UnityEngine;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{
    Animator anim;
    Weapons weapons;
    [SerializeField] int typeWeapons;
    [SerializeField] float timeSpownBulet;
    public Button btnWeaponsUI;


    void Start()
    {
        anim = GetComponent<Animator>();
        weapons = FindObjectOfType<Weapons>();
    }

    void TakeGun()
    {
        AnimationGun();
        Invoke("destroyGun", 1f);
    }

    void AnimationGun()
    {
        anim.SetInteger("state", 1);
    }

    void destroyGun()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeGun();
            weapons.GetComponent<Weapons>().pickUpWeapon(typeWeapons, timeSpownBulet);

            btnWeaponsUI.interactable = true;
            btnWeaponsUI.GetComponent<Button>().onClick.Invoke();

        }

    }

}
