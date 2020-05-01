using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsDatabase : MonoBehaviour
{

    public static WeaponsDatabase instance;
    public List<gunsData> guns = new List<gunsData>();

   
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
