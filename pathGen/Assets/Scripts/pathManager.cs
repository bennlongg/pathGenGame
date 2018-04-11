using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathManager : MonoBehaviour
{
    public GameObject[] rightFarmTiles;
    public GameObject[] straightFarmTiles;
    public GameObject[] leftFarmTiles;

    public GameObject[] rightCityTiles;
    public GameObject[] straightCityTiles;
    public GameObject[] leftCityTiles;

    public GameObject[] rightIceTiles;
    public GameObject[] straightIceTiles;
    public GameObject[] leftIceTiles;

    public GameObject[] transitionTiles;

    public GameObject currentTile;
    private GameObject nextTile;
    public GameObject previousTile;
    public int pathLength;
    public int totalTileCount;
    private int tileInt;

    public int changeToCity;
    public int changeToIce;

    public GameObject camera;

    void Start()
    {
        currentTile.transform.position = gameObject.transform.position;
        spawnMap();
    }

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

        if (transform.childCount > 20)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
            Invoke("spawnMap", 1.5f);
    }

    void spawnTile()
    {
        if (currentTile.gameObject.tag == "left")
        {
            if (previousTile.gameObject.tag == "left")
            {
                nextTile = Instantiate(getTile(0, 2), currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity) as GameObject;
                nextTile.transform.Rotate(0, currentTile.transform.rotation.eulerAngles.y - 90, 0);
            }
            else
            {
                instantiateTile();
                nextTile.transform.Rotate(0, currentTile.transform.rotation.eulerAngles.y - 90, 0);
            }
        }
        if (currentTile.gameObject.tag == "right")
        {
            if (previousTile.gameObject.tag == "right")
            {
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
        totalTileCount += 1;
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
        nextTile = Instantiate(getTile(min, max), currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity) as GameObject;
    }

        GameObject getTile(int min, int max)
    {
        int index = Random.Range(min, max);
        if(totalTileCount < changeToCity) {
        switch (index)
        {
            case 0:
                return rightFarmTiles[Random.Range(0, rightFarmTiles.Length)];
            case 1:
                return straightFarmTiles[Random.Range(0, straightFarmTiles.Length)];
            case 2:
                return leftFarmTiles[Random.Range(0, leftFarmTiles.Length)];
        } 
        } else if (totalTileCount == changeToCity) {
            return transitionTiles[0];
        } else if (totalTileCount > changeToCity && totalTileCount < changeToIce) {
            camera.transform.GetComponent<Camera>().backgroundColor = new Color32(58, 58, 58, 255);
             switch (index)
        {
            case 0:
                return rightCityTiles[Random.Range(0, rightCityTiles.Length)];
            case 1:
                return straightCityTiles[Random.Range(0, straightCityTiles.Length)];
            case 2:
                return leftCityTiles[Random.Range(0, leftCityTiles.Length)];
        }
        }  else if (totalTileCount == changeToIce) {
            return transitionTiles[1];
        }else if (totalTileCount > changeToIce) {
            camera.transform.GetComponent<Camera>().backgroundColor = new Color32(98, 189, 255, 255);
             switch (index)
        {
            case 0:
                return rightIceTiles[Random.Range(0, rightIceTiles.Length)];
            case 1:
                return straightIceTiles[Random.Range(0, straightIceTiles.Length)];
            case 2:
                return leftIceTiles[Random.Range(0, leftIceTiles.Length)];
        }
        }
        return null;
    }
}
