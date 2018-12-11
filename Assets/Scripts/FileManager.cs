using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour {

    protected StreamReader reader = null;
    protected StreamWriter writer = null;
    protected string text = "";

	public FileManager(){
    }

    public int getRecord()
    {
        reader = new StreamReader(Application.dataPath + "/Files/record.txt");
        int rec=0;

        if (text != null)
        {
            text = reader.ReadLine();
        }

        rec = Convert.ToInt32(text);
        reader.Close();
        return rec;
    }

    public void setRecord(int rec)
    {
        writer = new StreamWriter(Application.dataPath + "/Files/record.txt");

        writer.Write(Convert.ToString(rec));
        writer.Close();
    }

    public int getScore()
    {
        reader = new StreamReader(Application.dataPath + "/Files/score.txt");
        int sco=0;

        if (text != null)
        {
            text = reader.ReadLine();
        }

        sco = Convert.ToInt32(text);
        reader.Close();
        return sco;
    }

    public void setScore(int sco)
    {
        writer = new StreamWriter(Application.dataPath + "/Files/score.txt");

        writer.Write(Convert.ToString(sco));
        writer.Close();
    }
}
