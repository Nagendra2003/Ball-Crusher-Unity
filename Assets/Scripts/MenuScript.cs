using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MenuScript : MonoBehaviour
{
    static public int level;
    public GameObject easyButton;
    // Start is called before the first frame update
    public void Start(){
        level=1;
    }
    void Update () {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyUp (KeyCode.Escape)) {
                Application.Quit ();
                return;
            }
        }
    }
    public void OnPlay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void OnQuit(){
        Application.Quit();
    }

    public void onEasy(){
        level=1;
    }
    public void onMed(){
        level=2;
    }
    public void onHard(){
        level=3;
    }
}
