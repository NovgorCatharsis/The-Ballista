using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class MouseController : MonoBehaviour
{
    public float rotationSpeed;
    private PlayerInput playerInput;
    private GameObject ballistaObject;
    private new Camera camera;
    private Vector2 movementInput;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        ballistaObject = GameObject.Find("BallistaMain");
        camera = Camera.main;
    }
    
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Rigidbody ballistaRigidbody = ballistaObject.GetComponent<Rigidbody>();
        Quaternion ballistaRotation = Quaternion.Euler(
            movementInput.y * rotationSpeed,
            movementInput.x * rotationSpeed,
            0);
        //Debug.Log("MOVEMENT INPUT: " + movementInput);
        //Debug.Log("EULER ROTATION: " + ballistaRotation);
        Quaternion endRotation = ballistaRigidbody.rotation * ballistaRotation;
        Debug.Log(ballistaObject.transform.eulerAngles.x);
        if (Math.Abs(ballistaObject.transform.eulerAngles.x) >= 12)
        {
            //ballistaObject.transform.rotation.Set(0,ballistaObject.transform.rotation.y,ballistaObject.transform.rotation.z,0);
            endRotation = new Quaternion (0,endRotation.y,0,0);
        }
        
        ballistaRigidbody.MoveRotation(endRotation);





        /*
        Vector3 mousePosition = playerInput.actions.FindAction("MousePosition").ReadValue<Vector2>();
        Vector2 mousePositionNormalized = new Vector2(
            (float)((mousePosition.x / Screen.width)-0.5),
            (float)((mousePosition.y / Screen.height)-0.5)
        );
        //Vector3 test = camera.ScreenToWorldPoint(mousePosition);
        Debug.Log(mousePositionNormalized);
        Rigidbody ballistaRigidbody = ballistaObject.GetComponent<Rigidbody>();

        float ballistaVerticalRotation = mousePositionNormalized.y;
        float ballistaHorizontalRotation = mousePositionNormalized.x;
        
        if (Math.Abs(ballistaRigidbody.rotation.x) >= 12)
        {
            ballistaVerticalRotation = 0;
        }
        if (Math.Abs(ballistaRigidbody.rotation.y) >= 20)
        {
            ballistaHorizontalRotation = 0;
        }
        Quaternion ballistaRotation = Quaternion.Euler(ballistaVerticalRotation,ballistaHorizontalRotation,0);
        ballistaRigidbody.MoveRotation(ballistaRigidbody.rotation * ballistaRotation);
        //Quaternion ballistaRotation = new Quaternion ((mousePosition.y/100).normalized,mousePosition.x/100,0,0);
        //ballistaRigidbody.rotation = ballistaRotation;
        */



        /*
        Vector2 movementInput = playerInput.actions.FindAction("MouseDelta").ReadValue<Vector2>() * Time.deltaTime;
        Rigidbody ballistaRigidbody = ballistaObject.GetComponent<Rigidbody>();
        Quaternion ballistaRotation = Quaternion.Euler(
            movementInput.y * rotationSpeed,
            movementInput.x * rotationSpeed,
            0);
        Debug.Log("MOVEMENT INPUT: " + movementInput);
        Debug.Log("EULER ROTATION: " + ballistaRotation);
        ballistaRigidbody.MoveRotation(ballistaRigidbody.rotation * ballistaRotation);
        if (ballistaRigidbody.rotation.x >= 12)
        {
            ballistaRigidbody.rotation.Set(12,ballistaRigidbody.rotation.y,ballistaRigidbody.rotation.z,0);
        }
        else if (ballistaRigidbody.rotation.x <= -12)
        {
            ballistaRigidbody.rotation.Set(-12,ballistaRigidbody.rotation.y,ballistaRigidbody.rotation.z,0);
        }
        if (ballistaRigidbody.rotation.y >= 20)
        {
            ballistaRigidbody.rotation.Set(ballistaRigidbody.rotation.x,20,ballistaRigidbody.rotation.z,0);
        }
        else if (ballistaRigidbody.rotation.y <= -20)
        {
            ballistaRigidbody.rotation.Set(ballistaRigidbody.rotation.x,-20,ballistaRigidbody.rotation.z,0);
        }
        */
    }
}