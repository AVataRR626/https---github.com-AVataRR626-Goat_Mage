using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class BlurMainCamera : MonoBehaviour
{
    [Range(0, 5)] public float FadeDuration = 1.0f;
    [Range(0, 10)] public float BlurSize = 5.0f;

    public void Blur()
    {
        StopCoroutine(BlurRoutine());
        StopCoroutine(UnBlurRoutine());
        StartCoroutine(BlurRoutine());
    }

    public void UnBlur()
    {
        StopCoroutine(BlurRoutine());
        StopCoroutine(UnBlurRoutine());
        StartCoroutine(UnBlurRoutine());
    }

    private IEnumerator BlurRoutine()
    {
        BlurOptimized blurComponent = Camera.main.gameObject.GetComponent<BlurOptimized>();
        if (blurComponent == null)
        {
            blurComponent = Camera.main.gameObject.AddComponent<BlurOptimized>();
            blurComponent.downsample = 0;
            blurComponent.blurIterations = 1;
        }

        float oldBlurSize = blurComponent.blurSize;

        blurComponent.enabled = true;
        float blurStartTime = Time.time;

        while ((Time.time - blurStartTime) <= FadeDuration)
        {
            float progress = Mathf.Clamp01((Time.time - blurStartTime) / FadeDuration);
            blurComponent.blurSize = Mathf.Lerp(oldBlurSize, BlurSize, progress);
            print("bluring");
            yield return null;
        }

        blurComponent.blurSize = BlurSize;
    }

    private IEnumerator UnBlurRoutine()
    {
        BlurOptimized blurComponent = Camera.main.gameObject.GetComponent<BlurOptimized>();
        if (blurComponent == null)
        {
            blurComponent = Camera.main.gameObject.AddComponent<BlurOptimized>();
            blurComponent.downsample = 0;
            blurComponent.blurIterations = 1;
        }

        blurComponent.enabled = true;

        float oldBlurSize = blurComponent.blurSize;
        float blurStartTime = Time.time;

        while ((Time.time - blurStartTime) <= FadeDuration)
        {
            float progress = Mathf.Clamp01((Time.time - blurStartTime) / FadeDuration);
            blurComponent.blurSize = Mathf.Lerp(oldBlurSize, 0, progress);
            print("unbluring");
            yield return null;

        }

        blurComponent.blurSize = 0;
        blurComponent.enabled = false;
    }
}
