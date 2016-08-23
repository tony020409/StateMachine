using System.Collections;

public interface StateTransit {
    IEnumerator FadeIn( float fadeTime );
    IEnumerator FadeOut( float fadeTime );
}