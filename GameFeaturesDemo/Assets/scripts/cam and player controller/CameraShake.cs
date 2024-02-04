using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalPosition;

        public void Update()
    {
        originalPosition = transform.localPosition;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {

       

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(originalPosition.x+1f, originalPosition.x-1f) * magnitude;
            float y = Random.Range(originalPosition.y+1f, originalPosition.y-1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;

            

        }



    }




}
