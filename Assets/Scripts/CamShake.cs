using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] float ShakeDuration = 1f;
    [SerializeField] float ShakeMagnitude = 0.5f;

    Vector3 basePos;
    void Start()
    {
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float ElapseTime = 0f;
        while (ElapseTime < ShakeDuration)
        {
            transform.position = basePos + (Vector3)Random.insideUnitCircle * ShakeMagnitude;
            ElapseTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = basePos;
    }
}
