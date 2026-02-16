using System.Collections;
using UnityEngine;

public class BlinkingController : MonoBehaviour
{
    System.Random randomObject = new System.Random();
    [SerializeField] private int blinkRollCap;
    [SerializeField] private float enemiesSpawnCountdown;
    public Animator blinkAnimator;

    private GameObject playerObject;
    private ValuesController valuesController;

    EnemiesController enemiesController;

    void Awake()
    {
        enemiesController = Resources.Load<EnemiesController>("Scripts/Turn System/EnemiesController");
        playerObject = GameObject.Find("Player");
        valuesController = playerObject.GetComponent<ValuesController>();
    }
    public void Blink()
    {
        //Initiate();
        int defaultBlinkRoll = randomObject.Next(0, 50);
        //int fatigueLevel = valuesController.fatigueLevel; //from 0 to 100
        int totalBlinkRoll =  defaultBlinkRoll + valuesController.fatigueLevel;
        if (totalBlinkRoll > blinkRollCap)
        {
            blinkAnimator.SetTrigger("Blink");
            StartCoroutine(EnemiesSpawnCountdown());
        }
    }

    public IEnumerator EnemiesSpawnCountdown()
    {
        yield return new WaitForSeconds(enemiesSpawnCountdown);
        enemiesController.InitiateEnemies();
    }
}