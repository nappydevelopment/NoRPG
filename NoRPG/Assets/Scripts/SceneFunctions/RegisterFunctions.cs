using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RegisterFunctions : MonoBehaviour
{
    //Part 1
    public Text firstname;
    public Text lastname;
    public Text birthday;
    public Text gender;
    public Text country;
    public Text native_language;

    public Button NextBtnPart1;

    //Part 2
    public Text user;
    public Text email;
    public Text password;
    public Text password_repeat;

    public Button NextBtnPart2;
    public Image WrongUsernameImage;
    public Image WrongEmailImage;

    //Part 3
    public Text selected_character;

    public Button NextBtnPart3;

    public void Update()
    {
        // Set Button "Next" in Part1 to interactable when everything is set
        // no check with database needed
        if (firstname.text != "" && lastname.text != "" && birthday.text != "" && gender.text != "" && country.text != "" && native_language.text != "")
        {
            NextBtnPart1.interactable = true;
        }
        else
        {
            NextBtnPart1.interactable = false;
        }

        // Set Button "Next" in Part2 to interactable when everything is set and username doesn't exist yet!
        // username check with database necessary!
        if (user.text != "" && email.text != "" && password.text != "" && password_repeat.text != "")
        {
            //Todo: insert username check
            WrongUsernameImage.gameObject.SetActive(false);

            //check E-Mail
            bool validEmail = IsValidEmail(email.text);
            Debug.Log(validEmail);

            if (validEmail == true)
            {
                NextBtnPart2.interactable = true;
                WrongEmailImage.gameObject.SetActive(false);
            }
            else
            {
                NextBtnPart2.interactable = false;
                WrongEmailImage.gameObject.SetActive(true);
            }

            //Password checker? sonderzeichen etc?
        }
        else
        {
            NextBtnPart2.interactable = false;
        }
    }

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

    bool IsValidEmail(string email)
    {
        string expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, string.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
