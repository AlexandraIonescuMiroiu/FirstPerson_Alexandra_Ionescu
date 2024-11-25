using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEffect : MonoBehaviour
{

    private Volume efecto;
    [SerializeField] private float velocidad;


    // Start is called before the first frame update
    void Start()
    {

       efecto = GetComponent<Volume>();


    }

    // Update is called once per frame
    void Update()
    {

        


        if (efecto.profile.TryGet(out LensDistortion distortion));
        {
            FloatParameter miVariable = new FloatParameter(1 + Mathf.Cos(velocidad * Time.time)/ 2);
            FloatParameter miVariable2 = new FloatParameter(1 + Mathf.Sin(velocidad * Time.time) / 2);

            distortion.xMultiplier.SetValue(miVariable);
            distortion.yMultiplier.SetValue(miVariable2);


        }





    }
}
