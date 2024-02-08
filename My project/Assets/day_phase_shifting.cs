using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day_phase_shifting : MonoBehaviour
{
    public float shiftSpeed = 0.5f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        target.Rotate(shiftSpeed*Time.deltaTime, 0, 0);
    }
}
