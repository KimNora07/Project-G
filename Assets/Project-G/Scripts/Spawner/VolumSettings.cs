using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumSettings : MonoBehaviour
{
    public AudioSource musicsourse;

    public AudioSource btnsourse;
    public void SetMusicVolume(float volume)
    {
        musicsourse.volume = volume;
    }

    // Start is called before the first frame update
    public void SetbuttonVolume(float volume)
    {
        btnsourse.volume = volume;
    }
    public void OnSfx()
    {
        btnsourse.Play();
    }
}
