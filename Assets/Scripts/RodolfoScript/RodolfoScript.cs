using UnityEngine;

public class RodolfoScript : MonoBehaviour
{
    private RodolfoBehavior rodolfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rodolfo = GetComponent<RodolfoBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

        float movimiento = 0;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movimiento = 1;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movimiento = -1;
        }

        rodolfo.Mover(movimiento);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rodolfo.Saltar();
        }
    }
}
