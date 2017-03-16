using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterFunctions : MonoBehaviour {

    public void StartAnimationOnClick(Animation animation)
    {
        animation.Play("Cheer");
        WaitForAnimation(animation);
    }

    public IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);

        yield return animation;
    }

}
