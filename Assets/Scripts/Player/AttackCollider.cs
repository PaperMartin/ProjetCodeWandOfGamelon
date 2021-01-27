﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemiesList.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            enemiesList.Remove(collision.gameObject);
        }
    }
    
}