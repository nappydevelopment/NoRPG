public class MappingStandardsToCourses {
    public readonly Classes[] classes;
    public MappingStandardsToCourses(Classes[] classes) {
        this.classes = classes;
    }
}

public class Classes {
    public readonly Courses[] courses;
    public readonly string name; 

    public Classes(string name, Courses[] courses) {
        this.name = name; 
        this.courses = courses; 
    }
}

public class Courses {
    public readonly Standards[] standards;
    public readonly string name; 

    public Courses(string name, Standards[] standards) {
        this.name = name;
        this.standards = standards;
    }
}
    
public class Standards {
    public readonly string name;
    public readonly string[] vorbedingungen;
    public readonly string[] nachbedingungen;
    public readonly Games[] games;

    public Standards(string name, string[] vorbedingungen, string[] nachbedingungen, Games[] games) {
        this.name = name; 
        this.nachbedingungen = nachbedingungen;
        this.vorbedingungen = vorbedingungen; 
        this.games = games;
    }
}

[System.Serializable]
public class Games {
    public readonly string id;
    public readonly string name;
    public readonly string url;

    public Games(string id, string name, string url) {
        this.name = name;
        this.id = id;
        this.url = url; 
    }
}

