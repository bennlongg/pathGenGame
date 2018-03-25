using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{

    public Transform target;
    public Transform player;
    public GameObject path;
    public Vector3 offset;
    private float baseAngle = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
         transform.eulerAngles = new Vector3(35, transform.eulerAngles.y, transform.eulerAngles.z);
        
    }


    void OnMouseDown()
    {
        Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
        dir = Input.mousePosition - dir;
        baseAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }


    void OnMouseDrag()
    {
        Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
        dir = Input.mousePosition - dir;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        path.transform.rotation = Quaternion.AngleAxis(angle,  new Vector3(0, 1, 0));
    }


}
