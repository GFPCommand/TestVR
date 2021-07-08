using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllUI : MonoBehaviour {
    public Text textUI, textBut1, textBut2, textBut3;
    public Text textFieldUI, timerUI;
    public GameObject but1, but2, but3, TextUI, textField, back, timerText, timer;
    private string txtFileAboutVR = "aboutVR", txtFileAbout = "about", txtFileHelp = "help", txtContent;
    private int check, time = 10;
    public static bool controllerVR;

    private void Start()
    {
        check = 0;
    }

    public void StartProg()
    {
        if (check == 0)
        {
            textUI.text = "Выберите тип управления";

            textBut1.text = "VR контроллер";
            textBut2.text = "Датчики устройства";
            textBut3.text = "Помощь в выборе";

            back.SetActive(true);

            check = 1;
        }
        else if (check == 1)
        {
            but1.SetActive(false);
            but2.SetActive(false);
            but3.SetActive(false);
            back.SetActive(false);
            TextUI.SetActive(false);

            timerText.SetActive(true);
            timer.SetActive(true);

            StartCoroutine(startTimer());

            controllerVR = true;
        }
    }

    public void About()
    {
        if (check == 0)
        {
            but1.SetActive(false);
            but2.SetActive(false);
            but3.SetActive(false);
            TextUI.SetActive(false);
            textField.SetActive(true);
            back.SetActive(true);

            TextAsset textAsset = (TextAsset)Resources.Load(txtFileAbout);
            txtContent = textAsset.text;

            textFieldUI.text = txtContent.ToString();

            check = 2;
        }
        else if (check == 1)
        {
            but1.SetActive(false);
            but2.SetActive(false);
            but3.SetActive(false);
            back.SetActive(false);
            TextUI.SetActive(false);

            timerText.SetActive(true);
            timer.SetActive(true);

            StartCoroutine(startTimer());
            controllerVR = false;
        }
    }

    public void AboutVR()
    {
        if (check == 0)
        {
            but1.SetActive(false);
            but2.SetActive(false);
            but3.SetActive(false);
            TextUI.SetActive(false);
            textField.SetActive(true);
            back.SetActive(true);

            TextAsset textAsset = (TextAsset)Resources.Load(txtFileAboutVR);
            txtContent = textAsset.text;

            textFieldUI.text = txtContent.ToString();

            check = 3;
        }
        else if (check == 1)
        {
            but1.SetActive(false);
            but2.SetActive(false);
            but3.SetActive(false);
            TextUI.SetActive(false);
            textField.SetActive(true);
            back.SetActive(true);

            TextAsset textAsset = (TextAsset)Resources.Load(txtFileHelp);
            txtContent = textAsset.text;

            textFieldUI.text = txtContent.ToString();
        }
    }

    public void Back()
    {
        but1.SetActive(true);
        but2.SetActive(true);
        but3.SetActive(true);
        TextUI.SetActive(true);
        textField.SetActive(false);
        back.SetActive(false);

        textUI.text = "Добро пожаловать в виртуальную реальность";

        textBut1.text = "Запуск";
        textBut2.text = "О приложении";
        textBut3.text = "Что такое виртуальная реальность?";

        check = 0;
    }

    IEnumerator startTimer()
    {
        while (time >= 0)
        {
            timerUI.text = "Время до запуска: " + time;
            time--;
            if (time < 0) SceneManager.LoadScene(1);
            yield return new WaitForSeconds(1f);
        }
        
    }
}