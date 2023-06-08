using UnityEngine;
using TMPro;

public class FadeInOutAnimation : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float staticInterval = 2.0f;

    private float timer = 0f;
    private bool isFadingIn = false;
    private bool isFadingOut = false;

    private void Start()
    {
        // Set the initial state to fading in
        isFadingIn = true;
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, 0f);
    }

    private void Update()
    {
        if (isFadingIn)
        {
            timer += Time.deltaTime;

            // Calculate the alpha value based on the fade-in duration
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeInDuration);

            // Apply the alpha to the TextMeshPro object
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;

            // Check if the fade-in animation is complete
            if (timer >= fadeInDuration)
            {
                // Start the static interval timer
                timer = 0f;

                // Set the state to static interval
                isFadingIn = false;
            }
        }
        else if (!isFadingOut)
        {
            timer += Time.deltaTime;

            // Check if the static interval time is complete
            if (timer >= staticInterval)
            {
                // Start the fade-out animation
                isFadingOut = true;
                timer = 0f;
            }
        }
        else
        {
            timer += Time.deltaTime;

            // Calculate the alpha value based on the fade-out duration
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeOutDuration);

            // Apply the alpha to the TextMeshPro object
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;

            // Check if the fade-out animation is complete
            if (timer >= fadeOutDuration)
            {
                // Reset the timer and start the fade-in animation again
                timer = 0f;
                isFadingOut = false;
                isFadingIn = true;
            }
        }
    }
}
