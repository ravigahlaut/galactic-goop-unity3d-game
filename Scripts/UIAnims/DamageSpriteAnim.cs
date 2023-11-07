using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSpriteAnim : MonoBehaviour
{
    private float timeInterval=0f;
    private float blinkInterval=0f;
    private Vector3 desiredPos;
    private float zDist=1f;
    
    // Start is called before the first frame update
    void Start()
    {
        desiredPos=new Vector3(transform.position.x,transform.position.y,transform.position.z+zDist);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, 0.01f);
		transform.position = smoothedPos;

        
    }
    public void setZDist(float z){
        zDist=z;
    }
}
