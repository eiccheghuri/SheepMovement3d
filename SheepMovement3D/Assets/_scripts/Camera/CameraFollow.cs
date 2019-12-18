using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform _player;
    private float _damping = 2f;

    private float _hight = 10f;
    private Vector3 start_position;
    private bool can_follow;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        start_position = transform.position;
        can_follow = true;

    }


    public void Update()
    {
        Follow();
    }

    public void Follow()
    {
        if(can_follow)
        {
            transform.position = 
                Vector3.Lerp(transform.position,new Vector3(_player.position.x+10f,_player.position.y+_hight,_player.position.z-10f),Time.deltaTime*_damping);
        }
    }


    public bool CanFollow
    {
        get
        {
            return can_follow;
        }
        set
        {
            can_follow = value;
        }
    }




}//class camerafollow
