using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movilidad2 : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoTorrente();
    }

    

    public void MovimientoTorrente()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _vel;
        float inputVertical = Input.GetAxisRaw("Vertical") * _vel;

        GetComponent<Rigidbody2D>().velocity = new Vector2(inputHorizontal, inputVertical);
    }
}