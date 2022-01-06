using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameObject[] balls;
    Vector2 velocity; 
    public bool InitialVel;
    // Start is called before the first frame update
    void Start()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject circle in balls) {
            Physics2D.IgnoreCollision(circle.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if(InitialVel){
            gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(3f,0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        velocity=gameObject.GetComponent<Rigidbody2D>().velocity;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Arrow"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ScoreUp();
            if(gameObject.transform.localScale!=new Vector3(0.5f,0.5f,0.5f)){
                Vector2 vel=gameObject.GetComponent<Rigidbody2D>().velocity;

                Rigidbody2D temp1=Instantiate(gameObject.GetComponent<Rigidbody2D>(), new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x,gameObject.GetComponent<Rigidbody2D>().position.y), Quaternion.identity);
                temp1.GetComponent<Ball>().InitialVel=false;
                temp1.transform.position=new Vector2(temp1.position.x +2 , temp1.position.y);
                temp1.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
                
                Rigidbody2D temp2=Instantiate(gameObject.GetComponent<Rigidbody2D>(), new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x,gameObject.GetComponent<Rigidbody2D>().position.y), Quaternion.identity);
                temp2.GetComponent<Ball>().InitialVel=false;
                temp2.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
                temp2.transform.position=new Vector2(temp1.position.x -2 , temp1.position.y);
                if(vel.x>0){
                    temp1.velocity=new Vector2(vel.x,vel.y);
                    temp2.velocity=new Vector2(-vel.x,vel.y);
                }

                else{
                    temp1.velocity=new Vector2(-vel.x,vel.y);
                    temp2.velocity=new Vector2(vel.x,vel.y);
                }
                
                balls = GameObject.FindGameObjectsWithTag("Ball");
                foreach(GameObject circle in balls) {
                    Physics2D.IgnoreCollision(circle.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                }

            }

            Destroy(gameObject);


        }

        if (other.gameObject.CompareTag("Player")){
            GameObject.Find("GameManager").GetComponent<GameManager>().Result(false);
        }
        
        if (other.gameObject.CompareTag("Boundary")){
            gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(-gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
