using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSightAiming : MonoBehaviour
{


    [SerializeField] Vector3 orgPos;
    [SerializeField] Vector3 newPos;
    [SerializeField] Vector3 pistolPos;


    

    private Shooting shootScript;
    private PlayerMove playerMove;

    [SerializeField] float timer;

    [SerializeField] Transform gunHoldReference;
    // Start is called before the first frame update
    void Start()
    {
        orgPos = gunHoldReference.localPosition;
        shootScript = GetComponent<Shooting>();
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        AimDownSight();

    }

    void AimDownSight()
    {

        if (Input.GetMouseButton(1) && !playerMove.isRunning && !playerMove.isJumping)
        {
            if (!Inventory.instance.inventory[shootScript.gunIndex].isPistol)
                gunHoldReference.localPosition = Vector3.LerpUnclamped(gunHoldReference.localPosition, orgPos + newPos, timer);
            else
                gunHoldReference.localPosition = Vector3.LerpUnclamped(gunHoldReference.localPosition, orgPos + pistolPos, timer);
        }


        else
        {
            if (!Inventory.instance.inventory[shootScript.gunIndex].isPistol)
                gunHoldReference.localPosition = Vector3.LerpUnclamped(orgPos + newPos, orgPos, 1f);
            else
                gunHoldReference.localPosition = Vector3.LerpUnclamped(orgPos + pistolPos, orgPos , timer);



        }
    }
}
