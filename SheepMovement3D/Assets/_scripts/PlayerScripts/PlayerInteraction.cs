using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool player_died;


    public CameraFollow camera_follow;

    public void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();
        camera_follow = Camera.main.GetComponent<CameraFollow>();
    }//awake


    public void Update()
    {
        if(!player_died)
        {
            if(_rigidbody.velocity.sqrMagnitude>60)
            {

                player_died = true;
                camera_follow.CanFollow = false;
                GameplayController.Instance.RestartGame();


            }
        }
    }//update


    public void OnTriggerEnter(Collider _target)
    {
        

        if(_target.gameObject.CompareTag("coin"))
        {
            _target.gameObject.SetActive(false);
            GameplayController.Instance.IncrementScore();

        }

        if(_target.gameObject.CompareTag("Spike"))
        {

            camera_follow.CanFollow = false;
            gameObject.SetActive(false);
            GameplayController.Instance.RestartGame();


        }


    }//ontrigger Enter


    public void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.CompareTag("EndPlatform"))
        {
            GameplayController.Instance.RestartGame();
        }

    }// Collision Enter




}//class
