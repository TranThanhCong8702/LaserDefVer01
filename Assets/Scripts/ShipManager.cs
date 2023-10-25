using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] ShipDatabase shipDatabase;
    [SerializeField] SpriteRenderer spriter;
    int count = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Count"))
        {
            count = 0;
        }
        else
        {
            Load();
        }
        ChangeShip(count);
    }
    public void Next()
    {
        count++;
        if (count >= shipDatabase.GetSkinCount())
        {
            count = 0;
        }
        ChangeShip(count);
        Save();
    }
    public void Back()
    {
        count--;
        if (count < 0)
        {
            count = shipDatabase.GetSkinCount() - 1;
        }
        ChangeShip(count);
        Save();
    }
    private void ChangeShip(int count)
    {
        spriter.sprite = shipDatabase.Sprite(count);

    }
    void Load()
    {
        count = PlayerPrefs.GetInt("Count");
    }
    void Save()
    {
        PlayerPrefs.SetInt("Count", count);
    }
}
