using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class levelSelector : UdonSharpBehaviour
{
    public TextMeshProUGUI boolLogic;
    public bool firstTime;
    public SameOrDifferentBoardControls SameOrDifferentBoardControls;
    public Slider levelSlider;
    [UdonSynced] public int levelToPick = 0;
    [UdonSynced] public int levelThatWasPicked = 0;
    public Text levelIndicator;
    public GameObject LevelsEmpty;
    GameObject[] redImages;
    GameObject[] blueImages;
    public GameObject redButton;
    public GameObject blueButton;
    //public GameObject answerButton;
    public GameObject redPicture;
    public GameObject bluePicture;
    [UdonSynced] public bool isEven = true;
    [UdonSynced] public int redSelection = 0;
    [UdonSynced] public int blueSelection = 5;
    [UdonSynced] public int randomNumberGenerator = 12345;
    public bool[] doneBefore;


    void Start()
    {
        firstTime = true;
        Debug.Log($"The number of levels is {LevelsEmpty.transform.childCount}");
        levelSlider.maxValue = LevelsEmpty.transform.childCount - 1;

        InitialSetup();
        MoveSliderLevel();
        CreateImageArray();
        SelectLevel();
        firstTime = false;
    }

    public void InitialSetup()
    {
        //Turn off all level Containers
        for (int i = 0; i < LevelsEmpty.transform.childCount; i++)
        {
            GameObject levelContainer =LevelsEmpty.transform.GetChild(i).gameObject;
            levelContainer.SetActive(false);
        }
        //Turn on buttons
        blueButton.SetActive(true);
        redButton.SetActive(true);
    }

    public void MoveSliderLevel()
    {
        levelToPick = (int)levelSlider.value;
        levelIndicator.text = levelToPick.ToString();
    }

    public void CreateImageArray()
    {
        // grandchildren index
        int k = 0;
        int l = 0;
        int m = 0;

        //The number of images is four times the number of containers
        int numberOfImages = (LevelsEmpty.transform.childCount * 4);
        redImages = new GameObject[numberOfImages];
        blueImages = new GameObject[numberOfImages];

        //Also collect level titles for easy naming
        //levelTitles = new GameObject[LevelsEmpty.transform.childCount];

        //Searches two layers deep in children
        for (int i = 0; i < LevelsEmpty.transform.childCount; i++)
        {
            GameObject level = LevelsEmpty.transform.GetChild(i).gameObject;
            for (int j = 0; j < level.transform.childCount -1; j++)
            {
                GameObject image = level.transform.GetChild(j).gameObject;
                if(j < 4)
                {
                    redImages[k] = image;
                    k++;
                    image.SetActive(false);
                }
                else
                {
                    blueImages[l] = image;
                    l++;
                    image.SetActive(false);
                }
            }
        }
        PlaceImages(redImages, blueImages);
    }


    public void PlaceImages(GameObject[] redImagesToBePlaced, GameObject[] blueImagesToBePlaced)
    {
        foreach(GameObject image in redImagesToBePlaced)
        {   
            image.transform.localPosition = new Vector3(42.7f, 2.7f, -.9f);
            image.transform.localScale = new Vector3(6.2f, 6.2f, 1);
        }
        Debug.Log("red has been placed");

        foreach(GameObject image in blueImagesToBePlaced)
        {
            image.transform.localPosition = new Vector3(-42.23f, 2f, -1.06f);
            image.transform.localScale = new Vector3(6.2f, 6.2f, 1);
        }
        Debug.Log("blue has been placed");
    }
    public void SelectLevel()
    {
        
        //answerButton.SetActive(false);
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        DealWithPreviousLevel(levelThatWasPicked);
        if (!firstTime)
        {
            ChooseRandomLevel();
        }
        SetUpCurrentLevel(levelToPick);
        ChoosePictures();
        levelThatWasPicked = levelToPick;
    }

    public void DealWithPreviousLevel(int levelToTurnOff)
    {

        //Fuck it.  Turn it all off.
        GameObject previousLevel = LevelsEmpty.transform.GetChild(levelToTurnOff).gameObject;
        foreach(GameObject image in redImages)
        {
            image.SetActive(false);
        }

        foreach(GameObject image in blueImages)
        {
            image.SetActive(false);
        }
        /*for (int i = 0; i < previousLevel.transform.childCount - 2; i++)
        {
            GameObject levelContent = previousLevel.transform.GetChild(i).gameObject;
            levelContent.SetActive(false);
        }

        // previousLevel.SetActive(false);  Why doesn't Udon Sync like this!?  It won't turn off the pictures for the other player On Deserialization. */
    }
    public void ChooseRandomLevel()
    {
        levelToPick = Random.Range(0,LevelsEmpty.transform.childCount - 1);
    }

    public void SetUpCurrentLevel(int level)
    {
        SameOrDifferentBoardControls.voteSame.SetActive(true);
        SameOrDifferentBoardControls.voteDifferent.SetActive(true);
        SameOrDifferentBoardControls.ResetBoard();
        GameObject currentLevel = LevelsEmpty.transform.GetChild(level).gameObject;
        currentLevel.SetActive(true);
        currentLevel.transform.GetChild(8).gameObject.SetActive(true);
        GameObject levelTitle = currentLevel.transform.GetChild(8).gameObject;
        redButton.SetActive(true);
        blueButton.SetActive(true);
    }
    public void ChoosePictures()
    {
        int randomInt = Random.Range(1,3);
        
        if (randomInt % 2 == 0)
        {
            isEven = true;
            //boolLogic.text = isEven.ToString() + " " + randomInt;
        }
        else
        {
            isEven = false;
            //boolLogic.text = isEven.ToString();
            //boolLogic.text = isEven.ToString() + " " + randomInt;
        }
        Random.InitState(randomNumberGenerator);
        randomNumberGenerator++;
        if(isEven)
        {
            //Activate same pictures on both sides
            redSelection = Random.Range(0,4);
            blueSelection = (redSelection + 4);
            Debug.Log($"the blue int is {blueSelection}, The red int is {redSelection}");
        }
        else
        {
            //Choose two different pictures
            redSelection = Random.Range(0,4);
            //Choose second different picture
            blueSelection = redSelection;
            do
            {
            blueSelection = Random.Range(0,4);
            } while (blueSelection == redSelection);
            //boolLogic.text = isEven.ToString() + " " + randomInt + $"the blue int is {blueSelection}, The red int is {redSelection}";
            blueSelection += 4;
            Debug.Log($"the blue int is {blueSelection}, The red int is {redSelection}");
        }
        RequestSerialization();
        ActivateSelectedPictures();
        //levelThatWasPicked = levelToPick; ============================================================================================================================================================
    }

    public void ActivateSelectedPictures()
    {
        Debug.Log($"Activate Selected Time: the blue int is {blueSelection}, The red int is {redSelection}");
        GameObject currentLevel = LevelsEmpty.transform.GetChild(levelToPick).gameObject;
        redPicture = currentLevel.transform.GetChild(redSelection).gameObject;
        bluePicture = currentLevel.transform.GetChild(blueSelection).gameObject;
        Debug.Log($"The red picture is {redPicture.name}. The blue picture is {bluePicture.name}.");
    }

    public void OnDeserialization()
    {
        DealWithPreviousLevel(levelThatWasPicked);
        SetUpCurrentLevel(levelToPick);
        ActivateSelectedPictures();
    }
}