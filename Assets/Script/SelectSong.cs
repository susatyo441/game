using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSong : MonoBehaviour
{
    public userDatabase udb;
    // Start is called before the first frame update
    public Text lagu1, lagu2, lagu3, lagu4, lagu5, lagu6, lagu7, lagu8, lagu9, lagu10;
    void Start()
    {
        udb.awalan();
        lagu1.text = udb.highScore[0].ToString();
        lagu2.text = udb.highScore[1].ToString();
        lagu3.text = udb.highScore[2].ToString();
        lagu4.text = udb.highScore[3].ToString();
        lagu5.text = udb.highScore[4].ToString();
        lagu6.text = udb.highScore[5].ToString();
        lagu7.text = udb.highScore[6].ToString();
        lagu8.text = udb.highScore[7].ToString();
        lagu9.text = udb.highScore[8].ToString();
        lagu10.text = udb.highScore[9].ToString();
    }
    public void updateSong1()
    {
        udb.updateSong(1);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong2()
    {
        udb.updateSong(2);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong3()
    {
        udb.updateSong(3);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong4()
    {
        udb.updateSong(4);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong5()
    {
        udb.updateSong(5);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong6()
    {
        udb.updateSong(6);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong7()
    {
        udb.updateSong(7);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong8()
    {
        udb.updateSong(8);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong9()
    {
        udb.updateSong(9);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
    public void updateSong10()
    {
        udb.updateSong(10);                  //UPDATE LAGU YANG DIPILIH
        SceneManager.LoadScene("OnGame");
    }
}
