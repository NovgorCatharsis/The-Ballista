using UnityEngine;

public class MoonController : MonoBehaviour
{
    [SerializeField] private float moonSpeed;
    [SerializeField] private GameObject bloodMoon;
    public void MoonMotion()
    {
        UnityEngine.Vector3 moonPosition = transform.position;
        transform.position = new UnityEngine.Vector3(moonPosition.x, moonPosition.y + moonSpeed, moonPosition.z);
        if (transform.position.y == -5)
        {
            Instantiate(bloodMoon, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}