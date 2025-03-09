using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win_trigger_script : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter(Collider other)
   {
    SceneManager.LoadScene("ending_scene");

   }
}
