using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager
{
    private static string _keyThickness = "KEY_THICKNESS";
    private static string _keyMass = "KEY_MASS";
    private static string _keyIlv = "KEY_ILV";
    private static string _keyIav = "KEY_IAV";
    private static string _keyFriction = "KEY_FRICTION";
    private static string _keyAngle = "KEY_ANGLE";
    private static string _keyHeight = "KEY_HEIGHT";
    private static string _keyBounciness = "KEY_BOUNCINESS";

    private static string _keyThickness2 = "KEY_THICKNESS2";
    private static string _keyMass2 = "KEY_MASS2";
    private static string _keyIlv2 = "KEY_ILV2";
    private static string _keyIav2 = "KEY_IAV2";
    private static string _keyFriction2 = "KEY_FRICTION2";
    private static string _keyAngle2 = "KEY_ANGLE2";
    private static string _keyHeight2 = "KEY_HEIGHT2";
    private static string _keyBounciness2 = "KEY_BOUNCINESS2";

    private static string _keyThickness3 = "KEY_THICKNESS3";
    private static string _keyMass3 = "KEY_MASS3";
    private static string _keyIlv3 = "KEY_ILV3";
    private static string _keyIav3 = "KEY_IAV3";
    private static string _keyFriction3 = "KEY_FRICTION3";
    private static string _keyAngle3 = "KEY_ANGLE3";
    private static string _keyHeight3 = "KEY_HEIGHT3";
    private static string _keyBounciness3 = "KEY_BOUNCINESS3";

    private static string _keyThicknessb = "KEY_THICKNESSb";
    private static string _keyMassb = "KEY_MASSb";
    private static string _keyIlvb = "KEY_ILVb";
    private static string _keyIavb = "KEY_IAVb";
    private static string _keyFrictionb = "KEY_FRICTIONb";
    private static string _keyAngleb = "KEY_ANGLEb";
    private static string _keyHeightb = "KEY_HEIGHTb";
    private static string _keyBouncinessb = "KEY_BOUNCINESSb";

    private static string _keyCoins = "KEY_COINS";
    private static string _keyFilePath = "KEY_PATH";
    private static string _keyFileName = "KEY_NAME";
    private static string _keyTime = "KEY_TIME";

    public static void SaveThickness(float thickness, float thickness2, float thickness3, bool thicknessb)
    {
        PlayerPrefs.SetFloat(_keyThickness, thickness);
        PlayerPrefs.SetFloat(_keyThickness2, thickness2);
        PlayerPrefs.SetFloat(_keyThickness3, thickness3);
        if (thicknessb) {
            PlayerPrefs.SetFloat(_keyThicknessb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyThicknessb, 0);
        }
    }

    public static void SaveThickness2(float thickness, bool thicknessb)
    {
        PlayerPrefs.SetFloat(_keyThickness, thickness);
        if (thicknessb) {
            PlayerPrefs.SetFloat(_keyThicknessb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyThicknessb, 0);
        }
    }

    public static float[] LoadThickness()
    {   
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyThickness, 1f), PlayerPrefs.GetFloat(_keyThickness2, 2f), PlayerPrefs.GetFloat(_keyThickness3, 2f), PlayerPrefs.GetFloat(_keyThicknessb, 0f)};
        return Array;
    }

    public static void SaveMass(float mass, float mass2, float mass3, bool massb)
    {
        PlayerPrefs.SetFloat(_keyMass, mass);
        PlayerPrefs.SetFloat(_keyMass2, mass2);
        PlayerPrefs.SetFloat(_keyMass3, mass3);
        if (massb) {
            PlayerPrefs.SetFloat(_keyMassb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyMassb, 0);
        }
    }

    public static void SaveMass2(float thickness, bool thicknessb)
    {
        PlayerPrefs.SetFloat(_keyMass, thickness);
        if (thicknessb) {
            PlayerPrefs.SetFloat(_keyMassb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyMassb, 0);
        }
    }


    public static float[] LoadMass()
    {
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyMass, 1f), PlayerPrefs.GetFloat(_keyMass2, 2f), PlayerPrefs.GetFloat(_keyMass3, 2f), PlayerPrefs.GetFloat(_keyMassb, 0f)};
        return Array;
    }

    public static void SaveILV(float ilv, float ilv2, float ilv3, bool ilvb)
    {
        PlayerPrefs.SetFloat(_keyIlv, ilv);
        PlayerPrefs.SetFloat(_keyIlv2, ilv2);
        PlayerPrefs.SetFloat(_keyIlv3, ilv3);
        if (ilvb) {
            PlayerPrefs.SetFloat(_keyIlvb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyIlvb, 0);
        }
    }

    public static void SaveILV2(float ilv, bool ilvb)
    {
        PlayerPrefs.SetFloat(_keyIlv, ilv);
        if (ilvb) {
            PlayerPrefs.SetFloat(_keyIlvb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyIlvb, 0);
        }
    }

    public static float[] LoadILV()
    {
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyIlv, 1f), PlayerPrefs.GetFloat(_keyIlv2, 2f), PlayerPrefs.GetFloat(_keyIlv3, 2f), PlayerPrefs.GetFloat(_keyIlvb, 0f)};
        return Array;
    }

    public static void SaveIAV(float iav, float iav2, float iav3, bool iavb)
    {
        PlayerPrefs.SetFloat(_keyIav, iav);
        PlayerPrefs.SetFloat(_keyIav2, iav2);
        PlayerPrefs.SetFloat(_keyIav3, iav3);
        if (iavb) {
            PlayerPrefs.SetFloat(_keyIavb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyIavb, 0);
        }
    }

    public static void SaveIAV2(float iav, bool iavb)
    {
        PlayerPrefs.SetFloat(_keyIav, iav);
        if (iavb) {
            PlayerPrefs.SetFloat(_keyIavb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyIavb, 0);
        }
    }

    public static float[] LoadIAV()
    {
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyIav, 1f), PlayerPrefs.GetFloat(_keyIav2, 2f), PlayerPrefs.GetFloat(_keyIav3, 2f), PlayerPrefs.GetFloat(_keyIavb, 0f)};
        return Array;
    }

    public static void SaveFriction(float friction, float friction2, float friction3, bool frictionb)
    {
        PlayerPrefs.SetFloat(_keyFriction, friction);
        PlayerPrefs.SetFloat(_keyFriction2, friction2);
        PlayerPrefs.SetFloat(_keyFriction3, friction3);
        if (frictionb) {
            PlayerPrefs.SetFloat(_keyFrictionb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyFrictionb, 0);
        }
    }

    public static void SaveFriction2(float friction, bool frictionb)
    {
        PlayerPrefs.SetFloat(_keyFriction, friction);
        if (frictionb) {
            PlayerPrefs.SetFloat(_keyFrictionb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyFrictionb, 0);
        }
    }

    public static float[] LoadFriction()
    {
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyFriction, 1f), PlayerPrefs.GetFloat(_keyFriction2, 2f), PlayerPrefs.GetFloat(_keyFriction3, 2f), PlayerPrefs.GetFloat(_keyFrictionb, 0f)};
        return Array;
    }

    public static void SaveAngle(float angle, float angle2, float angle3, bool angleb)
    {
        PlayerPrefs.SetFloat(_keyAngle, angle);
        PlayerPrefs.SetFloat(_keyAngle2, angle2);
        PlayerPrefs.SetFloat(_keyAngle3, angle3);
        if (angleb) {
            PlayerPrefs.SetFloat(_keyAngleb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyAngleb, 0);
        }
    }

    public static void SaveAngle2(float angle, bool angleb)
    {
        PlayerPrefs.SetFloat(_keyAngle, angle);
        if (angleb) {
            PlayerPrefs.SetFloat(_keyAngleb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyAngleb, 0);
        }
    }

    public static float[] LoadAngle()
    {
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyAngle, 1f), PlayerPrefs.GetFloat(_keyAngle2, 2f), PlayerPrefs.GetFloat(_keyAngle3, 2f), PlayerPrefs.GetFloat(_keyAngleb, 0f)};
        return Array;
    }

    public static void SaveHeight(float height, float height2, float height3, bool heightb)
    {
        PlayerPrefs.SetFloat(_keyHeight, height);
        PlayerPrefs.SetFloat(_keyHeight2, height2);
        PlayerPrefs.SetFloat(_keyHeight3, height3);
        if (heightb) {
            PlayerPrefs.SetFloat(_keyHeightb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyHeightb, 0);
        }
    }

    public static void SaveHeight2(float height, bool heightb)
    {
        PlayerPrefs.SetFloat(_keyHeight, height);
        if (heightb) {
            PlayerPrefs.SetFloat(_keyHeightb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyHeightb, 0);
        }
    }

    public static float[] LoadHeight()
    {
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyHeight, 1f), PlayerPrefs.GetFloat(_keyHeight2, 2f), PlayerPrefs.GetFloat(_keyHeight3, 2f), PlayerPrefs.GetFloat(_keyHeightb, 0f)};
        return Array;
    }

    public static void SaveBounciness(float bounciness, float bounciness2, float bounciness3, bool bouncinessb)
    {
        PlayerPrefs.SetFloat(_keyBounciness, bounciness);
        PlayerPrefs.SetFloat(_keyBounciness2, bounciness2);
        PlayerPrefs.SetFloat(_keyBounciness3, bounciness3);
        if (bouncinessb) {
            PlayerPrefs.SetFloat(_keyBouncinessb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyBouncinessb, 0);
        }
    }

    public static void SaveBounciness2(float bounciness, bool bouncinessb)
    {
        PlayerPrefs.SetFloat(_keyBounciness, bounciness);
        if (bouncinessb) {
            PlayerPrefs.SetFloat(_keyBouncinessb, 1);
        } else {
            PlayerPrefs.SetFloat(_keyBouncinessb, 0);
        }
    }

    public static float[] LoadBounciness()
    {
        float[] Array = new float[]{PlayerPrefs.GetFloat(_keyBounciness, 1f), PlayerPrefs.GetFloat(_keyBounciness2, 2f), PlayerPrefs.GetFloat(_keyBounciness3, 2f), PlayerPrefs.GetFloat(_keyBouncinessb, 0f)};
        return Array;
    }

    public static void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt(_keyCoins, coins);
    }

    public static int LoadCoins()
    {
        return PlayerPrefs.GetInt(_keyCoins, 100);
    }

    public static void SavePath(string path)
    {
        PlayerPrefs.SetString(_keyFilePath, path);
    }

    public static string LoadPath()
    {
        return PlayerPrefs.GetString(_keyFilePath, "Enter file path...");
    }

    public static void SaveName(string name)
    {
        PlayerPrefs.SetString(_keyFileName, name);
    }

    public static string LoadName()
    {
        return PlayerPrefs.GetString(_keyFileName, "Data");
    }

    public static void SaveTime(int time)
    {
        PlayerPrefs.SetInt(_keyTime, time);
    }

    public static int LoadTime()
    {
        return PlayerPrefs.GetInt(_keyTime, 6);
    }
}
