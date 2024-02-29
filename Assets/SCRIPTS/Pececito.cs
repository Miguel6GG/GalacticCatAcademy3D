using UnityEngine;
using UnityEngine.SceneManagement;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidad de rotaci�n del objeto
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        // Rotar el objeto sobre su propio eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
        // Verificar si el objeto con el que colisionamos tiene el tag "Player"
        //if (other.CompareTag("Player"))
        //{
            // Si el jugador toca este objeto, completar el nivel y cargar la siguiente escena
            //CompleteLevel();
        //}
    }

    private void CompleteLevel()
    {
        // Cargar la siguiente escena en el �ndice siguiente al actual
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No hay m�s niveles disponibles.");
        }
    }
}
