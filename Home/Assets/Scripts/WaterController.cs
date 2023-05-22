using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var water = this.GetComponent<ParticleSystem>();
        water.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
