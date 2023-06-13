using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSong : MonoBehaviour
{
    public userDatabase udb;
    // Start is called before the first frame update

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
