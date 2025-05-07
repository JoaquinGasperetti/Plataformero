using UnityEngine;

public class CamaraMouse : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 3, -6);
    public float sensibilidadMouse = 2f;

    private float rotacionY = 0f;

    void LateUpdate()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;

        
        rotacionY += mouseX;

        
        jugador.rotation = Quaternion.Euler(0f, rotacionY, 0f);

        
        transform.position = jugador.position + Quaternion.Euler(0f, rotacionY, 0f) * offset;

        
        transform.LookAt(jugador.position + Vector3.up * 1.5f); 
    }
}
