using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonAnim : MonoBehaviour
{
    private bool animate= false;
    private Vector3 desiredPos;
     private float smoothFactor = 0.1f;
     private float xDist = 100f;
     private Transform original_t;
    // Start is called before the first frame update
    void Start()
    {
        original_t=transform;
        desiredPos = new Vector3(transform.position.x+xDist,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(animate){
        
            Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothFactor);
		    transform.position = smoothedPos;

            if(transform.position==desiredPos){
                //Destroy(this);
                animate=false;
            }
        }
        
    }

    public void startAnim(){
        animate=true;
    }
    public void setXDist(float x){
        xDist=x;
        desiredPos = new Vector3(original_t.position.x+xDist,original_t.position.y,original_t.position.z);
    }
}
