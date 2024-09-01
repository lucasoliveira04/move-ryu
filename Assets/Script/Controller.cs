using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public void LoadScene()
    {
       SceneManager.LoadScene("ScenaGame");
    }
}