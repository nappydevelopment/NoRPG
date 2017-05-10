using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendDataToServer : MonoBehaviour {

    private static string secretKey = "norpg";
    public static string registerURL = "http://norpg.it.dh-karlsruhe.de/register.php";

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

        //THIS IS THE RESULT OF THE SWITCH CASE: birthdayText = yearOfBirth.text + "-" + monthOfBirth.text + "-" + dayOfBirth.text;
        switch (monthOfBirth.text)
        {
            case "January":
                birthdayText = yearOfBirth.text + "-" + "01" + "-" + dayOfBirth.text;
                break;
            case "February":
                birthdayText = yearOfBirth.text + "-" + "02" + "-" + dayOfBirth.text;
                break;
            case "March":
                birthdayText = yearOfBirth.text + "-" + "03" + "-" + dayOfBirth.text;
                break;
            case "April":
                birthdayText = yearOfBirth.text + "-" + "04" + "-" + dayOfBirth.text;
                break;
            case "May":
                birthdayText = yearOfBirth.text + "-" + "05" + "-" + dayOfBirth.text;
                break;
            case "June":
                birthdayText = yearOfBirth.text + "-" + "06" + "-" + dayOfBirth.text;
                break;
            case "July":
                birthdayText = yearOfBirth.text + "-" + "07" + "-" + dayOfBirth.text;
                break;
            case "August":
                birthdayText = yearOfBirth.text + "-" + "08" + "-" + dayOfBirth.text;
                break;
            case "September":
                birthdayText = yearOfBirth.text + "-" + "09" + "-" + dayOfBirth.text;
                break;
            case "October":
                birthdayText = yearOfBirth.text + "-" + "10" + "-" + dayOfBirth.text;
                break;
            case "November":
                birthdayText = yearOfBirth.text + "-" + "11" + "-" + dayOfBirth.text;
                break;
            case "December":
                birthdayText = yearOfBirth.text + "-" + "12" + "-" + dayOfBirth.text;
                break;
        }
        Debug.Log(birthdayText);

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
        SendRegister();
    }

    public void SetCharacter(string character)
    {
        selected_characterText = character;
        GameControl.control.correctCharacterModel = character;
        GameControl.control.Save();
    }

    private void SendRegister()
    {
        GameControl.control.correctCharacterModel = selected_characterText;
        GameControl.control.Save();

        StartCoroutine(RegisterUser(userText, emailText, MD5Test.Md5Sum(passwordText), firstnameText, lastnameText, birthdayText, genderText, countryText, native_languageText, selected_characterText));
    }

    IEnumerator RegisterUser(string user, string email, string password, string firstname, string lastname, string birthday, string gender, string country, string native_language, string selected_character)
    {

        string hash = MD5Test.Md5Sum(user + email + password + firstname + country + selected_character + secretKey);

        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("firstname", firstname);
        form.AddField("lastname", country);
        form.AddField("birthday", birthday);
        form.AddField("gender", gender);
        form.AddField("country", country);
        form.AddField("native_language", native_language);
        form.AddField("selected_character", selected_character);
        form.AddField("hash", hash);
        WWW www = new WWW(registerURL, form);

        yield return www;

        if (www.error != null) {
            print("There was an error: " + www.error);
        }
        else {
            status.text = www.text;
        }
    }
}
