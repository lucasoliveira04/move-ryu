using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float velocidadeMovimento = 5f;
    [SerializeField] private AudioClip somSubindo;
    [SerializeField] private AudioClip somDescendo;

    private Rigidbody2D rb;
    private AudioSource audioSourceSubindo;
    private AudioSource audioSourceDescendo;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Obtenha ambos os componentes AudioSource
        audioSourceSubindo = GetComponents<AudioSource>()[0];
        audioSourceDescendo = GetComponents<AudioSource>()[1];

        // Configure os clips
        audioSourceSubindo.clip = somSubindo;
        audioSourceDescendo.clip = somDescendo;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector2 direcao = new Vector2(horizontal, vertical).normalized;

        rb.velocity = direcao * velocidadeMovimento;

        // Verifica se o personagem está subindo
        if (rb.velocity.y > 0)
        {
            if (!audioSourceSubindo.isPlaying)
            {
                audioSourceSubindo.Play();
            }
            audioSourceDescendo.Stop();
        }
        // Verifica se o personagem está descendo
        else if (rb.velocity.y < 0)
        {
            if (!audioSourceDescendo.isPlaying)
            {
                audioSourceDescendo.Play();
            }
            audioSourceSubindo.Stop();
        }
        // Se o personagem está parado
        else
        {
            audioSourceSubindo.Stop();
            audioSourceDescendo.Stop();
        }
    }
}