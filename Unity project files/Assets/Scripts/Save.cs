using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using System.IO;
using TMPro;
using SimpleFileBrowser;
using UnityEngine.InputSystem;

public class Save : MonoBehaviour
{

    private TMP_InputField InputField_Path;
    private string filePath;
    private string fileName;
    private string fullPath;
    public static Save instance;
    private GameObject warningBox;
    Action saveAction;
    Action openFolderAction;
    private Toggle Toggle_Compact;
    public TMP_Dropdown dropdown;

    void Awake() {

        Action openFolderAction = () => {
            OpenFolderButtonClicked();
        };

        Action saveAction = () => {
            SaveButtonClicked();
        };
        Button SaveButton = GameObject.Find("SaveButton").GetComponent<Button>();
        SaveButton.onClick.AddListener(() => {
           if (GameObject.Find("PopUp(Clone)") != null) return; 

            Popup popup = UIController.Instance.CreatePopup();
            popup.Init(UIController.Instance.MainCanvas, openFolderAction, saveAction);
            InputField_Path = GameObject.Find("FilePath").GetComponent<TMP_InputField>();
            string tempPath = SaveLoadManager.LoadPath() + "\\"  + SaveLoadManager.LoadName();
            InputField_Path.text = ((File.Exists(tempPath + ".txt")) ? tempPath + " (1)" : tempPath);
            warningBox = GameObject.Find("WarningBox");
            warningBox.SetActive(false);
            FileBrowser.SetDefaultFilter(".txt");
            dropdown = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
        });
    }

    void OpenFolderButtonClicked()
    {
        StartCoroutine( ShowFolderCoroutine() );
    }
    
    public int[] getIndices(){
        bool[] boolArray = new bool[8]{SimController.thicknessb, SimController.massb, SimController.frictionb, SimController.bouncinessb, SimController.ilvb, SimController.iavb, SimController.angleb, SimController.heightb};
        int length = 0;
        for (int j = 0; j < 8; j++){
            length += ((boolArray[j]) ? 1 : 0);
        }
        int[] indices = new int[length];
        int i = 0;
        for (int j = 0; j < 8; j++) {
            if (boolArray[j]) indices[i++] = j;
        }
        return indices;
    }
    
    void SaveButtonClicked(){
        fullPath = InputField_Path.text;
        if (!Directory.Exists(FileBrowserHelpers.GetDirectoryName(fullPath))){
            warningBox.SetActive(true);
            Invoke("DisableText", 3f);
            return;
        }

        filePath = FileBrowserHelpers.GetDirectoryName(fullPath);
        fileName = FileBrowserHelpers.GetFilename(fullPath);
        SaveLoadManager.SavePath(filePath);
        SaveLoadManager.SaveName(fileName);
        SaveData(fullPath + ((dropdown.value == 1) ? SimController.CoinState.fileNameSuffix(getIndices()) : "") + ".txt");
        GameObject.Destroy(GameObject.Find("PopUp(Clone)").gameObject);
    }

    void DisableText() {
        warningBox.SetActive(false);
    }

    IEnumerator ShowFolderCoroutine()
    {
        FileBrowser.AddQuickLink("Last location", filePath, null);
        yield return FileBrowser.WaitForSaveDialog( FileBrowser.PickMode.FilesAndFolders, false, SaveLoadManager.LoadPath(), SaveLoadManager.LoadName(), "Save", "Save" );
        
        if (FileBrowser.Success){
            InputField_Path.text = ((File.Exists(FileBrowser.Result[0] + ".txt")) ? (FileBrowser.Result[0] + " (1)") : (FileBrowser.Result[0]));
        }
    }

    void SaveData(string fullPath)
    {
        switch(dropdown.value){
            case 0: 
                normal(fullPath);
                break;
            case 1:
                compact(fullPath);
                break;
            case 2:
                probabilities(fullPath);
                break;
            case 3:
                header(fullPath);
                break;
        }
    }

