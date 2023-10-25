using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    //[SerializeField] GameObject FasterFrate;
    //[SerializeField] GameObject fullHP;
    [SerializeField] List<GameObject> list = new List<GameObject>();
    [SerializeField] float BoostLifeTime = 1f;

    public void PopOut()
    {
        int i = Random.Range(0, 9);
        if(i == 1 || i==0 || i == 2)
        {
            Debug.Log(i);
            GameObject instance = Instantiate(list[i].gameObject, transform.position, Quaternion.identity);
            Destroy(instance, BoostLifeTime);
        }
    }

}
