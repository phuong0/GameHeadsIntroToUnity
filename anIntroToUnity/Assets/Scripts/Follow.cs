using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject target;
    public float followDistance;
    public Vector3 followOffSet;
    public float cameraFollowSpeed = 0.1f;
    public float cameraRotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = CalculateCameraTargetPosition();

        transform.rotation = Quaternion.LookRotation(target.transform.forward);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraTargetPosition = CalculateCameraTargetPosition();

        Vector3 targetForward = target.transform.forward;

        //creates lag for the camera
        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, cameraFollowSpeed * Time.deltaTime);
        
        //Taking the camera direction and slowly rotating towards the capsule forward
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetForward, cameraRotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(direction);
    }

    Vector3 CalculateCameraTargetPosition()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector + followOffSet;

        return cameraTargetPosition;
    }
}
