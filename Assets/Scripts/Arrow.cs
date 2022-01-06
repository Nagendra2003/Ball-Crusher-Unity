using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arrow : MonoBehaviour


{
    int id;
    int maxArrows=10;
    public Rigidbody2D man;//man
    public Rigidbody2D up11;//to copy for others
    public Rigidbody2D[] arrows;
    public float[] timer;
    void Start()
    {
        id=0;
        // shootTime=3;
        arrows=new Rigidbody2D[maxArrows];
        timer =new float[maxArrows];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<maxArrows;i++){
            // Log(timer[i]);
            if(timer[i]>=2.5){
                Destroy(arrows[i].gameObject);
                timer[i]=0;
            }
            else if(timer[i]>=1.25 && arrows[i].velocity.y>0){
                arrows[i].velocity=new Vector2(0,-6f);
            }
            else if(timer[i]>0){timer[i]+=Time.deltaTime;}
        }

    }
    public void Shoot(){
        if(GameObject.Find("GameManager").GetComponent<GameManager>().canShoot() && timer[id%maxArrows]==0){
            GameObject.Find("GameManager").GetComponent<GameManager>().OnShoot();
            arrows[id%maxArrows]=Instantiate(up11, new Vector2(man.position.x,up11.position.y+70/60), Quaternion.identity);
            arrows[id%maxArrows].gameObject.transform.localScale = new Vector3(1, 1, 1);
            arrows[id%maxArrows].gameObject.GetComponent<SpriteRenderer>().sortingOrder=-1;
            arrows[id%maxArrows].transform.parent=up11.transform;
            arrows[id%maxArrows].velocity=new Vector2(0,6f);
            timer[id%maxArrows]=0.1f;
            id++;
        }
    }
}
