using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] transArray;
    private GameObject Wall;
    public float positionX;
    public float positionY;
    private int wallsid = 0;
    public GameObject level01;
    // Start is called before the first frame update
    //Data of four maps (initial x-axis, initial y-axis, x-axis creation direction, y-axis creation direction, map id)
    void Start()
    {
        level01.SetActive(false);
        CreateMap(-3.5f, -5.5f, 1, 1, 0);
        CreateMap(-23.5f, -5.5f, -1, 1, 1);
        CreateMap(-3.5f, -21.5f, 1, -1, 2);
        CreateMap(-23.5f, -21.5f, -1, -1, 3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateMap(float originalX, float originalY, int Xdirection, int Ydirection, int id)
    {
        
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


//By traversing the horizontal and vertical of the icon
        for (int y = 0; y < levelMap.GetLength(0); y++){
        for (int x = 0; x < levelMap.GetLength(1); x++){
            //Through the horizontal and vertical (x, y) data in the levelmap, put down the corresponding walls picture
            switch (id){
                case 0:

                switch (levelMap[y, x]){ 

                case 1:
                wallsid=levelMap[y, x];
                    Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);

                       if (y>0 && x+1 > 0 && y+1 <=  levelMap.GetLength(0) && x+1 <= levelMap.GetLength(1))
                    { 
                     if (levelMap[y-1, x]==2 && levelMap[y, x+1]==2 || levelMap[y-1, x]==7 && levelMap[y, x+1]==2)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==2 && levelMap[y, x-1]==2 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==2 && levelMap[y, x-1]==2)
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }
                    
                break;

                case 2:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                     if (y == 0){
                        Wall.transform.Rotate(0, 0, 90);
                     }else if (x-1 <0 && levelMap[y,x+1]==2 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< 13) {
                            if (levelMap[y, x-1]==2 || levelMap[y,x+1]==2 || levelMap[y,x-1]==7 || levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }
                        }
                break;
                
                case 3:
                    wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                     
                     if (x == levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y+1, x]==5 ||levelMap[y-1, x]==4  && levelMap[y+1, x]==0)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 && levelMap[y+1, x]!=4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }

                    }

                 if (y>0 && x > 0 && y+1 <= levelMap.GetLength(0) && x < levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==4 || levelMap[y-1, x]==3 && levelMap[y, x+1]==4  || levelMap[y-1, x]==4 && levelMap[y, x+1]==3 || levelMap[y-1, x]==3 && levelMap[y, x+1]==3)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 || levelMap[y-1, x]==3 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 || levelMap[y+1, x]==3 && levelMap[y, x-1]==3 ||  levelMap[y+1, x]==7 && levelMap[y, x-1]==4 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }

                 
                break;
                case 4:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);

                      if(y<0){
                           if(levelMap[y,x+1]==0 && levelMap[y-1,x]==4||levelMap[y,x+1]==0 && levelMap[y+1,x]==3){
                                 Wall.transform.Rotate(0, 0, 0);
                           }
                       }
                    if (x==13 && levelMap[y,x-1]==4 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< levelMap.GetLength(1)-1&& y<levelMap.GetLength(0)-1 ) {
                         if (levelMap[y, x-1]==5||levelMap[y,x+1]==5 || levelMap[y, x-1]==0||levelMap[y,x+1]==0 && levelMap[y+1,x]==4)
                       {
                            Wall.transform.Rotate(0, 0, 0);
                       
                       }else if (levelMap[y, x-1]==4 && levelMap[y,x+1]!=0 || levelMap[y, x-1]==4 && levelMap[y-1, x]==0 || levelMap[y,x+1]==4 || levelMap[y,x+1]==3 && levelMap[y,x+1]==3 || levelMap[y,x+1]==7 && levelMap[y,x+1]==4 || levelMap[y,x+1]==4 && levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0,0, 90);
                         }
                        }
                break;

                case 5:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
                case 6:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
                case 7:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);

                  if(y < levelMap.GetLength(0) && x < levelMap.GetLength(1)){
                     if (levelMap[y+1, x]==4 && levelMap[y, x-1]==2 )
                     {
                       Wall.transform.Rotate(0, 0, 270);  
                     }else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==2 || levelMap[y-1, x]==3 && levelMap[y, x+1]==2)
                     {
                          Wall.transform.Rotate(0, 0, 90);
                     }
                     if(x<0 ){
                         if (levelMap[y, x-1]==4 && levelMap[y+1, x]!=2 )
                     {
                          Wall.transform.Rotate(0, 0, 180);
                     }
                     }
                     }
                break;
                default:
                Debug.Log("Empty");
                break;
            }
            break;

