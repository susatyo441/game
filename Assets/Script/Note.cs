using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    bool isCollide;
    bool isCollide1;
    bool isCollide2;
    bool isCollide3;
    double timeInstantiated;
    public float assignedTime;
    void Start()
    {
        timeInstantiated = LaguManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = LaguManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (LaguManager.Instance.noteTime * 2));


        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * LaguManager.Instance.noteSpawnY, Vector3.up * LaguManager.Instance.noteDespawnY, t);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "box")
        {
            isCollide = true;
            Debug.Log("Kena Collider1 kih");

        }
        if (collision.tag == "box1")
        {
            isCollide1 = true;
            Debug.Log("Kena Collider2 kih");

        }
        if (collision.tag == "box2")
        {
            isCollide2 = true;
            Debug.Log("Kena Collider3 kih");

        }
        if (collision.tag == "box3")
        {
            isCollide3 = true;
            Debug.Log("Kena Collider4 kih");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "box")
        {
            isCollide = false;
            Debug.Log("Metu Collider kih");

        }
        if (collision.tag == "box1")
        {
            isCollide1 = false;
            Debug.Log("Metu Collider kih");

        }
        if (collision.tag == "box2")
        {
            isCollide2 = false;
            Debug.Log("Metu Collider kih");

        }
        if (collision.tag == "box3")
        {
            isCollide3 = false;
            Debug.Log("Metu Collider kih");

        }
    }
}