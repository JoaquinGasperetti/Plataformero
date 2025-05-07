using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 5, -7);

    void LateUpdate()
    {
        transform.position = jugador.position + offset;
    }
}