// map right up
           
           case 1:
                switch (levelMap[y, x]){ 

             case 1:
                wallsid=levelMap[y, x];
                    Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                    Wall.transform.Rotate(0, 180, 0);
                    if (y>0 && x+1 > 0 && y+1 <=  levelMap.GetLength(0) && x+1 <= levelMap.GetLength(1))
                    { 
                     if (levelMap[y-1, x]==2 && levelMap[y, x+1]==2 || levelMap[y-1, x]==7 && levelMap[y, x+1]==2)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==2 && levelMap[y, x-1]==2 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==2 && levelMap[y, x-1]==2)
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }
                    
                break;

                case 2:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                      if (y == 0){
                        Wall.transform.Rotate(0, 0, 90);
                     }else if (x-1 <0 && levelMap[y,x+1]==2 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< 13) {
                            if (levelMap[y, x-1]==2 || levelMap[y,x+1]==2 || levelMap[y,x-1]==7 || levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }
                        }
                break;
                
                case 3:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                    Wall.transform.Rotate(0, 180, 0);
                      if (x == levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y+1, x]==5 ||levelMap[y-1, x]==4  && levelMap[y+1, x]==0)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 && levelMap[y+1, x]!=4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }

                    }

                 if (y>0 && x > 0 && y+1 <= levelMap.GetLength(0) && x < levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==4 || levelMap[y-1, x]==3 && levelMap[y, x+1]==4  || levelMap[y-1, x]==4 && levelMap[y, x+1]==3 || levelMap[y-1, x]==3 && levelMap[y, x+1]==3)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 || levelMap[y-1, x]==3 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 || levelMap[y+1, x]==3 && levelMap[y, x-1]==3 ||  levelMap[y+1, x]==7 && levelMap[y, x-1]==4 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }
                break;
                case 4:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                      Wall.transform.Rotate(0, 180, 0);
                       
                     if(y<0){
                           if(levelMap[y,x+1]==0 && levelMap[y-1,x]==4||levelMap[y,x+1]==0 && levelMap[y+1,x]==3){
                                 Wall.transform.Rotate(0, 0, 0);
                           }
                       }
                    if (x==13 && levelMap[y,x-1]==4 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< levelMap.GetLength(1)-1&& y<levelMap.GetLength(0)-1 ) {
                         if (levelMap[y, x-1]==5||levelMap[y,x+1]==5 || levelMap[y, x-1]==0||levelMap[y,x+1]==0 && levelMap[y+1,x]==4)
                       {
                            Wall.transform.Rotate(0, 0, 0);
                       
                       }else if (levelMap[y, x-1]==4 && levelMap[y,x+1]!=0 || levelMap[y, x-1]==4 && levelMap[y-1, x]==0 || levelMap[y,x+1]==4 || levelMap[y,x+1]==3 && levelMap[y,x+1]==3 || levelMap[y,x+1]==7 && levelMap[y,x+1]==4 || levelMap[y,x+1]==4 && levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0,0, 90);
                         }
                        }
                break;

                case 5:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
                case 6:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
                case 7:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                      Wall.transform.Rotate(0, 180, 0);
                     
                    if(y < levelMap.GetLength(0) && x < levelMap.GetLength(1)){
                     if (levelMap[y+1, x]==4 && levelMap[y, x-1]==2 )
                     {
                       Wall.transform.Rotate(0, 0, 270);  
                     }else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==2 || levelMap[y-1, x]==3 && levelMap[y, x+1]==2)
                     {
                          Wall.transform.Rotate(0, 0, 90);
                     }
                     if(x<0 ){
                         if (levelMap[y, x-1]==4 && levelMap[y+1, x]!=2 )
                     {
                          Wall.transform.Rotate(0, 0, 180);
                     }
                     }
                     }
                break;
                default:
                Debug.Log("Empty");
                break;
                }
            break;

//map left down
            case 2:
                switch (levelMap[y, x]){ 
//fist one check up down left right wall is 2 or not change rotate
             case 1:
                wallsid=levelMap[y, x];
                    Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);

                        Wall.transform.Rotate(180, 0, 0);
                     if (y>0 && x+1 > 0 && y+1 <=  levelMap.GetLength(0) && x+1 <= levelMap.GetLength(1))
                    { 
                     if (levelMap[y-1, x]==2 && levelMap[y, x+1]==2 || levelMap[y-1, x]==7 && levelMap[y, x+1]==2)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==2 && levelMap[y, x-1]==2 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==2 && levelMap[y, x-1]==2)
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }
                    
                break;
