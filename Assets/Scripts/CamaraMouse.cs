using UnityEngine;

public class CamaraMouse : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 3, -6);
    public float sensibilidadMouse = 2f;

    private float rotacionY = 0f;

    void LateUpdate()
    {
        // Leemos el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;

        // Acumulamos la rotaci�n horizontal
        rotacionY += mouseX;

        // Aplicamos rotaci�n al jugador
        jugador.rotation = Quaternion.Euler(0f, rotacionY, 0f);

        // Reposicionamos la c�mara detr�s del jugador
        transform.position = jugador.position + Quaternion.Euler(0f, rotacionY, 0f) * offset;

        // Miramos siempre al jugador
        transform.LookAt(jugador.position + Vector3.up * 1.5f); // apuntamos a la parte superior del cuerpo
    }
}
