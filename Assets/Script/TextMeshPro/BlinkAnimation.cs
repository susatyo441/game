using UnityEngine;
using TMPro;

public class BlinkAnimation : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float minInterval = 0.5f;
    public float maxInterval = 2.0f;
    public AnimationCurve alphaCurve;

    private float timer = 0f;
    private bool isBlinking = false;
    private float nextBlinkTime;

    private void Start()
    {
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

            // Calculate the alpha value based on the animation curve
            float alpha = alphaCurve.Evaluate(timer / (nextBlinkTime * 0.5f));

            // Apply the alpha to the TextMeshPro object
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;

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

        // Reset the TextMeshPro object's alpha to fully visible
        Color color = textMeshPro.color;
        color.a = 1f;
        textMeshPro.color = color;

        // Generate a new random interval for the next blink
        SetNextBlinkTime();
    }

    private void SetNextBlinkTime()
    {
        // Generate a random interval for the next blink
        nextBlinkTime = Random.Range(minInterval, maxInterval);
    }
}
