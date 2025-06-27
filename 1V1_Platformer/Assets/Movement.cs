using UnityEngine;
using System ;
using System.Data.Common;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public float moveSpeed ;
    public float jumpForce ;
    public bool isGrounded ;
    public PlayerMovement player00 ;
    public Transform attackpoint ;
    public float attackRadius = 0.35f ;
    public LayerMask enemyLayer ;
    Animator animator ;
    public int attackPower = 40 ;
    public bool isMoving ;
    public Combat combat ;
    public Text healthbar ;

    void Start(){
        player00.player = gameObject.GetComponent<Rigidbody2D>() ;
        player00.sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& !combat.isDead){
            attack();
        }
        if(Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.A)&& !combat.isDead){
            player00.Movement(0);
            isMoving = false ;
        }
        combat.displayHealth(healthbar);
    }
    void FixedUpdate()
    {


        
        if(Input.GetKey(KeyCode.D)&& !combat.isDead){
            player00.Movement(100*moveSpeed*Time.fixedDeltaTime);
            player00.flip();
            isMoving = true ;
        }
        if(Input.GetKey(KeyCode.A)&& !combat.isDead){
            player00.Movement(100*moveSpeed*Time.fixedDeltaTime*-1);
            player00.flip();
            isMoving = true;
        }

        //player00.Movement(HorizontalMove*100*moveSpeed*Time.fixedDeltaTime);
        
        if(Input.GetKey(KeyCode.W)&& !combat.isDead){
            animator.SetTrigger("jump");
            player00.jump(isGrounded,jumpForce*100*Time.fixedDeltaTime);
            isGrounded = false ;
        }
        animator.SetFloat("xVelocity",Math.Abs(player00.player.linearVelocityX));
        
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
