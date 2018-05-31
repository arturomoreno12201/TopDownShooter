using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{

    public Transform Target;
    public float SmoothSpeed = 10;
    public Vector3 offset;

	
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        Vector3 desPos = Target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desPos, SmoothSpeed);

        transform.position = smoothPos;

        transform.LookAt(Target);

	}
}
