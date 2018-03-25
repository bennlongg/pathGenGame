using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

public Transform target;
public Transform ring;
public float smoothSpeed = 100f;
public Vector3 offset;

void FixedUpdate() {
	Vector3 desiredPosition = target.position + offset;
	Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
	transform.position = smoothedPosition;
	// transform.LookAt(ring);
}

}
