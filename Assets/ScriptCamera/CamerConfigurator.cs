using UnityEngine;
using UnityEngine.UI;

public class CamerConfigurator : MonoBehaviour
{
    //Se crean distintos elementos "public" para definirlos luego
    public Camera camara;

    //FOV -- Perspective
    public GameObject grupoFOV;
    public Slider sliderFOV;
    //Size -- Orthographic
    public GameObject grupoSize;
    public Slider sliderSize;


    //Far y Near -- Clipping Planes
    public GameObject grupoClipping;
    public Slider sliderFar;
    public Slider sliderNear;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        //Se otorgan valores maximos y minimos par los Sliders
        //FOV
        sliderFOV.minValue = 1;
        sliderFOV.maxValue = 180;
        //Size
        sliderSize.minValue = 1;
        sliderSize.maxValue = 100;

        //Valores minimos y maximos de los clipping planes
        //FAR
        sliderFar.minValue = 1;
        sliderFar.maxValue = 1000;
        //NEAR
        sliderNear.minValue = 0.01f;
        sliderNear.maxValue = 100;

        //Se pasa el valor del "slider" a la camara
        sliderFOV.value = camara.fieldOfView;
        sliderSize.value = camara.orthographicSize;

        //Actualiza los valores de los Clipping planes
        sliderFar.value = camara.farClipPlane;
        sliderNear.value = camara.nearClipPlane;

        sliderFOV.onValueChanged.AddListener(CambiarFOV);
        sliderSize.onValueChanged.AddListener(CambiarSize);

        sliderFar.onValueChanged.AddListener(CambiarFar);
        sliderNear.onValueChanged.AddListener(CambiarNear);

        ActualizarInterfaz();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.P)) {
            camara.orthographic = !camara.orthographic;
            ActualizarInterfaz();
        }
    }

    //Se actualizan los valores de los distintos elementos de la camara
    void CambiarFOV(float value){
        camara.fieldOfView = value;
    }

    void CambiarSize(float value){
        camara.orthographicSize = value;
    }

    void CambiarFar(float value){
        camara.farClipPlane = value;
    }
    void CambiarNear(float value){
        camara.nearClipPlane = value;
    }

    //se actualiza la vista de la camara
    void ActualizarInterfaz(){
        grupoFOV.SetActive(!camara.orthographic);
        grupoSize.SetActive(camara.orthographic);
        grupoClipping.SetActive(true);
    }

    //Se dibuja el Gizmo
    private void OnDrawGizmos(){
        
        //Setea el Color del Gizmo
        Gizmos.color = Color.yellow;
        Gizmos.matrix = camara.transform.localToWorldMatrix;

        //Dibuja el Gizmo segun la prespectiva de la camara y sus modificaciones
        //Si es proyeccion ortografica dibuja un cubo
        if(camara.orthographic){

            float alto = camara.fieldOfView * 2;
            float ancho = alto * camara.aspect;

            Gizmos.DrawWireCube(new Vector3(0, 0, (camara.nearClipPlane + camara.farClipPlane) / 2), new Vector3(ancho, alto, camara.farClipPlane - camara.nearClipPlane));
        }

        //Si es proyeccion por perspectiva dibuja un frustrum
        else{
            Gizmos.DrawFrustum(Vector3.zero, camara.fieldOfView, camara.farClipPlane, camara.nearClipPlane, camara.aspect);
        }

        Gizmos.matrix = Matrix4x4.identity;
    }
}
