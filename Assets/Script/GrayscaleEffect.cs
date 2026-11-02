using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GrayscaleEffect : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] float transitionSpeed = 50f;

    ColorAdjustments colorAdjustments;

    float targetSaturation = 0f;

    void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
    }

    void Update()
    {
        if (colorAdjustments == null) return;

        colorAdjustments.saturation.value = Mathf.MoveTowards(
            colorAdjustments.saturation.value,
            targetSaturation,
            transitionSpeed * Time.deltaTime
        );
    }

    public void EnableGrayscale()
    {
        targetSaturation = -100f;
    }

    public void DisableGrayscale()
    {
        targetSaturation = 0f;
    }
}