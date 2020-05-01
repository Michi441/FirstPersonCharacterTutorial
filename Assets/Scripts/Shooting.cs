using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform shootPoint;


    public Animator anim;



    [SerializeField] bool isShooting = false;
    public bool isReloading = false;



    public int ammo = 32;

    public int magazine = 32;


    [SerializeField] float shootTimer = 1.5f;

    [SerializeField] AudioSource gunSound;

    [SerializeField] GameObject hit_fx;
    [SerializeField] GameObject bullet_hole;

    public WeaponsDatabase weaponDatabase;

    private Inventory inventory;


    public GameObject gunGameMesh;

    [SerializeField] Transform gunHold;



    public int gunIndex = 0;


    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;


        inventory = GetComponent<Inventory>();



        //weaponDatabase = GetComponentInChildren<WeaponsDatabase>();
        ammo = Inventory.instance.inventory[gunIndex].ammo;
        magazine = Inventory.instance.inventory[gunIndex].magazine;
        shootTimer = Inventory.instance.inventory[gunIndex].shootTimer;
        gunSound.clip = Inventory.instance.inventory[gunIndex].shootSound;



        mainCam = Camera.main;

        if (gunGameMesh != null)
            Destroy(gunGameMesh);


        GameObject gunMesh = Instantiate(inventory.inventory[gunIndex].weaponMesh, gunHold.position, Quaternion.identity);

        gunMesh.transform.parent = gunHold;

        



        gunGameMesh = gunMesh;


        anim = gunGameMesh.GetComponent<Animator>();



        




        shootPoint = gunMesh.transform.GetComponentInChildren<Transform>();



       
    }

    public void SetWeapon(int index)
    {



        // Avoid any reload.

        ammo = inventory.inventory[index].ammo;
        magazine = inventory.inventory[index].magazine;
        shootTimer = inventory.inventory[index].shootTimer;
        gunSound.clip = inventory.inventory[index].shootSound;


        mainCam = Camera.main;

        if (gunGameMesh != null)
            Destroy(gunGameMesh);






            GameObject gunMesh = Instantiate(inventory.inventory[index].weaponMesh, gunHold.position, Quaternion.Euler(gunHold.eulerAngles.x, transform.eulerAngles.y, gunHold.eulerAngles.z), gunHold.transform);

            //gunMesh.transform.SetParent(gunHold);
            Debug.Log(gunHold.position);

            gunGameMesh = gunMesh;

            anim = gunGameMesh.GetComponent<Animator>();





            shootPoint = gunMesh.transform.GetComponentInChildren<Transform>();
        

       

    }



    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("reload_no_ammo"))
            isReloading = true;
        else
            isReloading = false;


        anim.SetBool("isFiring", isShooting);

      
        if (magazine > 0 && isShooting == false && isReloading == false)
        {
            Shoot();

        }
     

        Reload();

        
        
    }



    void Shoot()
    {


        if (!Inventory.instance.inventory[gunIndex].isPistol)
        {
            if (Input.GetMouseButton(0))
            {

                StartCoroutine("ShootingMechanics", shootTimer);
                Debug.Log("SHOOTING");
                Ray ray;
                RaycastHit hit;
                if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, 100f))
                {

                    GameObject hitFX = Instantiate(hit_fx, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    GameObject bulletFX = Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));


                    if (hit.collider.GetComponent<Health>() != null)
                    {

                        Debug.Log("found health script...");


                        hit.collider.GetComponent<Health>().DealDMG(50);
                    }



                }
            }
        } else
        {

            if (Input.GetMouseButtonDown(0))
            {



                StartCoroutine("ShootingMechanics", shootTimer);
                Debug.Log("SHOOTING");
                Ray ray;
                RaycastHit hit;
                if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, 100f))
                {

                    GameObject hitFX = Instantiate(hit_fx, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    GameObject bulletFX = Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));


                    if (hit.collider.GetComponent<Health>() != null)
                    {

                        Debug.Log("found health script...");


                        hit.collider.GetComponent<Health>().DealDMG(50);
                    }



                }
            }
        }
        
    }


    IEnumerator ShootingMechanics(float timer)
    {

        if (magazine > 0)
            magazine--;


        isShooting = true;

        gunSound.Play();
        
        
        

        yield return new WaitForSeconds(timer);

        isShooting = false;
    }

    void Reload()
    {
        

        if (magazine == 0 && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reloading gun...");
            if (ammo > 0)
            {

                    if(ammo >= Inventory.instance.inventory[gunIndex].orgMagazineSize)
                {

                    anim.SetTrigger("reloading");

                    //Manipulate the current ammo and magazine on this shooting script.
                    magazine = Inventory.instance.inventory[gunIndex].orgMagazineSize;
                    ammo -= Inventory.instance.inventory[gunIndex].orgMagazineSize;

                    //ammo = 64 -32 = 32 ammo bullets left. 
                    Debug.Log("current gun index:" + gunIndex);

                    //and then store the value to our inventory script. 
                    Inventory.instance.inventory[gunIndex].ammo = ammo;
                    Inventory.instance.inventory[gunIndex].magazine = magazine;
                } else
                {

                    anim.SetTrigger("reloading");

                    //Manipulate the current ammo and magazine on this shooting script.
                    magazine = ammo;
                    ammo -= ammo;

                    //ammo = 64 -32 = 32 ammo bullets left. 
                    Debug.Log("current gun index:" + gunIndex);

                    //and then store the value to our inventory script. 
                    Inventory.instance.inventory[gunIndex].ammo = ammo;
                    Inventory.instance.inventory[gunIndex].magazine = magazine;
                }
              
                   
            }
        
        } else if( magazine > 0 && magazine != Inventory.instance.inventory[gunIndex].orgMagazineSize && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reloading not empty gun...");
            if (ammo > 0)
            {

                if (ammo >= Inventory.instance.inventory[gunIndex].orgMagazineSize)
                {
                    anim.SetTrigger("ammo_reload");

                    //Manipulate the current ammo and magazine on this shooting script.
                    int difference = Inventory.instance.inventory[gunIndex].orgMagazineSize - magazine;
                    ammo -= difference;
                    magazine = Inventory.instance.inventory[gunIndex].orgMagazineSize;

                    //ammo = 64 -32 = 32 ammo bullets left. 
                    Debug.Log("current gun index:" + gunIndex);

                    //and then store the value to our inventory script. 
                    Inventory.instance.inventory[gunIndex].ammo = ammo;
                    Inventory.instance.inventory[gunIndex].magazine = magazine;
                } else
                {

                    anim.SetTrigger("ammo_reload");

                    //Manipulate the current ammo and magazine on this shooting script.
                    int difference = Inventory.instance.inventory[gunIndex].orgMagazineSize - magazine;

                    if(ammo - difference > 0)
                    {

                        magazine = Inventory.instance.inventory[gunIndex].orgMagazineSize;
                        ammo -= difference;

                    } else
                    {
                        magazine = magazine + ammo;
                        ammo = 0;

                    }
               

                    //ammo = 64 -32 = 32 ammo bullets left. 
                    Debug.Log("current gun index:" + gunIndex);

                    //and then store the value to our inventory script. 
                    Inventory.instance.inventory[gunIndex].ammo = ammo;
                    Inventory.instance.inventory[gunIndex].magazine = magazine;
                }

             
            }

        }
    }
}
