using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WheatOnABlock : MonoBehaviour
{
    public float growthTime = 10f;
    public int growthSteps = 10;
    public Vector3 growScale = new Vector3(0.5f, 0.5f, 1f);
    public GameObject flyingWheat;

    private RectTransform _rectTransform;
    
    private void Awake()
    {
        if(flyingWheat == null) Debug.LogWarning($"{gameObject.name}: no flying wheat attached");
        _rectTransform = GetComponent<RectTransform>();
    }

    public void StartGrowing(Action growthFinishedCallback)
    {
        StartCoroutine(Grow(growthFinishedCallback));
    }

    private IEnumerator Grow(Action growthFinishedCallback)
    {
        float deltaTime = growthTime / growthSteps;
        float deltaGrow = 1f / growthSteps;

        for (int i = 0; i < growthSteps; ++i)
        {
            yield return new WaitForSeconds(deltaTime);
            transform.localScale = Vector3.Lerp(Vector3.zero, growScale, i * deltaGrow);
        }
        
        growthFinishedCallback();
    }

    public void FlyToTheCounter()
    {
        transform.localScale = Vector3.zero;
        var wheat = Instantiate(flyingWheat, transform.parent.parent.parent);
        wheat.GetComponent<RectTransform>().position = _rectTransform.position;
        wheat.GetComponent<FlyingWheat>().FlyToTheCounter();
    }
}
