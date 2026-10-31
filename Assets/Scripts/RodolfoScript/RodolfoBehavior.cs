using UnityEngine;

public class RodolfoBehavior : MonoBehaviour
{
    public float velocidad = 3.0f;
    public float salto = 5.0f;

    private Rigidbody2D rb;
    private bool suelo = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Mover(float direccion){
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);
    }

    public void Saltar()
    {
        if (suelo){
            rb.linearVelocity = new Vector2(rb.linearVelocityX, salto);
        }

        suelo = false;
    }

    void OnCollisionEnter2D(Collision2D collision){
        ComprobarSuelo(collision);
    }
    void OnCollisionStay2D(Collision2D collision){
        ComprobarSuelo(collision);
    }
    void OnCollisionExit(Collision2D collision){
        suelo = false;
    }

    void ComprobarSuelo(Collision2D collision){

        foreach (ContactPoint2D contacto in collision.contacts){

            if (contacto.normal.y > 0.5f && rb.linearVelocity.y <= 0){
                suelo = true;
                return;
            }
        }
    }
}
