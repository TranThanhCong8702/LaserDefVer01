using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipDatabase : ScriptableObject
{
    [SerializeField] List<Sprite> sprites = new List<Sprite>();

    public int GetSkinCount()
    {
        return sprites.Count;
    }
    public Sprite Sprite(int index)
    {
        return sprites[index];
    }
}
