using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxSanity = 100;
    public int currentSanity;
    

    public SanityBar sanityBar;

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = 0;
        sanityBar.SetMaxSanity(maxSanity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeSanity(20);
        }
    }

    void TakeSanity(int damage)
    {
        currentSanity += damage;

        sanityBar.SetSanity(currentSanity);
    }
}
