using System.Collections;
using UnityEngine;

public class FlyingWheat : MonoBehaviour
{
    public float timeToFly = 1f;
    public int flySteps = 100;
    
    public void FlyToTheCounter() => StartCoroutine(Fly());

    private IEnumerator Fly()
    {
        var rectTransform = GetComponent<RectTransform>();
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = GameManager.WheatCounterPosition;
        float deltaTime = timeToFly / flySteps;
        float deltaStep = 1f / flySteps;

        for (int i = 0; i < flySteps; ++i)
        {
            yield return new WaitForSeconds(deltaTime);
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, i * deltaStep);
        }
        
        GameManager.IncrementWheatCounter();
        Destroy(gameObject);
    }
}
