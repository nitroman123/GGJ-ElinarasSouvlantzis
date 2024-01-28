using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour {
    public SouvlakiRecipe souvlakiRecipe;

    public Button tzatziki, patates, kremmidi, ntomata, gyros;
    public TextMeshProUGUI tzatzikiT, patatesT, kremmidiT, ntomataT, gyrosT;
    private void Start() {
        CreateInstance();
        tzatziki.onClick.AddListener(() => {
            IncrementIngridients(tzatziki: 1);
            SoundManager.instance.PlayOnce(SouvlakiYlika.Tzatziki);
        });
        patates.onClick.AddListener(() => {
            IncrementIngridients(patates: 1);
            SoundManager.instance.PlayOnce(SouvlakiYlika.Patates);
        });
        kremmidi.onClick.AddListener(() => {
            IncrementIngridients(kremmidi: 1);
            SoundManager.instance.PlayOnce(SouvlakiYlika.Kremidi);
        });
        ntomata.onClick.AddListener(() => {
            IncrementIngridients(ntomata: 1);
            SoundManager.instance.PlayOnce(SouvlakiYlika.Ntomata);

        });
        gyros.onClick.AddListener(() => {
            IncrementIngridients(gyros: 1);
            SoundManager.instance.PlayOnce(SouvlakiYlika.Gyros);
        });
    }
    public void ResetRecipy() {
        CreateInstance();
        IncrementIngridients(0, 0, 0, 0);
    }
    public void CreateInstance() {
        if (souvlakiRecipe != null) {
            ScriptableObject.Destroy(souvlakiRecipe);
        }
        souvlakiRecipe = ScriptableObject.CreateInstance<SouvlakiRecipe>();
    }
    public void IncrementIngridients(int tzatziki = 0, int patates = 0, int kremmidi = 0, int ntomata = 0, int gyros = 0) {
        if (souvlakiRecipe != null) {
            souvlakiRecipe.tzatziki += tzatziki;
            souvlakiRecipe.kremmidi += kremmidi;
            souvlakiRecipe.ntomata += ntomata;
            souvlakiRecipe.patates += patates;
            souvlakiRecipe.gyros += gyros;

            tzatzikiT.text = souvlakiRecipe.tzatziki.ToString();
            patatesT.text = souvlakiRecipe.patates.ToString();
            kremmidiT.text = souvlakiRecipe.kremmidi.ToString();
            ntomataT.text = souvlakiRecipe.ntomata.ToString();
            gyrosT.text = souvlakiRecipe.gyros.ToString();
        }
    }
}
