using UnityEngine;

public class CreateArray : MonoBehaviour
{

    public GameObject MyFirstPrefab;

    public int N = 5;
    public int M = 3;

    public float separacionx = 500f;
    public float separaciony = 500f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CrearMuro();
    }

    void CrearMuro(){

        if(MyFirstPrefab == null){
            Debug.LogError("Asigna un prefab");
            return;
        }

        for(int i = 0; i < N; i++){
            for(int j = 0; j < M; j++){

                Vector3 posicion = new Vector3(i * separacionx, j * separaciony, 0);

                Instantiate(MyFirstPrefab,posicion, Quaternion.identity);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
