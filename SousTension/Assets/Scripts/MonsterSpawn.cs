using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour {

    public GameObject monster;
    public float spawnTime = 1f;
    public Vector3 spawnPoint;
    public Quaternion spawnRotation;

    private Rigidbody2D rigi;
    private float angle = 0f;
    private float posX, posY;
    private float signeX = 1f;
    private float signeY = 1f; // Variable valant 1 ou -1 et permettant de changer le cadran dans lequel spawn le monstre
    private float rayon = 5f;
    private GameObject player;
    private Vector3 playerPos;
    private bool started = false;

    // Var Spawn Rect
    private float leftSpawn;
    private float rightSpawn;
    private float verticalSpawn;
    public float eloignement = 11f  ;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if(PlayerData.santeMentale <= PlayerData.maxSanteMentale * 0.19)
        {
            if (!started)
            {
                started = true;
                InvokeRepeating("SpawnRect", spawnTime, spawnTime);
            } 
        }
        else
        {
            CancelInvoke();
            started = false;
        }
    }

    void SpawnCircle()
    {
        playerPos = player.transform.position;
        angle = Random.value * (Mathf.PI / 2);
        Debug.Log(angle);
        if (Random.value < 0.5f)
            signeX = -1f;
        if (Random.value < 0.5f)
            signeY = -1f;
        posX = Mathf.Cos(angle) * rayon * signeX + playerPos.x;
        posY = Mathf.Sin(angle) * rayon * signeY + playerPos.y;
        spawnPoint = new Vector3(posX, posY, 0);
        spawnRotation = Quaternion.Euler(0, 0, 0);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(monster, spawnPoint, spawnRotation);
    }
    void SpawnRect()
    {
        playerPos = player.transform.position;
        leftSpawn = player.transform.position.x - eloignement + 0.5f;
        rightSpawn = player.transform.position.x + eloignement + 1f;
        verticalSpawn = Random.Range(-6f, 3f);
        if (Random.value < 0.5f)
        {
            posX = leftSpawn  ;
            spawnRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Random.value < 0.5f)
        {
            posX = rightSpawn ;
            spawnRotation = Quaternion.Euler(0, 180, 0);
        }
        posY = verticalSpawn + player.transform.position.y;
        spawnPoint = new Vector3(posX, posY, 0);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(monster, spawnPoint, spawnRotation);
    }
}
