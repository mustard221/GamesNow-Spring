using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interaction : MonoBehaviour
{
    public string message; // Optional: A message to display when interacting
    public UnityEvent onInteraction;
    public UnityEvent onPlayerCollided;
    public UnityEvent onExit;

    private bool playerInRange = false;

    public static bool hasPickedUpItem = false;

    // Called when the player interacts with the object
    public void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name); // Log interaction
        onInteraction.Invoke(); // Trigger custom interaction logic

        // Optional: Destroy the object after interaction
        Destroy(gameObject);
    }

    private void Update()
    {
        // Make sure interaction works w/ collider stuff
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact(); 
        }
    }

    // Enable interaction message
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            onPlayerCollided.Invoke(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            onExit.Invoke();
        }
    }
}
