using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[System.Serializable]
public class Audio
{
    public AudioClip Clip;
    public AudioSource Source;
}

public class ScAudioManager : MonoBehaviour
{
    public static ScAudioManager Instance;
    public AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }


    public List<ScDictionaryAudio<string, Audio>> sound;

    public void PlaySong(string name)
    {
        foreach (var item in sound)
        {
            if (item.Key == name)
            {
                item.Value.Source.PlayOneShot(item.Value.Clip);
            }
        }
    }
}
