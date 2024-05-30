using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cuser;
    public GameObject stonePrefab;

    public int currentClear = 0;

    void Start()
    {

    }

    void Update()
    {
        if(!GameManager.Instance().isMyTurn || GameManager.Instance().isGameOver)
        {
            cuser.SetActive(false);
            return;
        }

        cuser.SetActive(true);
        MovePosition();
    }

    public void MovePosition()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(transform.position.x < 8)
            {
                transform.position += new Vector3(0.5f, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(transform.position.x > 0)
            {
                transform.position += new Vector3(-0.5f, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(transform.position.y  < 0)
            {
                transform.position += new Vector3(0, 0.5f, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(transform.position.y > -8)
            {
                transform.position += new Vector3(0, -0.5f, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(GameManager.Instance().isMyTurn)
            {
                GameObject _stone = Instantiate(stonePrefab, transform.position, Quaternion.identity);
                _stone.transform.parent = GameObject.Find("Checkerboard").transform;
            }
        }
    }
}