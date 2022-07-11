using UnityEngine;

public class Weapons : MonoBehaviour
{
    Playr playr;
    [SerializeField] Sprite[] weaponSprite;
    float timeSpownBulet = 0f;

    void Start()
    {
        playr = FindObjectOfType<Playr>();
    }

    void Update()
    {
        
    }


    public void ChooseWeapons(int typeWeapons)
    {
        playr.GetComponent<Playr>().SetTypeWeapons(typeWeapons);
        GetComponent<SpriteRenderer>().sprite = weaponSprite[typeWeapons];
    }

    public float GetTimeSpowmBullet()
    {
        return timeSpownBulet;
    }

    public void SetTimeSpowmBullet(float timeSpownBulet)
    {
        this.timeSpownBulet = timeSpownBulet;
    }

    public void pickUpWeapon(int typeWeapon, float timeSpownBulet)
    {
        playr.GetComponent<Playr>().SetTypeWeapons(typeWeapon);
        GetComponent<SpriteRenderer>().sprite = weaponSprite[typeWeapon];
        this.timeSpownBulet = timeSpownBulet;
    }
}
