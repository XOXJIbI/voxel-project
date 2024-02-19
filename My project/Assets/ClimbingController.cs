using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    public float raycastDistance = 1.0f; // ����� ����
    public LayerMask obstacleMask; // ���� ��������, ������� �������� �������������
    public float jumpForce;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        bool canJump = false;
        // ���������� ��������� ������� ���� (��������, ������ ����� ���������)
        Vector3 raycastOrigin = transform.position - new Vector3(0f, 0.6f, 0f);
        Vector3 raycastFake = transform.position + new Vector3(0f, 0.3f, 0f);
        // ���������� ����������� ���� (��������, ����������� ������� ��������� ��� ��� ����������� ��������)
        Vector3 raycastDirection = transform.forward; // ������: ����������� ������ �� ���������
        Quaternion rotationQuaternion = Quaternion.Euler(0, 40, 0);
        Vector3 rotatedVector = rotationQuaternion * raycastDirection;
        // ��������� ������� ����������� ����� ����������
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastDistance, obstacleMask) || 
            Physics.Raycast(raycastOrigin, rotatedVector, out hit, raycastDistance, obstacleMask) ||
            Physics.Raycast(raycastOrigin, -rotatedVector, out hit, raycastDistance, obstacleMask))
        {
        
            if (Physics.Raycast(raycastFake, raycastDirection, out hit, raycastDistance, obstacleMask) ||
            Physics.Raycast(raycastFake, rotatedVector, out hit, raycastDistance, obstacleMask) ||
            Physics.Raycast(raycastFake, -rotatedVector, out hit, raycastDistance, obstacleMask))
            {
                canJump = true;
            }

            if (!canJump && (Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.z) > 0.1f) && rb.velocity.y == 0)
            {
                // ���� ������ ����������� ������ ��� ����� ������������ ������, ��������� ������
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