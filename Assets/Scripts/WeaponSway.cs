using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{



    [SerializeField] Vector3 orgPos;
   

    [SerializeField] float smoothness = 5;
    [SerializeField] float amount = 5;
    [SerializeField] float maxAmount = 5;




    [SerializeField] Shooting shootScript;
    // Start is called before the first frame update
    void Start()
    {
        shootScript = GetComponent<Shooting>();


        orgPos = shootScript.gunGameMesh.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {


        float movementY = Input.GetAxis("Mouse Y") * amount;
        float movementX = Input.GetAxis("Mouse X") * amount;

        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);



        Vector3 finalPosition = new Vector3(movementX, movementY, 0);

        shootScript.gunGameMesh.transform.localPosition = Vector3.Lerp(shootScript.gunGameMesh.transform.localPosition, orgPos + finalPosition, Time.deltaTime *  smoothness);
    }
}
