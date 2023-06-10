using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.IO;
public class SongManager : MonoBehaviour
{

    float songPositionInSec, songPositionInBit, secPerBeat, dspTime;
    //int bpm = 140;
    //[SerializeField] private AudioSource audio;
    float[] posSpwn = { -2.37f, -0.74f, 0.8f, 2.37f };
    int index = 0;
    [SerializeField] float tempo;
    [SerializeField] private GameObject notSpawn;
    [SerializeField] private Transform notPostion;
    [SerializeField] private float spawnDelay = 0.5f;
    [SerializeField] private int bpm;
    [SerializeField] private FFTWindow fftwindow;
    
    private float[] samples = new float[1024];
    private void Start()
    {
        //menghitung berapa detik dalam satu beat
        secPerBeat = 60f / bpm;
        tempo = bpm / 60f;
        //ukur waktu when music start play
        dspTime = (float)AudioSettings.dspTime;
        //start song
        //audio = GetComponent<AudioSource>();
        //audio.Play();
        //timeSpawn = songPositionInSec;
        AudioProcessor proc = FindAnyObjectByType<AudioProcessor>();
        proc.onBeat.AddListener(onBeatDetected);
        proc.onSpectrum.AddListener(onSpectrum);
    
    }

    private void Update()
    {

        //AudioListener.GetSpectrumData(samples, 0, fftwindow);
        //Debug.Log("Samples : " + samples[bpm]);
        //if(samples[bpm] > spawnDelay)
        //{
        //    GameObject spwn = Instantiate(notSpawn,new Vector3(Random.Range(-2.12f, 1.88f),notPostion.transform.position.y, notPostion.transform.position.z) , Quaternion.identity);
        //    spwn.AddComponent<MoveAfterSpawn>();
        //    spwn.GetComponent<MoveAfterSpawn>().tempo = tempo;

        //}




        //posisi lagu detik keberapa
        //songPositionInSec = (float)(AudioSettings.dspTime - dspTime);
        //songPositionInBit = songPositionInSec / secPerBeat;
        //not.Add(songPositionInBit);
        //Debug.Log("Detik ke : " + songPositionInSec);
        //Debug.Log("Beat  ke : " + songPositionInBit);

        //SpawnNot();
        
    }

    void BeatMapping()
    {
        try
        {
            StreamWriter sw = new StreamWriter("D:\\DataFlash/Kuliah smt 4/Game/RythmGame/game/Assets/BeatMap\beat.txt");
            sw.WriteLine(secPerBeat);            
        }catch(System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }


    void onBeatDetected()
    {
        Debug.Log("Beat terdeteksi");
        var rnd = new Random();
        float a = rnd.Next(0, posSpwn.Length);
        GameObject spwn = Instantiate(notSpawn, new Vector3(a, notPostion.transform.position.y, notPostion.transform.position.z), Quaternion.identity);
        spwn.AddComponent<MoveAfterSpawn>();
        spwn.GetComponent<MoveAfterSpawn>().tempo = tempo;
         
    }

    void onSpectrum(float[] spec)
    {
        for (int i = 0; i < spec.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spec[i], 0);
            Debug.DrawLine(start, end);
        }
    }
}
