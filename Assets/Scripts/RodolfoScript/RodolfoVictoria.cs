using UnityEngine;

public class RodolfoVictoria : MonoBehaviour
{

    public Collider2D jugador;
    public GameObject mensajeVictoria;

    private Collider2D zona;
    private bool victoria = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zona = GetComponent<Collider2D>();

        mensajeVictoria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){

        if (victoria || other != jugador){
            return;
        }

        Bounds limiterJugador = jugador.bounds;
        Bounds limiteZona = zona.bounds;

        bool dentro = limiterJugador.min.x >= limiteZona.min.x && limiterJugador.max.x <= limiteZona.max.x && limiterJugador.min.y >= limiteZona.min.y && limiterJugador.max.y <= limiteZona.max.y;

        if (dentro){
            victoria = true;

            mensajeVictoria.SetActive(true);

        }
    }
}
