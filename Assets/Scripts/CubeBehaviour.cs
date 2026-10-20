using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
    //Se establece una velocidad y dirección
    public float degreesPerSecond = 45.0f;

    private float rotacion = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Calcula y establece la rotación
        transform.Rotate(0, rotacion * degreesPerSecond * Time.deltaTime, 0);
    }

    //Establece la dirección de rotación
    public void derecha()
    {
        rotacion = 1;
    }

    public void izquierda()
    {
        rotacion = -1;
    }

    public void detener()
    {
        rotacion = 0;
    }
}
