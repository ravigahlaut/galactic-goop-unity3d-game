using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    private int scoreMultiplier = 1;

    //The UI
    [SerializeField] private GameObject textUI;
    [SerializeField] private GameObject TitleText;
    private Text scoreText;
    private Text waveText;

    private float timeSince;

    void Start()
    {
        scoreText = textUI.GetComponent<Text>();
        timeSince=0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!GameObject.FindWithTag("Sun").GetComponent<Sungod>().getGameOver()&&GameObject.FindWithTag("Sun").GetComponent<Sungod>().isPlaying()){
        scoreText.text = score.ToString();  
        //addScore();
        }
        
          
    }

    public void incrementScore(int damage){
        score+=damage;
    }
    
    private void addScore(){
        if(timeSince>=2.0f){
            score++;
            timeSince=0.0f;
        }else{
            timeSince+=Time.deltaTime;
        }

    }
    public void setScoreUIActive(){
        textUI.SetActive(true);
        TitleText.GetComponent<TitleAnim>().startAnim();
    }
    public int getScore(){
        return score;
    }

}
