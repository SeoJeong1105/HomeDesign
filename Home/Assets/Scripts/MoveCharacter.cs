using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public Camera playerCamera;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent nav;


    private void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;

                anim.SetBool("walk", true);
                nav.SetDestination(hit.point);

                if(selection.CompareTag("Sit"))
                {
                    nav.SetDestination(selection.GetChild(0).transform.position);
                }
            }                
        }
        if(Vector3.Distance(nav.destination, transform.position) <= nav.stoppingDistance)
        {
            anim.SetBool("walk", false);
        }
    }
}
