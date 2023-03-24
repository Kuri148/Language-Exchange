
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class LanguageProficiency : UdonSharpBehaviour

{
    public LanguageLevelSwitch[] LanguageLevelSwitch = new LanguageLevelSwitch[3];
    public string pressedButtonName;
    public GameObject[] englishIcon = new GameObject[3];
    public GameObject togglee;
    public GameObject[] englishLanguageLevels = new GameObject[3];
    public GameObject[] japaneseLanguageLevels = new GameObject[3];
    public GameObject[] spanishLanguageLevels = new GameObject[3];
    public GameObject[] mandarinLanguageLevels = new GameObject[3];

    public bool[] languagesSelected = new bool[4];
    public bool[] levelSelected = new bool[16];
    public Button englishButton;
    public Button japaneseButton;
    public Button spanishButton;
    public Button mandarinButton;
    private ColorBlock theColor;
    public int playerLanguageCount;

    public GameObject englishBeginnerIcon;
    public GameObject englishIntermediateIcon;
    public GameObject englishAdvancedIcon;

    public Text debugText;
    public Vector3 objectOnHead;
    public GameObject headNode;
    public float headOffset = 1.8f;
    public Quaternion myQuaternion = new Quaternion(0, 0, 0, 1);
    public void Start()

    {
        playerLanguageCount = 0;
        englishButton.image.color = Color.white;
        japaneseButton.image.color = Color.white;
        spanishButton.image.color = Color.white;
        mandarinButton.image.color = Color.white;
    }

    public void LevelSelect(string pressedButton)
    {
        Debug.Log("Button Clicked");
        pressedButtonName = pressedButton;
        Debug.Log("This is the button pressed:" + pressedButtonName);
        if (pressedButton == "englishBeginner" || pressedButton == "englishIntermediate" ||
            pressedButton == "englishAdvanced")
        {
            for (int i = 0; i < 3; i++)
            {
                if (englishLanguageLevels[i].name == pressedButton)
                {
                    // englishLanguageLevels[i].image.color = Color.black;
                    englishIcon[i].SetActive(true);
                }
                else
                {
                    // englishLanguageLevels[i].image.color = Color.black;
                    englishIcon[i].SetActive(false);
                }
            }
        }
    }

    public void EnglishSelect()
    {
        Debug.Log("You clicked it.");
        languagesSelected[0] = !languagesSelected[0];
        if (languagesSelected[0])
        {
            englishButton.image.color = Color.blue;
        }
        else
        {
            englishButton.image.color = Color.gray;
            foreach(GameObject level in englishLanguageLevels)
            {
                level.gameObject.SetActive(languagesSelected[0]);
            }
            foreach(GameObject icon in englishIcon)
            {
                icon.gameObject.SetActive(languagesSelected[0]);
            }
        }
        // englishSelected? englishButton.image.color = Color.blue : englishButton.image.color = Color.gray;
        // englishLanguageLevels[0].image.color = Color.blue;
        englishBeginnerIcon.gameObject.SetActive(languagesSelected[0]);
        playerLanguageCount += languagesSelected[0]? 1 : -1;
        Debug.Log("This many languages selected:" + playerLanguageCount);
        foreach(GameObject level in englishLanguageLevels)
        {
            level.gameObject.SetActive(languagesSelected[0]);
        }
    }

    public void EnglishLevelSelect()
    {
        // pressedButtonName = LanguageLevelSwitch[0].pressedButton;
        // Debug.Log("This was the button pressed:" + pressedButtonName);
        // for (i = 0, englishLanguageLevels.Length, i++)
    }

    public void SpanishSelect()
    {
        Debug.Log("You clicked it.");
        languagesSelected[1] = !languagesSelected[1];
        if (languagesSelected[1])
        {
            spanishButton.image.color = Color.blue;
        }
        else
        {
            spanishButton.image.color = Color.gray;
        }
        playerLanguageCount += languagesSelected[1]? 1 : -1;
        Debug.Log("This many languages selected:" + playerLanguageCount);
        foreach(GameObject level in spanishLanguageLevels)
        {
            level.SetActive(languagesSelected[1]);
        }
    }

    public void JapaneseSelect()
    {
        Debug.Log("You clicked it.");
        languagesSelected[2] = !languagesSelected[2];
        if (languagesSelected[2])
        {
            japaneseButton.image.color = Color.blue;
        }
        else
        {
            japaneseButton.image.color = Color.gray;
        }
        playerLanguageCount += languagesSelected[2]? 1 : -1;
        Debug.Log("This many languages selected:" + playerLanguageCount);
        foreach(GameObject level in japaneseLanguageLevels)
        {
            level.SetActive(languagesSelected[2]);
        }
    }

    public void MandarinSelect()
    {
        Debug.Log("You clicked it.");
        languagesSelected[3] = !languagesSelected[3];
        if (languagesSelected[3])
        {
            mandarinButton.image.color = Color.blue;
        }
        else
        {
            mandarinButton.image.color = Color.gray;
        }
        playerLanguageCount += languagesSelected[3]? 1 : -1;
        Debug.Log("This many languages selected:" + playerLanguageCount);
        foreach(GameObject level in mandarinLanguageLevels)
        {
            level.SetActive(languagesSelected[3]);
        }
    }
    public void SendAndReturnIcons()
    {
        foreach(bool bools in levelSelected)
        {
            if (bools)
            {
                // use a switch here not afor each statement
            }
        }
    }
    void Update()
    {
        var player = Networking.LocalPlayer;

        if (player != null)
        {
            // Get the position of the players head
            Vector3 headData = player.GetPosition();
            myQuaternion = player.GetRotation();
            // var headData = player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
            Debug.Log(headData.GetType());
            objectOnHead = headData;
            debugText.text = string.Format("Head-Rot: {0}\r\n", myQuaternion.ToString());
            headNode.transform.position = new Vector3(objectOnHead.x, headOffset, headData.z);
            headNode.transform.rotation = myQuaternion;
            // transform.LookAt(headData);
        }
    }
}

// Splat block for button select commands effects
// theColor.highlightedColor = Color.blue;
// theColor.normalColor = Color.cyan;
// theColor.pressedColor = Color.green;
// leButton.colors = theColor;