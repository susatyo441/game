using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScale : MonoBehaviour
{
    public float scaleFactor = 1.5f; // Faktor perbesaran objek prefab
    public float scaleSpeed = 1.0f; // Kecepatan perbesaran

    private Vector3 initialScale; // Skala awal objek prefab
    private Vector3 targetScale; // Skala tujuan objek prefab
    private float timeElapsed = 0f; // Waktu yang telah berlalu sejak perubahan ukuran dimulai

    // 3.641529 scale default simpen
    private void Start()
    {
        // Mendapatkan skala awal objek prefab
        initialScale = transform.localScale;

        // Menghitung skala tujuan objek prefab berdasarkan faktor perbesaran
        targetScale = initialScale * scaleFactor;
    }

    private void Update()
    {
        // Mengecek apakah perubahan ukuran masih berlangsung
        if (timeElapsed < scaleSpeed)
        {
            // Menghitung persentase perubahan ukuran yang telah terjadi
            float t = timeElapsed / scaleSpeed;

            // Melakukan perubahan ukuran objek prefab secara bertahap menggunakan Interpolasi Linier
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            // Mengupdate waktu yang telah berlalu
            timeElapsed += Time.deltaTime;
        }
    }
}
