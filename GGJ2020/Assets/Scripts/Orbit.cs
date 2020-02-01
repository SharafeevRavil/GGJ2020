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
    private float offsetMaxLength;

    public float minCameraDistance = 1f;
    public float obstacleOffestDistance = 0.5f;

    void Start()
    {
        var position = player.position;
        offset = position + deltaOffset;
        curPosition = offset;
        offsetMaxLength = offset.magnitude;
    }

    private Vector3 curPosition;

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * horizontalTurnSpeed, Vector3.up) * offset;
        float vertAngle = -1 * Input.GetAxis("Mouse Y") * verticalTurnSpeed;
        Quaternion vertRot = Quaternion.AngleAxis(vertAngle, transform.right);
        if (!(transform.eulerAngles.x < 280 && transform.eulerAngles.x >= 270 && vertAngle < 0) &&
            !(transform.eulerAngles.x > 80 && transform.eulerAngles.x <= 90 && vertAngle > 0))
        {
            offset = vertRot * offset;
        }

        var playerPos = player.position;
        transform.position = playerPos + offset;

        curPosition = playerPos + offset;
        Vector3 pos = curPosition;

        RaycastHit hit;

        Debug.DrawRay(playerPos, offset, Color.red);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(playerPos, offset, out hit,
            offsetMaxLength, ~LayerMask.GetMask("Player")))
        {
            //какой-то предмет
            pos = hit.point - offset.normalized * obstacleOffestDistance;
            if ((pos - playerPos).magnitude < minCameraDistance)
            {
                pos = playerPos + offset.normalized * minCameraDistance;
            }

            Debug.DrawLine(playerPos, hit.point, Color.blue);
        }

        //Debug.DrawLine(playerPos, playerPos + offset.normalized * offsetMaxLength, Color.magenta);
        
        
        transform.position = pos;

        transform.LookAt(playerPos);
    }
}