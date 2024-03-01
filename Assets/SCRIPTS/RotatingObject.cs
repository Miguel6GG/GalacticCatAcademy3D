using UnityEngine;
using UnityEngine.SceneManagement;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidad de rotación del objeto
    public int nextSceneLoad;
    public AudioClip collisionSound; // Sonido a reproducir al colisionar con el jugador
    private AudioSource audioSource;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Añadir un AudioSource si no existe en el objeto
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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
            // Reproducir sonido al entrar en contacto con el jugador
            if (collisionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                Application.OpenURL("https://www.youtube.com/embed/vxJ-tH4yM1Y");
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(nextSceneLoad);

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
}
