using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interaction : MonoBehaviour
{
    public string message; // Optional: A message to display when interacting
    public UnityEvent onInteraction;

    public static bool hasPickedUpItem = false;

    // Called when the player interacts with the object
    public void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name); // Log interaction
        onInteraction.Invoke(); // Trigger custom interaction logic

       

        // Optional: Destroy the object after interaction
        Destroy(gameObject);
        
    }
}
