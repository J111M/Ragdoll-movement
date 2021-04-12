using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopDown_Camera : MonoBehaviour
{
    public Transform playerFollow;
    
    [SerializeField]
    private float c_Height = 10f;
    
    [SerializeField]
    private float c_Distance = 20f;
    
    [SerializeField]
    private float c_Angle = 45f;

    [SerializeField]
    private float c_SmoothSpeed = 0.5f;

    
    private Vector3 refVelocity;

    // Start is called before the first frame update
    void Start()
    {
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        if (!playerFollow)
        {
            return;
        }

        //Build World Pos vector
        Vector3 worldPosition = (Vector3.forward * - c_Distance) + (Vector3.up * c_Height);
        //Debug.DrawLine(playerFollow.position, worldPosition, Color.red);

        Vector3 rotatedVector = Quaternion.AngleAxis(c_Angle, Vector3.up) * worldPosition;
        //Debug.DrawLine(playerFollow.position, rotatedVector, Color.green);

        Vector3 flatTargetPosition = playerFollow.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        //Debug.DrawLine(playerFollow.position, finalPosition, Color.blue);

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, c_SmoothSpeed);
        transform.LookAt(playerFollow.position);
    
    }
}
