using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayWeapon : MonoBehaviour
{


    [SerializeField] Vector3 orgPos;

    [SerializeField] Shooting shootScript;

    [SerializeField] float amount;

    [SerializeField] float maxAmount;

    [SerializeField] float smoothAmount;



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

        Vector3 finalPos = new Vector3(movementX, movementY, 0);


        shootScript.gunGameMesh.transform.position = Vector3.Lerp(shootScript.gunGameMesh.transform.localPosition, orgPos + finalPos, smoothAmount * Time.deltaTime);


    }
}
