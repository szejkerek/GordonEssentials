using System;
using System.Collections;
using UnityEngine;

public class FadeScreen : Singleton<FadeScreen>
{
    [SerializeField] private float fadeDuration = 0.75f;
    [SerializeField] private bool fadeOnStart;

    IFadeScreenTarget target;
    protected override void Awake()
    {
        base.Awake();
        target = GetComponent<IFadeScreenTarget>();
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    public float FadeDuration => fadeDuration;

    public void FadeIn() => Fade(1, 0);

    public void FadeOut() => Fade(0, 1);

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeCoroutine(alphaIn, alphaOut));
    }

    public void FadeAction(Action action)
    {
        StartCoroutine(FadeActionCoroutine(action));
    }

    private IEnumerator FadeActionCoroutine(Action action)
    {
        yield return FadeCoroutine(0, 1);

        action?.Invoke();

        yield return new WaitForSeconds(0.25f);

        yield return FadeCoroutine(1, 0);
    }

    private IEnumerator FadeCoroutine(float alphaIn, float alphaOut)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            target.SetAlpha(Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration));

            timer += Time.deltaTime;
            yield return null;
        }

        target.SetAlpha(alphaOut);
    }
}
