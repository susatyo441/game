using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tes : MonoBehaviour
{
    public InputField score, lagu, perform;
    public userDatabase udb;                    //INISIASI CLASS userDatabase
    public string hai = "";
    public string laguu = "";
    public string performance = "";

    public int[] perform1 = new int[4];         //VARIABEL ARRAY PERFORMANCE (BAD, POOR, GOOD, GREAT)
    public int song, skor;                     //VARIABEL LAGU DAN SKOR

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            hai += i + ". " + udb.highScore[i];
        }
        for (int i = 0; i < 4; i++)
        {
            performance += i + ". " + udb.perform[i];
        }
        perform.text = performance;
        score.text = hai;
        laguu = udb.lagu.ToString();
        lagu.text = laguu;
            
    }
    void Update()
    {
        hai = "";
        for (int i = 0; i < 10; i++)
        {
            hai += i + ". " + udb.highScore[i];  //AKSES ARRAY HIGH SCORE
        }
        performance = "";
        for (int i = 0; i < 4; i++)
        {
            performance += i + ". " + udb.perform[i]; //AKSES ARRAY PERFORMANCE
        }
        perform.text = performance;
        score.text = hai;
        laguu = udb.lagu.ToString();        //AKSES LAGU YANG DIPILIH
        lagu.text = laguu;

    }
    public void updateScore()      
    {
        udb.updateHighScore(song, skor);         //UPDATE HIGH SCORE
    }

    public void updateSong()
    {
       udb.updateSong(song);                  //UPDATE LAGU YANG DIPILIH
    }

    public void updatePerform()
    {
        udb.updatePerform(perform1);      //UPDATE PERFORMANCE
    }

    public void defaultPerformance()
    {
        udb.defaultPerform();             //GO BACK TO DEFAULT VALUE
    } 
}
