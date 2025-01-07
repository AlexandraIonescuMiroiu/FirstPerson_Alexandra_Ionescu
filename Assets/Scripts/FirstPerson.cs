using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    private Vector3 verticalMovement;
    [SerializeField] private float gravityEscale = -9.8f;
    [SerializeField] private float vidas = 100;
    [SerializeField] private float movementVelocity = 3.5f;
    CharacterController controller;
    [SerializeField] private float radiusDetection = 0.4f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); //h=0, h=-1, h=1
        float v = Input.GetAxisRaw("Vertical");  //v=0, v
        ///Vector3 movimiento = new Vector3(h, 0, v).normalized;

        Vector2 input = new Vector2(h, v).normalized;

        if (input.magnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * movementVelocity * Time.deltaTime);
        }

        ApplyGravity();
    }

    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        Debug.Log("Life: " + vidas);
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ApplyGravity()
    {
        verticalMovement.y += gravityEscale * Time.deltaTime;
        controller.Move(verticalMovement * Time.deltaTime);
    }
}
