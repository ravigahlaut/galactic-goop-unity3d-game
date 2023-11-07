using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveAnim : MonoBehaviour
{
    private float timeInterval=0f;
    private float blinkInterval=0f;
    private Vector3 desiredPos;
    [SerializeField] private Text textui;
    private float yDist=100f;
    
    // Start is called before the first frame update
    void Start()
    {
        desiredPos=new Vector3(transform.position.x,transform.position.y+yDist,transform.position.z);

        if(GameObject.FindWithTag("Sun").GetComponent<AsteroidSpawner>().getWave()==1){
            gameObject.GetComponent<Text>().text = "Incoming! Get Ready!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, 0.01f);
		transform.position = smoothedPos;

            if(timeInterval>2.5f){
                gameObject.SetActive(false);
                DestroyImmediate(gameObject,true);
            }else{
                timeInterval+=Time.deltaTime;
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
    public void setYDist(float y){
        yDist=y;
    }
}
