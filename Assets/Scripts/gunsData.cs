using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gunsData {


    public int id;
    public int ammo;
    public int orgMagazineSize;
    public int magazine;
    public string name;
    public GameObject weaponMesh;
    public AudioClip shootSound;
    public float shootTimer;
    public bool isPistol;

  
    

    public gunsData(int _id, int _ammo, int _magazine, int _orgMagazine, string _name, GameObject _weaponMesh, AudioClip _shootSound, float _shootTimer, bool _isPistol)
    {

        
        id = _id;
        ammo = _ammo;
        magazine = _magazine;
        name = _name;
        weaponMesh = _weaponMesh;
        shootSound = _shootSound;
        shootTimer = _shootTimer;
        orgMagazineSize = _orgMagazine;
        isPistol = _isPistol;
    
    }
}
