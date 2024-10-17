using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Tank : MonoBehaviourPunCallbacks
{

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

    bool moveForward;
    bool moveReverse;
    float moveSpeed;
    float moveSpeedReverse;
    float moveAcceleration;
    float moveDeceleration;
    float moveSpeedMax;

    bool rotateRight;
    bool rotateLeft;
    float rotateSpeedRight;
    float rotateSpeedLeft;
    float rotateAcceleration;
    float rotateDeceleration;
    float rotateSpeedMax;

    private void Start()
    {
        if (photonView.IsMine)
        {
            moveForward = false;
            moveReverse = false;
            moveSpeed = 0f;
            moveSpeedReverse = 0f;
            moveAcceleration = 0.1f;
            moveDeceleration = 0.20f;
            moveSpeedMax = 2.5f;

            rotateRight = false;
            rotateLeft = false;
            rotateSpeedRight = 0f;
            rotateSpeedLeft = 0f;
            rotateAcceleration = 4f;
            rotateDeceleration = 10f;
            rotateSpeedMax = 130f;
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            rotateLeft = (Input.GetKeyDown(keyRotateLeft)) ? true : rotateLeft;
            rotateLeft = (Input.GetKeyUp(keyRotateLeft)) ? false : rotateLeft;
            if (rotateLeft)
            {
                rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax;
            }
            else
            {
                rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
            }
            transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

            rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
            rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
            if (rotateRight)
            {
                rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax;
            }
            else
            {
                rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
            }
            transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

            moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
            moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
            if (moveForward)
            {
                moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax;
            }
            else
            {
                moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
            }
            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);

            moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
            moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
            if (moveReverse)
            {
                moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax;
            }
            else
            {
                moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
            }
            transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);

        }
    }

}

