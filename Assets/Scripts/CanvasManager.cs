using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager : MonoBehaviorHelper 
{
	public Text textPoint;

	public CanvasGroup menu;

	public Button buttonSound;
	public Button buttonPlay;
	public Button buttonRate;
	public Button buttonFacebook;

	public Text lastScore;
	public Text bestScore;

	public Text TextTutoDesktop;
	public Text TextTutoMobile;


	void Awake()
	{
		menu.gameObject.SetActive (true);

	}

	void Start()
	{
		buttonSound = menu.transform.FindChild ("ButtonSound").GetComponent<Button>();
		buttonPlay = menu.transform.FindChild ("ButtonPlay").GetComponent<Button>();
		buttonRate = menu.transform.FindChild ("ButtonRate").GetComponent<Button>();
		buttonFacebook = menu.transform.FindChild ("ButtonFacebook").GetComponent<Button>();

		buttonSound.onClick.AddListener (OnClickedSoundButton);
		buttonPlay.onClick.AddListener (OnClickedPlayButton);
		buttonRate.onClick.AddListener (OnClickedRateButton);
		buttonFacebook.onClick.AddListener (OnClickedFacebookButton);

		lastScore = menu.transform.FindChild ("LastScore").GetComponentInChildren<Text> ();
		bestScore = menu.transform.FindChild ("BestScore").GetComponentInChildren<Text> ();

		SetScoresCanvas ();

		SetSoundIcon ();

		TextTutoDesktop = transform.FindChild ("TextTutoDesktop").GetComponentInChildren<Text> ();
		TextTutoMobile = transform.FindChild ("TextTutoMobile").GetComponentInChildren<Text> ();

		TextTutoDesktop.gameObject.SetActive (false);
		TextTutoMobile.gameObject.SetActive (false);
	}

	public void SetScoresCanvas()
	{
		int last = PlayerPrefs.GetInt ("LAST_SCORE", 0);
		int best = PlayerPrefs.GetInt ("BEST_SCORE", 0);

		lastScore.text = "LAST\nSCORE\n" + last.ToString ();
		bestScore.text = "BEST\nSCORE\n" + best.ToString ();
	}

	void Update()
	{

		bool alphaIsOne = canvasManager.menu.alpha == 1;
		canvasManager.menu.blocksRaycasts = alphaIsOne;
		textPoint.gameObject.SetActive (!alphaIsOne);
			
	}

	void OnClickedSoundButton()
	{
		int soundOn = PlayerPrefs.GetInt ("SOUND", 1);

		if (soundOn == 1)
			TurnSoundOff ();
		else
			TurnSoundOn ();

		SetSoundIcon ();
	}

	void SetSoundIcon()
	{
		int soundOn = PlayerPrefs.GetInt ("SOUND", 1);

		buttonSound.transform.GetChild (0).gameObject.SetActive (soundOn == 0);
		buttonSound.transform.GetChild (1).gameObject.SetActive (soundOn == 1);
	}

	void TurnSoundOn()
	{
		PlayerPrefs.SetInt ("SOUND", 1);
		PlayerPrefs.Save ();
	}

	void TurnSoundOff()
	{
		PlayerPrefs.SetInt ("SOUND", 0);
		PlayerPrefs.Save ();
	}

	void OnClickedPlayButton()
	{
		gameManager.StartGame ();
	}

	void OnClickedRateButton()
	{
	}

	void OnClickedFacebookButton()
	{
	}

	public void SetPoint(int point)
	{
		textPoint.text = point.ToString ();
	}
}
