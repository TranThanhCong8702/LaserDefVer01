using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] Vector2 MoveSpeed;
    [SerializeField] float UpSpeed;
    Vector2 offset;
    Material mat;

    public void FasterBackground()
    {
        MoveSpeed.y += UpSpeed;
    }
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }


    void Update()
    {
        offset = MoveSpeed * Time.deltaTime;
        mat.mainTextureOffset += offset;
    }
}
