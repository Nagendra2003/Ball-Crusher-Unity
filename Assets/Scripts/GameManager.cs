using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score=0;
    float shootTime;
    public int level;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText ;
    public Rigidbody2D man;
    public Rigidbody2D upArrow;
    public GameObject button;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject shootButton;
    public GameObject HomeButton;

    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;


    // Start is called before the first frame update
    void Start()
    {
        level=MenuScript.level;
        if(level==1){circle1.SetActive(false);circle3.SetActive(false);}
        else if(level==2){circle2.SetActive(false);}
        shootTime=3;
        scoreText.gameObject.SetActive(true);
        scoreText.text="score: 0";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyUp (KeyCode.Escape)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
                return;
            }
        }
        if((int)shootTime >=0 && (int)shootTime <3){shootTime+=Time.deltaTime;}
        timeText.text=": " + (3-(int)shootTime).ToString();
    }
    public void ScoreUp(){
        score+=10;
        scoreText.text="score: " + score.ToString();
        if(score>=level*30){
            Result(true);
        }
    }

    public void Result(bool win){
        if(win){winText.gameObject.SetActive(true);}
        else{
            winText.text="Better Luck Next Time";
            winText.gameObject.SetActive(true);
        }
        HomeButton.SetActive(true);
        button.SetActive(true);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        shootButton.SetActive(false);
        man.gameObject.SetActive(false);
        foreach (Transform child in upArrow.transform)
        {
             child.gameObject.SetActive(false);
        }
        foreach(GameObject circle in GameObject.FindGameObjectsWithTag("Ball")) {
            circle.SetActive(false);
        }
        // scoreText.text=score.ToString();
    }
    public void Restart(){
        // button.SetActive(false);
        SceneManager.LoadScene("SampleScene");

    }
    public void GoHome(){
        // button.SetActive(false);
        SceneManager.LoadScene("Menu");

    }

    public void OnShoot(){
        shootTime=0;

    }
    public bool canShoot(){
        if(shootTime>=3){return true;}
        else{return false;}

    }
    
}
