using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    private float speed=4f;
    public Rigidbody2D man;
    public Animator manAnim;
    private bool notMoving;
    private bool movingLeft;
    // Start is called before the first frame update
    void Start()
    {
        notMoving=true;
        movingLeft=false;
        manAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoving();
    }
    private void HandleMoving(){
        if(notMoving){
             man.velocity=new Vector2(0,0);
        }
        else{
            if(movingLeft){
                man.velocity=new Vector2(-speed,0);
            }
            else{
                man.velocity=new Vector2(speed,0);
            }
        }
    }
    public void AllowMovement(bool movement){
        if (notMoving) {
            notMoving=false;
            movingLeft=movement;
            manAnim.SetBool("isMoving", !notMoving);
            manAnim.SetBool("movingLeft", movingLeft);
        }
    }
    public void dontAllowMovement(){
        if(!notMoving){
            notMoving=true;
            manAnim.SetBool("isMoving", !notMoving);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Boundary"))
        {
            man.velocity=new Vector2(-speed,0);
        }
    }
}
