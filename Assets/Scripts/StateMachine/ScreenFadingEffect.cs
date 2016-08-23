using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFadingEffect : MonoBehaviour, StateTransit {
    [SerializeField]
    private Image fadingImage;

    public IEnumerator FadeIn( float fadeTime ) {
        float fadeValue = 0f;
        float fadeDifference = 1f / fadeTime;

        while ( fadeValue < 1f ) {
            fadeValue += fadeDifference * Time.deltaTime;
            fadeValue = Mathf.Clamp01( fadeValue );
            fadingImage.color = new Color( 0, 0, 0, fadeValue );

            yield return null;
        }
    }

    public IEnumerator FadeOut( float fadeTime ) {
        float fadeValue = 1f;
        float fadeDifference = 1f / fadeTime;

        while ( fadeValue > 0f ) {
            fadeValue -= fadeDifference * Time.deltaTime;
            fadeValue = Mathf.Clamp01( fadeValue );
            fadingImage.color = new Color( 0, 0, 0, fadeValue );

            yield return null;
        }
    }
}