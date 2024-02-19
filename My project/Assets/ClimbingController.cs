using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        // ���������� ��������� ������� ���� (��������, ������ ����� ���������)
        Vector3 raycastOrigin1 = transform.position - new Vector3(0.15f, 0.6f, 0f); // ��������, ������� ��� ���� �� ������ ��������� �� �������� ������
        Vector3 raycastOrigin2 = transform.position - new Vector3(-0.15f, 0.6f, 0f);
        Vector3 raycastOrigin = transform.position - new Vector3(0f, 0.6f, 0f);
        Vector3 raycastFake = transform.position;
        // ���������� ����������� ���� (��������, ����������� ������� ��������� ��� ��� ����������� ��������)
        Vector3 raycastDirection = transform.forward; // ������: ����������� ������ �� ���������

        // ��������� ������� ����������� ����� ����������
        RaycastHit hit;
        if ((Physics.Raycast(raycastOrigin1, raycastDirection, out hit, raycastDistance, obstacleMask) ||
            Physics.Raycast(raycastOrigin2, raycastDirection, out hit, raycastDistance, obstacleMask) ||
            Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastDistance, obstacleMask)) &&
            !Physics.Raycast(raycastFake, raycastDirection, out hit, raycastDistance, obstacleMask))
        {
            if (rb.velocity.x != 0 && rb.velocity.z != 0 && rb.velocity.y == 0)
            {
                // ���� ������ ����������� ������ ��� ����� ������������ ������, ��������� ������
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}