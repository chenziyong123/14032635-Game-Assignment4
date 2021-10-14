using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public GameObject man;
    private Vector3 newaddress;

    private int y = 1;
    private int x = 1;
    
    private int diff =1;

    private int diffy =1;
    private int lastInput;

    private int firstInput = 0;

    private float StarTime ;
    // Start is called before the first frame update
    void Start()
    {
         newaddress = man.transform.position;
       // StarTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(StarTime);
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
        
        
       // Debug.Log(Time.time);

     MOVE();
      




    }

public void MOVE(){ 
    
     if (firstInput == 1 )
        {  
              if(diffenty()==1){
               y=y-1;
           }else{
               y=y+1;
           }
            Debug.Log(y);
             if(checknumber()&& y<14){
            newaddress = new Vector3(man.transform.position.x,man.transform.position.y+1,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
            StarTime = Time.time;
           
             }else if(y<14){
                     if(diffenty()==1){
               y=y+1;
           }else{
               y=y-1;
           }
             
             
        }
        }

        if (firstInput == 2  )
        {
              if(diffenty()==1){
               y=y+1;
           }else{
               y=y-1;
           }
             if(checknumber()&& y<14){
            newaddress = new Vector3(man.transform.position.x,man.transform.position.y-1,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
          Debug.Log(y);
             }else if(y<14){
                     if(diffenty()==1){
               y=y-1;
           }else{
               y=y+1;
           }
             
             }
        }

        if (firstInput == 3)
        {
              if(different()==1){
               x=x-1;
           }else{
               x=x+1;
           }
             if(checknumber()&& x<14){
            newaddress = new Vector3(man.transform.position.x-1,man.transform.position.y,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
           Debug.Log(x);
             }else if(x<14){
        if(different()==1){
            x=x+1;
           }else{
            x=x-1;
           }
             }
        }

        //Debug.Log(StarTime);
        if (firstInput == 4 )
        {
           if(different()==1){
            x=x+1;

           }else{
            x=x-1;
           }
            
            
            if(checknumber()&& x<14){
              newaddress = new Vector3(man.transform.position.x+1,man.transform.position.y,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
          Debug.Log(x);
          StarTime = Time.time;
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

    public bool checknumber(){
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
       
       
         
       if(y==15 || x==14){

           return true;
       }else{
         if(levelMap[y,x]==2 || levelMap[y,x]==1 || levelMap[y,x]==3 || levelMap[y,x]==4 || levelMap[y,x]==7 ){
                firstInput = lastInput;
                return false;
            }else {
            return true;
       }   
       }
       
    }

}
