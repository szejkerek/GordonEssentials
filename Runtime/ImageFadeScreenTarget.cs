using UnityEngine;
using UnityEngine.UI;
namespace GordonEssentials
{
    [RequireComponent(typeof(Image))]
    public class ImageFadeScreenTarget : MonoBehaviour, IFadeScreenTarget
    {
        [SerializeField] Color fadeColor = Color.black;
        private Image image;
        private void Awake()
        {
            image = GetComponent<Image>();
            SetAlpha(0);
        }

        public void SetAlpha(float target)
        {
            target = Mathf.Clamp01(target);
            Color newColor = fadeColor;
            newColor.a = target;
            image.color = newColor;
        }
    }
}