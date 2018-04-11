using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticles : MonoBehaviour
{

    public GameObject[] obsticlesArray;
    public Vector3 offset;
    // Use this for initialization
    void Start()
    {
        if (Random.value < 1)
        {
            int index = Random.Range(0, obsticlesArray.Length);

            if(gameObject.transform.eulerAngles.y >= 90 && gameObject.transform.eulerAngles.y < 91) {
                offset = new Vector3(Random.Range(0, 10f), 1f, Random.Range(0.8f, 1f));
                Debug.Log("90 " + this.gameObject.transform.eulerAngles.y + offset);
            } else if(gameObject.transform.eulerAngles.y >= 270 && gameObject.transform.eulerAngles.y < 271) {
                offset = new Vector3(Random.Range(0, -10f), 1f, Random.Range(0.8f, 1f));
                Debug.Log("270 " + this.gameObject.transform.eulerAngles.y + offset);
            } else {
                offset = new Vector3(Random.Range(0.8f, 1f), 1f, Random.Range(0, 10f));
                Debug.Log("0 " + this.gameObject.transform.eulerAngles.y + offset);
            }	
            GameObject obsticle = Instantiate(obsticlesArray[index], transform.position + offset, Quaternion.identity);
            obsticle.transform.parent = gameObject.transform;
            obsticle.transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
