using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WebJSONConfigReader: IConfigReader {

    private static readonly string rootURL = "http://norpg.it.dh-karlsruhe.de/";
    private static readonly string settingsURL = rootURL + "v1.json";

    public MappingStandardsToCourses LoadSettings() {

        WWW www = new WWW(settingsURL);
        while (!www.isDone) { }

        string json;

        string LocalFilePath = Application.persistentDataPath + "/v1.json";

        if (string.IsNullOrEmpty(www.error)) {
            json = www.text;
            File.WriteAllText(LocalFilePath, json);
        } else if (File.Exists(LocalFilePath)) {
            json = File.ReadAllText(LocalFilePath);
        } else {
            json = "";                
            File.WriteAllText(LocalFilePath, json);
        }
        Debug.Log(json.ToString());
        MappingStandardsToCoursesBean settingsBean = MappingStandardsToCoursesBean.CreateFromJSON(json);

        string json2 = JsonUtility.ToJson(settingsBean);
        Debug.Log(json2.ToString());

        
        List<Classes> classes = new List<Classes>();
        foreach (var classe in settingsBean.classes) {
            List<Courses> courses = new List<Courses>();

            foreach (var course in classe.courses) {
                List<Standards> standards = new List<Standards>();

                foreach (var standard in course.standards) {
                    List<Games> games = new List<Games>();
                    List<string> vor = new List<string>();
                    List<string> nach = new List<string>();

                    foreach (var game in standard.games) {
                        games.Add(new Games(game.id, game.name, game.url));
                    }

                    foreach (var vorbedingung in standard.vorbedingungen) {
                        vor.Add(vorbedingung);
                    }

                    foreach (var nachbedingung in standard.nachbedingungen) {
                        nach.Add(nachbedingung);
                    }

                    Games[] g = games.ToArray();
                    string[] v = vor.ToArray();
                    string[] n = nach.ToArray();
                    standards.Add(new Standards(standard.name, v, n, g));
                }
                Standards[] s = standards.ToArray();
                courses.Add(new Courses(course.name, s));
            }
            Courses[] c = courses.ToArray();
            classes.Add(new Classes(classe.name, c));
        }

        Classes[] cla = classes.ToArray();

        return new MappingStandardsToCourses(cla);
    }
}
