using UnityEngine;
using UnityEngine.UI;  // Necesario para usar Slider
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class Button3D : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickClip;
    public float volume = 1f;

    [Header("Efecto visual")]
    public Vector3 pressedScale = new Vector3(0.95f, 0.95f, 0.95f);
    private Vector3 originalScale;

    [Header("Acciones extra")]
    public UnityEvent onClick;

    private bool isPlaying = false;  // Variable para controlar el estado del audio

    [Header("Barra de Progreso")]
    public Slider progressBar; // Referencia al Slider (barra de progreso)

    void Awake()
    {
        if (!audioSource) audioSource = GetComponent<AudioSource>();
        originalScale = transform.localScale;

        if (progressBar)
        {
            progressBar.value = 0;  // Inicializar la barra en 0
            progressBar.onValueChanged.AddListener(OnSliderValueChanged);  // Detectar el cambio en el slider
        }
    }

    void Update()
    {
        // Si el audio está reproduciéndose, actualiza la barra de progreso
        if (audioSource.isPlaying && progressBar != null)
        {
            progressBar.value = audioSource.time / audioSource.clip.length; // Progreso del audio
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = pressedScale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Si el audio está sonando, pausarlo; si está pausado, reanudarlo.
        if (isPlaying)
        {
            audioSource.Pause();  // Pausar el audio
        }
        else
        {
            if (!audioSource.isPlaying)  // Si no está sonando, empezar desde el principio
            {
                audioSource.clip = clickClip;  // Asignar el clip de audio si no está asignado
                audioSource.Play();  // Reproducir desde el principio
            }
            else  // Si está pausado, reanudar desde donde se quedó
            {
                audioSource.UnPause();  // Reanudar el audio
            }
        }

        // Cambiar el estado de reproducción (pausado/reproduciendo)
        isPlaying = !isPlaying;

        // Ejecutar cualquier acción adicional configurada en el Inspector (si la hay)
        onClick?.Invoke();
    }

    // Esta función se llama cuando el Slider cambia
    private void OnSliderValueChanged(float value)
    {
        if (audioSource != null)
        {
            // Actualiza el tiempo del audio según el valor del Slider
            audioSource.time = value * audioSource.clip.length;  // Multiplicamos por la longitud del audio para ajustar
        }
    }
}
