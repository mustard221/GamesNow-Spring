using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resurge()
    {
        SceneManager.LoadScene("Game");
    }

    public void Rot()
    {
        SceneManager.LoadScene("Start");
    }

}
