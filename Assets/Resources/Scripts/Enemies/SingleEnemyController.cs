using UnityEngine;

public class SingleEnemyController : MonoBehaviour
{
    public void EnemyMotion()
    {
        float z = transform.position.z;
        if (z == -44)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, -37);
        }
        if (z == -37)
        {
            transform.position = new Vector3(transform.position.x, -2, -30);
        }
        else if (z == -30)
        {
            transform.position = new Vector3(transform.position.x, -2, -23);
        }
        else if (z == -23)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, -15);
        }
        else if (z == -15)
        {
            this.Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}