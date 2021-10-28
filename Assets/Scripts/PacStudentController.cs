using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public GameObject man;
    private Vector3 newaddress;
    public AudioSource WalkAudio;
     private Tweener tweener;
    public Animator a;
    private int y = 1;
    private int x = 1;
    
    private int diff =1;

    private int diffy =1;
    private int lastInput;

    private int currentInput =0 ;
    private int firstInput = 0;
  int checki=0;


    void Start()
    {
         newaddress = man.transform.position;
         tweener = GetComponent<Tweener>();
    }


    void Update()
    { 
        
        if (Input.GetKeyDown(KeyCode.W)){
           lastInput = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = 2;      
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = 3;
        }  
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = 4;  
        }
        if(firstInput == 0){
            firstInput = lastInput;
        }

        
     if(man.transform.position == newaddress){   
     MOVE();
     }

    }

public void MOVE(){ 
    checki++;
    if (firstInput == 1)
        {
            a.SetInteger("Hori",0);
            a.SetInteger("Veritical",1);
            
              if(diffenty()==1){
               y=y-1;
           }else{
               y=y+1;
           }
           WalkAudio.Play();
             if(checknumber()==1&& y<14){ 
            newaddress = new Vector3(man.transform.position.x,man.transform.position.y+1,man.transform.position.z);
             tweener.AddTween(man.transform, man.transform.position,newaddress, 0.2f);     
          Debug.Log("y"+y);
             }else if(y<14){
             if(diffenty()==1){
               y=y+1;
           }else{
               y=y-1;
           }
             
             }
             
        }else if (firstInput == 2  )
        {
            a.SetInteger("Hori",0);
            a.SetInteger("Veritical",-1);

              if(diffenty()==1){
               y=y+1;
           }else{
               y=y-1;
           }
           WalkAudio.Play();
             if(checknumber()==1&& y<14){
            newaddress = new Vector3(man.transform.position.x,man.transform.position.y-1,man.transform.position.z);
            tweener.AddTween(man.transform, man.transform.position,newaddress, 0.2f);
          Debug.Log("y"+y);
             }else if(y<14){
           if(diffenty()==1){
               y=y-1;
           }else{
               y=y+1;
           }
             
             }
        }else if (firstInput == 3)
        {
             a.SetInteger("Veritical",0);
            a.SetInteger("Hori",-1);

            if(different()==1){
               x=x-1;
           }else{
               x=x+1;
           }
            WalkAudio.Play();
             if(checknumber()==1&& x<=13){
            newaddress = new Vector3(man.transform.position.x-1,man.transform.position.y,man.transform.position.z);
            tweener.AddTween(man.transform, man.transform.position,newaddress, 0.2f);
           Debug.Log("x"+x);
             }else if(x<14){
        if(different()==1){
            x=x+1;
           }else{
            x=x-1;
           }
             }
        }else if (firstInput == 4 )
        {

             a.SetInteger("Veritical",0);
            a.SetInteger("Hori",1);

           if(different()==1){
            x=x+1;

           }else{
            x=x-1;
           }
           WalkAudio.Play();
            if(checknumber()==1&& x<=13){
                
              newaddress = new Vector3(man.transform.position.x+1,man.transform.position.y,man.transform.position.z);
              tweener.AddTween(man.transform, man.transform.position,newaddress, 0.2f);
         Debug.Log("x"+x);
            }else if(x<14){

        if(different()==1){
            x=x-1;
           }else{
            x=x+1;
           }
              
            }
        }
}

public int diffenty(){

     if (y == 14){
        diffy = diffy *-1;
        if(diff==-1){
           
        }
    }
    return diffy;
}

public int different(){
    

    if (x == 14){
        diff = diff *-1;
    }
    return diff;
}

    public int checknumber(){
        currentInput = lastInput;
          int[,] levelMap =
        {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };
       
       
         
       if(y==14 || x==14){

           return 1;
       }else {
           
         if(levelMap[y,x]==2 || levelMap[y,x]==1 || levelMap[y,x]==3 || levelMap[y,x]==4 || levelMap[y,x]==7 ){
                firstInput = currentInput;
                 WalkAudio.Stop();
           WalkAudio.loop = false;
                return 2;
      
            }else if(diffenty()==1 && currentInput == 1 && levelMap[y-1,x]==5 ){
            firstInput = lastInput;
             return 1;

            }else if(y<14&&diffenty()==-1 && currentInput == 1 && levelMap[y+1,x]==5 ){
            firstInput = lastInput;
            return 1;
            
       }else if(y<14&&diffenty()==1 && currentInput == 2 && levelMap[y+1,x]==5  ){
            firstInput = lastInput;
             return 1;

    }else if(diffenty()==-1 && currentInput == 2 && levelMap[y-1,x]==5 ){
            firstInput = lastInput;
            return 1;
    
       }else if(different()==1 && currentInput == 3 && levelMap[y,x-1]==5 ){
            firstInput = lastInput;
             return 1;
            }else if(x<13&&different()==-1 && currentInput == 3 && levelMap[y,x+1]==5){
                Debug.Log (x);
            firstInput = lastInput;
            return 1;
         }else if(x<13 && different()==1 && currentInput == 4 && levelMap[y,x+1]==5 ){
            firstInput = lastInput;
             return 1;
            }else if(different()==-1 && currentInput == 4 && levelMap[y,x-1]==5 ){    
            firstInput = lastInput;
            return 1;
       }
        return 1;
       }   
       
       
    }

}
