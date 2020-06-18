using UnityEngine;
using System.Collections;
using System.IO;
using System;

public interface IFileIO
{
    void writeFileToDisc(string description);
}
public class FileIO : IFileIO
{
    public void writeFileToDisc(string description)
    {
        string pathToSave = @"D:\UnityProject\BezierTest2\Assets\log.txt"; //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        File.AppendAllText(pathToSave,description + ";" );
    }

}
