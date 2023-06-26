using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    public List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    public int spawnIndex = 0;
    public int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnIndex = 0;
        inputIndex = 0;
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, LaguManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (spawnIndex < timeStamps.Count)
        {
            if (LaguManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - LaguManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex <= timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = LaguManager.Instance.marginOfError;
            double audioTime = LaguManager.GetAudioSourceTime() - (LaguManager.Instance.inputDelayInMilliseconds / 1000.0);
            /*Debug.Log(audioTime);*/
       
                if (Input.GetKeyDown(input))
                {
                    if (notes[inputIndex].gameObject.transform.position.y >= -1f)
                    {
                        /*print($"Hit on {inputIndex} note");*/
                        Destroy(notes[inputIndex].gameObject);
                    Debug.Log("Bad" + notes[inputIndex].gameObject.transform.position.y);
                    ScoreManager.HitBad();
                    inputIndex++;
                        
                }
                    if (notes[inputIndex].gameObject.transform.position.y <= -1.01f && notes[inputIndex].gameObject.transform.position.y >= -3.00f)
                    {
                        /*print($"Hit on {inputIndex} note");*/
                        Destroy(notes[inputIndex].gameObject);
                    Debug.Log("Poor" + notes[inputIndex].gameObject.transform.position.y);
                    ScoreManager.HitPoor();
                    inputIndex++;
                        
                }
                    else if (notes[inputIndex].gameObject.transform.position.y <= -3.01f && notes[inputIndex].gameObject.transform.position.y >= -3.30f)
                    {
                        /*print($"Hit on {inputIndex} note");*/
                        Destroy(notes[inputIndex].gameObject);
                    Debug.Log("Normal" + notes[inputIndex].gameObject.transform.position.y);
                    ScoreManager.HitGood();
                    inputIndex++;
                       
                }
                    else if (notes[inputIndex].gameObject.transform.position.y <= -3.31f && notes[inputIndex].gameObject.transform.position.y >= -3.80f)
                    {
                        /*print($"Hit on {inputIndex} note");*/
                        Destroy(notes[inputIndex].gameObject);
                    Debug.Log("Perfect" + notes[inputIndex].gameObject.transform.position.y);
                    ScoreManager.HitGreat();
                    inputIndex++;
                        
                }
                    else if (notes[inputIndex].gameObject.transform.position.y <= -3.81f && notes[inputIndex].gameObject.transform.position.y >= -4.10f)
                    {
                        /*print($"Hit on {inputIndex} note");*/
                        Destroy(notes[inputIndex].gameObject);
                    Debug.Log("Normal" + notes[inputIndex].gameObject.transform.position.y);
                    ScoreManager.HitGood();
                    inputIndex++;
                       
                }
                    else if (notes[inputIndex].gameObject.transform.position.y <= -4.11f && notes[inputIndex].gameObject.transform.position.y >= -4.60f)
                    {
                        /*print($"Hit on {inputIndex} note");*/
                        Destroy(notes[inputIndex].gameObject);
                    Debug.Log("Poor" + notes[inputIndex].gameObject.transform.position.y);
                    ScoreManager.HitPoor();
                    inputIndex++;
                        
                }
                    /*else if (transform.position.y <= -4.61f)
                    {

                        print($"Hit on {inputIndex} note");
                        Destroy(notes[inputIndex].gameObject);
                        inputIndex++;
                        Debug.Log("Bad" + transform.position.y);
                    }
                    *//* if (notes[inputIndex].gameObject == null)
                     {*//*
                    if (Math.Abs(audioTime - timeStamp) < 0.1)
                        {

                            //  Hit();

                        }

                        else
                        {
                            print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                        Destroy(notes[inputIndex].gameObject);
                        inputIndex++;
                    }*/
                    /* }
                     else
                     {
                         Destroy(notes[inputIndex].gameObject);
                         inputIndex++;
                     }*/
                }
            /* if (Math.Abs(audioTime - timeStamp) < 0.1)
             {*/

            /*         }*/
            /*  }*/
            if (notes[inputIndex].gameObject.transform.position.y <= -4.61f)
            {
                /*if (Input.GetKeyDown(input))
                {*/
                /* if (notes[inputIndex + 1].gameObject == null)
                 {*/
                // Miss();
                /*ScoreManager.HitBad();*/
                print($"Missed {inputIndex} note");
                Destroy(notes[inputIndex].gameObject);
                inputIndex++;
                ScoreManager.HitBad();
            }
        }
        
    }
    //private void Hit()
    //{
    //    ScoreManager.HitGreat();
    //}
    //private void Miss()
    //{
    //    ScoreManager.HitBad();
    //}
}