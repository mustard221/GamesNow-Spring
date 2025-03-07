using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string message; // Optional: A message to display when interacting
    public UnityEvent onInteraction;

    public static bool hasPickedUpItem = false;

    // Called when the player interacts with the object
    public void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name); // Log interaction
        onInteraction.Invoke(); // Trigger custom interaction logic

        // Lets it know that the item has been interacted with
        hasPickedUpItem = true;

        // Optional: Destroy the object after interaction
        Destroy(gameObject);
        
    }
}
