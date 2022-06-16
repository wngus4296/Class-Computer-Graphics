using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0; // 회전 속도
    void Start()
    {
        
    }

    void Update()
    {
        // 좌클릭하는 동안의 회전 속도를 설정한다.
         if (Input.GetMouseButton(0)) {
             this.rotSpeed = 15;
         }   

         // 회전 속도만큼 룰렛을 회전시킨다.
         transform.Rotate(0, 0, this.rotSpeed);

         // 룰렛을 감속시킨다. (클릭하지 않는다면)
         this.rotSpeed *= 0.97f;

        // 우클릭시 회전 속도를 0으로 설정한다. -> 멈춘다.
         if (Input.GetMouseButtonDown(1)) {
             this.rotSpeed = 0;
         }
    }
}
