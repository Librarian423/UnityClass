using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviourPun
{
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도

    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    public Camera mainCamera;

    private void Start()
    {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        Rotate();
        Move();
        var dir = new Vector3(playerInput.moveH, 0f, playerInput.moveV);
        //dir.Normalize();

        playerAnimator.SetFloat("Move", dir.magnitude);
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
        var forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        var right = Camera.main.transform.right;
        right.y = 0f;
        right.Normalize();

        var dir = forward * playerInput.moveV;
        dir += right * playerInput.moveH;

        if (dir.magnitude > 1f) 
        {
            dir.Normalize();
        }

        var delta = dir * moveSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(playerRigidbody.position + delta);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(playerInput.mousePos);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,
            LayerMask.GetMask("Ground"))) 
        {
            var forward = hit.point - transform.position;
            forward.y = 0f;
            forward.Normalize();

            transform.rotation = Quaternion.LookRotation(forward);

        }
    }
}