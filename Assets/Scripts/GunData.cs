using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunData {

    public int id;
    public int ammo;
    public int original_ammo_size;
    public int magazine;
    public string name;
    public GameObject weaponMesh;
    public int dmg;
    public float shootTimer;
    public AudioClip gunShootingClip;


    public GunData(int _id, int _ammo, int _original_ammo_size, int _magazine, string _name, GameObject _weaponMesh, int _dmg, float _shootTimer, AudioClip _gunShootingClip)
    {


        id = _id;
        ammo = _ammo;
        original_ammo_size = _original_ammo_size;
        magazine = _magazine;
        name = _name;
        weaponMesh = _weaponMesh;
        dmg = _dmg;
        shootTimer = _shootTimer;
        gunShootingClip = _gunShootingClip;
    }



}
