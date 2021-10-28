using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;
   private List<Tween> activeTweens;
    // Start is called before the first frame update
    void Start()
    {
          activeTweens = new List<Tween>(); 
    }

    // Update is called once per frame
    void Update()
    {
  
         
        for (int i=activeTweens.Count  -1; i >=0; i--)
        {
            activeTween = activeTweens[i];

        float dis = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if (dis > 0.1f)
            {
                float tF = (Time.time - activeTween.StartTime)/activeTween.Duration;
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, tF);
            }

            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTweens.RemoveAt(i);
            }
        }   
    }
        

   public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (!TweenExists(targetObject))
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
          return true;
        }
        return false;
    }

    public bool TweenExists(Transform target)
    {
        foreach (Tween activeTween in activeTweens)
        {
            if (activeTween.Target.transform == target)
           {
                return true;
            }
        }
        return false;
   }

   
}
