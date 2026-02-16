using UnityEngine;
using UnityEngine.InputSystem;

public class Outro : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
}