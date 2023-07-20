using UnityEngine;
using System.Collections;
public class Interactable : MonoBehaviour
{

    public float radius = 2f;
    public Transform interactionTransform;
    bool isFocus = false;
    bool hasInteracted = false;
    Transform hero;

    private void Start() {
        if (interactionTransform==null)
        interactionTransform = transform;
    }
    public virtual void Interact()
    {
        //This method is ment to be overwritten
         Debug.Log ("Interacting with:" + transform.name);  
    }

    private void Update() {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(interactionTransform.position, hero.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true; 
           }
        }
    }
    public void OnFocused(Transform heroTransform)
    {
        isFocus = true;
        hero = heroTransform;
        hasInteracted = false;
    }

    public void  OnDefocused()
    {
        isFocus = false;
        hero = null;
        hasInteracted = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);
    }
}
