using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

public Transform target;
public Transform ring;
public float smoothSpeed = 100f;
public Vector3 offset;
// public GameObject pathManager;


void start() {
// pathManager = GameObject.Find("pathManager").GetComponent<pathManager>();
}
void FixedUpdate() {
	Vector3 desiredPosition = target.position + offset;
	Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
	transform.position = smoothedPosition;

	// if(pathManager.totalTileCount > pathManager.changeToCity) {
	// 	transform.GetComponent<Camera>().backgroundColor = new Color32(58, 58, 58, 255);
	// }
}
}
