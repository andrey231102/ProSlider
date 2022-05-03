using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increment : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Fading());
    }

    private IEnumerator Fading()
    {
        float time = 0;

        while (time < 2)
        {
            transform.position += new Vector3(0, transform.position.y * Time.deltaTime, 0);
            time += Time.deltaTime;
            yield return null;  
        }

        gameObject.SetActive(false);
        yield break;
    }
}
