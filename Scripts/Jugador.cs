using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    AudioSource fuenteDeAudio;

    [SerializeField] private float VerticalForce = 400f;
    [SerializeField] private float TiempoReinicio = 1f;
    [SerializeField] private ParticleSystem particulasJugador;
    private AudioSource sonidoJugador;

    Rigidbody2D jugadorRb;
    SpriteRenderer jugadorSR;

    public AudioClip sonidoSalto;
    [SerializeField] private Color amarillocolor;
    [SerializeField] private Color moradocolor;
    [SerializeField] private Color ciancolor;
    [SerializeField] private Color rosadocolor;
    private string coloractual;

    void Start()
    {
       
        jugadorRb = GetComponent<Rigidbody2D>();
        jugadorSR = GetComponent<SpriteRenderer>();
        CambiarColor();
        Awake();
        sonidoJugador = GetComponent<AudioSource>();
    }

    

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

 

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            jugadorRb.velocity = Vector2.zero;
            jugadorRb.AddForce(new Vector2(0, VerticalForce));
            sonidoJugador.PlayOneShot(sonidoSalto, 0.5f);
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisono con: "+collision.gameObject.name);
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CambioColor"))
        {
            CambiarColor();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.gameObject.CompareTag("Meta"))
        {
            gameObject.SetActive(false);
            Instantiate(particulasJugador, transform.position, Quaternion.identity);
            Invoke("CargarSiguienteNivel", TiempoReinicio);
            return;
        }
        
        if(!collision.gameObject.CompareTag(coloractual))
        {
            gameObject.SetActive(false);
            Instantiate(particulasJugador, transform.position, Quaternion.identity);
            Invoke("ReiniciarEscena", TiempoReinicio);
           
        
        }
    }

    void  CargarSiguienteNivel()
    {
        int IndiceEscenaActiva = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(IndiceEscenaActiva + 1);
    }


    void  ReiniciarEscena()
    {
        int IndiceEscenaActiva = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(IndiceEscenaActiva);
    }



    void CambiarColor()
    {
        int NumRandom = Random.Range(0, 4);
        Debug.Log(NumRandom);

        if(NumRandom == 0)
        {
            jugadorSR.color = amarillocolor;
            coloractual = "Amarillo";

        }
        else if(NumRandom == 1)
        {
            jugadorSR.color = moradocolor;
            coloractual = "Morado";
        }
        else if(NumRandom == 2)
        {
            jugadorSR.color = ciancolor;
            coloractual = "Cian";
        }
        else if(NumRandom == 3)
        {
            jugadorSR.color = rosadocolor;
            coloractual = "Rosado";
        }
    }

}
