using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePath : MonoBehaviour
{

    // Use this for initialization
    public float currentSpeed = 5f;
    public float endSpeed = 20f;
	public Transform target;
	
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < endSpeed) {
             currentSpeed += Time.deltaTime / 20;
        }
		transform.position += Vector3.back * currentSpeed * Time.deltaTime;
    }
}
