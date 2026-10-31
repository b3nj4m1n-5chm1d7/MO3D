using System;
using UnityEngine;

public class RodolfoCamera : MonoBehaviour
{
    public Transform jugador;
    public float velocidadCam = 5f;

    public float margenX =  0.2f;
    public float margenY = 0.2f;

    public float limiteArr = 5f;
    public float limiteAba = -5f;
    public float limiteIzq = -10f;
    public float limiteDer = 10f;

    public bool seguirVertical = false;
    public bool seguirHorizontal = true;

    private Camera camara;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
     camara = GetComponent<Camera>();   
    }

    // Update is called once per frame
    void LateUpdate(){

        if(jugador == null || camara == null){
            return;
        }

        Vector3 posJugador = camara.WorldToViewportPoint(jugador.position);

        Vector3 nuevaPos = transform.position;

        float MidAlt = camara.orthographicSize;
        float MidAnch = MidAlt * camara.aspect;

        float MargenIzq = transform.position.x - MidAnch + (MidAlt * 2 * margenX);
        float MargenDer = transform.position.x + MidAnch - (MidAlt * 2 * margenX);

        float MargenSup = transform.position.y + MidAlt - (MidAlt * 2 * margenY);
        float MargenInf = transform.position.y - MidAlt + (MidAlt * 2 * margenY);

        if (seguirHorizontal){

            if (jugador.position.x < MargenIzq){
                nuevaPos.x = jugador.position.x + MidAnch - (MidAlt * 2 * margenX);
            }
            else if (jugador.position.x > MargenDer){
                nuevaPos.x = jugador.position.x - MidAnch + (MidAlt * 2 * margenX);
            }
        }

        if (seguirVertical){

            if (jugador.position.y < MargenInf){
                nuevaPos.y = jugador.position.y + MidAlt - (MidAlt * 2 * margenY);
            }
            else if (jugador.position.y > MargenSup){
                nuevaPos.y = jugador.position.y - MidAlt + (MidAlt * 2 * margenY);
            }
        }

        nuevaPos.x = LimitarPos(nuevaPos.x, limiteIzq + MidAnch, limiteDer - MidAnch);

        nuevaPos.y = LimitarPos(nuevaPos.y, limiteAba + MidAlt, limiteArr - MidAlt);

        nuevaPos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, nuevaPos, velocidadCam * Time.deltaTime);
    }

    float LimitarPos(float valor, float minimo, float maximo){

        if (minimo > maximo){
            return (minimo + maximo) / 2f;
        }

        return Mathf.Clamp(valor, minimo, maximo);
    }
}
