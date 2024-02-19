using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    public float raycastDistance = 1.0f; // ƒлина луча
    public LayerMask obstacleMask; // —лои объектов, которые €вл€ютс€ преп€тстви€ми
    public float jumpForce;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // ќпределите начальную позицию луча (например, нижний конец персонажа)
        Vector3 raycastOrigin = transform.position - new Vector3(0f, 0.6f, 0f);
        Vector3 raycastFake = transform.position;
        // ќпределите направление луча (например, направление взгл€да персонажа или его направление движени€)
        Vector3 raycastDirection = transform.forward; // ѕример: направление вперед от персонажа
        Quaternion rotationQuaternion = Quaternion.Euler(0, 40, 0);
        Vector3 rotatedVector = rotationQuaternion * raycastDirection;
        // ѕровер€ем наличие преп€тстви€ перед персонажем
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastDistance, obstacleMask)|| 
            Physics.Raycast(raycastOrigin, rotatedVector, out hit, raycastDistance, obstacleMask)||
            Physics.Raycast(raycastOrigin, -rotatedVector, out hit, raycastDistance, obstacleMask))
        {
            if (rb.velocity.x != 0 && rb.velocity.z != 0 && rb.velocity.y == 0)
            {
                // ≈сли высота преп€тстви€ меньше или равна максимальной высоте, выполн€ем прыжок
                Jump();
            }
        }
    }

    void Jump()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        transform.Translate(0, jumpForce, 0);
    }
}