using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Audio;
    bool play = false;

    void Update()
    {
        if (!play)
        {
            Audio.Play();
            play = true;
        }
    }
}