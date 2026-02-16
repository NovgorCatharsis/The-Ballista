using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            StartCoroutine(sceneLoad());
        }
    }

    public IEnumerator sceneLoad()
    {
        gameObject.SetActive(false);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}