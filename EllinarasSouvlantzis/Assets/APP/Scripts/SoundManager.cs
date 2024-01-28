using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;   

    public AudioSource source;
    public AudioClip[] ylikalist;

    public Queue<AudioClip> clipqueue = new();
    public bool speel = false;
    private void Awake() {
        instance = this;
    }
    public void PlayOnce(SouvlakiYlika souvlaki) {
        Debug.Log((int)souvlaki);
        source.PlayOneShot(ylikalist[(int)souvlaki]);
        clipqueue.Enqueue(ylikalist[(int)souvlaki]);
    }
    public void SpellOrder() {
        speel = true;
    }
    void Update() {
        if (source.isPlaying == false && clipqueue.Count > 0 && speel) {
            source.clip = clipqueue.Dequeue();
            source.Play();
        }
        else if(clipqueue.Count == 0 && !source.isPlaying)
        {
            speel = false;
        }
    }
}
