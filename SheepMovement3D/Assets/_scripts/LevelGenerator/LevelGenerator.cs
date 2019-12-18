using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LevelGenerator : MonoBehaviour
{


    public GameObject Start_Platform, Last_Platform, Platform_Prefab;
    public GameObject player_prefab;

    public Vector3 last_position;

    public float block_width = 0.5f;
    public float block_heigth = 0.2f;

    public int begin_ammount=0, spawn_ammount=100;

    [SerializeField]
    private List<GameObject> platform_list = new List<GameObject>();


    public void Awake()
    {
        InstantiateLevel();
        
    }

    public void InstantiateLevel()
    {

        for(int i=begin_ammount;i<spawn_ammount;i++)
        {
            GameObject new_platform;

            if(i==0)
            {
                new_platform = Instantiate(Start_Platform);
            }
            else if(i==spawn_ammount-1)
            {
                new_platform = Instantiate(Last_Platform);
            }
            else
            {
                new_platform = Instantiate(Platform_Prefab);
            }


            new_platform.transform.parent = transform;
            platform_list.Add(new_platform);

            if(i==0)
            {
                last_position = new_platform.transform.position;
                Vector3 _temp = last_position;
                _temp.y += 0.1f;
                Instantiate(player_prefab,_temp,Quaternion.identity);

                continue;
            }

            int left = Random.Range(0, 2);

            if(left==0)
            {
                new_platform.transform.position =
                    new Vector3(last_position.x+block_width,last_position.y+block_heigth,last_position.z);
            }
            else
            {
                new_platform.transform.position =
                    new Vector3(last_position.x, last_position.y + block_heigth, last_position.z+block_width);
            }


            last_position = new_platform.transform.position;

            if(i<25)
            {
                float end_pos = new_platform.transform.position.y;
                new_platform.transform.position = new Vector3(new_platform.transform.position.x, new_platform.transform.position.y - block_heigth * 3f, new_platform.transform.position.z);

                new_platform.transform.DOLocalMoveY(end_pos,0.3f).SetDelay(i*0.1f);

            }
                


           
        }//for loop
        


    }//instantiateLevel



}//class
