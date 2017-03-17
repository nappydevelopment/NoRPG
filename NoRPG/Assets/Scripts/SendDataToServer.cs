using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendDataToServer : MonoBehaviour {

    //TODO: Eingaben überprüfen

    public Text firstname;
    public Text lastname;
    public Text birthday;
    public Text gender;
    public Text country;
    public Text native_language;

    public Text user;
    public Text email;
    public Text password;
    public Text password_repeat;

    public Text selected_character;

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
        birthdayText = birthday.text;
        genderText = gender.text;
        countryText = country.text;
        native_languageText = native_language.text;
    }

    public void GetSecondData()
    {
        userText = user.text;
        emailText = email.text;
        passwordText = password.text;
        password_repeatText = password_repeat.text;
    }

    public void GetThirdData()
    {
        selected_characterText = selected_character.text;
        SendData();
    }

    private void SendData()
    {
        Debug.Log("Start sending");
        string url = "http://norpg.it.dh-karlsruhe.de/register.php";

        WWWForm form = new WWWForm();
        form.AddField("firstname", firstnameText);
        form.AddField("lastname", lastnameText);
        form.AddField("birthday", birthdayText);
        form.AddField("gender", genderText);
        form.AddField("country", countryText);
        form.AddField("native_language", native_languageText);
        form.AddField("user", userText);
        form.AddField("email", emailText);
        form.AddField("password", passwordText);
        form.AddField("selected_character", selected_characterText);

        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
