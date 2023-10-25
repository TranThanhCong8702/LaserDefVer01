using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject ProjectTile;
    [SerializeField] GameObject ProjectTile1;
    [SerializeField] GameObject ProjectTile2;

    [SerializeField] float ProjtSpeed = 10f;
    [SerializeField] float ProjectLifeTime = 5f;
    [SerializeField] float FiringRate = 0.2f;
    [SerializeField] float FiringRateVar = 0f;
    [SerializeField] float FiringRateMin = 0f;
    [SerializeField] bool useAI;
    [SerializeField] List<GameObject> projtilePool;
    [SerializeField] float PoolAmount = 10f;
    public bool IsFiring;
    Coroutine firing;
    AudioPlayer player;
    float bullNumbCount = 0;
    private void Awake()
    {
        player = FindObjectOfType<AudioPlayer>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boostFireRate")
        {
            Debug.Log("BFR");
            Boost b = collision.GetComponent<Boost>();
            if (b == null) { Debug.Log("FR Failed"); return; }
            FiringRate -= b.ShootFaster(FiringRate);
            if(FiringRate < 0.12)
            {
                FiringRate = 0.12f;
            }
            b.Hit();
        }
        if( collision.tag == "boostBulletNumb")
        {
            Debug.Log("BBN");
            Boost b = collision.GetComponent<Boost>();
            if (b == null) { Debug.Log("BulletNumb Failed"); return; }
            if (bullNumbCount == 0)
            {
                for(int i = 0;i< projtilePool.Count; i++)
                {
                    Destroy(projtilePool[i], ProjectLifeTime);
                }
                projtilePool.Clear();
                CreatePool(ProjectTile1);
                bullNumbCount++;
            }
            else if(bullNumbCount == 1)
            {
                for (int i = 0; i < projtilePool.Count; i++)
                {
                    Destroy(projtilePool[i], ProjectLifeTime);
                }
                projtilePool.Clear();
                CreatePool(ProjectTile2);
                bullNumbCount++;
            }
            b.Hit();
        }
    }

    void CreatePool(GameObject ProjectTile)
    {
        projtilePool = new List<GameObject>();
        GameObject instance;
        for(int i=0; i < PoolAmount; i++)
        {
            instance = Instantiate(ProjectTile);
            instance.gameObject.SetActive(false);
            projtilePool.Add(instance);
        }
    }
    GameObject GetPooledObject()
    {
        for (int i = 0; i < PoolAmount; i++)
        {
            if (!projtilePool[i].activeInHierarchy)
            {
                return projtilePool[i];
            }
        }
        return null;
    }

    void Start()
    {
        if (useAI)
        {
            IsFiring = true;

        }
        else if (!useAI)
        {
            CreatePool(ProjectTile);
        }
    }
    private void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Fire();
    }

    private void Fire()
    {
        if (IsFiring && firing == null)
        {
            firing = StartCoroutine(FireContinue());
        }
        else if(!IsFiring && firing != null)
        {
            StopCoroutine(firing);
            firing = null;
        }
    }

    IEnumerator FireContinue()
    {
        while(true)
        {
            GameObject instance = null;
            if (!useAI)
            {
                instance = GetPooledObject();
                instance.transform.position = transform.position;
                instance.transform.rotation = transform.rotation;
                instance.SetActive(true);
            }
            else if (useAI)
            {
                instance = Instantiate(ProjectTile, transform.position, Quaternion.identity);
            }
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * ProjtSpeed;
            }

            float FiringRateingame = Random.Range(FiringRate - FiringRateVar, FiringRate + FiringRateVar);
            Mathf.Clamp(FiringRateingame, FiringRateMin, float.MaxValue);

            player.PlayShootingClip();

            yield return new WaitForSeconds(FiringRateingame);
        }
    }

    //IEnumerator DesProjtile(GameObject instance)
    //{
    //    if (instance.activeInHierarchy)
    //    {
    //        yield return new WaitForSecondsRealtime(ProjectLifeTime);
    //        instance.SetActive(false);
    //    }
    //}
}
