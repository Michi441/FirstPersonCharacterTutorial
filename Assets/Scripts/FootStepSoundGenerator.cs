using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSoundGenerator : MonoBehaviour
{


    public List<AudioClip> footStepSounds = new List<AudioClip>();


    public AudioSource leftFoot;

    // Start is called before the first frame update
    void Start()
    {

       
    }


    public void PlayFootStepSound()
    {
        int randomIndex = Random.Range(0, 2);

        Debug.Log(randomIndex);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
