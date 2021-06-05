using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }
    public AudioSource[] sfx;
    private void Start()
    {
        instance = this;
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }
}
