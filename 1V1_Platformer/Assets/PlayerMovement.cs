using System;
using UnityEngine;
[System.Serializable]
public class PlayerMovement
{   public Rigidbody2D player ;
    public SpriteRenderer sprite ;
    
    public void Movement(float moveForce){
        player.linearVelocityX = moveForce ;   
    }
    public void flip(){
        if (player.linearVelocityX > 0)sprite.flipX = true ;
        else if (player.linearVelocityX < 0) sprite.flipX = false ;
    }
    public void jump(bool isGrounded, float jumpForce){
        if(isGrounded){
            player.linearVelocityY = jumpForce ;
        }
    }
}
