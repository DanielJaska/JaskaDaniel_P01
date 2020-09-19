using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioSource source;

    public static void PlayClip(AudioClip audioClip)
    {
       //source.clip = audioClip;
       source.PlayOneShot(audioClip);

    }

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
