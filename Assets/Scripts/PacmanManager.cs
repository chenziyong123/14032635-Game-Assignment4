using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanManager : MonoBehaviour
{
    public GameObject man;
    private Tweener tweener;
    public Animator a;
    public AudioSource WalkAudio;
    public Vector3 leftup = new Vector3(-2.5f, 4.5f, 0f);
    public Vector3 rightup = new Vector3(2.5f, 4.5f, 0f);
    public Vector3 rightdown = new Vector3(2.5f, 0.5f, 0f);
    public Vector3 leftdown = new Vector3(-2.5f, 0.5f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        tweener.AddTween(man.transform, leftup,leftup, 3f);
        man.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        // man move and change animation
        if (man.transform.position == leftup)
        {
            a.SetInteger("Veritical",0);
            a.SetInteger("Hori",1);
            tweener.AddTween(man.transform, man.transform.position,rightup, 2f);
           WalkAudio.Play();
           WalkAudio.loop = true;
        }
        
         if (man.transform.position == rightup )
        {
            a.SetInteger("Hori",0);
            a.SetInteger("Veritical",-1);
            tweener.AddTween(man.transform, man.transform.position, rightdown, 2f);
            WalkAudio.Play();  
            WalkAudio.loop = true;
        }
        
        if (man.transform.position == rightdown)
        {
            a.SetInteger("Veritical",0);
            a.SetInteger("Hori",-1);
            tweener.AddTween(man.transform, man.transform.position, leftdown, 2f);
            WalkAudio.Play();   
            WalkAudio.loop = true;
        }
        
         if (man.transform.position == leftdown )
        {
            a.SetInteger("Hori",0);
            a.SetInteger("Veritical",1);
            tweener.AddTween(man.transform, man.transform.position,leftup, 2f);
            WalkAudio.Play();  
            WalkAudio.loop = true;   
        }
    }
}