    void normal(string fullPath){
        var sc = SimController.CoinStates;
        StreamWriter sw = new StreamWriter(fullPath);
        
        sw.WriteLine("Parameters:");

        if (SimController.thicknessb) {
            sw.WriteLine("Thickness range: " + SimController.thickness + " - " + SimController.thickness2 + " Elements: " + SimController.thickness3);
        } else {
            sw.WriteLine("Thickness value: " + SimController.thickness);
        }

        if (SimController.massb) {
            sw.WriteLine("Mass range: " + SimController.mass + " - " + SimController.mass2 + " Elements: " + SimController.mass3);
        } else {
            sw.WriteLine("Mass value: " + SimController.mass);
        }

        if (SimController.frictionb) {
            sw.WriteLine("Friction coefficient range: " + SimController.friction + " - " + SimController.friction2 + " Elements: " + SimController.friction3);
        } else {
            sw.WriteLine("Friction coefficient value: " + SimController.friction);
        }

        if (SimController.bouncinessb) {
            sw.WriteLine("Bounciness range: " + SimController.bounciness + " - " + SimController.bounciness2 + " Elements: " + SimController.bounciness3);
        } else {
            sw.WriteLine("Bounciness value: " + SimController.bounciness);
        }

        if (SimController.ilvb) {
            sw.WriteLine("Initial linear velocity range: " + SimController.ilv + " - " + SimController.ilv2 + " Elements: " + SimController.ilv3);
        } else {
            sw.WriteLine("Initial linear velocity value: " + SimController.ilv);
        }

        if (SimController.iavb) {
            sw.WriteLine("Initial angular velocity range: " + SimController.iav + " - " + SimController.iav2 + " Elements: " + SimController.iav3);
        } else {
            sw.WriteLine("Initial angular velocity value: " + SimController.iav);
        }

        if (SimController.angleb) {
            sw.WriteLine("Initial angle range: " + SimController.angle + " - " + SimController.angle2 + " Elements: " + SimController.angle3);
        } else {
            sw.WriteLine("Initial angle value: " + SimController.angle);
        }

        if (SimController.heightb) {
            sw.WriteLine("Initial height range: " + SimController.height + " - " + SimController.height2 + " Elements: " + SimController.height3);
        } else {
            sw.WriteLine("Initial height value: " + SimController.height);
        }

        for (int i = 0; i < sc.Length; i++){
            sw.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", Math.Round(sc[i].thickness, 4), Math.Round(sc[i].mass, 4), Math.Round(sc[i].friction, 4), Math.Round(sc[i].bounciness, 4), Math.Round(sc[i].ilv, 4), Math.Round(sc[i].iav, 4), Math.Round(sc[i].angle, 4), Math.Round(sc[i].height, 4), sc[i].result);
        }
        sw.Close();
    }

    void compact(string fullPath){
        var sc = SimController.CoinStates;
        StreamWriter sw = new StreamWriter(fullPath);
        int[] indices = getIndices();

        for (int r = 0; r < sc.Length; r++){
            sw.WriteLine(sc[r].getString(indices));
        }
        sw.Close();
    }

    void probabilities(string fullPath){
        StreamWriter sw = new StreamWriter(fullPath);
        float[][] result = SimController.CoinState.getProbability(SimController.CoinStates, SimController.bounds);
        int[] indices = getIndices();
        for (int i = 0; i < result.Length; i++){
            string output = "";
            for (int j = 0; j < 4 && j < indices.Length; j++){
                output = ((indices[j] < 4) ? SimController.makeString(output, result[i][indices[j]]) : output);
            }
            for (int j = 4; j < 7; j++){
                output = SimController.makeString(output, result[i][j]);
            }
            sw.WriteLine(output);
        }
        sw.Close();
    }

    void header(string fullPath){
        StreamWriter sw = new StreamWriter(fullPath);
        
        sw.WriteLine("Parameters:");

        if (SimController.thicknessb) {
            sw.WriteLine("Thickness range: " + SimController.thickness + " - " + SimController.thickness2 + " Elements: " + SimController.thickness3);
        } else {
            sw.WriteLine("Thickness value: " + SimController.thickness);
        }

        if (SimController.massb) {
            sw.WriteLine("Mass range: " + SimController.mass + " - " + SimController.mass2 + " Elements: " + SimController.mass3);
        } else {
            sw.WriteLine("Mass value: " + SimController.mass);
        }

        if (SimController.frictionb) {
            sw.WriteLine("Friction coefficient range: " + SimController.friction + " - " + SimController.friction2 + " Elements: " + SimController.friction3);
        } else {
            sw.WriteLine("Friction coefficient value: " + SimController.friction);
        }

        if (SimController.bouncinessb) {
            sw.WriteLine("Bounciness range: " + SimController.bounciness + " - " + SimController.bounciness2 + " Elements: " + SimController.bounciness3);
        } else {
            sw.WriteLine("Bounciness value: " + SimController.bounciness);
        }

        if (SimController.ilvb) {
            sw.WriteLine("Initial linear velocity range: " + SimController.ilv + " - " + SimController.ilv2 + " Elements: " + SimController.ilv3);
        } else {
            sw.WriteLine("Initial linear velocity value: " + SimController.ilv);
        }

        if (SimController.iavb) {
            sw.WriteLine("Initial angular velocity range: " + SimController.iav + " - " + SimController.iav2 + " Elements: " + SimController.iav3);
        } else {
            sw.WriteLine("Initial angular velocity value: " + SimController.iav);
        }

        if (SimController.angleb) {
            sw.WriteLine("Initial angle range: " + SimController.angle + " - " + SimController.angle2 + " Elements: " + SimController.angle3);
        } else {
            sw.WriteLine("Initial angle value: " + SimController.angle);
        }

        if (SimController.heightb) {
            sw.WriteLine("Initial height range: " + SimController.height + " - " + SimController.height2 + " Elements: " + SimController.height3);
        } else {
            sw.WriteLine("Initial height value: " + SimController.height);
        }

        sw.Close();
    }
}