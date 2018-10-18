using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyController : MonoBehaviour {
    
    public float velocity = 10f;
    public float jumpSpeed = 20f;
    public float rotationVel = 100f;
    public bool isGrounded = true;
    public LayerMask ground;
    Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        anim.SetBool("Grounded", true);
        anim.SetBool("isStill", true);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
        Attack();
        // checkGrounded();
        // Jump();
	}
    
    void Move(){
        float moveVert = Input.GetAxis("Vertical");
        anim.SetFloat("Velocity", moveVert);
        transform.position += new Vector3(0, 0, moveVert * velocity * Time.deltaTime);
        
        // float moveHori = Input.GetAxis("Horizontal");
        // anim.SetFloat("Velocity", moveHori);
        // transform.position += new Vector3(moveHori * velocity * Time.deltaTime, 0 , 0);
        
        if ( (moveVert == 0) ){
            anim.SetBool("isStill", true);
        } else {
            anim.SetBool("isStill", false);
        }
        
    }
    
    // void checkGrounded(){
        // bool grounded(Physics.Raycast(transform.position, Vector3.down, 1f, layerMask
    // }
    
    // void Jump() {
        
        // float jump = Input.GetAxis("Vertical") * jumpSpeed;
        // anim.SetFloat("
    // }
    
    void Attack(){
        if (Input.GetKeyDown(KeyCode.F)){
            anim.SetTrigger("Slash");
        }
    }
}
