using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    [SerializeField] private Transform jugadorTransform;


    void Update()
    {
        if(jugadorTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, jugadorTransform.position.y, transform.position.z);
        }
    }
}
