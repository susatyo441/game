using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    bool isCollide;
    bool isCollide1;
    bool isCollide2;
    bool isCollide3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isCollide)
            {
                gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isCollide1)
            {
                gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isCollide2)
            {
                gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isCollide3)
            {
                gameObject.SetActive(false);
            }
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
