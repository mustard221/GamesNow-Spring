using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Player : MonoBehaviour
{
    public int maxSanity = 10000;
    public int currentSanity;

    public FieldOfView fieldOfView;
    public SanityBar sanityBar;
    public PostProcessVolume postProcessVolume;

    public bool seenEnemy = false;


    // Start is called before the first frame update
    void Start()
    {
        currentSanity = 0;
        sanityBar.SetMaxSanity(maxSanity);

        if (postProcessVolume != null)
        {
            postProcessVolume.enabled = false;
        }

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

            if (postProcessVolume != null)
            {
                bool enablePostProcessing = currentSanity <= maxSanity / 2;
                postProcessVolume.enabled = enablePostProcessing;

                Debug.Log($"Sanity: { currentSanity}, Post-processing enabled:) {enablePostProcessing}");
            }
        }

        if (currentSanity > maxSanity / 2 && postProcessVolume != null)
        {
            postProcessVolume.enabled = false;
            Debug.Log($"Sanity: {currentSanity}, Post-processing turned off.");
        }

        if (currentSanity > maxSanity)
        {
            SceneManager.LoadScene("Death");
        }
    }

    //void TakeSanity(int damage)
   // {
       // currentSanity += damage;
        

        //sanityBar.SetSanity(currentSanity);
    //}
}
