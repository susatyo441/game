using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC6 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Play("heaven");
            /*FindObjectOfType<AudioManager>().Stop("Theme");*/
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Stop("heaven");
            /*FindObjectOfType<AudioManager>().Play("Theme");*/
        }
    }
}
