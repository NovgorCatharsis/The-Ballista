using UnityEngine;

public class MoonController : MonoBehaviour
{
    [SerializeField] private float moonSpeed;

    public void MoonMotion()
    {
        UnityEngine.Vector3 moonPosition = transform.position;
        transform.position = new UnityEngine.Vector3(moonPosition.x, moonPosition.y + moonSpeed, moonPosition.z);
    }
}