using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
     private Tweener tweener;
    [SerializeField] private GameObject cherry; 
    float times = 2f;
    int i;
 
 
  
float Randomx;
float Randony;

GameObject Clone;
    private List<GameObject> itemList;
void Start () {
     tweener = GetComponent<Tweener>();
        itemList = new List<GameObject>();
        itemList.Add(cherry);

    
}

  void Update()
    {
            //Debug.Log(times);
        times -= Time.deltaTime;  //减时间]
        if (times < 0)  //倒计时
        {
        
           create();
        }
        

         

}


private void create(){

     //产生物体
       i = Random.Range(0,4);
          
           if(i==0){
            Randomx = Random.Range(-2.39f, 22.48f);
            Randony = Random.Range(6.92f,7f);  
            cherry.transform.position = new Vector3(Randomx, Randony, 0f);
            tweener.AddTween(cherry.transform, cherry.transform.position, new Vector3(Randomx, -23, 0f), 1.5f);
             

            
            //up to down
           }else if(i==1){
            Randomx = Random.Range(-2.39f, 22.48f);
            Randony = Random.Range(-23f, -24f);
           cherry.transform.position = new Vector3(Randomx, Randony, 0f); 
           tweener.AddTween(cherry.transform, cherry.transform.position, new Vector3(Randomx, 6.92f, 0f), 1.5f);
             
            
            //down to up
           }else if(i==2){
            Randomx = Random.Range(55f, 56f);
            Randony = Random.Range(4.62f, -20.9f);
            cherry.transform.position = new Vector3(Randomx, Randony, 0f);
            tweener.AddTween(cherry.transform, cherry.transform.position, new Vector3(-34.8f, Randony, 0f), 1.5f);
             
           
            //Left to right
           }else if(i==3){
            Randomx = Random.Range(-34.8f, -35f);
            Randony = Random.Range(4.62f, -20.9f); 
            cherry.transform.position = new Vector3(Randomx, Randony, 0f);
            tweener.AddTween(cherry.transform, cherry.transform.position, new Vector3(55f,Randony, 0f), 1.5f);
            // right to left
           }
           
            times = 10f;


          
            
}
}
