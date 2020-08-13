using System;
using System.Collections;
using UnityEngine;

public class WheatOnABlock : MonoBehaviour
{
    [SerializeField]
    private float growthTime = 10f;
    [SerializeField]
    private int growthSteps = 10;
    [SerializeField]
    [Tooltip("Scale to which wheat grows")]
    private Vector3 growScale = new Vector3(0.5f, 0.5f, 1f);
    [SerializeField]
    [Tooltip("Prefab used to show wheat flying to counter")]
    private GameObject flyingWheat;

    private RectTransform _rectTransform;
    
    private void Awake()
    {
        if(flyingWheat == null) Debug.LogWarning($"{gameObject.name}: no flying wheat attached");
        _rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Grows wheat from zero-scale to required.
    /// </summary>
    /// <param name="growthFinishedCallback">Will be called then the tree finished growing</param>
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

    /// <summary>
    /// Makes it look like this wheat is flying to the wheat counter
    /// </summary>
    public void FlyToTheCounter()
    {
        transform.localScale = Vector3.zero;
        var wheat = Instantiate(flyingWheat, transform.parent.parent.parent);
        wheat.transform.localScale = growScale;
        wheat.GetComponent<RectTransform>().position = _rectTransform.position;
        wheat.GetComponent<FlyingWheat>().FlyToTheCounter();
    }
}
