using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;   

    public AudioSource source;
    public AudioClip[] ylikalist;
    public AudioClip kaliapantisi, kakiapantisi, epanafora;
    public Queue<AudioClip> clipqueue = new();
    public bool speel = false;

    [Header("Image Changer")]
    public Image head;
    public Sprite goodface, badface;
    private void Awake() {
        instance = this;
    }
    public void PlayOnce(SouvlakiYlika souvlaki) {
        Debug.Log((int)souvlaki);
        source.PlayOneShot(ylikalist[(int)souvlaki]);
        clipqueue.Enqueue(ylikalist[(int)souvlaki]);
    }
    public void Epanafora() {
        source.PlayOneShot(epanafora);
        RecipeManager.instance.ResetRecipy();
        head.sprite = goodface;
    }
    public void CorrectOrder() {
        source.PlayOneShot(kaliapantisi);
    }
    public void BadOrder() {
        source.PlayOneShot(kakiapantisi);
    }
    Coroutine routine;
    public void SpellOrder() {
        routine ??= StartCoroutine(spellRoutine());
    }
    public IEnumerator spellRoutine() {
        speel = true;
        yield return new WaitUntil(() =>  !speel);
        bool correct = RecipeManager.instance.souvlakiRecipe.CorrectRecipy();
        if (head.sprite != null) {
            head.sprite = correct ? goodface : badface;
        }
        if (correct) {
            CorrectOrder();
        } else {
            BadOrder();
        }
        routine = null;
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
