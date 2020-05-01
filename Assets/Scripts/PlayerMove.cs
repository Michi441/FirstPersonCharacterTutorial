using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    [SerializeField] float speed = 150f;
    [SerializeField] float runningSpeed = 300f;

    [SerializeField] float rotationYSpeed = 5.0f;
    [SerializeField] float rotationXSpeed = 5.0f;



    [SerializeField] Camera mainCam;


    [SerializeField] bool inverseCamera = false;


   
    [SerializeField] bool isWalking = false;
    public bool isJumping = false;
    public bool isRunning = false;

    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float jumpTimer = 5.0f;



    [SerializeField] Shooting shootScript;





    [SerializeField] FootStepGenerator soundGenerator;
    [SerializeField] float footStepTimer;










    private float rotateY, rotateX;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();

        mainCam = Camera.main;

        soundGenerator = GetComponent<FootStepGenerator>();

        shootScript = GetComponent<Shooting>();

       
      
        
    }

    private void Update()
    {
        Running();

    }

    void Running()
    {

        if (Input.GetKey(KeyCode.LeftShift))
            isRunning = true;
        else
            isRunning = false;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
      

        Move();

        PlayerRotationSide();

        PlayerRotationUpDown();

        Jump();


        
    }


    void Move()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 playerVelocity = new Vector3(h, 0, v);



       

        if (!isRunning)
            playerVelocity *= speed;
        else
            playerVelocity *= runningSpeed;

        playerVelocity = transform.TransformDirection(playerVelocity);

        if (playerVelocity.x < 0 || playerVelocity.x > 0 || playerVelocity.y < 0 || playerVelocity.y > 0 || playerVelocity.z < 0 || playerVelocity.z > 0)
        {
            if (!isWalking && !isJumping)
                PlayFootSound();

            shootScript.anim.SetBool("isRunning", isRunning);




        }



        var velocityChange = playerVelocity - rb.velocity;
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void Jump()
    {

        if (isJumping)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("JumpTask", jumpTimer);


    }


    IEnumerator JumpTask(float timer)
    {

        rb.velocity = new Vector3(0, jumpForce, 0);
        isJumping = true;
        yield return new WaitForSeconds(timer);

        isJumping = false;


    }


    void PlayFootSound()
    {

        StartCoroutine("PlayStepSound", footStepTimer);
    }

    IEnumerator PlayStepSound(float timer)
    {

        var randomIndex = Random.Range(0, 5);
        soundGenerator.audioSource.clip = soundGenerator.footStepSounds[randomIndex];

        soundGenerator.audioSource.Play();
        isWalking = true;

        yield return new WaitForSeconds(timer);


        isWalking = false;
    }

   


    void PlayerRotationSide()
    {

        
        

        rotateY = Input.GetAxis("Mouse X") * rotationYSpeed * Time.deltaTime;


        transform.Rotate(0, rotateY, 0);

    }

    void PlayerRotationUpDown()
    {

        if(inverseCamera)
            rotateX += Input.GetAxis("Mouse Y") * rotationXSpeed * Time.deltaTime;
        else
            rotateX += -Input.GetAxis("Mouse Y") * rotationXSpeed * Time.deltaTime;

        float clampedRotation = Mathf.Clamp(rotateX, -90, 90);


        mainCam.transform.rotation = Quaternion.Euler(clampedRotation, transform.eulerAngles.y, transform.eulerAngles.z);

    }
}
