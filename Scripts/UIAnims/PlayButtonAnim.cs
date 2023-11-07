using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAnim : MonoBehaviour
{
    private bool animate= false;
    private Vector3 desiredPos;
     private float smoothFactor = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        desiredPos = new Vector3(transform.position.x,transform.position.y-1000f,transform.position.z);
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
}
