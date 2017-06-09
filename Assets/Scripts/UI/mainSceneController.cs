using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mainSceneController : MonoBehaviour
{

    //Botones de la UI principal
    public Button endlessModeBtn, levelModeBtn, optionsBtn, shopBtn, shareTwBtn, shareFbBtn;
    //Botones de la UI de niveles;
    public Button[] easyLevelsBtns = new Button[10];
    public Button[] mediumLevelsBtns = new Button[10];
    public Button[] hardLevelsBtns = new Button[10];
    public Button returnLevelBtn;
    //Botones del settings panel
    public Button returnSettingsBtn;
    public Button bgMusicBtn, gameSoundsBtn;
    public Sprite soundCancel, soundA;


    //TExto con el score mas alto
    public Text bestScoreText;

    //Sonindos de botones
    public AudioClip UIButtonEnterSound, UIButtonReturnSound;
    public GameObject sounds;

    //Objetos que contiene los layout de las UI
    public GameObject mainUI, levelUI, settingUI;

    // Use this for initialization
    void Start()
    {
        mainUI.SetActive(true);
        levelUI.SetActive(false);
        settingUI.SetActive(false);
        bestScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }
    

    //////////Funciones para manejar el accionar de los botones de la interface//////////////

    ///////MAIN UI///////
    //Mostrar el menu del niveles y ocultar el principal -> levelModeBtn
    public void showLevelUI()
    {
        enterSound();
        mainUI.SetActive(false);
        levelUI.SetActive(true);
        settingUI.SetActive(false);
    }

    public void showSettingUI()
    {
        enterSound();
        mainUI.SetActive(false);
        levelUI.SetActive(false);
        settingUI.SetActive(true);
    }

    //Leer scene de endless mode -> endlessModeBtn
    public void loadEndlessScene()
    {
        enterSound();
        SceneManager.LoadScene("endless");
    }

    ///////LEVEL UI///////
    //Ocultar la interface de niveles y mostrar la principal
    public void showMainUI()
    {
        returnSound();
        mainUI.SetActive(true);
        levelUI.SetActive(false);
        settingUI.SetActive(false);
    }


    /////Sonidos de UI///////////////
    void enterSound()
    {
        sounds.GetComponent<AudioSource>().clip = UIButtonEnterSound;
        sounds.GetComponent<AudioSource>().Play();
    }

    void returnSound()
    {
        sounds.GetComponent<AudioSource>().clip = UIButtonReturnSound;
        sounds.GetComponent<AudioSource>().Play();
    }
}