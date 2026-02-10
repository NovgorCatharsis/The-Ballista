/*
using UnityEngine;

[CreateAssetMenu(fileName = "BlinkingController", menuName = "Scriptable Objects/BlinkingController")]

public class BlinkingController_OLD : ScriptableObject
{
    System.Random randomObject = new System.Random();
    [SerializeField] private int blinkRollCap;
    public Animator blinkAnimator;

    private GameObject playerObject;
    private FatigueController fatigueController;

    EnemiesController enemiesController;

    void Initiate()
    {
        enemiesController = Resources.Load<EnemiesController>("Scripts/Turn System/EnemiesController");
        playerObject = GameObject.Find("Player");
        fatigueController = playerObject.GetComponent<FatigueController>();
    }
    public void Blink()
    {
        Initiate();
        int defaultBlinkRoll = randomObject.Next(0, 50);
        int fatigueLevel = fatigueController.fatigueLevel; //from 0 to 100
        int totalBlinkRoll =  defaultBlinkRoll + fatigueLevel;

        if (totalBlinkRoll > blinkRollCap)
        {
            Debug.Log("test blink");
            blinkAnimator.SetTrigger("Blink");
            enemiesController.InitiateEnemies();

        }
        
        else Debug.Log("not blink");
    }
}
*/