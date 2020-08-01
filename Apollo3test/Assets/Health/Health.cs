using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public int maxHP;
    

    private int actualHP;
    private bool isPlayer;

    private HealthBar healthBar;
    void Start()
    {
        actualHP = maxHP;
        isPlayer = (gameObject.tag == "Player");

        healthBar = GetComponent<HealthBar>();
        if(healthBar != null)
        {
            healthBar.initSlider(0,maxHP,actualHP);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        actualHP -= damage;
        setHealthBar();
        if(actualHP<=0)
        {
            if(isPlayer)
            {
                //Cant destroy player gameobject cause maincamera is under him in hierarchy.
                GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
                gm.gameOver();
            }
            else
            {
                GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
                gm.turretKilled();
                Destroy(gameObject);
            }
            
        }
        
    }

    private void setHealthBar()
    {
        if(healthBar != null)
            healthBar.setSlider(actualHP);

    }
}
