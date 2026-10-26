using UnityEngine;

public class CameraMarker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos(){
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 10f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 15f);
    }
}
