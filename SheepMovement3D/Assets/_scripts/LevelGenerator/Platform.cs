using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{

    [SerializeField]
    private Transform[] _spikes;

    [SerializeField]
    private GameObject _coin;

    private bool fall_down;

    public void Start()
    {
        ActivatePlatform();
    }//start function

    public void ActivateSpike()
    {

        int _index = Random.Range(0,_spikes.Length);

        _spikes[_index].gameObject.SetActive(true);

        _spikes[_index].DOLocalMoveY(0.7f, 1.3f).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(3f,5f));


    }//activating spikes

    public void AddCoin()
    {

        GameObject c = Instantiate(_coin);
        c.transform.position = transform.position;
        c.transform.SetParent(transform);
        c.transform.DOLocalMoveY(1f,0f);//moving coin upward


    }//add coin

    public void ActivatePlatform()
    {
        int chance = Random.Range(0,100);
        if(chance>70)
        {

            int _type = Random.Range(0, 8);
            if(_type==0)
            {
                ActivateSpike();
            }
            else if(_type==1)
            {
                AddCoin();
            }
            else if (_type == 2)
            {
                fall_down = true;
            }
            else if (_type == 3)
            {

            }
            else if (_type == 4)
            {
                AddCoin();
            }
            else if (_type == 5)
            {

            }
            else if (_type == 6)
            {

            }
            else if (_type == 7)
            {
                AddCoin();
            }

        }


    }//activating platform

    public void InvokeFalling()
    {

        gameObject.AddComponent<Rigidbody>();

    }


    public void OnCollisionEnter(Collision _target)
    {
        
        if(_target.gameObject.CompareTag("Player"))
        {
            if(fall_down)
            {
                fall_down = false;
                Invoke("InvokeFalling", 2f);
            }
        }
        
    }








}// class
