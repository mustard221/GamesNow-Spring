using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteractable();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
            HUDController.instance.DisableInteractionText();
        }
    }

    void CheckInteractable()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.CompareTag("Interactable")) // if looking at an interactable object
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable != newInteractable)
                {
                    currentInteractable = newInteractable; // set new interactable

                    HUDController.instance.EnableInteractionText(currentInteractable.message);
                }
            }
            else // if not an interactable
            {
                if (currentInteractable != null)
                {
                    currentInteractable = null;
                    HUDController.instance.DisableInteractionText();
                }
            }
        }
        else // if nothing is in reach
        {
            if (currentInteractable != null)
            {
                currentInteractable = null;
                HUDController.instance.DisableInteractionText();
            }
        }
    }
}
