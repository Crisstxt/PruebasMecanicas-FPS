using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    #region Variables

    //ST
    public static ControladorJuego instance;

    [Header("MovimientoJuegador")]

    [SerializeField] private Camera camara_Jugador;
    [SerializeField] private GameObject jugador;
    [SerializeField] private float velocidad_Jugador = 5f;
    [SerializeField] private float velocidad_Correr = 2f;

    [SerializeField] private float sensibilidad_Horizontal = 3;
    [SerializeField] private float sensibilidad_Vertical = 3;

    [Header("Mundo")]

    [SerializeField] private float gravedad = -9.81f;

    #endregion

    void Awake()
    {
        instance = this;   
    }

    #region Getter y Setters
    
    public Camera CamaraJugador { get { return camara_Jugador; } }

    public GameObject Jugador{ get { return jugador; } }

    public float VelocidadJugador { get { return velocidad_Jugador; } }
    
    public float VelocidadCorrer { get { return velocidad_Correr; } }

    public float Gravedad { get { return gravedad; } }

    public float Sensibilidad_Vertical { get {  return sensibilidad_Vertical; } }

    public float Sensibilidad_Horizontal { get {  return sensibilidad_Horizontal; } }
    


    #endregion
}
