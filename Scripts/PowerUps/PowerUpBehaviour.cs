using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUpBehaviour : MonoBehaviour
{
    private float scaleFactor=1.0f;
    private float counter=0.0f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(counter<0.5f){
            scaleFactor+=0.01f;
            transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);
            counter+=Time.deltaTime;
        }else if(counter>0.5f&&counter<1.0f){
            scaleFactor-=0.01f;
            transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);
            counter+=Time.deltaTime;
        }else{
            counter=0.0f;
            scaleFactor = 1.0f;
            transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);
        }
        
    }

    public void onClick(){
        string name=gameObject.name;
        Debug.Log(gameObject.name);
        switch (name)
        {
            case "2x(Clone)":
                gotTwoX();
                break;
            case "Andromeda(Clone)":
                gotAndromeda();
                break;
            case "Mayhem(Clone)":
                gotMayhem();
                break;
            case "Turret(Clone)":
                gotTurret();
                break;
            case "TimeKill(Clone)":
                gotTimeKill();
                break;
            default:
                break;
        }

    }

    void gotTwoX(){
        GameObject.FindWithTag("Sun").GetComponent<PowerUp>().setActive("Multiplier");
        Debug.Log("Player got 2x powerUp!");
        Destroy(gameObject);
    }
    void gotAndromeda(){
        GameObject.FindWithTag("Sun").GetComponent<PowerUp>().setActive("Andromeda");
        Debug.Log("Player got Andromeda powerUp!");
        Destroy(gameObject);

    }
    void gotTimeKill(){
        GameObject.FindWithTag("Sun").GetComponent<PowerUp>().setActive("Time Kill");
        Debug.Log("Player got TimeKill powerUp!");
        Destroy(gameObject);

    }
    void gotMayhem(){
        GameObject.FindWithTag("Sun").GetComponent<PowerUp>().setActive("Mayhem");
        Debug.Log("Player got Mayhem powerUp!");
        Destroy(gameObject);

    }
    void gotTurret(){
        GameObject.FindWithTag("Sun").GetComponent<PowerUp>().setActive("Turret");
        Debug.Log("Player got Turret powerUp!");
        Destroy(gameObject);

    }

    
}
