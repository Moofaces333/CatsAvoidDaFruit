using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RahdomAudioPlaylistLoop : MonoBehaviour
{
    // variables
    public AudioClip[] soundTrack;
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<AudioSource>().playOnAwake) {
            GetComponent<AudioSource>().clip = soundTrack[Random.Range(0, soundTrack.Length)];
            GetComponent<AudioSource>().Play();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying) {
            GetComponent<AudioSource>().clip = soundTrack[Random.Range(0, soundTrack.Length)];
            GetComponent<AudioSource>().Play();
        }
        
    }
}
