using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float startScale = 0.1f; // Skala awal objek
    public float targetScale = 1f; // Skala akhir objek
    public float scaleSpeed = 0.5f; // Kecepatan perubahan skala

    private float currentScale; // Skala saat ini
    private bool isScaling; // Status penanda apakah sedang dalam proses scaling

    void Start()
    {
        currentScale = startScale;
        transform.localScale = Vector3.one * currentScale; // Set skala awal objek
        isScaling = true; // Mulai proses scaling
    }

    void Update()
    {
        if (isScaling)
        {
            // Perbarui skala objek menggunakan Lerp
            currentScale = Mathf.Lerp(currentScale, targetScale, scaleSpeed * Time.deltaTime);
            transform.localScale = Vector3.one * currentScale;

            // Periksa apakah objek telah mencapai skala akhir
            if (Mathf.Approximately(currentScale, targetScale))
            {
                isScaling = false; // Selesaikan proses scaling
            }
        }
    }
}
