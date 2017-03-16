public class StaticConfigReader : IConfigReader {
    MappingStandardsToCourses IConfigReader.LoadSettings() {
        string id = "12345";
        string name = "Game XYZ";
        string url = "play.google.com";

        Games g = new Games(id, name, url);
        Games g1 = new Games(id, name, url);
        Games g2 = new Games(id, name, url);
        Games g3 = new Games(id, name, url);
        Games g4 = new Games(id, name, url);

        Games[] games = { g, g1, g2, g3, g4 };

        string[] vorbedingungen1 = { };
        string[] nachbedingungen1 = {"2"};

        Standards s1 = new Standards("1", vorbedingungen1, nachbedingungen1, games);

        string[] vorbedingungen2 = {"2"};
        string[] vorbedingungen12 = { "1" };

        string[] nachbedingungen2 = { "3", "4" };

        Standards s2 = new Standards("2", vorbedingungen12, nachbedingungen2, games);
        Standards s3 = new Standards("3", vorbedingungen2, vorbedingungen1, games);
        Standards s4 = new Standards("4", vorbedingungen2, vorbedingungen1, games);

        Standards[] standards = { s1, s2, s3, s4 };

        Courses math = new Courses("Math", standards);
        Courses english = new Courses("English", standards);

        Courses[] courses = { math, english };

        Classes first_class = new Classes("First Class", courses);
        Classes second_class = new Classes("Second Class", courses);

        Classes[] classes = { first_class, second_class };

        MappingStandardsToCourses settings = new MappingStandardsToCourses(classes);

        return settings;
    }
}
