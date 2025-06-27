using UnityEngine;

public class attackPointPosition : MonoBehaviour
{
    public float positionFromPlayer = 0.25f;
    public Transform attackPosition ;
    public Transform player;
    public Movement playerMovement ;
    
    void Update()
    {   
        if(playerMovement.player00.player.linearVelocityX < 0 && playerMovement.isMoving){
            attackPosition.position = player.position + new Vector3(positionFromPlayer*-1,0,0);
        }
        else if(playerMovement.player00.player.linearVelocityX > 0 && playerMovement.isMoving){
            attackPosition.position = player.position +  new Vector3(positionFromPlayer,0,0);}
        
    }
}
