using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendDataToServer : MonoBehaviour {

    private static string secretKey = "norpg";
    public static string registerURL = "http://norpg.it.dh-karlsruhe.de/register.php?";
    public static string loginURL = "http://norpg.it.dh-karlsruhe.de/login.php?";

    public InputField firstname;
    public InputField lastname;
    public Text dayOfBirth;
    public Text monthOfBirth;
    public InputField yearOfBirth;
    public Text gender;
    public InputField country;
    public Text native_language;

    public InputField user;
    public InputField email;
    public InputField password;
    public InputField password_repeat;

    public Text selected_character;

    public Text status;

    public string firstnameText;
    public string lastnameText;
    public string birthdayText;
    public string genderText;
    public string countryText;
    public string native_languageText;

    public string userText;
    public string emailText;
    public string passwordText;
    public string password_repeatText;

    public string selected_characterText;

    public void GetFirstData()
    {
        firstnameText = firstname.text;
        lastnameText = lastname.text;
        birthdayText = yearOfBirth.text + "-" + monthOfBirth.text + "-" + dayOfBirth.text;
        genderText = gender.text;
        countryText = country.text;
        native_languageText = native_language.text;
    }

    public void GetSecondData()
    {
        userText = user.text;
        emailText = email.text;
        passwordText = password.text;
        //Debug.Log(passwordText);
        password_repeatText = password_repeat.text;
    }

    public void GetThirdData()
    {
        selected_characterText = selected_character.text;
        SendRegister();
    }

    private void SendRegister()
    {
        StartCoroutine(RegisterUser(userText, emailText, MD5Test.Md5Sum(passwordText), firstnameText, lastnameText, birthdayText, genderText, countryText, native_languageText, selected_characterText));
    }

    IEnumerator RegisterUser(string user, string email, string password, string firstname, string lastname, string birthday, string gender, string country, string native_language, string selected_character)
    {

        string hash = MD5Test.Md5Sum(user + email + password + firstname + country + selected_character + secretKey);

        string post_url = registerURL
            + "user=" + WWW.EscapeURL(user)
            + "&email=" + WWW.EscapeURL(email)
            + "&password=" + WWW.EscapeURL(password)
            + "&firstname=" + WWW.EscapeURL(firstname)
            + "&lastname=" + WWW.EscapeURL(lastname)
            + "&birthday=" + WWW.EscapeURL(birthday)
            + "&gender=" + WWW.EscapeURL(gender)
            + "&country=" + WWW.EscapeURL(country)
            + "&native_language=" + WWW.EscapeURL(native_language)
            + "&selected_character=" + WWW.EscapeURL(selected_character)
            + "&hash=" + hash;
        WWW hs_post = new WWW(post_url);
        yield return hs_post;

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        else
        {
            status.text = hs_post.text;
        }

    }
}
