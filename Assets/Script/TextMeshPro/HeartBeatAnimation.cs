using UnityEngine;
using TMPro;

public class HeartBeatAnimation : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float beatDuration = 1.0f;
    public AnimationCurve scaleCurve;

    private float timer = 0f;
    private bool isGrowing = true;
    private Vector3 initialScale;

    private void Start()
    {
        // Store the initial scale of the TextMeshPro object
        initialScale = textMeshPro.transform.localScale;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Calculate the scale factor based on the animation curve
        float scale = scaleCurve.Evaluate(timer / beatDuration);

        // Apply the scale to the TextMeshPro object
        textMeshPro.transform.localScale = initialScale * scale;

        // Check if the beat duration has passed
        if (timer >= beatDuration)
        {
            // Reverse the scaling direction
            isGrowing = !isGrowing;

            // Reset the timer
            timer = 0f;
        }
    }
}
