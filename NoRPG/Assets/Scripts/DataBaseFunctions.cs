using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataBaseFunction : MonoBehaviour
{
    private string secretKey = "norpg";
    public string registerURL = "http://localhost:8080/unity_test/register.php?";
    public string loginURL = "http://localhost:8080/unity_test/login.php?";
    public Text gameobject;

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
            gameobject.GetComponent<Text>().text = hs_post.text;
        }

    }

    IEnumerator LoginUser(string user, string password)
    {
        gameobject.GetComponent<Text>().text = "Loading Scores";

        string hash = MD5Test.Md5Sum(user + password + secretKey);


        string get_url = loginURL
            + "user=" + WWW.EscapeURL(user)
            + "&password=" + WWW.EscapeURL(password)
            + "&hash=" + hash;

        WWW hs_get = new WWW(get_url);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the information: " + hs_get.error);
        }
        else
        {
            gameobject.GetComponent<Text>().text = hs_get.text;
        }
    }

}