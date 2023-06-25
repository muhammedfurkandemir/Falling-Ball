using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public Vector3 distance;
    public float speed;
    //public Transform lookTarget;

    private void LateUpdate()
    {
        float yPos = cameraTarget.position.y;
        Vector3 dPos = new Vector3(transform.position.x, yPos, distance.z);
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, Time.deltaTime * speed);
        transform.position = sPos;
        //transform.LookAt(lookTarget);
    }
}
