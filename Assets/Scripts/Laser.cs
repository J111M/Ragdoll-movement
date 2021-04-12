using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public int reflections;
    public float MaxLength;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    public bool laserIsOn;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        laserIsOn = true;
    }

    private void Update()
    {
        if (laserIsOn == true)
        {
            laserOn();
        }
        else if (laserIsOn == false)
        {
            
        }
    }

    private void laserOn()
    {
        MaxLength = 100;

        ray = new Ray(transform.position, transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remaningLength = MaxLength;

        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remaningLength))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remaningLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag != "Mirror")
                    break;
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remaningLength);
            }
        }
    }
}
