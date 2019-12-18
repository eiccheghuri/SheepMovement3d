using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _rigidbody;

    private float movement_force = 0.5f;
    private float jump_force = 0.15f;
    private float jump_time = 0.15f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }//awake

    public void Update()
    {

        GetInput();
        
    }//update

    void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Jump(true);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Jump(false);
        }


    }//get input method

    public void Jump(bool _left)
    {

        if(_left)
        {
            transform.DORotate(new Vector3(0f,-90f,0f),0f);
            _rigidbody.DOJump(new Vector3(transform.position.x+movement_force,transform.position.y+jump_force,transform.position.z),0.5f,1,jump_time);

        }
        else
        {

            transform.DORotate(new Vector3(0f, -180f, 0f), 0f);
            _rigidbody.DOJump(new Vector3(transform.position.x , transform.position.y + jump_force, transform.position.z+movement_force), 0.5f, 1, jump_time);

        }


    }

  



}//class