//chec left and right change roate
                case 2:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                     Wall.transform.Rotate(180, 0, 0);
                     if (y == 0){
                        Wall.transform.Rotate(0, 0, 90);
                     }else if (x-1 <0 && levelMap[y,x+1]==2 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< 13) {
                            if (levelMap[y, x-1]==2 || levelMap[y,x+1]==2 || levelMap[y,x-1]==7 || levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }
                        }
                break;
// check  up down left right wall and not change rotate
                case 3:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                    Wall.transform.Rotate(180, 0, 0);
                      if (x == levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y+1, x]==5 ||levelMap[y-1, x]==4  && levelMap[y+1, x]==0)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 && levelMap[y+1, x]!=4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }

                    }

                 if (y>0 && x > 0 && y+1 <= levelMap.GetLength(0) && x < levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==4 || levelMap[y-1, x]==3 && levelMap[y, x+1]==4  || levelMap[y-1, x]==4 && levelMap[y, x+1]==3 || levelMap[y-1, x]==3 && levelMap[y, x+1]==3)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 || levelMap[y-1, x]==3 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 || levelMap[y+1, x]==3 && levelMap[y, x-1]==3 ||  levelMap[y+1, x]==7 && levelMap[y, x-1]==4 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }
                break;
                // check  up down left right wall and not change rotate and not rotate
                case 4:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                      Wall.transform.Rotate(180, 0, 0);
                       
                      if(y<0){
                           if(levelMap[y,x+1]==0 && levelMap[y-1,x]==4||levelMap[y,x+1]==0 && levelMap[y+1,x]==3){
                                 Wall.transform.Rotate(0, 0, 0);
                           }
                       }
                    if (x==13 && levelMap[y,x-1]==4 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< levelMap.GetLength(1)-1&& y<levelMap.GetLength(0)-1 ) {
                         if (levelMap[y, x-1]==5||levelMap[y,x+1]==5 || levelMap[y, x-1]==0||levelMap[y,x+1]==0 && levelMap[y+1,x]==4)
                       {
                            Wall.transform.Rotate(0, 0, 0);
                       
                       }else if (levelMap[y, x-1]==4 && levelMap[y,x+1]!=0 || levelMap[y, x-1]==4 && levelMap[y-1, x]==0 || levelMap[y,x+1]==4 || levelMap[y,x+1]==3 && levelMap[y,x+1]==3 || levelMap[y,x+1]==7 && levelMap[y,x+1]==4 || levelMap[y,x+1]==4 && levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0,0, 90);
                         }
                        }
                break;

                case 5:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
                case 6:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
               // rotate t check left , right ,up,down and rotate 
                case 7:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                      Wall.transform.Rotate(180, 0, 0);
                     if(y < levelMap.GetLength(0) && x < levelMap.GetLength(1)){
                     if (levelMap[y+1, x]==4 && levelMap[y, x-1]==2 )
                     {
                       Wall.transform.Rotate(0, 0, 270);  
                     }else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==2 || levelMap[y-1, x]==3 && levelMap[y, x+1]==2)
                     {
                          Wall.transform.Rotate(0, 0, 90);
                     }
                     if(x<0 ){
                         if (levelMap[y, x-1]==4 && levelMap[y+1, x]!=2 )
                     {
                          Wall.transform.Rotate(0, 0, 180);
                     }
                     }
                     }
                break;
                default:
                Debug.Log("Empty");
                break;
                }
            break;
            
