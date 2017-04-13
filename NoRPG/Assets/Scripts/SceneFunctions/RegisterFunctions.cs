﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RegisterFunctions : MonoBehaviour
{
    //Part 1
    public InputField firstname;
    public InputField lastname;
    public Text dayOfBirth;
    public Text monthOfBirth;
    public InputField yearOfBirth;
    public Text gender;
    public InputField country;
    public Text native_language;

    public Button NextBtnPart1;

    //Part 2
    public InputField user;
    public InputField email;
    public InputField password;
    public InputField password_repeat;

    public Button NextBtnPart2;
    public Image WrongUsernameImage;
    public Image WrongEmailImage;
    public Image WrongPassword;

    //Part 3
    public Text selected_character;
    private Animator characterAnimator;

    public Button NextBtnPart3;

    //private variables to check input
    private bool part1Completed;
    private bool part2Completed;
    private bool validBirthday;
    private bool validUsername;
    private bool validEmail;
    private bool validPassword;

    public void Update()
    {
        //Validate Part1
        StartCoroutine(CheckPart1());
        StartCoroutine(CheckBirthday());

        if (part1Completed == true && validBirthday && true)
        {
            NextBtnPart1.interactable = true;
        }
        else
        {
            NextBtnPart1.interactable = false;
        }

        //Validate Part2
        StartCoroutine(CheckPart2());
        StartCoroutine(CheckUsername());
        StartCoroutine(CheckEmail());
        StartCoroutine(CheckPassword());

        if (part2Completed == true && validUsername == true && validEmail == true && validPassword == true)
        {
            NextBtnPart2.interactable = true;
        }
        else
        {
            NextBtnPart2.interactable = false;
        }        
    }

    public void StartAnimationOnClick(GameObject character)
    {
        Debug.Log("Start Cheer Animation");
        characterAnimator = character.GetComponent<Animator>();

        characterAnimator.SetTrigger("cheer");
    }

    private IEnumerator CheckPart1()
    {
        if (firstname.text != "" && lastname.text != "" && dayOfBirth.text != "" && monthOfBirth.text != "" && yearOfBirth.text != "" && gender.text != "" && country.text != "" && native_language.text != "")
        {
            part1Completed = true;
        }
        else
        {
            part1Completed = false;
        }
        yield return null;
    }

    private IEnumerator CheckBirthday()
    {
        string birthdayText = dayOfBirth.text + "-" + monthOfBirth.text + "-" + yearOfBirth.text;
        string expresion = "(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[1,3-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})";

        /*if (Regex.IsMatch(birthdayText, expresion))
        {
            if (Regex.Replace(birthdayText, expresion, string.Empty).Length == 0)
            {
                validBirthday = true;
            }
            else
            {
                validBirthday = false;
            }
        }
        else
        {
            validBirthday = false;
        }*/

        validBirthday = true;
        yield return null;
    }

    private IEnumerator CheckPart2()
    {
        if (user.text != "" && email.text != "" && password.text != "" && password_repeat.text != "")
        {
            part2Completed = true;
        }
        else
        {
            part2Completed = false;
        }
        yield return null;
    }

    private IEnumerator CheckUsername()
    {
        //check neccessary
        validUsername = true;
        yield return null;
    }

    private IEnumerator CheckPassword()
    {
        if (password.text == password_repeat.text)
        {
            validPassword = true;
            WrongPassword.gameObject.SetActive(false);
        }
        else
        {
            validPassword = false;
            WrongPassword.gameObject.SetActive(true);
        }
        yield return null;
    }

    private IEnumerator CheckEmail()
    {
        string emailString = email.text;
        string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

        if (Regex.IsMatch(emailString, expresion))
        {
            if (Regex.Replace(emailString, expresion, string.Empty).Length == 0)
            {
                validEmail = true;
                WrongEmailImage.gameObject.SetActive(false);
            }
            else
            {
                validEmail = false;
                WrongEmailImage.gameObject.SetActive(true);
            }
        }
        else
        {
            validEmail = false;
            WrongEmailImage.gameObject.SetActive(true);
        }
        yield return null;
    }
}
