using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    [SerializeField] float destroyTimer = 1f;



    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void DealDMG(int dmg)
    {


        if (currentHealth > 0)
            currentHealth -= dmg;
    }

    private void Update()
    {
        if(currentHealth <= 0) {

            Debug.Log("no health left...");

            Destroy(this.gameObject, destroyTimer);
        }
    }
}
