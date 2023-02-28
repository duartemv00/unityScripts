using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public GameObject cam;

    public IEnumerator Shake (float duration, float magnitude) {
        Vector3 originalPos = GetComponent<Camera>().transform.localPosition;
        float elapsed = 0.0f;

        while(elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            GetComponent<Camera>().transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        GetComponent<Camera>().transform.localPosition = originalPos;
    }
}
