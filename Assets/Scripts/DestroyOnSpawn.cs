using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnSpawn : MonoBehaviour
{
    public float fadeDelay = 10f;
    public float alphaValue = 0;
    public bool destroyGameObject = false;

    Image image;
    void OnEnable()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeTo(alphaValue, fadeDelay));
    }

    IEnumerator FadeTo(float aValue, float fadeTime)
    {
        float alpha = image.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime)
        {
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(alpha, aValue, t));
            image.color = newColor;
            yield return null;
        }

        if (destroyGameObject)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Color newColor = new Color(image.color.r, image.color.g, image.color.b, 255);
        image.color = newColor;
    }
}
