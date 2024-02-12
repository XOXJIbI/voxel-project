using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    public float maxObstacleHeight = 1.0f; // ћаксимальна€ высота преп€тстви€, которое персонаж может перепрыгнуть
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
        Vector3 raycastOrigin = transform.position - new Vector3(0f, 0.6f, 0f); // Ќапример, смещаем луч вниз от центра персонажа на половину высоты
    
        // ќпределите направление луча (например, направление взгл€да персонажа или его направление движени€)
        Vector3 raycastDirection = transform.forward; // ѕример: направление вперед от персонажа

        // ѕровер€ем наличие преп€тстви€ перед персонажем
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastDistance, obstacleMask))
        {
            // ≈сли луч столкнулс€ с преп€тствием, провер€ем его высоту
            float obstacleHeight = hit.point.y - transform.position.y; // ¬ысота преп€тстви€ относительно текущей позиции персонажа
            if (rb.velocity != Vector3.zero)
            {
                if (obstacleHeight <= maxObstacleHeight)
                {
                    // ≈сли высота преп€тстви€ меньше или равна максимальной высоте, выполн€ем прыжок
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