using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public GameObject man;
    private Vector3 newaddress;

    private int y = 1;
    private int x = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
              

        if (Input.GetKeyDown(KeyCode.W))
        {
            y=y-1;
             if(checknumber()){
            newaddress = new Vector3(man.transform.position.x,man.transform.position.y+1,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
            Debug.Log(y);
             }else{

                  y=y+1;
             }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
             y=y+1;
             if(checknumber()){
            newaddress = new Vector3(man.transform.position.x,man.transform.position.y-1,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
          Debug.Log(y);
             }else{
                 y=y-1;
             }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x=x-1;
             if(checknumber()){
            newaddress = new Vector3(man.transform.position.x-1,man.transform.position.y,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
           Debug.Log(x);
             }else{
                  x=x+1;
             }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
             x=x+1;
            if(checknumber()){
            newaddress = new Vector3(man.transform.position.x+1,man.transform.position.y,man.transform.position.z);
           man.transform.position = Vector3.Lerp(man.transform.position, newaddress , 1);
          Debug.Log(x);
            }else{
                x=x-1;
            }
        }
      




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
       
            if(levelMap[y,x]==2 || levelMap[y,x]==1 || levelMap[y,x]==3 || levelMap[y,x]==4 || levelMap[y,x]==7 ){
                return false;
            }
            return true;

    }
}
