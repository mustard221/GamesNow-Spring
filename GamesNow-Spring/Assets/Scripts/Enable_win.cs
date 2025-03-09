using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Enable_win : MonoBehaviour
{

    public UnityEvent onExit;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onExit.Invoke(); // Enable fire alarm and win trigger after last teacher interaction
        }
    }

}
