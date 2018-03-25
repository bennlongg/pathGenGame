using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathManager3D : MonoBehaviour
{
    public GameObject[] rightTiles;
    public GameObject[] straightTiles;
    public GameObject[] leftTiles;
    public GameObject currentTile;
    private GameObject nextTile;
    public GameObject previousTile;
    public int pathLength;

    private int tileInt;

    // Use this for initialization
    void Start()
    {
        Debug.Log(leftTiles.Length);
        currentTile.transform.position = gameObject.transform.position;
        // transform.position = new Vector3(0, 0, 0);
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
                // int index = Random.Range(0, 2);
                ;
                nextTile = Instantiate(getTile(0, 2), currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity) as GameObject;
                nextTile.transform.Rotate(0, currentTile.transform.rotation.eulerAngles.y - 90, 0);
            }
            else
            {
                instantiateTile();
                // instantiateTile(0, tiles.Length);
                nextTile.transform.Rotate(0, currentTile.transform.rotation.eulerAngles.y - 90, 0);
            }

        }
        if (currentTile.gameObject.tag == "right")
        {
            if (previousTile.gameObject.tag == "right")
            {
                // int index = Random.Range(1, 3);
                nextTile = Instantiate(getTile(1, 3), currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity) as GameObject;
                nextTile.transform.Rotate(0, currentTile.transform.rotation.eulerAngles.y + 90, 0);
            }
            else
            {
                instantiateTile();
                nextTile.transform.Rotate(0, currentTile.transform.rotation.eulerAngles.y + 90, 0);
            }
        }
        if (currentTile.gameObject.tag == "straight")
        {
            instantiateTile();
            nextTile.transform.Rotate(0, currentTile.transform.rotation.eulerAngles.y, 0);
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
            max = 3;
        }
        // int index = Random.Range(min, max);
        nextTile = Instantiate(getTile(min, max), currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity) as GameObject;
    }

    GameObject getTile(int min, int max) {
        int index = Random.Range(min, max);
        switch(index) {
            case 0:
            return rightTiles[Random.Range(0, rightTiles.Length)];
            case 1:
            return straightTiles[Random.Range(0, straightTiles.Length)];
            case 2:
            return leftTiles[Random.Range(0, leftTiles.Length)];
        }
        return null;
    }
}
