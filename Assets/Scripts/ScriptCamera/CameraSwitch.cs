using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject SecondCamera;
    public GameObject camera;

    public GameObject CambioPos;
    public Transform[] marcador;

    private int marcadorActual = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera.SetActive(true);
        SecondCamera.SetActive(false);

        marcadorActual = 0;
        ActualizarPosicion();

        CambioPos.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.T)){

            bool activa = camera.activeSelf;
            
            camera.SetActive(!activa);
            SecondCamera.SetActive(activa);

            CambioPos.SetActive(activa);

            if(activa){
                ActualizarPosicion();
            }
        }
    }

    public void ProximoMarcador(){

        if(!SecondCamera.activeSelf || marcador.Length == 0){
            return;
        }

        marcadorActual = (marcadorActual + 1) % marcador.Length;

        ActualizarPosicion();
    }

    private void ActualizarPosicion(){

        Transform marcadores = marcador[marcadorActual];

        SecondCamera.transform.position = marcadores.position;
        SecondCamera.transform.rotation = marcadores.rotation;
    }
}
