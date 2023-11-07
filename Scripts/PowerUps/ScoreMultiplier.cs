using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplier : MonoBehaviour
{
    private float scaleFactor;
    private float counter=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        scaleFactor=0.0f;

        //Set InGameUI Canvas as the parent
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Internet is down since 3 days, will search this up as soon as it is back.
        // TO-DO: Scale the image up n down, up n down.
       /* if(counter<1.0f){
            scaleFactor-=0.2f;
            gameObject.transform.Scale;
            counter+=Time.deltaTime;
        }else if(counter>1.0f&&counter<2.0f){
            scaleFactor+=0.2f;
            gameObject.GetComponent<RectTransform>().SetScale(scaleFactor);
            counter+=Time.deltaTime;
        }else{
            counter=0.0f;
            gameObject.GetComponent<RectTransform>().SetScale(1.0f);
        }*/

        
    }
    public void setPos(Transform t){
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(t.position);

		screenPosition.y = Screen.height - screenPosition.y;
        
		
    }
    

}
