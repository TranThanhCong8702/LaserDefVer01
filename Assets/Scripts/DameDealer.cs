using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DameDealer : MonoBehaviour
{
    [SerializeField] float dame = 10f;
    [SerializeField] bool Isbullet;
    [SerializeField] bool IsPlayerBullet;
    float Timer = 0;
    public float GetDmae()
    {
        return dame;
    }
    public void Hit()
    {
        if (IsPlayerBullet)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }


    void Update()
    {
        if (Isbullet && Vector2.Distance(transform.position, Camera.main.transform.position) > 15f)
        {
            if (IsPlayerBullet)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
