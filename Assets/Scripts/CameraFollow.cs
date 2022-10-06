using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float tranlateSpeed;
    public float rotationSpeed;
    void FixedUpdate()
    {
        moveToCamera();
        rotateTheCamera();
    }

    private void rotateTheCamera()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation=Quaternion.Lerp( transform.rotation,rotation,rotationSpeed*Time.deltaTime);
    }

    private void moveToCamera()
    {
        Vector3 targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position,targetPosition,tranlateSpeed*Time.deltaTime);
    }
}
