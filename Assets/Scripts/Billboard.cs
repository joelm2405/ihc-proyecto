using UnityEngine;

public class Billboard : MonoBehaviour
{
    [Tooltip("Si lo dejas vacío, usa Camera.main. Puedes arrastrar aquí tu ARCamera si quieres forzar esa.")]
    public Camera targetCamera;

    [Tooltip("Full: mira totalmente a la cámara. YAxis: solo rota en Y (como un póster).")]
    public Mode mode = Mode.YAxis;

    public enum Mode { Full, YAxis }

    void Awake()
    {
        // Si no asignaste una cámara en el prefab, intentará usar Camera.main en runtime.
        if (targetCamera == null) targetCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (!targetCamera) return;

        switch (mode)
        {
            case Mode.Full:
                // Cara del panel hacia la cámara
                transform.forward = targetCamera.transform.forward;
                break;

            case Mode.YAxis:
                // Solo giro en Y (útil para que no se incline hacia arriba/abajo)
                Vector3 camPos = targetCamera.transform.position;
                Vector3 lookPos = new Vector3(camPos.x, transform.position.y, camPos.z);
                transform.LookAt(lookPos);
                break;
        }
    }
}
