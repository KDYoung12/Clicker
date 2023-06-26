using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int num = 0;

    [SerializeField]
    private int clickNum = 1;

    [SerializeField]
    private int upGradeNum = 10;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI nextCoinText;
    public TextMeshProUGUI clickText;

    public GameObject noMoneyNotice;

    public GameObject ExitPanel;

    public Sprite[] image;

    public Button clickButton;

    int imageInt = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Screen.SetResolution(1080, 1920, true);

        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);

        imageInt = PlayerPrefs.GetInt("imgNum", 0);
        clickButton.GetComponent<Image>().sprite = image[imageInt];


        num = PlayerPrefs.GetInt("num", 0);
        clickNum = PlayerPrefs.GetInt("clickNum", 1);
        upGradeNum = PlayerPrefs.GetInt("upgradeNum", 40);
    }

    private void Update()
    {
        clickText.text = "CLICK : " + clickNum.ToString();
        coinText.text = "COIN : " + num.ToString();
        nextCoinText.text = "NEXT COIN : " + upGradeNum.ToString();
    }

    public void OnClickButton()
    {
        num += clickNum;
        Debug.Log(num);
    }

    public void OnClickUpgradeButton()
    {
        if (num >= upGradeNum)
        {
            num -= upGradeNum;
            clickNum *= 2  ;
            upGradeNum *= 2;
            imageInt++;
            clickButton.GetComponent<Image>().sprite = image[imageInt];
            Debug.Log("남은 돈 : " + num);


        }
        else 
        {
            Debug.Log("No Money");
            StartCoroutine("NoMoneyNotice");
        }
    }

    public void save()
    {
        PlayerPrefs.SetInt("num", num);
        PlayerPrefs.SetInt("clickNum", clickNum);
        PlayerPrefs.SetInt("upgradeNum", upGradeNum);
        PlayerPrefs.SetInt("imgNum", imageInt);
    }

    public void ExitButton()
    {
        ExitPanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    IEnumerator NoMoneyNotice()
    {
        noMoneyNotice.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        noMoneyNotice.SetActive(false);
    }
}
