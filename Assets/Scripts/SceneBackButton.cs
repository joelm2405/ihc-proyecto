using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBackButtonHandler : MonoBehaviour  // Cambié el nombre aquí
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiar a la escena "INTERFAZ"
            SceneManager.LoadScene("INTERFAZ");
        }
    }
}
