using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroMotor))]
public class HeroController : MonoBehaviour
{

    public Camera cam;

    public LayerMask movementMask;

    public float maxMovementDistance = 100f;
    private HeroMotor motor;



    public Interactable focus;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<HeroMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //movements
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxMovementDistance, movementMask))
            {
                //Movement
                if (!hit.collider && hit.collider.gameObject.layer == 7) ;
                {
                    motor.MoveToPoint(hit.point);
                    //remove focus from interactable object
                    RemoveFocus();
                }
                //Interaction
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }


        }
        //interactions
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    
    void SetFocus(Interactable newfocus)
    {
        focus = newfocus;
    }
    void RemoveFocus()
    {
        focus = null;
    }
}