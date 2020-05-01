using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Instance
    public static Inventory instance;


    public List<gunsData> inventory = new List<gunsData>();


    private void Awake()
    {
        if (instance == null)
            instance = this;


    }


    private void Start()
    {

        inventory.Add(WeaponsDatabase.instance.guns[0]);
        inventory.Add(WeaponsDatabase.instance.guns[1]);

    }


}
