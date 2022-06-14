using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
	    bulletRigidbody = GetComponent<Rigidbody>();
	    // 중력의 속도 = 앞 방향 * 이속
	    bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other) {
       
        // 충돌한 상대 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                // 핫상대 PlayerController 컴포넌트의 Die() 함수 실행 (playerController 컴포넌트가 없을 때를 대비)
                playerController.Die();
            }
        }
        else if(other.tag == "Wall") {
            Destroy(gameObject, 0f);
        }
    }

}
