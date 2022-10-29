using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimController : MonoBehaviour
{
    public TextMeshProUGUI ParamsText;
    public TextMeshProUGUI ResultsText;
    public TextMeshProUGUI ThrowText;
    private GameObject BackButton;
    private GameObject SaveButton;
    public float D;
    public CoinState instance;

    public GameObject CoinPrefab;
    public PhysicsMaterial2D FloorPhysMat;

    private Transform _coinParent;

    public static float thickness;
    public static float thickness2;
    public static int thickness3;
    public static bool thicknessb;
    public static float[] thicknessv;

    public static float mass;
    public static float mass2;
    public static int mass3;
    public static bool massb;
    public static float[] massv;

    public static float ilv;
    public static float ilv2;
    public static int ilv3;
    public static bool ilvb;
    public static float[] ilvv;

    public static float iav;
    public static float iav2;
    public static int iav3;
    public static bool iavb;
    public static float[] iavv;

    public static float friction;
    public static float friction2;
    public static int friction3;
    public static bool frictionb;
    public static float[] frictionv;

    public static float angle;
    public static float angle2;
    public static int angle3;
    public static bool angleb;
    public static float[] anglev;

    public static float height;
    public static float height2;
    public static int height3;
    public static bool heightb;
    public static float[] heightv;

    public static float bounciness;
    public static float bounciness2;
    public static int bounciness3;
    public static bool bouncinessb;
    public static float[] bouncinessv;

    private int coins;

    public static GameObject[] _coinObjects;
    public static CoinState[] CoinStates;
    public static int[] bounds;
    private int NOC;
    private int thrownCoins;
    public static PhysicsMaterial2D placeholderMat;

    private float _coinDiameter = 1f;
    public static float _waitTime;

    public static int _faceUp = 0;
    public static int _faceDown = 0;
    public static int _faceEdge = 0;

    public class CoinState 
    {
        public float thickness;
        public float mass;
        public float ilv;
        public float iav;
        public float friction;
        public float angle;
        public float height;
        public float bounciness;
        public string result;


        public CoinState(float aThickness, float aMass, float aIlv, float aIav, float aFriction, float aAngle, float aHeight, float aBounciness, string aResult)
        {
            thickness = aThickness;
            mass = aMass;
            ilv = aIlv;
            iav = aIav;
            friction = aFriction;
            angle = aAngle;
            height = aHeight;
            result = aResult;
            bounciness = aBounciness;
        }
        public CoinState(){}

        public string getString(int[] array){
            string output = ""; 
            for (int i = 0; i < array.Length; i++){
                switch(array[i]){
                    case 0: 
                        output = makeString(output, thickness);
                        break;
                    case 1: 
                        output = makeString(output, mass);
                        break;
                    case 2: 
                        output = makeString(output, friction);
                        break;
                    case 3: 
                        output = makeString(output, bounciness);
                        break;
                    case 4: 
                        output = makeString(output, ilv);
                        break;
                    case 5: 
                        output = makeString(output, iav);
                        break;
                    case 6: 
                        output = makeString(output, angle);
                        break;
                    case 7:
                        output = makeString(output, height);
                        break;
                }
            }
            return output + result;            
        }
        public static string fileNameSuffix(int[] array){
            string output = " (";
            for (int i = 0; i < array.Length; i++){
                switch(array[i]){
                    case 0: output += "thickness";
                        break;
                    case 1: output += "mass";
                        break;
                    case 2: output += "friction";
                        break;
                    case 3: output += "bounciness";
                        break;
                    case 4: output += "ilv";
                        break;
                    case 5: output += "iav";
                        break;
                    case 6: output += "angle";
                        break;
                    case 7: output += "height";
                        break;
                }
                output += ((i < array.Length-1) ? ", " : "");
            }
            return output + ")";
        }
        
        public static float[][] getProbability(CoinState[] sc, int[] bounds){
            int[] ind = new int[]{0, 0, 0, 0, 0, 0, 0, 0};
            float[][] result = new float[bounds[0] * bounds[1] * bounds[2] * bounds[3]][];
            int headsCount, tailsCount, edgeCount;
            int sum = 0;
            int j = 0;
            float total = bounds[4] * bounds[5] * bounds[6] * bounds[7];
            for (;ind[0] < bounds[0]; ind[0] += 1 + (ind[1] = 0)){
                for (;ind[1] < bounds[1]; ind[1] += 1 + (ind[2] = 0)){
                    for (;ind[2] < bounds[2]; ind[2] += 1 + (ind[3] = 0)){
                        for (;ind[3] < bounds[3]; ind[3] += 1 + (ind[4] = 0)){
                            headsCount = (tailsCount = (edgeCount = 0));
                            for (;ind[4] < bounds[4]; ind[4] += 1 + (ind[5] = 0)){
                                for (;ind[5] < bounds[5]; ind[5] += 1 + (ind[6] = 0)){
                                    for (;ind[6] < bounds[6]; ind[6] += 1 + (ind[7] = 0)){
                                        for (;ind[7] < bounds[7]; ind[7]+= 1 + 0 * sum++){
                                            switch(sc[sum].result){
                                                case "H":
                                                    headsCount++;
                                                    break;
                                                case "T":
                                                    tailsCount++;
                                                    break;
                                                case "E":
                                                    edgeCount++;
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            result[j] = new float[7]{thicknessv[ind[0]], massv[ind[1]], frictionv[ind[2]], bouncinessv[ind[3]], headsCount/total, tailsCount/total, edgeCount/total};
                            j++;
                        }
                    }
                }
            }          
            return result;
        } /*(thicknessv[ind[0]], massv[ind[1]], ilvv[ind[4]], iavv[ind[5]], frictionv[ind[2]], anglev[ind[6]], heightv[ind[7]], bouncinessv[ind[3]]*/
    }


    void Start()
    {
        _coinParent = transform.Find("CoinParent");
        
        SaveButton = GameObject.Find("SaveButton");
        SaveButton.SetActive(false);


        BackButton = GameObject.Find("BackButton");
        BackButton.GetComponent<Button>().onClick.AddListener(OnBackButtonClicked);

        thickness = SaveLoadManager.LoadThickness()[0];
        thickness2 = SaveLoadManager.LoadThickness()[1];
        thickness3 = (int)Math.Round(SaveLoadManager.LoadThickness()[2]);
        if (SaveLoadManager.LoadThickness()[3] == 1) {
            thicknessb = true;
        } else {
            thicknessb = false;
        }


        if (thickness < 0.01f)
            thickness = 0.01f;
        if (thickness > 10f)
            thickness = 10f;
        else if (thickness2 > 10f)
            thickness = 10f;

        mass = SaveLoadManager.LoadMass()[0];
        mass2 = SaveLoadManager.LoadMass()[1];
        mass3 = (int)Math.Round(SaveLoadManager.LoadMass()[2]);
        if (SaveLoadManager.LoadMass()[3] == 1) {
            massb = true;
        } else {
            massb = false;
        }

        if (mass < 0.01f)
            mass = 0.01f;

        ilv = SaveLoadManager.LoadILV()[0];
        ilv2 = SaveLoadManager.LoadILV()[1];
        ilv3 = (int)Math.Round(SaveLoadManager.LoadILV()[2]);
        if (SaveLoadManager.LoadILV()[3] == 1) {
            ilvb = true;
        } else {
            ilvb = false;
        }

        iav = SaveLoadManager.LoadIAV()[0];
        iav2 = SaveLoadManager.LoadIAV()[1];
        iav3 = (int)Math.Round(SaveLoadManager.LoadIAV()[2]);
        if (SaveLoadManager.LoadIAV()[3] == 1) {
            iavb = true;
        } else {
            iavb = false;
        }

        friction = SaveLoadManager.LoadFriction()[0];
        friction2 = SaveLoadManager.LoadFriction()[1];
        friction3 = (int)Math.Round(SaveLoadManager.LoadFriction()[2]);

        if (SaveLoadManager.LoadFriction()[3] == 1) {
            frictionb = true;
        } else {
            frictionb = false;
        }

        if (friction < 0f)
            friction = 0f;
        else if (friction > 1f)
            friction = 1f;

        bounciness = SaveLoadManager.LoadBounciness()[0];
        bounciness2 = SaveLoadManager.LoadBounciness()[1];
        bounciness3 = (int)Math.Round(SaveLoadManager.LoadBounciness()[2]);

        if (SaveLoadManager.LoadBounciness()[3] == 1) {
            bouncinessb = true;
        } else {
            bouncinessb = false;
        }

        if (bounciness < 0f)
            bounciness = 0f;
        else if (bounciness > 1f)
            bounciness = 1f;
        
        angle = SaveLoadManager.LoadAngle()[0];
        angle2 = SaveLoadManager.LoadAngle()[1];
        angle3 = (int)Math.Round(SaveLoadManager.LoadAngle()[2]);

        if (SaveLoadManager.LoadAngle()[3] == 1) {
            angleb = true;
        } else {
            angleb = false;
        }


        height = SaveLoadManager.LoadHeight()[0];
        height2 = SaveLoadManager.LoadHeight()[1];
        height3 = (int)Math.Round(SaveLoadManager.LoadHeight()[2]);
        if (SaveLoadManager.LoadHeight()[3] == 1) {
            heightb = true;
        } else {
            heightb = false;
        }
      

        coins = SaveLoadManager.LoadCoins();
        _waitTime = (float)SaveLoadManager.LoadTime();

        if (coins < 1)
            coins = 1; 

        NOC = 1; // Number Of Coins

        if (thicknessb) {
            NOC *= thickness3;
        }
        if (massb) {
            NOC *= mass3;
        }
        if (ilvb) {
            NOC *= ilv3;
        }
        if (iavb) {
            NOC *= iav3;
        }
        if (heightb) {
            NOC *= height3;
        }
        if (frictionb) {
            NOC *= friction3;
        }
        if (bouncinessb) {
            NOC *= bounciness3;
        }
        if (angleb) {
            NOC *= angle3;
        }

        string text1 = thicknessb ? "Range: [" + thickness.ToString() + ", " + thickness2.ToString() + "], Elements: " + thickness3.ToString() : thickness.ToString();
        string text2 = massb ? "Range: [" + mass.ToString() + ", " + mass2.ToString() + "], Elements: " + mass3.ToString() : mass.ToString();
        string text5 = ilvb ? "Range: [" + ilv.ToString() + ", " + ilv2.ToString() + "], Elements: " + ilv3.ToString() : ilv.ToString();
        string text6 = iavb ? "Range: [" + iav.ToString() + ", " + iav2.ToString() + "], Elements: " + iav3.ToString() : iav.ToString();
        string text3 = frictionb ? "Range: [" + friction.ToString() + ", " + friction2.ToString() + "], Elements: " + friction3.ToString() : friction.ToString();
        string text7 = angleb ? "Range: [" + angle.ToString() + ", " + angle2.ToString() + "], Elements: " + angle3.ToString() : angle.ToString();
        string text8 = heightb ? "Range: [" + height.ToString() + ", " + height2.ToString() + "], Elements: " + height3.ToString() : height.ToString();
        string text4 = bouncinessb ? "Range: [" + bounciness.ToString() + ", " + bounciness2.ToString() + "], Elements: " + bounciness3.ToString() : bounciness.ToString();

        ParamsText.text = string.Format(CultureInfo.InvariantCulture, 
            "{0} total coin tosses, {1} per toss \n{10}s total time, {11}s per toss \nThickness: {2}\nMass: {3}\nFriction coefficient: {4}\nBounciness: {5}\nInitial linear velocity: {6}\nInitial angular velocity : {7}\nInitial angle: {8}\nInitial height: {9}",
           NOC, coins, text1, text2, text3, text4, text5, text6, text7, text8, (NOC + coins - 1)/coins * _waitTime, _waitTime);
        
             
        if (thicknessb) {
            thicknessv = new float[thickness3];
            D = (thickness2 - thickness)/(thickness3 - 1);
            for (int i = 0; i < thickness3; i++)
            {
                thicknessv[i] = thickness + i * D;
            }
        } else {
            thicknessv = new float[]{thickness};
        }

        if (massb) {
            massv = new float[mass3];
            D = (mass2 - mass)/(mass3 - 1);
            for (int i = 0; i < mass3; i++)
            {
                massv[i] = mass + i * D;
            }
        } else {
            massv = new float[]{mass};
        }

        if (ilvb) {
            ilvv = new float[ilv3];
            D = (ilv2 - ilv)/(ilv3 - 1);
            for (int i = 0; i < ilv3; i++)
            {
                ilvv[i] = ilv + i * D;
            }
        } else {
            ilvv = new float[]{ilv};
        }

        if (iavb) {
            iavv = new float[iav3];
            D = (iav2 - iav)/(iav3 - 1);
            for (int i = 0; i < iav3; i++)
            {
                iavv[i] = iav + i * D;
            }
        } else {
            iavv = new float[]{iav};
        }

        if (frictionb) {
            frictionv = new float[friction3];
            D = (friction2 - friction)/(friction3 - 1);
            for (int i = 0; i < friction3; i++)
            {
                frictionv[i] = friction + i * D;
            }
        } else {
            frictionv = new float[]{friction};
        }

        if (angleb) {
            anglev = new float[angle3];
            D = (angle2 - angle)/(angle3 - 1);
            for (int i = 0; i < angle3; i++)
            {
                anglev[i] = angle + i * D;
            }
        } else {
            anglev = new float[]{angle};
        }

        if (heightb) {
            heightv = new float[height3];
            D = (height2 - height)/(height3 - 1);
            for (int i = 0; i < height3; i++)
            {
                heightv[i] = height + i * D;
            }
        } else {
            heightv = new float[]{height};
        }

        if (bouncinessb) {
            bouncinessv = new float[bounciness3];
            D = (bounciness2 - bounciness)/(bounciness3 - 1);
            for (int i = 0; i < bounciness3; i++)
            {
                bouncinessv[i] = bounciness + i * D;
            }
        } else {
            bouncinessv = new float[]{bounciness};
        }

        int[] ind = new int[]{0, 0, 0, 0, 0, 0, 0, 0};
        bounds = new int[]{thicknessv.Length, massv.Length, frictionv.Length, bouncinessv.Length, ilvv.Length, iavv.Length, anglev.Length, heightv.Length};
        int sum = 0;
        CoinStates = new CoinState[NOC];
        while (ind[0] < bounds[0]){
            while (ind[1] < bounds[1]){
                while (ind[2] < bounds[2]){
                    while (ind[3] < bounds[3]){
                        while (ind[4] < bounds[4]){
                            while (ind[5] < bounds[5]){
                                while (ind[6] < bounds[6]){
                                    while (ind[7] < bounds[7])
                                    {
                                        CoinStates[sum] = new CoinState(thicknessv[ind[0]], massv[ind[1]], ilvv[ind[4]], iavv[ind[5]], frictionv[ind[2]], anglev[ind[6]], heightv[ind[7]], bouncinessv[ind[3]], " ");
                                        sum += 1;
                                        ind[7] += 1;
                                    }
                                    ind[7] = 0;
                                    ind[6] += 1;
                                }
                                ind[6] = 0;
                                ind[5] += 1;
                            }
                            ind[5] = 0;
                            ind[4] += 1;
                        }
                        ind[4] = 0;
                        ind[3] += 1;
                    }
                    ind[3] = 0;
                    ind[2] += 1;
                }
                ind[2] = 0;
                ind[1] += 1;
            }
            ind[1] = 0;
            ind[0] += 1;
        }

        _coinObjects = new GameObject[coins]; 

        FloorPhysMat.bounciness = 0;
        FloorPhysMat.friction = 1;

        thrownCoins = 0;
        StartCoroutine(DoThrows());
    }

    private void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
        MenuController.LoadVariables();
        _faceUp = 0;
        _faceDown = 0;
        _faceEdge = 0;
    }


    private IEnumerator DoThrows()
    {
        for(var i = 0; i < (NOC + coins - 1)/coins; i++)
        {
            yield return DoSingleThrow();
        }

        SaveButton.SetActive(true);

        ResultsText.text = string.Format(CultureInfo.InvariantCulture, "Results:\nUp: {0}\nDown: {1}\nEdge: {2}", 
        _faceUp, _faceDown, _faceEdge);
    }

    private IEnumerator DoSingleThrow()
    {
        int currentThrow = (int)thrownCoins/coins + 1;
        int totalThrows = (int) (NOC + coins - 1)/coins;
        ThrowText.text = string.Format("Throw: {0}/{1}", currentThrow, totalThrows);

        for (var i = 0; i < coins && i < NOC - thrownCoins; i++){
            _coinObjects[i] = Instantiate(CoinPrefab, _coinParent);
        }

        ThrowCoins();
        yield return new WaitForSeconds(_waitTime);

        for(var i = thrownCoins; i < thrownCoins + coins && i < NOC; i++)
        {
            var angleToUp = Vector2.Angle(_coinObjects[i - thrownCoins].transform.up, Vector2.up);
            var angleToDown = Vector2.Angle(_coinObjects[i - thrownCoins].transform.up, Vector2.down);

            if (angleToUp < 80) {
                _faceUp++;
                CoinStates[i].result = "H";
            } else if (angleToDown < 80) {
                _faceDown++;
                CoinStates[i].result = "T";
            } else {
                _faceEdge++;
                CoinStates[i].result = "E";
            }
        }

        for (var i = 0; i < coins && i < NOC - thrownCoins; i++) {
            Destroy(_coinObjects[i]);
        }
        thrownCoins += coins;
    }

    private void ThrowCoins()
    {   
        for(var i = thrownCoins; i < thrownCoins + coins && i < NOC; i++)
        {
            var coin = SimController._coinObjects[i - thrownCoins];

            coin.transform.position = new Vector2(0, CoinStates[i].height);
            coin.transform.rotation = Quaternion.Euler(0, 0, CoinStates[i].angle);
            coin.transform.localScale = new Vector2(_coinDiameter, CoinStates[i].thickness * _coinDiameter * 0.5f); // 0.5 necessary because of cylinder default size

            placeholderMat = new PhysicsMaterial2D("PhysMat" + i);
            placeholderMat.friction = CoinStates[i].friction;
            placeholderMat.bounciness = CoinStates[i].bounciness;
            coin.GetComponent<Collider2D>().sharedMaterial = placeholderMat;

            var rb = coin.GetComponent<Rigidbody2D>();
            rb.mass = CoinStates[i].mass; 
            rb.velocity = Vector2.right * CoinStates[i].ilv;
            rb.angularVelocity = CoinStates[i].iav;
        }
    }
    public static string makeString(string a, float b){
        return String.Format("{0}{1}", a, Math.Round(b, 4).ToString().PadRight(10));
    }
}
