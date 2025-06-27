using UnityEngine;

public class AttackPointPosition01 : MonoBehaviour
{
    public float positionFromPlayer = 0.25f;
    public Transform attackPosition ;
    public Transform player;
    public Movement01 playerMovement ;
    
    void Update()
    {   
        if(playerMovement.player01.player.linearVelocityX < 0 && playerMovement.isMoving){
            attackPosition.position = player.position + new Vector3(positionFromPlayer*-1,1.2f,0);
        }
        else if(playerMovement.player01.player.linearVelocityX > 0 && playerMovement.isMoving){
            attackPosition.position = player.position +  new Vector3(positionFromPlayer,1.2f,0);}
        
    }
}
