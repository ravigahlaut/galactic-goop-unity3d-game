using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloMoEffect : MonoBehaviour
{
    private float effectDuration = 0.8f;
    private float counter=0.0f;

    private bool startEffect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startEffect){
            if(counter<effectDuration){
                Time.timeScale=0.3f;
                counter+=Time.deltaTime;
            }
            if(counter>=effectDuration){
                counter=0.0f;
                Time.timeScale=1.0f;
                startEffect=false;
            }
        }  
    }

    public void startSloMo(){

        startEffect=true;
    }

    public void stopSloMo(){
        startEffect=false;
    }

    
    
}
