using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using System.IO;
using TMPro;
using SimpleFileBrowser;

public class Popup : MonoBehaviour
{
    [SerializeField] Button _returnButton;
    [SerializeField] Button _button1;
    [SerializeField] Button _button2;

    public static Popup Instance;
    
    public void Init(Transform canvas, Action action1, Action action2) {

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;
        transform.localPosition = Vector2.zero;

        _returnButton.onClick.AddListener(() => {
            GameObject.Destroy(this.gameObject);
        });

        _button1.onClick.AddListener(() => {
            action1();
        });

        _button2.onClick.AddListener(() => {
            action2();
        });
    }

}
