using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private SpriteRenderer ren;
    private int level;

    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();

        //Determine the level of the objective (lower chances for higher levels)
        int ran = Random.Range(1, 101);
        if(ran <= 40)
        {
            level = 1;
        }else if(ran <= 70)
        {
            level = 2;
        }else if(ran <= 85)
        {
            level = 3;
        }else if(ran <= 95)
        {
            level = 4;
        }else if(ran <= 100)
        {
            level = 5;
        }

        ApplyLevelAttributes();

    }

    //Sets level specific attributes such as color and points gained on desctruction
    private void ApplyLevelAttributes()
    {
        switch (level)
        {
            case 1:
                ren.color = Color.green;
                break;
            case 2:
                ren.color = Color.cyan;
                break;
            case 3:
                ren.color = new Color(1, 0.5f, 0);
                break;
            case 4:
                ren.color = Color.red;
                break;
            case 5:
                ren.color = new Color(0.5f, 0, 1);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(level > 1)
        {
            level--;
            ApplyLevelAttributes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
