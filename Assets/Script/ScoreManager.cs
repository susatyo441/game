using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    public userDatabase udb;
    //public AudioSource hitSFX;
    //public AudioSource missSFX;
    public static int Score;
    public static int bad, poor, good, great, combo, maxcombo;
    void Start()
    {
        Instance = this;
        maxcombo = 0;
        Score = 0;
        bad = 0;
        poor = 0;
        good = 0;
        great = 0;
        combo = 0;
    }
    public static void HitGood()
    {
        Score += 5;
        good++;
        combo++;
        if (combo > maxcombo)
            maxcombo = combo;
        /*Instance.hitSFX.Play();*/
    }
    public static void HitGreat()
    {
        Score += 10;
        great++;
        combo++;
        if (combo > maxcombo)
            maxcombo = combo;
        /*Instance.hitSFX.Play();*/
    }
    public static void HitPoor()
    {
        Score += 2;
        poor++;
        combo++;
        if (combo > maxcombo)
            maxcombo = combo;
        /*Instance.hitSFX.Play();*/
    }
    public static void HitBad()
    {
        Score += 0;
        bad++;
        combo = 0;
        /*Instance.missSFX.Play();*/
    }
    private void Update()
    {
        scoreText.text = Score.ToString();
    }
}