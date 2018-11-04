using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TyController : MonoBehaviour {
    
    [System.Serializable]
    public class MoveSettings{
        public float baseForwardVel = 10;
        public float forwardVel = 10;
        public float rotateVel = 100;
        public float baseJumpVel = 25;
        public float jumpVel = 25;
        public float distToGround = 0.02f;
        public LayerMask ground;
    }
    
    [System.Serializable]
    public class PhysSettings{
        public bool isGrounded;
        public float downAccel = 2f;
    }
    
    [System.Serializable]
    public class InputSettings{
        public float inputDelay = 0.01f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
        public string AUTO_ATTACK = "Fire1";
    }
    
    public Health HP;
    public bool isAlive = true;
    public bool isAbleToAttack = true;
    public int damageAmount = 50;
    public float takeDamageCooldown = 1.5f;
    public bool isInvincible;
    public float timeLastTookDamage = 0.0f;
    public string currentWeapon = "staff";
    public SnowflakeProjectileScript snowflakeScript;
    public Image HPBar;
    public bool isSpeedy;

    Animator anim;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput;
    float turnInput;
    float jumpInput;
    public float attackInput;
    Vector3 velocity = Vector3.zero;
    Bounds bounds;
    
    
    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings physSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();
    
    public Quaternion TargetRotation{
        get {return targetRotation;}
    }

    // Use this for initialization
	void Start () {
        bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1f, 1f, 1f));
		targetRotation = transform.rotation;
        HP = GetComponent<Health>();
        anim = GetComponent<Animator>();
        anim.SetFloat("VelocityForward", 0);
        if (GetComponent<Rigidbody>()){
            rBody = GetComponent<Rigidbody>();
        } else {
            Debug.LogError("Add rigidbody to object");
        }
        forwardInput = turnInput = jumpInput = attackInput = 0;
	}
	
	// Update is called once per frame
	void Update () {
        updateHPBar();
        if (isAlive){
            GetInput();
            Turn();
            checkAlive();
        } else {
            anim.SetTrigger("Dead");
            velocity.z = 0f;
        }
	}
    
    void FixedUpdate(){
        if (isAlive){
            Run();
            Jump();
            Attack();
            
            rBody.velocity = transform.TransformDirection(velocity);
        }
    }
    
    void GetInput(){
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS);
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);
        attackInput = Input.GetAxisRaw(inputSetting.AUTO_ATTACK);
    }
    
	void Run(){
        // if ((transform.position.x > 0.5f) && (transform.position.x < 199.5f) && (transform.position.z > 0.5f) && (transform.position.z < 199.5f)){
            if (Mathf.Abs(forwardInput) > inputSetting.inputDelay){
                // rBody.velocity = transform.forward * forwardInput * moveSetting.forwardVel;
                velocity.z = moveSetting.forwardVel * forwardInput;
                anim.SetFloat("VelocityForward", velocity.z);
            } else {
                // rBody.velocity = Vector3.zero;
                velocity.z = 0;
                anim.SetFloat("VelocityForward", 0);
            }
        // }
    }
    
    void Turn() {
        if (Mathf.Abs(turnInput) > inputSetting.inputDelay){
            targetRotation *= Quaternion.AngleAxis(moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        
        transform.rotation = targetRotation;
    }
    
    bool Grounded(){
        physSetting.isGrounded = Physics.Raycast(transform.position, Vector3.down, moveSetting.distToGround, moveSetting.ground);
        if (physSetting.isGrounded){
            anim.SetBool("isGrounded", true);
        } else {
            anim.SetBool("isGrounded", false);
        }
        return physSetting.isGrounded;
    }
    
    void Jump(){
        if ( (jumpInput > 0) && Grounded() ){
            velocity.y = moveSetting.jumpVel;
        } else if ( (jumpInput == 0)  && Grounded() ){
            velocity.y = 0;
        } else {
            velocity.y -= physSetting.downAccel;
        }
    }
    
    void Attack(){
        if ( attackInput > 0 && isAbleToAttack){
            // int layerMask = 1 << 10;
            anim.SetTrigger("Slash");
            if (Equals(currentWeapon,"staff")){
                snowflakeScript.snowflakeAttack();
            }
            isAbleToAttack = false;
            Invoke("canDamage", 0.85f);
            
            // RaycastHit hit;
            // if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f, layerMask)) {
                // if (hit.transform.gameObject.tag.Equals("Enemy")){
                    // Debug.Log("Hit " + hit.transform.gameObject.name + "for " + damageAmount);
                    // hit.transform.gameObject.GetComponent<Health>().DecrementHealth(damageAmount);
                // }
            // }
        }
    }
    
    private void OnCollisionEnter(Collision collision) { // 
        if (!isInvincible){
            if (collision.gameObject.tag.Equals("EnemyProjectile")){
                recentlyTookDamage();
                Debug.Log("Ty took damage from " + collision.gameObject);
                HP.DecrementHealth(20);
            }
        }
    }
    
    public void doDamageToPlayer(int monsterPower){
        if (!isInvincible){
            recentlyTookDamage();
            HP.DecrementHealth(monsterPower);
            // Debug.Log("Ty took damage from a monster");
        }
    }

    void recentlyTookDamage(){
        isInvincible = true;
        Invoke("notInvincinble", takeDamageCooldown);
    }
    
    public void powerUpInvincible(float duration){
        if (isInvincible){ // This makes sure invincibility buff gets refreshed
            CancelInvoke("notInvincinble");
        }
        isInvincible = true;
        Invoke("notInvincinble", duration);
    }
    
    void notInvincinble(){
        isInvincible = false;
    }
    
    // i kept all speed naming the same BUT I MADE IT DOUBLE JUMP INSTEAD OF SPEED FOR BETTER PLAYABILITY
    public void powerUpSpeed(float duration, float multiplier){
        if (isSpeedy){
            // CancelInvoke("resetSpeed");
            CancelInvoke("resetJump");
        }
        isSpeedy = true;
        // moveSetting.forwardVel *= multiplier;
        moveSetting.jumpVel *= multiplier;
        // Invoke("resetSpeed", duration);
        Invoke("resetJump", duration);
    }
    
    void resetSpeed(){
        moveSetting.forwardVel = moveSetting.baseForwardVel;
    }
    
    void resetJump(){
        moveSetting.jumpVel = moveSetting.baseJumpVel;
    }
    
    void canDamage(){
        isAbleToAttack = true;
    }
    
    void checkAlive(){
        if (HP.currentHealth <= 0){
            isAlive = false;
            anim.SetTrigger("Dead");
            gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0f, 2f, 0f);
        }
    }
    
    void updateHPBar(){
        HPBar.fillAmount = ratioHP(HP.currentHealth, HP.minHealth, HP.startingHealth, 0f, 1f);
    }
    
    float ratioHP(float currHealth, float inMin, float inMax, float outMin, float outMax){
        return (currHealth - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
    
    public void updateWeapon(string weaponName){
        currentWeapon = weaponName;
    }
}
