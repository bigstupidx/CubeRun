using UnityEngine;
using System.Collections;

public class MonoBehaviorHelper : MonoBehaviour 
{
	GameManager _gameManager;
	public GameManager gameManager
	{
		get
		{
			if (_gameManager == null)
				_gameManager = FindObjectOfType<GameManager> ();

			return _gameManager;
		}
	}

	CanvasManager _canvasManager;
	public CanvasManager canvasManager
	{
		get
		{
			if (_canvasManager == null)
				_canvasManager = FindObjectOfType<CanvasManager> ();

			return _canvasManager;
		}
	}

	Camera _cam;
	public Camera cam
	{
		get
		{
			if (_cam == null)
				_cam = Camera.main;

			return _cam;
		}
	}
}
