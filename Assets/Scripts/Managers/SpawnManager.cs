using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private DataContainer dataContainer;
    [SerializeField] private GameSetup gameSetup;
    [SerializeField] private GameOver gameOver;
    void Start()
    {
        gameSetup.SpawnObjectsEvent += GameSetup_SpawnChest;
        gameSetup.SpawnObjectsEvent += GameSetup_SpawnDoor;
        gameSetup.SpawnObjectsEvent += GameSetup_SpawnPlayer;

        gameOver.DestroyObjectsEvent += GameOver_DestroyChest;
        gameOver.DestroyObjectsEvent += GameOver_DestroyDoor;
        gameOver.DestroyObjectsEvent += GameOver_MovePlayerToTryAgainMenu;
    }

    private void GameSetup_SpawnChest()
    {
        float randomPositionX, randomRotationY, randomPositionZ;

        randomPositionX = UnityEngine.Random.Range(-28f, 28f);
        randomRotationY = UnityEngine.Random.Range(-180f, 180f);
        randomPositionZ = UnityEngine.Random.Range(-28f, 28f);
  
        Quaternion randomRotation = Quaternion.Euler(0f,randomRotationY,0f);
        Vector3 chestPosition = new Vector3(randomPositionX,0f,randomPositionZ);

        GameObject newChest = Instantiate(dataContainer.Chest, chestPosition, randomRotation);

        dataContainer.ChestOnScene = newChest;
        dataContainer.KeyOnScene = newChest.transform.GetChild(0).gameObject;
    }

    private void GameSetup_SpawnDoor()
    {
        float randomPosition;
        Vector3 doorPosition;
        int randomWall;

        randomWall = UnityEngine.Random.Range(0, 4);
        randomPosition = UnityEngine.Random.Range(-28f, 28f);

        switch(randomWall)
        {
            case 0:
                doorPosition = new Vector3(randomPosition, 0f, -30f);
                GameObject newDoor0 = Instantiate(dataContainer.DoorVariants[0],doorPosition, dataContainer.DoorVariants[0].transform.rotation);
                dataContainer.DoorOnScene = newDoor0;
                break;
            case 1:
                doorPosition = new Vector3(randomPosition, 0f, 30f);
                GameObject newDoor1 = Instantiate(dataContainer.DoorVariants[1], doorPosition, dataContainer.DoorVariants[1].transform.rotation);
                dataContainer.DoorOnScene = newDoor1;
                break;
            case 2:
                doorPosition = new Vector3(-30f, 0f, randomPosition);
                GameObject newDoor2 = Instantiate(dataContainer.DoorVariants[2], doorPosition, dataContainer.DoorVariants[2].transform.rotation);
                dataContainer.DoorOnScene = newDoor2;
                break;
            case 3:
                doorPosition = new Vector3(30f, 0f, randomPosition);
                GameObject newDoor3 = Instantiate(dataContainer.DoorVariants[3], doorPosition, dataContainer.DoorVariants[3].transform.rotation);
                dataContainer.DoorOnScene = newDoor3;
                break;
            default:
                doorPosition = Vector3.zero;
                break;
        }
    }
    private void GameSetup_SpawnPlayer()
    {
       PlayerManager.instance.transform.position = new Vector3(0f, 3f, 0f);
    }

    private void GameOver_DestroyDoor()
    {
        Destroy(FindObjectOfType<Door>().gameObject);
    }
    private void GameOver_DestroyChest()
    {
        Destroy(FindObjectOfType<Chest>().gameObject);
    }

    private void GameOver_MovePlayerToTryAgainMenu()
    {
        PlayerManager.instance.transform.position = new Vector3(0f, 33f, 0f);
        PlayerManager.instance.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
