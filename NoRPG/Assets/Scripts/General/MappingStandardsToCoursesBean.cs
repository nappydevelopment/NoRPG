using System;
using UnityEngine;

[Serializable]
public class MappingStandardsToCoursesBean {
    public ClassBean[] classes;

    public static MappingStandardsToCoursesBean CreateFromJSON(string json) {
        return JsonUtility.FromJson<MappingStandardsToCoursesBean>(json);
    }
}

[Serializable]
public class ClassBean {
    public string name;
    public CourseBean[] courses;
}

[Serializable]
public class CourseBean {
    public string name;
    public StandardBean[] standards;
}

[Serializable]
public class StandardBean {
    public string name;
    public string[] vorbedingungen;
    public string[] nachbedingungen;
    public GamesBean[] games;
}

[Serializable]
public class GamesBean {
    public string id;
    public string name;
    public string url;
    public string standard;
}

