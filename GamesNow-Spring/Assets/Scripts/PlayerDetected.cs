using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    static public bool found = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            found = true;
            print (found);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            found = false;
            print (found);
        }
    }
}
