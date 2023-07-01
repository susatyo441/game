using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC0 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Play("Indonesia Raya");
            /*FindObjectOfType<AudioManager>().Stop("Theme");*/
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Stop("Indonesia Raya");
            /*FindObjectOfType<AudioManager>().Play("Theme");*/
        }
    }
}
