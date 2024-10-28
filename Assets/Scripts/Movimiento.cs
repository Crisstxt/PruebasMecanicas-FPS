using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public static Movimiento instance;

    private CharacterController characterController;
    private Camera camara_Jugador;
    private Vector3 velocidad_Jugador;

    private float yaw, pitch;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        Recibir_Info();
    }

    private void Update()
    {
        MovimientoJugador();
        CamaraJugador();
    }

    private void Recibir_Info()
    {
        camara_Jugador = ControladorJuego.instance.CamaraJugador;
        characterController = GetComponent<CharacterController>();
    }

    private void MovimientoJugador()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movimientoX + transform.forward * movimientoZ;

        if(characterController.isGrounded && velocidad_Jugador.y < 0)  velocidad_Jugador.y = 0;
        velocidad_Jugador.y += ControladorJuego.instance.Gravedad * Time.deltaTime;
        characterController.Move(velocidad_Jugador * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && movimientoZ > 0)
        {
            movimiento *= ControladorJuego.instance.VelocidadCorrer;
        }

        characterController.Move(movimiento * ControladorJuego.instance.VelocidadJugador * Time.deltaTime);
    }

    private void CamaraJugador()
    {
        yaw += ControladorJuego.instance.Sensibilidad_Horizontal * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3 (0, yaw, 0);  

        if(camara_Jugador.transform != null)
        {
            pitch -= ControladorJuego.instance.Sensibilidad_Vertical * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 90f);
            camara_Jugador.transform.localEulerAngles = new Vector3 (pitch, 0, 0);
        }

    }
}
