using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tes : MonoBehaviour
{
    public InputField score, lagu, perform;
    public userDatabase udb;
    public string hai = "";
    public string laguu = "";
    public string performance = "";

    public int[] perform1 = new int[4];
    public int song, skor;
    // Start is called before the first frame update
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
            hai += i + ". " + udb.highScore[i];
        }
        performance = "";
        for (int i = 0; i < 4; i++)
        {
            performance += i + ". " + udb.perform[i];
        }
        perform.text = performance;
        score.text = hai;
        laguu = udb.lagu.ToString();
        lagu.text = laguu;

    }
    public void updateScore()
    {
        udb.updateHighScore(song, skor);
    }

    public void updateSong()
    {
       udb.updateSong(song);
    }

    public void updatePerform()
    {
        udb.updatePerform(perform1);
    }
}
