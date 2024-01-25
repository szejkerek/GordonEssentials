using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFadeScreenTarget : MonoBehaviour, IFadeScreenTarget
{
    [SerializeField] Color fadeColor = Color.black;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetAlpha(float target)
    {
        target = Mathf.Clamp01(target);
        Color newColor = fadeColor;
        newColor.a = target;
        image.material.SetColor("_BaseColor", newColor);
    }

}