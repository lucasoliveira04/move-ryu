using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviJoystick : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float velocidadeMovimento = 30f;
    
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        
        Vector2 direcao = new Vector2(horizontal, vertical).normalized;

        rb.velocity = direcao * velocidadeMovimento;
    }
}
