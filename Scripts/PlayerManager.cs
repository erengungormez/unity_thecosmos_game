using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed;

    bool dead = false;

    Transform muzzle;

    public Transform bullet, floatingText, bloodParticle;

     
    void Start()
    {
        muzzle = transform.GetChild(1);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) 
        {
            ShootBullet();
        }
    }


    public void  GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

        if ((health - damage) >= 0)
        {
            health-= damage;
        }
        else
        {
            health = 0;
        }
        AmIdead();
    }

    void AmIdead()
    {
       if (health <= 0)
      {
        Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
        DataManager.Instance.LoseProcess(); 
        dead = true;  
        Destroy(gameObject);
      }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity); 
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataManager.Instance.ShotBullet++;
    }


}
