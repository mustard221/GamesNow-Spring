using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SimpleEnergySystem : MonoBehaviour
{
    public float energy = 100f; // Current energy
    public float maxEnergy = 100f; // Max energy
    public float energyRegenRate = 5f; // Energy regen per second

    public PostProcessVolume postProcessVolume; // Post-processing effects
    public Image energyBar; // UI energy bar

    void Update()
    {
        // Regenerate energy over time
        energy = Mathf.Min(energy + energyRegenRate * Time.deltaTime, maxEnergy);

        // Update energy bar UI
        if (energyBar != null)
            energyBar.fillAmount = energy / maxEnergy;

        // Toggle post-processing based on energy level
        if (postProcessVolume != null)
            postProcessVolume.enabled = energy > maxEnergy / 2;
    }

    public void ModifyEnergy(float amount)
    {
        energy = Mathf.Clamp(energy + amount, 0, maxEnergy);
    }
}