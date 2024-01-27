using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] soundlist;

    public void PlayOnce(int byindex) {
        source.PlayOneShot(soundlist[byindex]);
    }
}
