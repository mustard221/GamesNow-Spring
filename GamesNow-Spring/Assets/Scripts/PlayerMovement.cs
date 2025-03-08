using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public AudioSource walkingSound, sprintSound;

    public float speed = 12f; // Walking speed
    public float sprintSpeed = 18f; // Running speed
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;

    [HideInInspector] public StaminaScript _staminaScript;

    public KeyCode sprintKey = KeyCode.LeftShift;

    private void Start()
    {
        _staminaScript = GetComponent<StaminaScript>();
    }

    public void setRunSpeed(float speed)
    {
        sprintSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Check if its on ground

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walkingSound.enabled = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walkingSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                walkingSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            walkingSound.enabled = false;
            sprintSound.enabled = false;
        }


        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }

        //Player control movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // if player is pressing the sprint key and has stamina allowing to sprint
        isSprinting = Input.GetKey(sprintKey) && _staminaScript.playerStamina > 0;

        if (isSprinting)
        {
            _staminaScript.weAreSprinting = true;
            _staminaScript.Sprinting();
            controller.Move(move * sprintSpeed * Time.deltaTime);  // Move with sprinting speed
        }
        else
        {
            _staminaScript.weAreSprinting = false;
            controller.Move(move * speed * Time.deltaTime); // Move with walk speed
        }
        if (_staminaScript.playerStamina <= 0)
        {
            _staminaScript.weAreSprinting = false;
            _staminaScript.playerStamina = 0;
            setRunSpeed(speed); // Set speed back to walking speed when stamina is 0
        }
        else if (_staminaScript.playerStamina > 0)
        {
            setRunSpeed(4); // Set speed back to sprinting speed when stamina is above 0
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
