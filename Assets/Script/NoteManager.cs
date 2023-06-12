using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    bool isCollide;
    bool isCollide1;
    bool isCollide2;
    bool isCollide3;
/*    [SerializeField] ParticleSystem vfx_whenPressed1;
    [SerializeField] ParticleSystem vfx_whenPressed2;
    [SerializeField] ParticleSystem vfx_whenPressed11;
    [SerializeField] ParticleSystem vfx_whenPressed21;
    [SerializeField] ParticleSystem vfx_whenPressed12;
    [SerializeField] ParticleSystem vfx_whenPressed22;
    [SerializeField] ParticleSystem vfx_whenPressed13;
    [SerializeField] ParticleSystem vfx_whenPressed23;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
           /* vfx_whenPressed1.Play();
            vfx_whenPressed2.Play();*/

            if (isCollide)
            {
                gameObject.SetActive(false);
            }
        }else if (!Input.GetKeyDown(KeyCode.D))
        {
           /* vfx_whenPressed1.Stop();
            vfx_whenPressed2.Stop();*/

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
           /* vfx_whenPressed11.Play();
            vfx_whenPressed21.Play();*/

            if (isCollide1)
            {
                gameObject.SetActive(false);
            }
        }
        else if (!Input.GetKeyDown(KeyCode.F))
        {
           /* vfx_whenPressed11.Stop();
            vfx_whenPressed21.Stop();*/

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
          /*  vfx_whenPressed12.Play();
            vfx_whenPressed22.Play();*/

            if (isCollide2)
            {
                gameObject.SetActive(false);
            }
        }
        else if (!Input.GetKeyDown(KeyCode.J))
        {
           /* vfx_whenPressed12.Stop();
            vfx_whenPressed22.Stop();*/

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
           /* vfx_whenPressed13.Play();
            vfx_whenPressed23.Play();*/

            if (isCollide3)
            {
                gameObject.SetActive(false);
            }
        }
        else if (!Input.GetKeyDown(KeyCode.K))
        {
            /*vfx_whenPressed13.Stop();
            vfx_whenPressed23.Stop();*/

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "box")
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
