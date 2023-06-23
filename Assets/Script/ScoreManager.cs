using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    //public AudioSource hitSFX;
    //public AudioSource missSFX;
    public static int Score;
    void Start()
    {
        Instance = this;
        Score = 0;
    }
    public static void HitGood()
    {
        Score += 5;
        
        /*Instance.hitSFX.Play();*/
    }
    public static void HitGreat()
    {
        Score += 10;
        
        /*Instance.hitSFX.Play();*/
    }
    public static void HitPoor()
    {
        Score += 2;
        
        /*Instance.hitSFX.Play();*/
    }
    public static void HitBad()
    {
        Score += 0;
        
        /*Instance.missSFX.Play();*/
    }
    private void Update()
    {
        scoreText.text = Score.ToString();
    }
}