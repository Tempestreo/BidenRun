using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class CTBAnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GrowUpNum(this.gameObject, new Vector3(1, 1, 1)));
    }
    
    // menu animation with numerator
    public IEnumerator GrowUpNum(GameObject gameObject, Vector3 target)
    {
        while (this.gameObject.activeSelf)
        {
            for (; gameObject.transform.localScale.x < target.x*1.15f;)
            {
                gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);
                yield return new WaitForSecondsRealtime(0.03f);
            }
            for (; gameObject.transform.localScale.x > target.x/1.15f;)
            {
                gameObject.transform.localScale = gameObject.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
                yield return new WaitForSecondsRealtime(0.03f);
            }
        }
    }
}