// map right down
             case 3:
                switch (levelMap[y, x]){ 

             case 1:
                wallsid=levelMap[y, x];
                    Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);

                        Wall.transform.Rotate(180, 180, 0);
                     if (y>0 && x+1 > 0 && y+1 <=  levelMap.GetLength(0) && x+1 <= levelMap.GetLength(1))
                    { 
                     if (levelMap[y-1, x]==2 && levelMap[y, x+1]==2 || levelMap[y-1, x]==7 && levelMap[y, x+1]==2)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==2 && levelMap[y, x-1]==2 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==2 && levelMap[y, x-1]==2)
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }
                    
                break;

                case 2:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                    Wall.transform.Rotate(180, 180, 0);
                     if (y == 0){
                        Wall.transform.Rotate(0, 0, 90);
                     }else if (x-1 <0 && levelMap[y,x+1]==2 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< 13) {
                            if (levelMap[y, x-1]==2 || levelMap[y,x+1]==2 || levelMap[y,x-1]==7 || levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }
                        }
                break;
                
                case 3:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                    Wall.transform.Rotate(180, 180, 0);
                        if (x == levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y+1, x]==5 ||levelMap[y-1, x]==4  && levelMap[y+1, x]==0)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 && levelMap[y+1, x]!=4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }

                    }

                 if (y>0 && x > 0 && y+1 <= levelMap.GetLength(0) && x < levelMap.GetLength(1)-1)
                    {
                        if(levelMap[y-1, x]==3 && levelMap[y, x+1]==4 && levelMap[y, x-1]==4){
                        Wall.transform.Rotate(0, 0, 0);    
                        }
                         else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==4 || levelMap[y-1, x]==3 && levelMap[y, x+1]==4  || levelMap[y-1, x]==4 && levelMap[y, x+1]==3 || levelMap[y-1, x]==3 && levelMap[y, x+1]==3)
                         {
                         Wall.transform.Rotate(0, 0, 90);
                         }else if (levelMap[y-1, x]==4 && levelMap[y, x-1]==4 || levelMap[y-1, x]==3 && levelMap[y, x-1]==4 || levelMap[y-1, x]==4 && levelMap[y, x-1]==3 || levelMap[y-1, x]==3 && levelMap[y, x-1]==3 )
                        {
                        Wall.transform.Rotate(0, 0, 180);
                        }else if (levelMap[y+1, x]==4 && levelMap[y, x-1]==4 || levelMap[y+1, x]==3 && levelMap[y, x-1]==4 || levelMap[y+1, x]==4 && levelMap[y, x-1]==3 || levelMap[y+1, x]==3 && levelMap[y, x-1]==3 ||  levelMap[y+1, x]==7 && levelMap[y, x-1]==4 )
                        {
                        Wall.transform.Rotate(0, 0, 270);
                        }
                    }
                    
                break;
                case 4:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                      Wall.transform.Rotate(180, 180, 0);
                       
                      if(y<0){
                           if(levelMap[y,x+1]==0 && levelMap[y-1,x]==4||levelMap[y,x+1]==0 && levelMap[y+1,x]==3){
                                 Wall.transform.Rotate(0, 0, 0);
                           }
                       }
                    if (x==13 && levelMap[y,x-1]==4 )
                     {
                         Wall.transform.Rotate(0, 0, 90);
                     }else if(x>0 && x< levelMap.GetLength(1)-1&& y<levelMap.GetLength(0)-1 ) {
                         if (levelMap[y, x-1]==5||levelMap[y,x+1]==5 || levelMap[y, x-1]==0||levelMap[y,x+1]==0 && levelMap[y+1,x]==4)
                       {
                            Wall.transform.Rotate(0, 0, 0);
                       
                       }else if (levelMap[y, x-1]==4 && levelMap[y,x+1]!=0 || levelMap[y, x-1]==4 && levelMap[y-1, x]==0 || levelMap[y,x+1]==4 || levelMap[y,x+1]==3 && levelMap[y,x+1]==3 || levelMap[y,x+1]==7 && levelMap[y,x+1]==4 || levelMap[y,x+1]==4 && levelMap[y,x+1]==7)
                         {
                         Wall.transform.Rotate(0,0, 90);
                         }
                        }
                break;

                case 5:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
                case 6:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                break;
                case 7:
                wallsid=levelMap[y, x];
                     Movemap(wallsid, x, y, originalX,originalY,Xdirection,Ydirection,id);
                     Wall.transform.Rotate(180, 180, 0);
                   
                     if(y < levelMap.GetLength(0) && x < levelMap.GetLength(1)){
                     if (levelMap[y+1, x]==4 && levelMap[y, x-1]==2 )
                     {
                       Wall.transform.Rotate(0, 0, 270);  
                     }else if (levelMap[y-1, x]==4 && levelMap[y, x+1]==2 || levelMap[y-1, x]==3 && levelMap[y, x+1]==2)
                     {
                          Wall.transform.Rotate(0, 0, 90);
                     }
                     if(x<0 ){
                         if (levelMap[y, x-1]==4 && levelMap[y+1, x]!=2 )
                     {
                          Wall.transform.Rotate(0, 0, 180);
                     }
                     }
                     }
                break;
                default:
                Debug.Log("Empty");
                break;
                }
            break;
        }
        }
        }
        }
    //Initial position (originx, originy) + levelmap (very vertical position x, y), multiplied by the icon creation direction (left to right = 1, right to left = -1, first determine whether the size of the wall is 1)
    //Pass value to rotate
    private void Movemap(int wallsid,int x,int y,float originalX,float originalY,int Xdirection,int Ydirection,int id){
                     
         Wall = (GameObject)Instantiate(transArray[wallsid], transform);
                    positionX = (originalX + x)  * Xdirection;
                    positionY = (originalY + y)  * -Ydirection;
                    Wall.transform.position = new Vector3(positionX, positionY,90);
                
    }
    }

