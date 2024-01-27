using UnityEngine;

[CreateAssetMenu(menuName = "Recipe/SouvlakiRecipe")]
public class SouvlakiRecipe : ScriptableObject
{
    public int tzatziki, patates, kremmidi, ntomata , gyros;

    public bool CorrectRecipy() {
        return gyros == 1 && tzatziki == 1 && patates == 1 && kremmidi == 1 && ntomata == 1;
    }
}
public enum SouvlakiYlika {
    Patates,
    Ntomata,
    Kremidi,
    Tzatziki,
    Gyros
}
