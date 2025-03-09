using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class delay_script : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneChange",25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SceneChange()
   {
    SceneManager.LoadScene("End");

   }
}
