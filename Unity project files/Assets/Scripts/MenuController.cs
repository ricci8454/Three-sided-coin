using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static TMP_InputField _inputFieldThickness;
    public static Toggle _thicknessToggle;
    public static TMP_InputField _inputFieldThickness2;
    public static TMP_InputField _inputFieldThickness3;
    public static GameObject thicknessCover;

    public static TMP_InputField _inputFieldMass;
    public static Toggle _massToggle;
    public static TMP_InputField _inputFieldMass2;
    public static TMP_InputField _inputFieldMass3;
    public static GameObject massCover;

    public static TMP_InputField _inputFieldIlv;
    public static Toggle _ilvToggle;
    public static TMP_InputField _inputFieldIlv2;
    public static TMP_InputField _inputFieldIlv3;
    public static GameObject ilvCover;

    public static TMP_InputField _inputFieldIav;
    public static Toggle _iavToggle;
    public static TMP_InputField _inputFieldIav2;
    public static TMP_InputField _inputFieldIav3;
    public static GameObject iavCover;

    public static TMP_InputField _inputFieldFriction;
    public static Toggle _frictionToggle;
    public static TMP_InputField _inputFieldFriction2;
    public static TMP_InputField _inputFieldFriction3;
    public static GameObject frictionCover;

    public static TMP_InputField _inputFieldAngle;
    public static Toggle _angleToggle;
    public static TMP_InputField _inputFieldAngle2;
    public static TMP_InputField _inputFieldAngle3;
    public static GameObject angleCover;

    public static TMP_InputField _inputFieldHeight;
    public static Toggle _heightToggle;
    public static TMP_InputField _inputFieldHeight2;
    public static TMP_InputField _inputFieldHeight3;
    public static GameObject heightCover;

    public static TMP_InputField _inputFieldBounciness;
    public static Toggle _bouncinessToggle;
    public static TMP_InputField _inputFieldBounciness2;
    public static TMP_InputField _inputFieldBounciness3;
    public static GameObject bouncinessCover;

    public static TMP_InputField _inputFieldCoins;
    public static TMP_InputField _inputFieldTime;


    private void Start()
    {
        GameObject.Find("ExitButton").GetComponent<Button>().onClick.AddListener(OnExitClicked);
        GameObject.Find("RunButton").GetComponent<Button>().onClick.AddListener(OnRunClicked);

        _inputFieldThickness = GameObject.Find("InputField_Thickness").GetComponent<TMP_InputField>();
        _thicknessToggle = GameObject.Find("Toggle_Thickness").GetComponent<Toggle>();
        _inputFieldThickness2 = GameObject.Find("InputField_Thickness2").GetComponent<TMP_InputField>();
        _inputFieldThickness3 = GameObject.Find("InputField_Thickness3").GetComponent<TMP_InputField>();
        thicknessCover = GameObject.Find("Cover_Thickness");

        _inputFieldMass = GameObject.Find("InputField_Mass").GetComponent<TMP_InputField>();
        _massToggle = GameObject.Find("Toggle_Mass").GetComponent<Toggle>();
        _inputFieldMass2 = GameObject.Find("InputField_Mass2").GetComponent<TMP_InputField>();
        _inputFieldMass3 = GameObject.Find("InputField_Mass3").GetComponent<TMP_InputField>();
        massCover = GameObject.Find("Cover_Mass");

        _inputFieldIlv = GameObject.Find("InputField_ILV").GetComponent<TMP_InputField>();
        _ilvToggle = GameObject.Find("Toggle_ILV").GetComponent<Toggle>();
        _inputFieldIlv2 = GameObject.Find("InputField_ILV2").GetComponent<TMP_InputField>();
        _inputFieldIlv3 = GameObject.Find("InputField_ILV3").GetComponent<TMP_InputField>();
        ilvCover = GameObject.Find("Cover_ILV");

        _inputFieldIav = GameObject.Find("InputField_IAV").GetComponent<TMP_InputField>();
        _iavToggle = GameObject.Find("Toggle_IAV").GetComponent<Toggle>();
        _inputFieldIav2 = GameObject.Find("InputField_IAV2").GetComponent<TMP_InputField>();
        _inputFieldIav3 = GameObject.Find("InputField_IAV3").GetComponent<TMP_InputField>();
        iavCover = GameObject.Find("Cover_IAV");

        _inputFieldFriction = GameObject.Find("InputField_Friction").GetComponent<TMP_InputField>();
        _frictionToggle = GameObject.Find("Toggle_Friction").GetComponent<Toggle>();
        _inputFieldFriction2 = GameObject.Find("InputField_Friction2").GetComponent<TMP_InputField>();
        _inputFieldFriction3 = GameObject.Find("InputField_Friction3").GetComponent<TMP_InputField>();
        frictionCover = GameObject.Find("Cover_Friction");

        _inputFieldAngle = GameObject.Find("InputField_Angle").GetComponent<TMP_InputField>();
        _angleToggle = GameObject.Find("Toggle_Angle").GetComponent<Toggle>();
        _inputFieldAngle2 = GameObject.Find("InputField_Angle2").GetComponent<TMP_InputField>();
        _inputFieldAngle3 = GameObject.Find("InputField_Angle3").GetComponent<TMP_InputField>();
        angleCover = GameObject.Find("Cover_Angle");

        _inputFieldHeight = GameObject.Find("InputField_Height").GetComponent<TMP_InputField>();
        _heightToggle = GameObject.Find("Toggle_Height").GetComponent<Toggle>();
        _inputFieldHeight2 = GameObject.Find("InputField_Height2").GetComponent<TMP_InputField>();
        _inputFieldHeight3 = GameObject.Find("InputField_Height3").GetComponent<TMP_InputField>();
        heightCover = GameObject.Find("Cover_Height");

        _inputFieldBounciness = GameObject.Find("InputField_Bounciness").GetComponent<TMP_InputField>();
        _bouncinessToggle = GameObject.Find("Toggle_Bounciness").GetComponent<Toggle>();
        _inputFieldBounciness2 = GameObject.Find("InputField_Bounciness2").GetComponent<TMP_InputField>();
        _inputFieldBounciness3 = GameObject.Find("InputField_Bounciness3").GetComponent<TMP_InputField>();
        bouncinessCover = GameObject.Find("Cover_Bounciness");

        _inputFieldCoins = GameObject.Find("InputField_Coins").GetComponent<TMP_InputField>();
        _inputFieldTime = GameObject.Find("InputField_Time").GetComponent<TMP_InputField>();


        _thicknessToggle.onValueChanged.AddListener((on) => {thicknessCover.GetComponent<Image>().enabled = !thicknessCover.GetComponent<Image>().enabled;}); //(on) =>  (!thicknessCover.activeSelf)
        _massToggle.onValueChanged.AddListener((on) => {massCover.GetComponent<Image>().enabled = !massCover.GetComponent<Image>().enabled;}); 
        _iavToggle.onValueChanged.AddListener((on) => {iavCover.GetComponent<Image>().enabled = !iavCover.GetComponent<Image>().enabled;}); 
        _ilvToggle.onValueChanged.AddListener((on) => {ilvCover.GetComponent<Image>().enabled = !ilvCover.GetComponent<Image>().enabled;}); 
        _frictionToggle.onValueChanged.AddListener((on) => {frictionCover.GetComponent<Image>().enabled = !frictionCover.GetComponent<Image>().enabled;}); 
        _angleToggle.onValueChanged.AddListener((on) => {angleCover.GetComponent<Image>().enabled = !angleCover.GetComponent<Image>().enabled;}); 
        _heightToggle.onValueChanged.AddListener((on) => {heightCover.GetComponent<Image>().enabled = !heightCover.GetComponent<Image>().enabled;}); 
        _bouncinessToggle.onValueChanged.AddListener((on) => {bouncinessCover.GetComponent<Image>().enabled = !bouncinessCover.GetComponent<Image>().enabled;});         
        LoadVariables();
    }

    public static void LoadVariables()
    {    
        _inputFieldThickness.text = SaveLoadManager.LoadThickness()[0].ToString();
        _inputFieldThickness2.text = SaveLoadManager.LoadThickness()[1].ToString();
        _inputFieldThickness3.text = SaveLoadManager.LoadThickness()[2].ToString();
        if (SaveLoadManager.LoadThickness()[3] == 0){
            _thicknessToggle.isOn = false;
        } else {
            _thicknessToggle.isOn = true;
        }

        _inputFieldMass.text = SaveLoadManager.LoadMass()[0].ToString();
        _inputFieldMass2.text = SaveLoadManager.LoadMass()[1].ToString();
        _inputFieldMass3.text = SaveLoadManager.LoadMass()[2].ToString();
        if (SaveLoadManager.LoadMass()[3] == 0){
            _massToggle.isOn = false;
        } else {
            _massToggle.isOn = true;
        }

        _inputFieldIlv.text = SaveLoadManager.LoadILV()[0].ToString();
        _inputFieldIlv2.text = SaveLoadManager.LoadILV()[1].ToString();
        _inputFieldIlv3.text = SaveLoadManager.LoadILV()[2].ToString();
        if (SaveLoadManager.LoadILV()[3] == 0){
            _ilvToggle.isOn = false;
        } else {
            _ilvToggle.isOn = true;
        }
        
        _inputFieldIav.text = SaveLoadManager.LoadIAV()[0].ToString();
        _inputFieldIav2.text = SaveLoadManager.LoadIAV()[1].ToString();
        _inputFieldIav3.text = SaveLoadManager.LoadIAV()[2].ToString();
        if (SaveLoadManager.LoadIAV()[3] == 0){
            _iavToggle.isOn = false;
        } else {
            _iavToggle.isOn = true;
        }

        _inputFieldFriction.text = SaveLoadManager.LoadFriction()[0].ToString();
        _inputFieldFriction2.text = SaveLoadManager.LoadFriction()[1].ToString();
        _inputFieldFriction3.text = SaveLoadManager.LoadFriction()[2].ToString();
        if (SaveLoadManager.LoadFriction()[3] == 0){
            _frictionToggle.isOn = false;
        } else {
            _frictionToggle.isOn = true;
        }

        _inputFieldAngle.text = SaveLoadManager.LoadAngle()[0].ToString();
        _inputFieldAngle2.text = SaveLoadManager.LoadAngle()[1].ToString();
        _inputFieldAngle3.text = SaveLoadManager.LoadAngle()[2].ToString();
        if (SaveLoadManager.LoadAngle()[3] == 0){
            _angleToggle.isOn = false;
        } else {
            _angleToggle.isOn = true;
        }

        _inputFieldHeight.text = SaveLoadManager.LoadHeight()[0].ToString();
        _inputFieldHeight2.text = SaveLoadManager.LoadHeight()[1].ToString();
        _inputFieldHeight3.text = SaveLoadManager.LoadHeight()[2].ToString();
        if (SaveLoadManager.LoadHeight()[3] == 0){
            _heightToggle.isOn = false;
        } else {
            _heightToggle.isOn = true;
        }

        _inputFieldBounciness.text = SaveLoadManager.LoadBounciness()[0].ToString();
        _inputFieldBounciness2.text = SaveLoadManager.LoadBounciness()[1].ToString();
        _inputFieldBounciness3.text = SaveLoadManager.LoadBounciness()[2].ToString();
        if (SaveLoadManager.LoadBounciness()[3] == 0){
            _bouncinessToggle.isOn = false;
        } else {
            _bouncinessToggle.isOn = true;
        }

        _inputFieldCoins.text = SaveLoadManager.LoadCoins().ToString();
        _inputFieldTime.text = SaveLoadManager.LoadTime().ToString();

    }

    private void OnExitClicked()
    {   
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    private void OnRunClicked()
    {
        if (_thicknessToggle.isOn) {
            SaveLoadManager.SaveThickness(float.Parse(_inputFieldThickness.text), float.Parse(_inputFieldThickness2.text), int.Parse(_inputFieldThickness3.text), _thicknessToggle.isOn);
        } else {
            SaveLoadManager.SaveThickness2(float.Parse(_inputFieldThickness.text), _thicknessToggle.isOn);
        }

        if (_massToggle.isOn) {
            SaveLoadManager.SaveMass(float.Parse(_inputFieldMass.text), float.Parse(_inputFieldMass2.text), int.Parse(_inputFieldMass3.text), _massToggle.isOn);
        } else {
            SaveLoadManager.SaveMass2(float.Parse(_inputFieldMass.text), _massToggle.isOn);
        }
        
        if (_ilvToggle.isOn) {
            SaveLoadManager.SaveILV(float.Parse(_inputFieldIlv.text), float.Parse(_inputFieldIlv2.text), int.Parse(_inputFieldIlv3.text), _ilvToggle.isOn);
        } else {
            SaveLoadManager.SaveILV2(float.Parse(_inputFieldIlv.text), _ilvToggle.isOn);
        }

        if (_iavToggle.isOn) {
            SaveLoadManager.SaveIAV(float.Parse(_inputFieldIav.text), float.Parse(_inputFieldIav2.text), int.Parse(_inputFieldIav3.text), _iavToggle.isOn);
        } else {
            SaveLoadManager.SaveIAV2(float.Parse(_inputFieldIav.text), _iavToggle.isOn);
        }

        if (_frictionToggle.isOn) {
            SaveLoadManager.SaveFriction(float.Parse(_inputFieldFriction.text), float.Parse(_inputFieldFriction2.text), int.Parse(_inputFieldFriction3.text), _frictionToggle.isOn);
        } else {
            SaveLoadManager.SaveFriction2(float.Parse(_inputFieldFriction.text), _frictionToggle.isOn);
        }

        if (_angleToggle.isOn) {
            SaveLoadManager.SaveAngle(float.Parse(_inputFieldAngle.text), float.Parse(_inputFieldAngle2.text), int.Parse(_inputFieldAngle3.text), _angleToggle.isOn);
        } else {
            SaveLoadManager.SaveAngle2(float.Parse(_inputFieldAngle.text), _angleToggle.isOn);
        }

        if (_heightToggle.isOn) {
            SaveLoadManager.SaveHeight(float.Parse(_inputFieldHeight.text), float.Parse(_inputFieldHeight2.text), int.Parse(_inputFieldHeight3.text), _heightToggle.isOn);
        } else {
            SaveLoadManager.SaveHeight2(float.Parse(_inputFieldHeight.text), _heightToggle.isOn);
        }

        if (_bouncinessToggle.isOn) {
            SaveLoadManager.SaveBounciness(float.Parse(_inputFieldBounciness.text), float.Parse(_inputFieldBounciness2.text), int.Parse(_inputFieldBounciness3.text), _bouncinessToggle.isOn);
        } else {
            SaveLoadManager.SaveBounciness2(float.Parse(_inputFieldBounciness.text), _bouncinessToggle.isOn);
        }

        SaveLoadManager.SaveCoins(int.Parse(_inputFieldCoins.text));
        SaveLoadManager.SaveTime(int.Parse(_inputFieldTime.text));

        SceneManager.LoadScene("SimScene");
    }
}
