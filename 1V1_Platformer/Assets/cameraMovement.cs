using System;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player00 ;
    public Transform player01 ;
    public Camera camera ;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position =new Vector3((player00.transform.position.x+player01.position.x)/2,0,-10);
        if (Math.Abs((player00.position.x - player01.position.x))>= 12)camera.orthographicSize = Math.Abs((player00.position.x - player01.position.x)/3.0f);

    }
}
