using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public Camera camera;
    private Vector2 prevTouch1;
    private Vector2 prevTouch2;
    public float zoomSpeed=0.5f;
    private float orthographicSize;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        orthographicSize=camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            // �������� ���������� � ��������
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // ���� ��� ������ �������
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                prevTouch1 = touch1.position;
                prevTouch2 = touch2.position;
            }
            // ���� ��� ����������� �������
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                Vector2 currentTouch1 = touch1.position;
                Vector2 currentTouch2 = touch2.position;

                float prevMagnitude = (prevTouch1 - prevTouch2).magnitude;
                float currentMagnitude = (currentTouch1 - currentTouch2).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                // ������ ������ ��������������� ������ � ����������� �� ������� � ���������� ����� ��������
                camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - ( difference * zoomSpeed*Time.deltaTime), 1f, Mathf.Infinity);

                prevTouch1 = currentTouch1;
                prevTouch2 = currentTouch2;
            }
        }

    }
}
