using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    [SerializeField] public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null; // UI image for the stamina
    [SerializeField] private CanvasGroup sliderCanvasGroup = null; // UI canvas group that controls visiblility of stamina

    private PlayerMovement playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!weAreSprinting) // If the player is not sprinting, regenerate stamina
        {
            if (playerStamina < maxStamina)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStaminaUI(1);
            }
        }

        // Handle stamina UI and regeneration limit
        if (playerStamina >= maxStamina)
        {
            playerStamina = maxStamina;
            sliderCanvasGroup.alpha = 0;
        }

        if (playerStamina <= 0)
        {
            sliderCanvasGroup.alpha = 1;
        }
    }

    public void Sprinting()
    {
        if (weAreSprinting && playerStamina > 0)
        {
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStaminaUI(1);
        }
        if (playerStamina <= 0)
        {
            playerStamina = 0;
             weAreSprinting = false;
        }
    }

    void UpdateStaminaUI(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0; // Hide UI
        }
        else
        {
            sliderCanvasGroup.alpha = 1; // Show UI
        }
    }
}
