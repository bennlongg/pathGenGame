using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathManager : MonoBehaviour
{

    public GameObject[] tiles;
    public GameObject currentTile;
    private GameObject nextTile;
    public GameObject previousTile;
    public int pathLength;

    private int tileInt;

    // Use this for initialization
    void Start()
    {
        currentTile.transform.position = gameObject.transform.position;
        transform.position = new Vector3(0, 0, 0);
        spawnMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnMap()
    {
        for (int i = 0; i < pathLength; i++)
        {
            spawnTile();
            switch (currentTile.gameObject.tag)
            {
                case "left":
                    tileInt -= 1;
                    break;
                case "right":
                    tileInt += 1;
                    break;
                case "straight":
                    tileInt += 0;
                    break;
            }
        }
    }

    void spawnTile()
    {
        if (currentTile.gameObject.tag == "left")
        {
            if (previousTile.gameObject.tag == "left")
            {
                int index = Random.Range(0, 2);
                nextTile = Instantiate(tiles[index], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity) as GameObject;
                nextTile.transform.Rotate(0, 0, currentTile.transform.rotation.eulerAngles.z + 90);
            }
            else
            {
                instantiateTile();
                // instantiateTile(0, tiles.Length);
                nextTile.transform.Rotate(0, 0, currentTile.transform.rotation.eulerAngles.z + 90);
            }

        }
        if (currentTile.gameObject.tag == "right")
        {
            if (previousTile.gameObject.tag == "right")
            {
                int index = Random.Range(1, 3);
                nextTile = Instantiate(tiles[index], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity) as GameObject;
                nextTile.transform.Rotate(0, 0, currentTile.transform.rotation.eulerAngles.z - 90);
            }
            else
            {
                instantiateTile();
                nextTile.transform.Rotate(0, 0, currentTile.transform.rotation.eulerAngles.z - 90);
            }
        }
        if (currentTile.gameObject.tag == "straight")
        {
            instantiateTile();
            nextTile.transform.Rotate(0, 0, currentTile.transform.rotation.eulerAngles.z);
        }
        previousTile = currentTile;
        currentTile = nextTile;
        currentTile.transform.parent = gameObject.transform;

    }

    void instantiateTile()
    {
        int min;
        int max;

        if (tileInt >= 1)
        {
            min = 1;
            max = 3;
        }
        else if (tileInt <= -1)
        {
            min = 0;
            max = 2;
        }
        else
        {
            min = 0;
            max = tiles.Length;
        }
        int index = Random.Range(min, max);
        nextTile = Instantiate(tiles[index], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity) as GameObject;

    }
}
