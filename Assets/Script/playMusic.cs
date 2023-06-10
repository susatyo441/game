using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musik;
    // Start is called before the first frame update
    void Start()
    {
        musik = GetComponent<AudioSource>();
        musik.Play();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
