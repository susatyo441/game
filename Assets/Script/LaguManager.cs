using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;
public class LaguManager : MonoBehaviour
{
    public static LaguManager Instance;
    public AudioSource audioSource, audioSource1;
    public Lane[] lanes;
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds
    public int max = 0;
    public int inputDelayInMilliseconds;
    public TextMeshProUGUI kombo, countDown;
    public GameObject duaKali, empatKali, panel;
    public Text skoor;
    public VideoClip videoClip1, videoClip2;
    public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public AudioClip Lagu1, Lagu2, Lagu3, Lagu4, Lagu5, Lagu6, Lagu7, Lagu8, Lagu9, Lagu10;
    public int lagu;
    public int[] perform = new int[4];
    public userDatabase udb;
    public float noteTapY;
    public bool pause = false, pause1 = true;
    float current = 3;
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }
    
    public void PlaySound(AudioClip _sound)
    {
        audioSource1.PlayOneShot(_sound);
    }
    public static MidiFile midiFile;
    // Start is called before the first frame update
    void Start()
    {
        pause = true;
        pause1 = false;
        max = 0;
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        udb.awalan();
        lagu = udb.getLagu();
        ScoreManager.bad = 0;
        ScoreManager.poor = 0;
        ScoreManager.good = 0;
        ScoreManager.great = 0;
        ScoreManager.Score = 0;
        ScoreManager.combo = 0;
        ScoreManager.health = 30;
        if (lagu == 1)
        {
            audioSource.clip = Lagu1;
            fileLocation = "Indonesia raya.mid";
        }
        else if (lagu == 2)
        {
            audioSource.clip = Lagu2;
            fileLocation = "Hymne Polines.mid";
        }
        else if (lagu == 3)
        {
            audioSource.clip = Lagu3;
            fileLocation = "Pupus.mid";
        }
        else if (lagu == 4)
        {
            audioSource.clip = Lagu4;
            fileLocation = "moshimo.mid";
        }
        else if (lagu == 5)
        {
            audioSource.clip = Lagu5;
            fileLocation = "Gomene summer.mid";
        }
        else if (lagu == 6)
        {
            audioSource.clip = Lagu6;
            fileLocation = "whistlerevisi.mid";
        }
        else if (lagu == 7)
        {
            audioSource.clip = Lagu7;
            fileLocation = "A little peace of heaven.mid";
        }
        else if (lagu == 8)
        {
            audioSource.clip = Lagu8;
            fileLocation = "Killing.mid";
        }
        else if (lagu == 9)
        {
            audioSource.clip = Lagu9;
            fileLocation = "Apuse.mid";
        }
        else if (lagu == 10)
        {
            audioSource.clip = Lagu10;
            fileLocation = "Tokecang.mid";
        }

        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else
        {
            ReadFromFile();
        }
    }

    private IEnumerator ReadFromWebsite()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation));
                byte[] results = www.downloadHandler.data;
                using (var stream = new MemoryStream(results))
                {
                    midiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }
    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    public void StartSong()
    {
        audioSource.Play();
    }
    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }
    public void checkkk()
    {
        for (int i = 0; i < 4; i++)
        {
            udb.awalan();
            if (udb.i < 13)
            {
                udb.insert_1();
            }
        }
    }
    private void Resume()
    {
/*        float current = 3f;*/
        panel.SetActive(false);  
        Time.timeScale = 1f;
        pause = false;
        pause1 = false;
        audioSource.UnPause();
    }
    public void Resume1()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
        pause1 = false;
        current = 3;
    }
    public void Exit()
    {
        pause = false;
        audioSource.UnPause();
        Time.timeScale = 1f;
        panel.SetActive(false);
        SceneManager.LoadScene("Select Song 1");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            countDown.enabled = false;
            current = 0;
            pause1 = true;
            pause = true;
            audioSource.Pause();
            Time.timeScale = 0f;
            panel.SetActive(true);
        }
        if (current >=-0.1 && !pause1)
        {
            audioSource.Pause();
            countDown.enabled = true;
            pause = true;
            countDown.text = current.ToString("0");
            current -= 1 * Time.deltaTime;
            if(current <= 1)
            {
                countDown.text = "Start!";
            }
        }
        else if (!pause1 && current <= 0)
        {
            Resume();
            countDown.enabled = false;
        }
       
        Debug.Log(Application.dataPath);
        skoor.text = ScoreManager.Score.ToString();
        kombo.text = ScoreManager.combo.ToString();
        if (ScoreManager.combo >= 20 && ScoreManager.combo < 40)
        {
            videoPlayer.clip = videoClip2;
            duaKali.SetActive(true);
            empatKali.SetActive(false);
        }
        else if(ScoreManager.combo >= 40)
        {
            videoPlayer.clip = videoClip2;
            duaKali.SetActive(false);
            empatKali.SetActive(true);
        }
        else
        {
            duaKali.SetActive(false);
            empatKali.SetActive(false);
            videoPlayer.clip = videoClip1;
        }
        perform[0] = ScoreManager.bad;
        perform[1] = ScoreManager.poor;
        perform[2] = ScoreManager.good;
        perform[3] = ScoreManager.great;
        if (!audioSource.isPlaying && !pause)
        {
            foreach (var lane in lanes)
            {
                max += lane.timeStamps.Count;
            }
            checkkk();
            perform[0] = ScoreManager.bad;
            perform[1] = ScoreManager.poor;
            perform[2] = ScoreManager.good;
            perform[3] = ScoreManager.great;
            udb.updatePerform(perform);

            udb.updateHighScore(11, ScoreManager.Score);
            udb.updateHighScore(12, ScoreManager.maxcombo);
            udb.updateHighScore(13, max);
            SceneManager.LoadScene("HalamanPenilaian");
                
        }
        if(ScoreManager.health <= 0)
        {
            audioSource.Stop();
        }
    }
}