using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] float MaxHP2 = 10f;
    public void Hit()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public float ShootFaster(float hp)
    {
        if (hp < 0.12)
        {
            return 0;
        }
        return 0.01f;
    }
    public float FullHP(float hp)
    {
        if (hp >= 50)
        {
            return 0;
        }
        return MaxHP2;
    }

}
