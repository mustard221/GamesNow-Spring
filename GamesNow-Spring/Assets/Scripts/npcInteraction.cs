using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interaction
{
    public void Interact();
}

public class npcInteraction : MonoBehaviour
{
    public Transform InteractSource;
    public float InteractRange;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractSource.position, InteractSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interaction interactObj))
                {
                    interactObj.Interact();
                }
            } 
        }
    }
}
