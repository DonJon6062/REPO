using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    public static SFX_Manager instance;
    [SerializeField] private AudioSource SFX_Obj;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void PlaySoundClip(AudioClip audioClip, Transform spawnTransform, float volume) 
    {
        AudioSource audioSource = Instantiate(SFX_Obj, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSoundClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        int random = Random.Range(0, audioClip.Length);

        AudioSource audioSource = Instantiate(SFX_Obj, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip[random];

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayClickSound(AudioClip audioClip, float volume) 
    {
        AudioSource audioSource = Instantiate(SFX_Obj);

        audioSource.clip = audioClip;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
