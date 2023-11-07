using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject multiplier;
    [SerializeField] private GameObject timeKill;
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject andromeda;
    [SerializeField] private GameObject mayhem;

    // Start is called before the first frame update
    void Start()
    {
        setUnactive("Turret");
        setUnactive("Multiplier");
        setUnactive("Andromeda");
        setUnactive("Time Kill");
        setUnactive("Mayhem");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPowerUp(Transform trans){
        int i = Random.Range(0,100);
        if(i>50&&i<55){
            GameObject go =Instantiate(multiplier);
            go.transform.position = trans.position;
            
        }else if(i>60&&i<=65){
            GameObject go =Instantiate(timeKill);
            go.transform.position = trans.position;
        }else if(i>65&&i<68){
            GameObject go =Instantiate(mayhem);
            go.transform.position = trans.position;
        }else if(i==99||i==98){
            GameObject go =Instantiate(andromeda);
            go.transform.position = trans.position;
        }else if(i>80&&i<84){
            GameObject go =Instantiate(turret);
            go.transform.position = trans.position;
        }
    }

    public void setUnactive(string name){
        GameObject panel = GameObject.FindWithTag("inGameCanvas").transform.Find("PowerUpPanel").gameObject;
        GameObject powerup = panel.transform.Find(name).gameObject;
        Color tempColor = powerup.GetComponent<Image>().color;
        tempColor.a=0.4f;
        powerup.GetComponent<Image>().color=tempColor;
    }

    public void setActive(string name){
        GameObject panel = GameObject.FindWithTag("inGameCanvas").transform.Find("PowerUpPanel").gameObject;
        GameObject powerup = panel.transform.Find(name).gameObject;
        Color tempColor = powerup.GetComponent<Image>().color;
        tempColor.a=1.0f;
        powerup.GetComponent<Image>().color=tempColor;
    }


}
