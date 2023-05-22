using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform _selection;
    [SerializeField] GameObject character;
    private Animator charAnim;

    void Start()
    {
        charAnim = character.GetComponent<Animator>();
    }
 
    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            _selection = null;
            selectionRenderer.material.color = Color.white;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if(selection.gameObject.layer == 6)
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                var anim = selection.GetComponent<Animator>();
                selectionRenderer.material.color = Color.yellow;
                
                if(selection.CompareTag("Door") && selectionRenderer != null)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        if(anim.GetBool("Open"))
                        {
                            charAnim.SetTrigger("close");
                            anim.SetBool("Open", false);
                            anim.Play("DoorClose", 0, 0.0f);
                        }
                        else
                        {
                            charAnim.SetTrigger("open");
                            anim.SetBool("Open", true);
                            anim.Play("DoorOpen", 0, 0.0f);
                        }
                    }
                }
                else if(selection.CompareTag("Sit") && selectionRenderer != null)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        if(!charAnim.GetBool("sit"))
                        {
                            charAnim.SetBool("sit", true);
                        }
                        else
                        {
                            charAnim.SetBool("sit", false);
                        }
                    }
                }
                else if(selection.CompareTag("Bed") && selectionRenderer != null)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        if(!charAnim.GetBool("lay"))
                        {
                            charAnim.SetBool("lay", true);
                        }
                        else
                        {
                            charAnim.SetBool("lay", false);
                        }
                    }
                }
                else if(selection.CompareTag("Lamp") && selectionRenderer != null)
                {
                    var light = selection.GetChild(0).GetComponent<Light>();
                    if(Input.GetMouseButtonDown(0))
                    {
                        light.enabled = !light.enabled;
                    }
                }
                else if(selection.CompareTag("Fireplace") && selectionRenderer != null)
                {
                    var fire = selection.GetChild(0).GetComponent<ParticleSystem>();
                    if(Input.GetMouseButtonDown(0))
                    {
                        if(fire.isPlaying)
                        {
                            fire.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                        }
                        else
                        {
                            fire.Play();
                        }
                    }
                }
                else if(selection.CompareTag("Water") && selectionRenderer != null)
                {
                    var water = selection.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
                    if(Input.GetMouseButtonDown(0))
                    {
                        if(water.isPlaying)
                        {
                            water.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                        }
                        else{
                            water.Play();
                        }
                    }
                }
                _selection = selection;
            }
        }
    }

    public Transform getSelection()
    {
        return _selection;
    }
}
