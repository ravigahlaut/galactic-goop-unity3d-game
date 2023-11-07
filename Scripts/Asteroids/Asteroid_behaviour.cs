using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_behaviour : MonoBehaviour
{
    [SerializeField]private float projection_speed;
    [SerializeField]Transform[] transforms;
    [SerializeField] private ParticleSystem tinyExplosion;
    [SerializeField]private GameObject damageSprite;
    [SerializeField] private float damage;

    private GameObject SUN;

    private bool onScreen = false;


    void Start()
    {
        projection_speed = Random.Range(0.2f,1.0f);

        //Rotating towards any random celestial body in the solar system
        transform.LookAt(transforms[Random.Range(0,7)]);
        transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);

        SUN = GameObject.FindWithTag("Sun");


    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindWithTag("Sun").GetComponent<Sungod>().getGameOver()&&GameObject.FindWithTag("Sun").GetComponent<Sungod>().isPlaying()) {
            transform.Translate(Vector3.forward*projection_speed*Time.deltaTime);
        }
    }

    /*void OnCollisionEnter(Collision collisionInfo){
        Debug.Log("Some collision detected");
        if(collisionInfo.collider.tag == "bound"){

            destroySelf();

        }
        else if(collisionInfo.collider.tag == "Planet"){
            if(collisionInfo.collider.GetComponent<Planet_behaviour>().isObjectOnScreen()){
            collisionInfo.collider.GetComponent<Planet_behaviour>().deductHealth(damage);
            Instantiate(damageSprite,transform.position,Quaternion.identity);
            shakeCamera();
            if(damage!=100){
            Instantiate(tinyExplosion,gameObject.transform.position,gameObject.transform.rotation);
            
            }
            destroySelf();
            }else{
                Debug.Log("Collision did not happen on Screen");
            }
        }else if(collisionInfo.collider.tag == "Sun"){
            Instantiate(tinyExplosion,gameObject.transform.position,gameObject.transform.rotation);
            
            destroySelf();
        }
    }*/
    void OnTriggerEnter(Collider collider){
        Debug.Log("Some collision detected");
        if(collider.tag == "bound"){

            destroySelf();

        }
        else if(collider.tag == "Planet"){
            if(collider.GetComponent<Planet_behaviour>().isObjectOnScreen()){
            collider.GetComponent<Planet_behaviour>().deductHealth(damage);
            GameObject go =Instantiate(damageSprite);
            go.transform.position = transform.position;
            shakeCamera();
            if(collider.gameObject!=null){
            Instantiate(tinyExplosion,transform.position,transform.rotation);
            }
            destroySelf();
            }else{
                Debug.Log("Collision did not happen on Screen");
            }
        }else if(collider.tag == "Sun"){
            Instantiate(tinyExplosion,transform.position,transform.rotation);
            
            destroySelf();
        }
    }

    void destroySelf(){
        SUN.GetComponent<AsteroidSpawner>().asteroidDestroyed();
        Destroy(gameObject);

    }

    public void destroyedByPlayer(){
        SUN.GetComponent<AsteroidSpawner>().asteroidDestroyed();
        SUN.GetComponent<ScoreManager>().incrementScore((int)damage);
        //shakeCamera();
        Instantiate(tinyExplosion,transform.position,Quaternion.identity);
        SUN.GetComponent<PowerUp>().spawnPowerUp(transform);
       
        DestroyImmediate(gameObject,true);
    }

    void OnBecameVisible(){
      onScreen=true;
    }

    void shakeCamera(){
        /*if(Camera.main.GetComponent<CameraShake>().shakeDuration==0.0f){
        Camera.main.GetComponent<CameraShake>().shakeDuration = 1.0f;
        }*/
    }

    
}
