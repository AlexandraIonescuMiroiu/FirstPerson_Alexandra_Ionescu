using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;

    void Start()
    {

        controller = GetComponent<CharacterController>();




    }

    // Update is called once per frame
    void Update()
    {
      float h = Input.GetAxisRaw("Horizontal"); //h=0, h=-1, h=1
      float v = Input.GetAxisRaw("Vertical");  //v=0, v

      ///Vector3 movimiento = new Vector3(h, 0, v).normalized;

      Vector2 input = new Vector2 (h, v).normalized;
        
        if(input.magnitude > 0)
        {

            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        }






    }





}
