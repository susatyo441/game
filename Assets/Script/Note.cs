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
    public ScoreManager sm;
    void Start()
    {
        sm = new ScoreManager();
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
            if (Input.GetKeyDown(KeyCode.D))
            {
                //vfx_whenPressed1.Play();
                //vfx_whenPressed2.Play();

                /*JudgementScoreOutside();*/
                if (isCollide)
                {
                    JudgmentScore();
                    gameObject.SetActive(false);
                }
            }
            else if (!Input.GetKeyDown(KeyCode.D))
            {

                //  vfx_whenPressed1.Stop();
                //  vfx_whenPressed2.Stop();



            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                //vfx_whenPressed11.Play();
                //vfx_whenPressed21.Play();


                /*JudgementScoreOutside();*/
                if (isCollide1)
                {
                    JudgmentScore();
                    gameObject.SetActive(false);
                }
            }
            else if (!Input.GetKeyDown(KeyCode.F))
            {
                //vfx_whenPressed11.Stop();
                //vfx_whenPressed21.Stop();


            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                //vfx_whenPressed12.Play();
                // vfx_whenPressed22.Play();

                /*JudgementScoreOutside();*/
                if (isCollide2)
                {
                    JudgmentScore();
                    gameObject.SetActive(false);
                }
            }
            else if (!Input.GetKeyDown(KeyCode.J))
            {
                //vfx_whenPressed12.Stop();
                //vfx_whenPressed22.Stop();


            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                //vfx_whenPressed13.Play();
                //vfx_whenPressed23.Play();

                /*JudgementScoreOutside();*/
                if (isCollide3)
                {
                    JudgmentScore();
                    gameObject.SetActive(false);
                }
            }
            else if (!Input.GetKeyDown(KeyCode.K))
            {
                //vfx_whenPressed13.Stop();
                //vfx_whenPressed23.Stop();

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "box")
        {
            isCollide = true;
            /*Debug.Log("Kena Collider1 kih");*/

        }
        if (collision.tag == "box1")
        {
            isCollide1 = true;
            /*Debug.Log("Kena Collider2 kih");*/

        }
        if (collision.tag == "box2")
        {
            isCollide2 = true;
            /*Debug.Log("Kena Collider3 kih");*/

        }
        if (collision.tag == "box3")
        {
            isCollide3 = true;
            /*Debug.Log("Kena Collider4 kih");*/

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "box")
        {
            isCollide = false;
            /*Debug.Log("Metu Collider kih");*/

        }
        if (collision.tag == "box1")
        {
            isCollide1 = false;
            /*Debug.Log("Metu Collider kih");*/

        }
        if (collision.tag == "box2")
        {
            isCollide2 = false;
            /*Debug.Log("Metu Collider kih");*/

        }
        if (collision.tag == "box3")
        {
            isCollide3 = false;
            /*Debug.Log("Metu Collider kih");*/

        }
    }

    private void JudgmentScore()
    {
        if (transform.position.y >= -2.80f)
        {
            Miss();
            Debug.Log("Bad" + transform.position.y);
        }
        if (transform.position.y <= -2.81f && transform.position.y >= -3.00f)
        {
            HitPoor();
            Debug.Log("Poor" + transform.position.y);
        else if (transform.position.y <= -3.01f && transform.position.y >= -3.30f)
        {
            HitGood();
            Debug.Log("Normal" + transform.position.y);
        }
        else if (transform.position.y <= -3.31f && transform.position.y >= -3.80f)
        {
            HitPerfect();
            Debug.Log("Perfect" + transform.position.y);
        }
        else if (transform.position.y <= -3.81f && transform.position.y >= -4.10f)
        {
            HitGood();
            Debug.Log("Normal" + transform.position.y);
        }
        else if (transform.position.y <= -4.11f && transform.position.y >= -4.60f)
        {
            HitPoor();
            Debug.Log("Poor" + transform.position.y);
        }
        else if (transform.position.y <= -4.61f)
        {

            Miss();
            Debug.Log("Bad" + transform.position.y);
        }
    }

    private void JudgementScoreOutside()
    {
        if (transform.localPosition.y <= 5.72f && transform.localPosition.y >= -2.84f)
        {
            Debug.Log("Bad" + transform.localPosition.y);
        }
        /*else if (transform.position.y <= -4.64f && transform.position.y >= -5f)
        {
            Debug.Log("Bad");
        }*/
    }

    private void HitGood()
    {
        ScoreManager.HitGood();
    }
    private void HitPoor()
    {
        ScoreManager.HitPoor();
    }
    private void HitPerfect()
    {
        ScoreManager.HitGreat();
    }
    private void Miss()
    {
        ScoreManager.HitBad();
    }
}