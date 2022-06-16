using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 컴퓨터 화살표 키
        // 화면 밖으로 나가지 않을 때만 이동
        // 왼쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (transform.position.x > -9) {
                transform.Translate(-3, 0, 0); // 왼쪽으로 3 움직인다.
            }
        }

        // 오른쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (transform.position.x < 9) {
                transform.Translate(3, 0, 0); // 오른쪽으로 3 움직인다.
            }
        }
    }

    // 모바일 환경일 경우 (화살표 키가 존재하지 않음.)
    // 화면 밖으로 나가지 않을 때만 이동
    public void LButtonDown() {
        if (transform.position.x > -9) {
            transform.Translate(-3, 0, 0); // 왼쪽으로 3 움직인다.
        }
    }
        
    public void RButtonDown() {
        if (transform.position.x < 9) {
            transform.Translate(3, 0, 0); // 오른쪽으로 3 움직인다.
        }
    }
}
