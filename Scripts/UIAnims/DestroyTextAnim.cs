using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTextAnim : MonoBehaviour
{
    private float timeInterval=0f;
    private float blinkInterval=0f;
    private Vector3 desiredPos;
    // Start is called before the first frame update
    void Start()
    {
        desiredPos=new Vector3(transform.position.x,transform.position.y+100f,transform.position.z);
        //GameObject.FindWithTag("destroyText").GetComponent<Text>().text = "Planet Destroyed!";
        if(GameObject.FindWithTag("Sun").GetComponent<Sungod>().getPlanetsLeft()==0){
            GameObject.FindWithTag("destroyText").GetComponent<Text>().text = "Solar System Destroyed!!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, 0.3f);
		transform.position = smoothedPos;
        if(GameObject.FindWithTag("Sun").GetComponent<Sungod>().getPlanetsLeft()!=0){
            if(timeInterval>1.5f){
                gameObject.SetActive(false);
                DestroyImmediate(gameObject,true);
            }else{
                timeInterval+=Time.deltaTime;
            }
        }else{
            
        }

            /*if(blinkInterval>=0.5f){
                /*if(gameObject.isActive){
                    gameObject.SetVisible(false);
                    blinkInterval=0.0f;
                }else{
                    gameObject.SetVisible(true);
                    blinkInterval=0.0f;
                } 
                blinkInterval+=Time.deltaTime;
            }*/
        
    }
}
