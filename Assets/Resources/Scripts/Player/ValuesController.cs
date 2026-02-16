using UnityEngine;


public class ValuesController : MonoBehaviour
{
    public int fatigueLevel;
    public bool hasArrow;
    public bool isBallistaLoaded;

    void Awake()
    {
        fatigueLevel = 0;
        hasArrow = false;
        isBallistaLoaded = true;
    }
}