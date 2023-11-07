using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIAnim : MonoBehaviour
{
    private bool animate= false;
    private Vector3 desiredPos;
     private float smoothFactor = 0.3f;
    private float xDist=-1200f;

    // Start is called before the first frame update
    void Start()
    {
        desiredPos = new Vector3(transform.position.x+xDist,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(animate){
        
            Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothFactor);
		    transform.position = smoothedPos;
            GameObject.FindWithTag("FinalScore").GetComponent<Text>().text = GameObject.FindWithTag("Sun").GetComponent<ScoreManager>().getScore().ToString();

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
    }
}
