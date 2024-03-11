using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSilder : MonoBehaviour
{
    [SerializeField] AudioSettings audioSettings;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0.001f;
    }

}