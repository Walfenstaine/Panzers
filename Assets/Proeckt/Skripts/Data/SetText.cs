using UnityEngine;
using UnityEngine.UI;
using YG;


public class SetText: MonoBehaviour
{
    public enum Langviges {rus, eng, turk}
    public Langviges langviges;
    [SerializeField] private Language language;

    private void Start()
    {
        Text myText = GetComponent<Text>(); 
        if (YandexGame.EnvironmentData.language == "ru")
        {
            myText.text = language.ru;
        }
        else
        {
            if (YandexGame.EnvironmentData.language == "en") 
            {
                myText.text = language.en;
            }
            if (YandexGame.EnvironmentData.language == "tr")
            {
                myText.text = language.tr;
            }
            
        }
    }
}
