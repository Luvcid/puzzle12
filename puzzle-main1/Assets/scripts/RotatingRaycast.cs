using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRaycast : MonoBehaviour

{
      public GameObject Mirror { get; set; }
    public LineRenderer LineOfSight;
    public float MaxRayDistance;
    public LayerMask LayerDetection;
    public float rotationSpeed = 5f;

    private bool isBeingControlled = false;

    void Update()
    {
        
        if (isBeingControlled)
        {
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotation);   
        }
        UpdateLineRenderer();
        
    }

    void UpdateLineRenderer()
    {
        LineOfSight.SetPosition(0, transform.position);

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, MaxRayDistance, LayerDetection);

        LineOfSight.positionCount = 2;
        if (hitinfo.collider != null)
        {
            LineOfSight.SetPosition(1, hitinfo.point);
        }
        else
        {
            LineOfSight.SetPosition(1, transform.position + transform.right * MaxRayDistance);
        }
    }

    public void StartControlling()
    {
        isBeingControlled = true;
    }

    public void StopControlling()
    {
        isBeingControlled = false;
    }
}
