using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    public AudioClip[] musicClips;
    private int currentTrack;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        PlayMusic();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void PlayMusic()
    {
        if (source.isPlaying)
        {
            return;
        }

        currentTrack--;
        if(currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        StartCoroutine(WaitForMusicEnd());
    }

    IEnumerator WaitForMusicEnd()
    {
        while (source.isPlaying)
        {
            yield return null;
        }
        NextTitle();
        //Play next title once track ends

    }

    public void NextTitle()
    {
        source.Stop();
        currentTrack++;

        //Reset after all songs have finished
        if(currentTrack > musicClips.Length - 1)
        {
            currentTrack = 0;
        }

        source.clip = musicClips[currentTrack];
        source.Play();

        StartCoroutine("WaitForMusicEnd");
    }

    public void PauseMusic()
    {
        StopCoroutine("WaitForMusicEnd");
        source.Stop();
    }


}