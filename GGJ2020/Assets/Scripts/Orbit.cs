using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float horizontalTurnSpeed = 4.0f;
    public float verticalTurnSpeed = 3.0f;
    public Transform player;
    public Vector3 deltaOffset = new Vector3(0, 8f, 7f);
    private Vector3 offset;

    void Start()
    {
        var position = player.position;
        offset = position + deltaOffset;
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * horizontalTurnSpeed, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(-1 * Input.GetAxis("Mouse Y") * verticalTurnSpeed, Vector3.left) * offset;
        var position = player.position;
        transform.position = position + offset;
        transform.LookAt(position);
    }
}