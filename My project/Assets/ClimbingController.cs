using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    public float maxObstacleHeight = 1.0f; // ������������ ������ �����������, ������� �������� ����� ������������
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
        Vector3 raycastOrigin = transform.position - new Vector3(0f, 0.6f, 0f); // ��������, ������� ��� ���� �� ������ ��������� �� �������� ������
    
        // ���������� ����������� ���� (��������, ����������� ������� ��������� ��� ��� ����������� ��������)
        Vector3 raycastDirection = transform.forward; // ������: ����������� ������ �� ���������

        // ��������� ������� ����������� ����� ����������
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastDistance, obstacleMask))
        {
            // ���� ��� ���������� � ������������, ��������� ��� ������
            float obstacleHeight = hit.point.y - transform.position.y; // ������ ����������� ������������ ������� ������� ���������
            if (rb.velocity != Vector3.zero)
            {
                if (obstacleHeight <= maxObstacleHeight)
                {
                    // ���� ������ ����������� ������ ��� ����� ������������ ������, ��������� ������
                    Jump();
                }
            }
        }
    }
    
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}