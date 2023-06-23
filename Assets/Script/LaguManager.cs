using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class LaguManager : MonoBehaviour
{
    public static LaguManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds
    public int max = 0;
    public int inputDelayInMilliseconds;


    public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public AudioClip Lagu1, Lagu2, Lagu3, Lagu4, Lagu5, Lagu6, Lagu7, Lagu8, Lagu9, Lagu10;
    public int lagu;
    public int[] perform = new int[4];
    public userDatabase udb;
    public float noteTapY;
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    public static MidiFile midiFile;
    // Start is called before the first frame update
    void Start()
    {
        max = 0;
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        udb.awalan();
        lagu = udb.getLagu();
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
            fileLocation = "Killing In The Name Of.mid";
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
    void Update()
    {
        perform[0] = ScoreManager.bad;
        perform[1] = ScoreManager.poor;
        perform[2] = ScoreManager.good;
        perform[3] = ScoreManager.great;
        if (!audioSource.isPlaying)
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
    }
}