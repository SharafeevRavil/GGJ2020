using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
  
    public float turnSpeed = 4.0f;
    public Transform player;
  
    private Vector3 offset;
  
    void Start ()
    {
        var position = player.position;
        offset = new Vector3(position.x, position.y + 8.0f, position.z + 7.0f);
    }
  
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        var position = player.position;
        transform.position = position + offset; 
        transform.LookAt(position);
    }
}
