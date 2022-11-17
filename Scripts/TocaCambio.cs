using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocaCambio : MonoBehaviour
{
   
   public AudioSource quienEmite;
   public AudioClip elSonido;
   public float Volumen = 1f;


   private void OnTriggerEnter2D(Collider2D other)
   {
    quienEmite.PlayOneShot(elSonido, Volumen);
   }

}
