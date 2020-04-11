using System;
using System.Collections;
using System.Collections.Generic;
using CnControls;
using Photon.Pun;
using UnityEngine;

public class PlayerMoving : MonoBehaviourPunCallbacks
{
    
    private float fishSpeed = 10;

    private Direction direction = Direction.Right;

    private enum Direction
    {
        Right,
        Left,
    }

    private int rotate = 0;

    void Start()
    {
      
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        

        var axisX = CnInputManager.GetAxis("Horizontal");

        var position = new Vector3(axisX, CnInputManager.GetAxis("Vertical"), 0f);
        transform.position += position * Time.deltaTime * fishSpeed;

        CheckReversePlayer(axisX);

    }

    private void CheckReversePlayer(float axisX)
    {

        if (axisX > 0 && direction == Direction.Left)
        {
            direction = Direction.Right;
            ReversePlayer();

        }
        else if (axisX < 0 && direction == Direction.Right)
        {
            direction = Direction.Left;
            ReversePlayer();
        }
    }

    private void ReversePlayer()
    {
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
