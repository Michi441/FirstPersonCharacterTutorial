using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{


    [SerializeField] GameObject canvas;
    [SerializeField] Text ammoText;
    [SerializeField] GameObject ammoPanel;


    [SerializeField] Shooting shootScript;
    // Start is called before the first frame update
    void Start()
    {
        shootScript = GetComponent<Shooting>();
        canvas = GameObject.Find("UI").gameObject;
        ammoPanel = canvas.transform.Find("AmmoPanel").gameObject;
        ammoText = ammoPanel.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Ammo();
    }


    void Ammo()
    {


        ammoText.text = "Ammo: " + shootScript.magazine.ToString() + "/" + shootScript.ammo.ToString();


    }
}
