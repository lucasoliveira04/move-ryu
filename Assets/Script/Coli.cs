using System.Collections;
using UnityEngine;

public class Coli : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;
    
    [SerializeField]
    private UpdateCoins updateCoinsScript;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DuckRed"))
        {
            if (!audioSource.isPlaying) 
            {
                audioSource.Play(); 
            }

            updateCoinsScript.UpdateText("1");
            
            Destroy(collision.gameObject); 
        }
    }
}