using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount==1&&!GetComponent<Sungod>().getPaused()&&Input.GetTouch(0).phase==TouchPhase.Began){
        RaycastHit hit;
        Debug.Log("Touch Detected");
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.tag =="Enemy")
            {
                hit.collider.gameObject.GetComponent<Asteroid_behaviour>().destroyedByPlayer();
         
            }else if(hit.collider.gameObject.tag =="PowerUp")
            {
                Debug.Log("Tapped a powerup");
                hit.collider.gameObject.GetComponent<PowerUpBehaviour>().onClick();
            }
        }
         if(Input.GetMouseButtonDown(0)&&!GetComponent<Sungod>().getPaused()){
        RaycastHit hit;
        Debug.Log("Touch Detected");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.tag =="Enemy")
            {
                hit.collider.gameObject.GetComponent<Asteroid_behaviour>().destroyedByPlayer();
         
            }else if(hit.collider.gameObject.tag =="PowerUp")
            {
                Debug.Log("Tapped a powerup");
                hit.collider.gameObject.GetComponent<PowerUpBehaviour>().onClick();
            }
        }
    }
}
