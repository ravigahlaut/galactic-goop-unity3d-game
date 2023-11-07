using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int WAVE = 1;
    [SerializeField] private GameObject waveCanvas;
    
    private int No_of_asteroids_on_field = 0;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindWithTag("Sun").GetComponent<Sungod>().getGameOver()&&GameObject.FindWithTag("Sun").GetComponent<Sungod>().isPlaying()){
            if(No_of_asteroids_on_field<=0){
                SpawnAsteroidOnce(WAVE);
            }
        }
            
    }

    void SpawnAsteroidOnce(int i){
        Instantiate(waveCanvas,transform.position,Quaternion.identity);
    for(int j=0;j<i*2;j++){        
        Instantiate(asteroidPrefabs[Random.Range(0,3)],spawnPoints[Random.Range(0,6)].transform.position,Quaternion.identity);
        No_of_asteroids_on_field++;
    }
   }

   void nextWave(){
       WAVE++;
        
       No_of_asteroids_on_field=0;
   }

   public int getWave(){
       return WAVE;
   }

   public void asteroidDestroyed(){
       if(No_of_asteroids_on_field>0){
            No_of_asteroids_on_field--;
       }
       if(No_of_asteroids_on_field<=0){
           nextWave();
       }
   }
}
