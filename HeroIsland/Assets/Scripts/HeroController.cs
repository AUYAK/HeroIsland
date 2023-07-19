using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroMotor))]
public class HeroController : MonoBehaviour
{

    public Camera cam;

    public LayerMask movementMask;

    public float maxMovementDistance = 100f;
    public Interactable focus;
    private HeroMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<HeroMotor>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, maxMovementDistance, movementMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //Movement
                if (hit.collider!=null && hit.collider.gameObject.layer == 7 && interactable == null)
                {
                    //remove focus from interactable object
                    RemoveFocus();

                    Debug.Log("movement");
                    motor.MoveToPoint(hit.point);
                 }
                //Interaction
                
                else if (interactable != null){
                    Debug.Log("interaction");
                    SetFocus(interactable);
                }

            }


        }
    }

    void SetFocus(Interactable newfocus)
    {
        focus = newfocus;
        // motor.FollowTarget(newfocus);
    }
    void RemoveFocus()
    {
        focus = null;
        // motor.StopFollowingTarget();
    }
}