using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP;

    private int actualHP;
    private bool isPlayer;
    void Start()
    {
        actualHP = maxHP;
        isPlayer = (gameObject.tag == "Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        actualHP -= damage;
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
                Destroy(gameObject);
            }
            
        }
    }
}
