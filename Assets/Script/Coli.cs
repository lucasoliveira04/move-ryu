using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coli : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;
    
    [SerializeField]
    private UpdateCoins updateCoinsScript;
    
    [SerializeField]
    private GameObject duckRedPrefab;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("DuckRed"))
        {
            if (!audioSource.isPlaying) 
            {
                audioSource.Play(); 
            }

            updateCoinsScript.UpdateText(1);
        
            Destroy(collision.gameObject); 
            
            RespawnDuckRed();
        }
    }

    private void RespawnDuckRed()
    {
        Camera camera = Camera.main;

        if (camera != null)
        {
            float cameraHeight = camera.orthographicSize * 2;
            float cameraWidth = cameraHeight * camera.aspect;
            
            float randomX = Random.Range(-cameraWidth / 2, cameraWidth / 2);
            float randomY = Random.Range(-cameraHeight / 2, cameraHeight / 2);
            
            Instantiate(duckRedPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
        }
    }

}