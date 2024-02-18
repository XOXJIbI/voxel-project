using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody obj;
    public FloatingJoystick joystick;
    public float speed;
    public float dead_Zone;
    private Vector3 velocity = Vector3.zero;
    public float d;
    // Start is called before the first frame update
    void Start()
    {
        joystick.DeadZone = dead_Zone;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPosition = obj.position;
        Vector3 velosityMap= new Vector3((joystick.Horizontal) * speed, 0, (joystick.Vertical) * speed);
        Quaternion rotationQuaternion =  Quaternion.Euler(0, 45, 0);
        Vector3 rotatedVector = rotationQuaternion * velosityMap;
        obj.velocity = rotatedVector;
        Vector3 originXAxis=new Vector3(1,0,1);
        transform.LookAt(transform.position+rotatedVector);
    }
}
