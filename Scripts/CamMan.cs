using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMan : MonoBehaviour
{
    private bool isPlayPressed = false;
    [SerializeField] private Transform finalPos;
    [SerializeField] private float smoothFactor;
    // Start is called before the first frame update
    void Start()
    {
        
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
        isPlayPressed=true;
    }


}
