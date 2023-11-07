using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sungod : MonoBehaviour
{

    private int planetsLeft;
    private bool gameOver = false;
    private bool playing = false;
    private bool paused = false;
    
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject powerUpPanel;

    void Start()
    {
        planetsLeft=6;
        
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver();
        
    }

    public void planetDestroyed(){
        if(planetsLeft>0){
          planetsLeft--;
        }
    }

    private void isGameOver(){
        if(planetsLeft<=0){
            gameOver=true;
            playing=false;
            setGameOverUI();
        }
    }

    public void setPlaying(bool play){
        playing=play;
    }

    public bool isPlaying(){
        return playing;
    }

    public bool getGameOver(){
        return gameOver;
    }

    public void playPressed(){
        playing=true;
        playButton.GetComponent<PlayButtonAnim>().startAnim();
        pauseButton.GetComponent<PauseButtonAnim>().startAnim();
        powerUpPanel.GetComponent<SlideAnim>().startAnim();
        gameObject.GetComponent<ScoreManager>().setScoreUIActive();
    }

    public void pausePressed(){
        if(!paused){
            GetComponent<SloMoEffect>().stopSloMo();
            Time.timeScale=0.0f;
            paused=true;
            GameObject.FindWithTag("PauseMenu").GetComponent<PauseUIAnim>().setXDist(1200f);
            GameObject.FindWithTag("PauseMenu").GetComponent<PauseUIAnim>().startAnim();
            pauseButton.GetComponent<PauseButtonAnim>().setXDist(-100f);
            pauseButton.GetComponent<PauseButtonAnim>().startAnim();
        }else{
            GameObject.FindWithTag("PauseMenu").GetComponent<PauseUIAnim>().setXDist(-1200f);
            GameObject.FindWithTag("PauseMenu").GetComponent<PauseUIAnim>().startAnim();
            pauseButton.GetComponent<PauseButtonAnim>().setXDist(100f);
            pauseButton.GetComponent<PauseButtonAnim>().startAnim();
            Time.timeScale= 1.0f;
            paused=false;

        }
        
    }
    public bool getPaused(){
        return paused;
    }
    public int getPlanetsLeft(){
        return planetsLeft;
    }
    public void setGameOverUI(){
        GameObject.FindWithTag("Finish").GetComponent<GameOverUIAnim>().setXDist(-1200f);
        GameObject.FindWithTag("Finish").GetComponent<GameOverUIAnim>().startAnim();

    }

    public void replayButton(){
        Time.timeScale= 1.0f;
        paused=false;
        SceneManager.LoadScene(0);
        Debug.Log("Pasue: "+paused);
    }
}
