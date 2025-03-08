using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PressOneScript : MonoBehaviour
{

    public UnityEvent pressedOneKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Alpha1)){
        pressedOneKey.Invoke();
       }
    }
}
