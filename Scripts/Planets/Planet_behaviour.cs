using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet_behaviour : MonoBehaviour
{

	[SerializeField]private float degreesPerSecond;
  [SerializeField] private float revolutionDegreePerSecond;
  [SerializeField] private ParticleSystem explosion;
  [SerializeField] private GameObject destroyTextCanvas;
  GameObject sun;
  private float health = 100.0f;
  private bool onScreen = false;
   
    void Start()
    {
        sun = GameObject.FindWithTag("Sun");
        health = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
     if(!GameObject.FindWithTag("Sun").GetComponent<Sungod>().getGameOver()&&GameObject.FindWithTag("Sun").GetComponent<Sungod>().isPlaying()) {
      transform.Rotate(0,degreesPerSecond*Time.deltaTime,0);
      transform.RotateAround(sun.transform.position,Vector3.up,revolutionDegreePerSecond*Time.deltaTime);
      checkLife();
     }
    }

    public void deductHealth(float damage){
      if(health>0)
      health-=damage;
  }

    void checkLife(){
      if(health<=0.0f){
        Instantiate(explosion,gameObject.transform.position,gameObject.transform.rotation);
        explosion.Play();
        GameObject.FindWithTag("Sun").GetComponent<SloMoEffect>().startSloMo();
        GameObject.FindWithTag("Sun").GetComponent<Sungod>().planetDestroyed();
        Instantiate(destroyTextCanvas,new Vector3(0f,0f,0f),Quaternion.identity);
        GameObject.FindWithTag("destroyText").GetComponent<Text>().text = gameObject.name+" Destroyed!";
        Destroy(gameObject);
      }
    }

    void OnBecameVisible(){
      onScreen=true;
    }

    public bool isObjectOnScreen(){
      return onScreen;
    }

    
}
