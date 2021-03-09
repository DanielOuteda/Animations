using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

// Use a separate PlayerInput component for setting up input.
public class ControlPlayer : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("onMove!");
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                // interaccion realizada
                // ¿Estoy manteniendo la tecla?
                if (context.interaction is SlowTapInteraction)
                {
                    // me pongo a correr cuando la tecla está mantenida
                    Debug.Log("Tecla mantenida");
                    Corro();
                }
                else
                {
                    Debug.Log("Tecla presionada y soltada");
                    // Paro de correr
                    anim.SetBool("corro", false);              
                }
                break;

            case InputActionPhase.Started:
                // tecla presionada
                Debug.Log("Phase Iniciada");
                Corro();
                break;

            case InputActionPhase.Canceled:
                Debug.Log("Phase Cancelelada");
                // Paro de correr
                anim.SetBool("corro", false);
                break;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("onLook!");
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                // interaccion realizada
                // ¿Estoy manteniendo la tecla?
                if (context.interaction is SlowTapInteraction)
                {
                    // no pongo a false el parametro
                    // el jugador queda saltando
                    Debug.Log("Tecla mantenida");
                }
                else
                {
                    Debug.Log("Salto realizado");
                    // pongo a false el parametro
                    // si no lo hago sigue saltando
                    anim.SetBool("salto", false);               
                }
                break;

            case InputActionPhase.Started:
                // tecla presionada
                Debug.Log("Phase Iniciada");
                Salto();
                break;

            case InputActionPhase.Canceled:
                Debug.Log("Phase Cancelelada");
                break;
        }
    }

    private void Salto()
    {
        Debug.Log("Saltando....");
        // activo el parametro de la transicion en el Animator
        anim.SetBool("salto", true);
    }
    private void Corro()
    {
        Debug.Log("Corriendo....");
        // activo el parametro de la transicion en el Animator
        anim.SetBool("corro", true);
    }
}