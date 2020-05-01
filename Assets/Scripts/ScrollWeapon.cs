using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWeapon : MonoBehaviour
{

    [SerializeField] Inventory inventory;
    [SerializeField] Shooting shootScript;


    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        shootScript = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
     
        
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {

            Debug.Log("we are scrolling!");

            if (shootScript.gunIndex == inventory.inventory.Count - 1)
                return;
            else
            {

                inventory.inventory[shootScript.gunIndex].magazine = shootScript.magazine;
                shootScript.gunIndex++;

                Debug.Log(shootScript.gunIndex);

                shootScript.SetWeapon(shootScript.gunIndex);
            }


           
               

            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (shootScript.gunIndex == 0)
                return;
            else
            {

                Debug.Log(shootScript.gunIndex);

                inventory.inventory[shootScript.gunIndex].magazine = shootScript.magazine;
                shootScript.gunIndex--;

                shootScript.SetWeapon(shootScript.gunIndex);
            }




        }
    }
}
