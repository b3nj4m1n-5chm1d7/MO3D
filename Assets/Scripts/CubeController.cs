using UnityEngine;

public class CobeController : MonoBehaviour
{
    private CubeBehaviour cubeBehaviour;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //LLama al script de actualización del movimiento del cubo
        cubeBehaviour = GetComponent<CubeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se modifica la dirección del cubo dependiendo de la tecla que se presione
        if (Input.GetKeyDown(KeyCode.A)){
            cubeBehaviour.derecha();
        }

        if (Input.GetKeyDown(KeyCode.D)){
            cubeBehaviour.izquierda();
        }

        if (Input.GetKeyDown(KeyCode.S)){
            cubeBehaviour.detener();
        }

    }
}
