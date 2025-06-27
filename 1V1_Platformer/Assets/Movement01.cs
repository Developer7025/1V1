using UnityEngine;
using System ;
using UnityEngine.UI;

public class Movement01 : MonoBehaviour
{
    public float moveSpeed ;
    public float jumpForce ;
    public bool isGrounded ;
    public PlayerMovement player01 ;
    public Transform attackpoint ;
    public float attackRadius = 0.35f ;
    public LayerMask enemyLayer ;
    Animator animator ;
    public int attackPower = 40 ;
    public bool isMoving ;
    public Combat combat ;
    public Text healthbar ;


    void Start(){
        player01.player = gameObject.GetComponent<Rigidbody2D>() ;
        player01.sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightControl)&& !combat.isDead){
            attack();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow)&& !combat.isDead){
            player01.Movement(0);
            isMoving = false ;
        }
        combat.displayHealth(healthbar);
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow)&& !combat.isDead){
            player01.Movement(100*moveSpeed*Time.fixedDeltaTime);
            player01.flip();
            isMoving = true ;
        }
        if(Input.GetKey(KeyCode.LeftArrow)&& !combat.isDead){
            player01.Movement(100*moveSpeed*Time.fixedDeltaTime*-1);
            player01.flip();
            isMoving = true ;
        }
        
        
        if(Input.GetKey(KeyCode.UpArrow)&& !combat.isDead){
            animator.SetTrigger("jump");
            player01.jump(isGrounded,jumpForce*100*Time.fixedDeltaTime);
            isGrounded = false ;
        }
        animator.SetFloat("xVelocity",Math.Abs(player01.player.linearVelocityX));
        
        animator.SetBool("isJumping",!isGrounded);
    }

    void OnCollisionEnter2D(){
        isGrounded = true ;
    }
    void attack(){
        FindAnyObjectByType<Audio>().play("Attack");
        animator.SetTrigger("attack");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackpoint.position,attackRadius,enemyLayer);
        foreach(Collider2D enemy in hitEnemy){
            Debug.Log("Hit");
            enemy.GetComponent<Combat>().TakeDamage(attackPower);
            
        }
    }
}
