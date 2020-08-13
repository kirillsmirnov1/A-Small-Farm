using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    public Sprite greenSprite;
    public Sprite brownSprite;

    public float outlineWidth = 5f;

    public BlockStatus Status { get; private set; }
    public bool ObjectOverBlock;// { get; private set; }
    
    private Image _image;
    private Material _material;
    private Renderer _renderer;
    private WheatOnABlock _wheat;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.material = new Material(_image.material);
        _wheat = GetComponentInChildren<WheatOnABlock>();
        
        if(_wheat == null) Debug.Log($"{gameObject.name}: no WheatOnABlock in children");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ObjectOverBlock = true;
        
        switch (Status)
        {
            case BlockStatus.Green:
                if (other.CompareTag("Ground"))
                {
                    EnableOutline(true);
                    Status = BlockStatus.GreenSelected;
                }
                break;
            case BlockStatus.Brown: 
                if (other.CompareTag("Wheat"))
                {
                    EnableOutline(true);
                    Status = BlockStatus.BrownSelected;
                }
                break;
            case BlockStatus.Grown:
                if (other.CompareTag("Sickle"))
                {
                    _wheat.FlyToTheCounter();
                    Status = BlockStatus.Brown;
                    _image.sprite = brownSprite;
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectOverBlock = false;
    }

    private void EnableOutline(bool enable)
    {
        _image.material.SetFloat("_Thickness", enable ? outlineWidth : 0f);
    }


    public enum BlockStatus
    {
        Green,
        GreenSelected,
        Brown,
        BrownSelected,
        Grows,
        Grown
    }

    public void CompleteOperation(MovesWithMouse.Movable movableType, bool success)
    {
        switch (movableType)
        {
            case MovesWithMouse.Movable.Ground:
                if (Status == BlockStatus.GreenSelected)
                {
                    Status = success ? BlockStatus.Brown : BlockStatus.Green;
                    _image.sprite = success ? brownSprite : greenSprite;
                    if(success) GameManager.IncrementGroundCounter();
                    EnableOutline(false);
                }
                break;
            case MovesWithMouse.Movable.Wheat:
                if (Status == BlockStatus.BrownSelected)
                {
                    Status = success ? BlockStatus.Grows : BlockStatus.Brown;
                    _wheat.StartGrowing(() => Status = BlockStatus.Grown);
                    EnableOutline(false);
                } 
                break;
        }
    }
}
