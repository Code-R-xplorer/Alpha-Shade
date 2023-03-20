using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Gun_System
{
    public class DecalFade : MonoBehaviour
    {
        private DecalProjector decal;
        public float fadeDuration = 2.5f;
        public float delay = 5f;

        private void Start()
        {
            decal = transform.GetChild(0).GetComponent<DecalProjector>();
            
            StartCoroutine(DelayFadeOut());
        }

        private IEnumerator DelayFadeOut()
        {
            yield return new WaitForSeconds(delay);
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
                decal.fadeFactor = alpha;
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
