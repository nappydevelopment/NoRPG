using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterFunctions : MonoBehaviour
{

    public void StartAnimationOnClick(Animation animation)
    {
        StartCoroutine(WaitForAnimation(animation));
    }

    public IEnumerator WaitForAnimation(Animation animation)
    {
        animation.Play("Cheer");

        while (animation.isPlaying)
        {
            yield return null;
        }
    }
}
