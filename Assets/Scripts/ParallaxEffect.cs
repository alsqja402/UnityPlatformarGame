using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    
    // 카메라
    public Camera cam;

    // 플레이어 위치
    public Transform followTarget;

    // 현재ㅔ 나의 시작 위치
    Vector2 startingPosition;

    // 현재 게임 오브젝의 위치의 Z 값
    float startingZ = 0;

    // 게임이 시작되고나서 카메라가 움직이는 방향
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    
    // 현재 Z 축 위치에서 follow 타켓의 Z 축 값을 뺀다.
    float ZDistanceFormTarget => transform.position.z - followTarget.position.z;

    //카메라와의 거리값을 기준으로 Plane 값을 가져온다.
    float clippingPlane => (cam.transform.position.z + ZDistanceFormTarget) > 0 ? cam.farClipPlane : cam.nearClipPlane;

    // Z 간의 거리를 기반으로 Factor를 구현한다.
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
