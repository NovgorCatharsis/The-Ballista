using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesController", menuName = "Scriptable Objects/EnemiesController")]

public class EnemiesController : ScriptableObject
{
    System.Random randomObject = new System.Random();
    private GameObject[] enemiesObjects;
    private int enemiesSpawnNumber;
    TurnController turnController;
    private GameObject enemiesGroup;
    [SerializeField] GameObject soldierGroupPrefab;
    [SerializeField] GameObject knightGroupPrefab;

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
        else if (turnCount < 20) enemiesSpawnNumber = randomObject.Next(1, 3);
        else if (turnCount < 30) enemiesSpawnNumber = randomObject.Next(2, 4);
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
        if (randomObject.Next(0, 2) == 0) enemiesGroup = soldierGroupPrefab;
        else if (randomObject.Next(0, 2) == 1) enemiesGroup = knightGroupPrefab;
        SpawnEnemies(spawnPositions, enemiesGroup);
    }

    void SpawnEnemies (List<int> spawnPositions, GameObject enemiesGroup)
    {
        Vector3 spawnCords = new Vector3(0, 0, 0);
        Quaternion spawnRotation = new Quaternion(0, 0, 0, 0);
        foreach (int position in spawnPositions)
        {
            Debug.Log ("SPAWN POSITION NUMBER  " + position);
            if (position == 0) spawnCords = new Vector3(5, -0.5f, -44);
            else if (position == 1) spawnCords = new Vector3(0, -0.5f, -44);
            else if (position == 2) spawnCords = new Vector3(-5, -0.5f, -44);

            Instantiate(enemiesGroup, spawnCords, spawnRotation);
        }
    }
}