using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelSalir; // Arrastra tu PanelSalir aquí

    // Cambiar de escena
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // Mostrar panel salir
    public void MostrarPanelSalir()
    {
        panelSalir.SetActive(true);
    }

    // Ocultar panel salir
    public void OcultarPanelSalir()
    {
        panelSalir.SetActive(false);
    }

    // Salir del juego
    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
        // En el editor no se ve, pero en móvil sí cierra la app
    }
}
