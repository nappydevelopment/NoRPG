using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GetGameList : MonoBehaviour {

    public static Hashtable playedGames;

    public static List<Games> GetGames(string interactionobjectName)
    {
        string[] dependencies = interactionobjectName.Split('_');
        List<Games> games = new List<Games>();
        
        if (dependencies[0].Equals("0")) {
            if (dependencies[1].Equals("Math")) {
                foreach (Standards standard in LoadingScreen.Settings.classes[0].courses[0].standards) {
                    if (standard.name.Contains("1.OA"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("1.NBT"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("1.MD"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("1.G"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
            else if (dependencies[1].Equals("English"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[0].courses[1].standards)
                {
                    if (standard.name.Contains("RL.1"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RI.1"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RF.1"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("W.1"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("SL.1"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("L.1"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }

        }
        else if (dependencies[0].Equals("1"))
        {
            if (dependencies[1].Equals("Math"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[1].courses[0].standards)
                {
                    if (standard.name.Contains("2.OA"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("2.NBT"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("2.MD"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("2.G"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
            else if (dependencies[1].Equals("English"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[1].courses[1].standards)
                {
                    if (standard.name.Contains("RL.2"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RI.2"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RF.2"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("W.2"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("SL.2"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("L.2"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
        }
        else if (dependencies[0].Equals("2"))
        {
            if (dependencies[1].Equals("Math"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[2].courses[0].standards)
                {
                    if (standard.name.Contains("3.OA"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("3.NBT"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("3.MD"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("3.G"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("3.NF"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
            else if (dependencies[1].Equals("English"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[2].courses[1].standards)
                {
                    if (standard.name.Contains("RL.3"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RI.3"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RF.3"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("W.3"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("SL.3"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("L.3"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
        }
        else if (dependencies[0].Equals("3"))
        {
            if (dependencies[1].Equals("Math"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[3].courses[0].standards)
                {
                    if (standard.name.Contains("4.OA"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("4.NBT"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("4.MD"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("4.G"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("4.NF"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
            else if (dependencies[1].Equals("English"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[3].courses[1].standards)
                {
                    if (standard.name.Contains("RL.4"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RI.4"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RF.4"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("W.4"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("SL.4"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("L.4"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
        }
        else if (dependencies[0].Equals("4"))
        {
            if (dependencies[1].Equals("Math"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[4].courses[0].standards)
                {
                    if (standard.name.Contains("5.OA"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("5.NBT"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("5.MD"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("5.G"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("5.NF"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
            else if (dependencies[1].Equals("English"))
            {
                foreach (Standards standard in LoadingScreen.Settings.classes[4].courses[1].standards)
                {
                    if (standard.name.Contains("RL.5"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RI.5"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("RF.5"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("W.5"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("SL.5"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                    else if (standard.name.Contains("L.5"))
                    {
                        foreach (Games game in standard.games)
                        {
                            if (checkVorbedingung(standard.vorbedingungen))
                                games.Add(game);
                        }
                        return games;
                    }
                }
            }
        }
        return games;
    }

    private static bool checkVorbedingung(string[] vorbedingungen) {
        if(vorbedingungen.Length == 0) {
            return true;
        }
        if(playedGames.Count == 0) {
            return false;
        } else {
            foreach(string standard in vorbedingungen) {
                if (playedGames.Contains(standard)) {
                    if (!(playedGames[standard].ToString().Equals("1")))
                        return false;
                } else {
                    return false;
                }
            }
        }
        return true;
    }
}
