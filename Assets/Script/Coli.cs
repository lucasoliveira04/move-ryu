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

    private bool isFirstCollision = true;
    
    private int duckCount = 0;
    private int maxDucks = 24;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        StartCoroutine(SpawnDuckEvery8Seconds());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
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

    private IEnumerator SpawnDuckEvery8Seconds()
    {
        while (duckCount < maxDucks)
        {
            RespawnDuckRed();
            duckCount++;
            
            yield return new WaitForSeconds(8f);
        }
    } 
    
    private void RespawnDuckRed()
    {
        Camera camera = Camera.main;

        if (camera != null)
        {
            float cameraHeight = camera.orthographicSize * 2;
            float cameraWidth = cameraHeight * camera.aspect;
            
            float randomX1 = Random.Range(-cameraWidth / 2, cameraWidth / 2);
            float randomY1 = Random.Range(-cameraHeight / 2, cameraHeight / 2);
            
            Instantiate(duckRedPrefab, new Vector3(randomX1, randomY1, 0), Quaternion.identity);
        }
    }

}