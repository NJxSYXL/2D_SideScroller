using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitchTrigger : MonoBehaviour
{
    public AudioClip newTrack;

    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tag == "Player")
        {
            if(newTrack != null)
            {
                audioManager.ChangeBGM(newTrack);
            }
        }
    }
}
