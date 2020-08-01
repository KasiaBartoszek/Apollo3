using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    // Start is called before the first frame updatepublic int maxHP;
    

    public float maxOxygen;
    public float speedOfBreathing;
    public float actualOxygen;

    private OxygenBar oxygenBar;
    void Start()
    {
        actualOxygen = maxOxygen;

        oxygenBar = GetComponent<OxygenBar>();
        if(oxygenBar != null)
        {
            oxygenBar.initSlider(0,maxOxygen,actualOxygen);
        }
    }

    // Update is called once per frame
    void Update()
    {
        breath();
        setOxygenBar();
        if(!hasOxygen())
        {
                GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
                gm.gameOver();
        }
    }


    private void breath()
    {
        actualOxygen -= speedOfBreathing * Time.deltaTime;
    }

    private bool hasOxygen()
    {
        return actualOxygen > 0.0f;
    }



    private void setOxygenBar()
    {
        if(oxygenBar != null)
            oxygenBar.setSlider(actualOxygen);

    }
}
