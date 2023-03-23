using System.Collections;
using UnityEngine;

public class AchievementBarScript : MonoBehaviour
{
    bool isFirst = true;

    //if achievementbar is enable then start the move coroutine 
    private void OnEnable()
    {
        if (isFirst == true)
        {
            isFirst = false;
            return;
        }
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        for (; this.transform.position.x < -5; this.transform.position += new Vector3(5, 0, 0))
        {
            yield return new WaitForSecondsRealtime(0.005f);
        }
        yield return new WaitForSecondsRealtime(2f);
        for (; this.transform.position.x > -450; this.transform.position += new Vector3(-5, 0, 0))
        {
            yield return new WaitForSecondsRealtime(0.005f);
        }
    }
}
