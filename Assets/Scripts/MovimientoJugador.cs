using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public float gravedad = -9.81f;

    private CharacterController controller;
    private Vector3 velocidadVertical;
    private bool estaEnElSuelo;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movimiento horizontal
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;
        controller.Move(movimiento * velocidad * Time.deltaTime);

        // Verificar si está en el suelo
        estaEnElSuelo = controller.isGrounded;
        if (estaEnElSuelo && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }

        // Salto
        if (Input.GetButtonDown("Jump") && estaEnElSuelo)
        {
            velocidadVertical.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
        }

        // Aplicar gravedad
        velocidadVertical.y += gravedad * Time.deltaTime;
        controller.Move(velocidadVertical * Time.deltaTime);
    }
}
