using UnityEngine;
using TMPro;

public class GlowBlinkAnimation : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float minInterval = 0.5f;
    public float maxInterval = 2.0f;
    public AnimationCurve glowCurve;

    private float timer = 0f;
    private bool isBlinking = false;
    private float nextBlinkTime;
    private float initialGlow;

    private void Start()
    {
        // Store the initial glow value of the TextMeshPro object
        initialGlow = textMeshPro.fontSharedMaterial.GetFloat(ShaderUtilities.ID_GlowPower);

        // Set the initial time for the next blink
        SetNextBlinkTime();
    }

    private void Update()
    {
        if (!isBlinking)
        {
            timer += Time.deltaTime;

            // Check if it's time to blink again
            if (timer >= nextBlinkTime)
            {
                StartBlink();
            }
        }
        else
        {
            timer += Time.deltaTime;

            // Calculate the glow value based on the animation curve
            float glow = glowCurve.Evaluate(timer / (nextBlinkTime * 0.5f));

            // Apply the glow value to the TextMeshPro object
            textMeshPro.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glow);

            // Check if the blink animation is complete
            if (timer >= nextBlinkTime)
            {
                EndBlink();
            }
        }
    }

    private void StartBlink()
    {
        // Reset the timer
        timer = 0f;

        // Start the blink animation
        isBlinking = true;

        // Generate a new random interval for the next blink
        SetNextBlinkTime();
    }

    private void EndBlink()
    {
        // Reset the timer
        timer = 0f;

        // End the blink animation
        isBlinking = false;

        // Reset the TextMeshPro object's glow value to the initial value
        textMeshPro.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, initialGlow);

        // Generate a new random interval for the next blink
        SetNextBlinkTime();
    }

    private void SetNextBlinkTime()
    {
        // Generate a random interval for the next blink
        nextBlinkTime = Random.Range(minInterval, maxInterval);
    }
}
