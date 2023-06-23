using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HalamanAkhir : MonoBehaviour
{
    public Animator animator;
    public userDatabase udb;
    public int[] perform1 = new int[4];
    public int song, skor, skor1, total, persentase;
    public TextMeshProUGUI bad, poor, good, great, combo, persen;
    public Text highSkor;
    // Start is called before the first frame update
    void Start()
    {
        udb.awalan();
        bad.text = udb.perform[0].ToString();
        poor.text = udb.perform[1].ToString();
        good.text = udb.perform[2].ToString();
        great.text = udb.perform[3].ToString();
        song = udb.lagu;
        total = (udb.perform[0] + udb.perform[1] + udb.perform[2] + udb.perform[3]) * 10;
        persentase = (udb.perform[1] * 2) + (udb.perform[2] * 5) + (udb.perform[3] * 10) / total * 100;
        persen.text = persentase.ToString() + "%";
        if (persentase < 30)
        {
            animator.SetBool("sedih", true);
        }
        else
        {
            animator.SetBool("sedih", false);
        }
        skor = udb.highScore[song];
        skor1 = udb.highScore[10];
        combo.text = udb.highScore[11].ToString();
        highSkor.text = skor1.ToString();
        if (skor < skor1)
        {
            updateScore(song, skor1);
        }
        
        udb.defaultPerform();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int soong, int skorrr)
    {
        udb.updateHighScore(soong, skorrr);         //UPDATE HIGH SCORE
    }
}
