using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private float lifeSpan=4.0f;
    private float counter=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter>=lifeSpan){
            DestroyImmediate(gameObject,true);
        }else{
            counter+=Time.deltaTime;
        }
        
    }
}
