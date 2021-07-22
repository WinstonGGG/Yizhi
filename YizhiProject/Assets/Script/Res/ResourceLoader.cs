using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    public Sprite[] backgrounds;
    public Sprite[] characters;

    public Sprite getBackground(int bgId)
    {
        return backgrounds[bgId];
    }

    public Sprite getCharacter(int chId)
    {
        return characters[chId];
    }
}
