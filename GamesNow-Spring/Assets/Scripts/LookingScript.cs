using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingScript : MonoBehaviour
{

    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(Player);
    }
}
