using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene을 사용하는 데 필요하다.

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 점프한다.
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0) { // y축 방향의 속도가 0일 경우 (점프 x, 정지 중)
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if (speedx < this.maxWalkSpeed) {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 움직이는 방향에 따라 반전한다.
        if (key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        this.animator.speed = speedx / 2.0f;

        if (transform.position.y < -10) {
            SceneManager.LoadScene("GameScene");
        }
    }

    // 골 도착
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finish") {
            SceneManager.LoadScene("GameScene");
        } else {
            Debug.Log("골");
            SceneManager.LoadScene("ClearScene");
        }
    }
}
