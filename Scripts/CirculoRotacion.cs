using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirculoRotacion : MonoBehaviour
{
    [SerializeField] private float VelocidadRotacion = 100f;
    

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, VelocidadRotacion * Time.deltaTime));
    }
}
