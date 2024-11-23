using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    
    // ī�޶�
    public Camera cam;

    // �÷��̾� ��ġ
    public Transform followTarget;

    // ����� ���� ���� ��ġ
    Vector2 startingPosition;

    // ���� ���� �������� ��ġ�� Z ��
    float startingZ = 0;

    // ������ ���۵ǰ��� ī�޶� �����̴� ����
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    
    // ���� Z �� ��ġ���� follow Ÿ���� Z �� ���� ����.
    float ZDistanceFormTarget => transform.position.z - followTarget.position.z;

    //ī�޶���� �Ÿ����� �������� Plane ���� �����´�.
    float clippingPlane => (cam.transform.position.z + ZDistanceFormTarget) > 0 ? cam.farClipPlane : cam.nearClipPlane;

    // Z ���� �Ÿ��� ������� Factor�� �����Ѵ�.
    private float parallaxFactor => Mathf.Abs(ZDistanceFormTarget) / clippingPlane;

    //[SerializeField] private float parallaxFactor = -1;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart / parallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
