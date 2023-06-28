using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    //public AudioSource hitSFX;
    //public AudioSource missSFX;
    public static int Score;
    public static int bad, poor, good, great, combo, maxcombo;
    public static int health = 30;
    public static int kali = 1;
    
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
        health = 30;
        kali = 1;
        
    }
    public static void HitGood()
    {
        combo++;
        if (combo >= 20 && combo < 40)
        {
            kali = 2;
        }
        else if (combo >= 40)
        {
            kali = 4;
        }
        else
        {
            kali = 1;
        }
        Score += 5 * kali;
        good++;
        if (combo > maxcombo)
            maxcombo = combo;
        /*Instance.hitSFX.Play();*/
    }
    public static void HitGreat()
    {
        combo++;
        if (combo >= 20 && combo < 40)
        {
            kali = 2;
        }
        else if (combo >= 40)
        {
            kali = 4;
        }
        else
        {
            kali = 1;
        }
        Score += 10 * kali;
        great++;
        if (combo > maxcombo)
            maxcombo = combo;
        /*Instance.hitSFX.Play();*/
    }
    public static void HitPoor()
    {
        combo++;
        if (combo >= 20 && combo < 40)
        {
            kali = 2;
        }
        else if (combo >= 40)
        {
            kali = 4;
        }
        else
        {
            kali = 1;
        }
        Score += 2 * kali;
        poor++;
        
        if (combo > maxcombo)
            maxcombo = combo;
        /*Instance.hitSFX.Play();*/
    }
    public static void HitBad()
    {
        Score += 0;
        bad++;
        combo = 0;
        health--;
        /*Instance.missSFX.Play();*/
    }
    void Update()
    {
        

    }
}