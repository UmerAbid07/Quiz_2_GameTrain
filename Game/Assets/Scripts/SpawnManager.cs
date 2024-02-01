using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Vector3 spawnPos = new Vector3(-13, 7, 11);
    Vector3 playerPos = new Vector3(-12, -5, 11);
    Vector3 obstacleRotation = new Vector3(270, 0, 0);
    public GameObject obstacle;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        obstacle.transform.rotation = Quaternion.Euler(obstacleRotation);
        InvokeRepeating("spawner", 0.5f,8);
        Invoke("SpawnPlayer", 10);
    }
    void spawner()
    {
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }
    void SpawnPlayer()
    {
        Instantiate(player, playerPos, player.transform.rotation);
    }
}
