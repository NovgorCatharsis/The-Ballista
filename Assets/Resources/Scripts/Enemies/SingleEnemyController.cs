using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class SingleEnemyController : MonoBehaviour
{
    [SerializeField] private AudioClip whooshSound;
    [SerializeField] private AudioClip breachSound;
    ValuesController valuesController;
    void Awake()
    {
        valuesController = GameObject.Find("Player").GetComponent<ValuesController>();
    }
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
            this.Breach();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Breach()
    {
        if (valuesController.breachLevel < 3)
        {
            AudioSource.PlayClipAtPoint(breachSound, transform.position, 1.5f);
            valuesController.breachLevel += 1;
            this.Death();
        }
        else if (valuesController.breachLevel == 3)
        {
            AudioSource.PlayClipAtPoint(whooshSound, transform.position, 1.5f);
            StartCoroutine(sceneLoad());
        }
    }

    private IEnumerator sceneLoad()
    {
        //yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OutroScene", LoadSceneMode.Single);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
