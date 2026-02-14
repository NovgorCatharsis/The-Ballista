using UnityEngine;

public class SingleEnemyController : MonoBehaviour
{
    [SerializeField] private float enemyOffset;

    public void EnemyMotion()
    {
        UnityEngine.Vector3 enemyPosition = transform.position;
        transform.position = new UnityEngine.Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.z + enemyOffset);

        if (transform.position.z > -6) // Removing enemy if he has breached the defense
        {
            Destroy(gameObject);
        }
    }
}