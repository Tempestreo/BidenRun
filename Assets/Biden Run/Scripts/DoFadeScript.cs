using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoFadeScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DoFade());
    }
    //fade animation with numerator
    IEnumerator DoFade()
    {
        if (this.gameObject.GetComponent<Image>() != null)
        {
            Color deneme = this.gameObject.GetComponent<Image>().color;
            deneme.a = 0;
            for (float i = 0; i <= 1.5f; i += 0.025f)
            {
                deneme.a = i;
                this.gameObject.GetComponent<Image>().color = deneme;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }
        if (this.gameObject.GetComponent<TextMeshProUGUI>() != null) 
        {
            float deneme2 = this.gameObject.GetComponent<TextMeshProUGUI>().alpha;
            deneme2 = 0;
            for (float i = 0; i <= 1.5f; i += 0.025f)
            {
                deneme2 = i;
                this.gameObject.GetComponent<TextMeshProUGUI>().alpha = deneme2;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }
        if (this.gameObject.GetComponent<Text>() != null)
        {
            Color deneme2 = this.gameObject.GetComponent<Text>().color;
            deneme2.a = 0;
            for (float i = 0; i <= 1.5f; i += 0.025f)
            {
                deneme2.a = i;
                this.gameObject.GetComponent<Text>().color = deneme2;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }
    }
}
