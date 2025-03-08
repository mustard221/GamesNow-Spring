using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PressTwoScript : MonoBehaviour
{

    public UnityEvent pressedTwoKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)){
        pressedTwoKey.Invoke();
       }
    }
}
