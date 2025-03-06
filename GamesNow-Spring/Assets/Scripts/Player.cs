using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxSanity = 10000;
    public int currentSanity;

    public FieldOfView fieldOfView;
    public SanityBar sanityBar;

    public bool seenEnemy = false;


    // Start is called before the first frame update
    void Start()
    {
        currentSanity = 0;
        sanityBar.SetMaxSanity(maxSanity);

    }

    // Update is called once per frame
    void Update()
    {

        fieldOfView = FindAnyObjectByType<FieldOfView>();
        Debug.Log(fieldOfView.canSeeEnemy);
        seenEnemy = fieldOfView.canSeeEnemy;

        if (seenEnemy == true)
        {
            currentSanity += 1;
            sanityBar.SetSanity(currentSanity);
        }
    }

    //void TakeSanity(int damage)
   // {
       // currentSanity += damage;
        

        //sanityBar.SetSanity(currentSanity);
    //}
}
