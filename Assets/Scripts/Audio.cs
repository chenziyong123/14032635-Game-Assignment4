using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
   public AudioSource InthegameSound;
    public AudioSource HomeSound;
    // Start is called before the first frame update
    void Start()
    {
        HomeSound = GetComponent<AudioSource>();
        HomeSound.loop = false;
        HomeSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HomeSound.isPlaying){
            HomeSound = InthegameSound;
           HomeSound.Play();
        }
        
    }
}
