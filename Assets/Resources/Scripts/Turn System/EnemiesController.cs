using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesController", menuName = "Scriptable Objects/EnemiesController")]

public class EnemiesController : ScriptableObject
{
    System.Random randomObject = new System.Random();
    private GameObject[] enemiesObjects;
    private int enemiesSpawnNumber;
    TurnController turnController;
    [SerializeField] GameObject soldierPrefab;

    void Initiate()
    {
        turnController = Resources.Load<TurnController>("Scripts/Turn System/TurnController");
        enemiesObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }
    public void InitiateEnemies()
    {
        Initiate();
        foreach (GameObject enemyObject in enemiesObjects)
        {
            //Move Enemies
            enemyObject.GetComponent<SingleEnemyController>().EnemyMotion();
        }

        //Spawn enemies depending on current turn
        int turnCount = turnController.turnCount;
        if (turnCount < 5) enemiesSpawnNumber = randomObject.Next(0, 2);
        else if (turnCount < 10) enemiesSpawnNumber = randomObject.Next(1, 2);
        else if (turnCount < 13) enemiesSpawnNumber = randomObject.Next(1, 3);
        else if (turnCount < 15) enemiesSpawnNumber = randomObject.Next(2, 4);
        else enemiesSpawnNumber = randomObject.Next(2, 4);

        List<int> spawnPositions = new List<int>();
        for (int i = 0; i< enemiesSpawnNumber; i++)
        {
            int randomPosition = randomObject.Next(0, 3); // What lane will be chosen for enemy (0/1/2)
            if (spawnPositions.Contains(randomPosition))
            {
                continue;
            }
            else
            {
                spawnPositions.Add(randomPosition);
            }
        }
        
        Debug.Log ("SPAWN POSITIONS AMOUNT " + spawnPositions.Count);
        SpawnEnemies(spawnPositions);
    }

    void SpawnEnemies (List<int> spawnPositions)
    {
        Vector3 spawnCords = new Vector3(0, 0, 0);
        Quaternion spawnRotation = new Quaternion(0, 0, 0, 0);
        foreach (int position in spawnPositions)
        {
            Debug.Log ("SPAWN POSITION NUMBER  " + position);
            if (position == 0) spawnCords = new Vector3((float)2.5, 0, -14);
            else if (position == 1) spawnCords = new Vector3((float)0, 0, -14);
            else if (position == 2) spawnCords = new Vector3((float)-2.5, 0, -14);

            Instantiate(soldierPrefab, spawnCords, spawnRotation);
        }
    }
}