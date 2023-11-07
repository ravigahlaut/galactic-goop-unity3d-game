using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotate : MonoBehaviour
{
    [SerializeField]private float degreesPerSecond;
    [SerializeField] private Transform finalPos;
    private float smoothFactor = 0.1f;

    private bool isPlayPressed = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,degreesPerSecond*Time.deltaTime,0);
        if(isPlayPressed){
            if(degreesPerSecond>-15.0f)
            degreesPerSecond-=2f;

            GetComponent<Timer>().Add(stopSpeedRot,0.3f);
        }else{
            if(degreesPerSecond<-5.0f)
            degreesPerSecond+=0.1f;
        }
        
    }
    void FixedUpdate()
    {
        if(isPlayPressed){
           Vector3 desiredPos = finalPos.position;
           Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothFactor);
           transform.position = smoothedPos;
        }
        
    }

    public void setIsPlayPressed(){
        isPlayPressed = true;
    }

    public void stopSpeedRot(){
        Debug.Log("Stop Rotation");
        isPlayPressed = false;
    }
    public void moveForwardWithCamera(){

    }
}
