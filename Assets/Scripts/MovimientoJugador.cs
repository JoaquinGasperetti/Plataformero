using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public float gravedad = -20f;
    public Transform chequeoSuelo;
    public float radioChequeo = 0.3f;
    public LayerMask capaSuelo;

    private CharacterController controller;
    private Vector3 velocidadY;
    private bool estaEnElSuelo;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        estaEnElSuelo = Physics.CheckSphere(chequeoSuelo.position, radioChequeo, capaSuelo);

        if (estaEnElSuelo && velocidadY.y < 0)
        {
            velocidadY.y = -2f;
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movimiento = transform.right * x + transform.forward * z;
        controller.Move(movimiento * velocidad * Time.deltaTime);

        
        if (Input.GetButtonDown("Jump") && estaEnElSuelo)
        {
            velocidadY.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
        }

        
        velocidadY.y += gravedad * Time.deltaTime;
        controller.Move(velocidadY * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject.layer == LayerMask.NameToLayer("Lava"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
