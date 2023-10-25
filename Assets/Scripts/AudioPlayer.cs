using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip m_Clip;
    [SerializeField][Range(0f, 1f)] float volume = 1f;

    [SerializeField] AudioClip dm_Clip;
    [SerializeField][Range(0f, 1f)] float dvolume = 1f;
    static AudioPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        if (m_Clip != null)
        {
            AudioSource.PlayClipAtPoint(m_Clip, Camera.main.transform.position, volume);
        }
    }
    public void PlayDamagingClip()
    {
        if (dm_Clip != null)
        {
            AudioSource.PlayClipAtPoint(dm_Clip, Camera.main.transform.position, dvolume);
        }
    }
}
