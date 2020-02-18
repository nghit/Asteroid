using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    public float invulnPeriod = 0.5f;
    float invuln = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;
        spriteRend = GetComponent<SpriteRenderer>();
        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
            Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
        }
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");

        health--;
        invuln = invulnPeriod;
        gameObject.layer = 10;
       
    }

    void Update()
    {
        if (invuln > 0)
        {
            invuln -= Time.deltaTime;

            if (invuln <= 0)
            {
                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;

                }
            }   
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }


            
        }

    
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
