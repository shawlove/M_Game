using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartUIView : MonoBehaviour {

    private GameObject _main;
    private Button _gameStartBtn;
    private Button _gameEndBtn;
    private Button _optionBtn;

    private GameObject _option;
    private Button _returnBtn;

	void Start () {
        _main= transform.Find("Main").gameObject;
        _gameStartBtn = transform.Find("Main/GameStartBtn").GetComponent<Button>();
        _gameEndBtn = transform.Find("Main/GameEndBtn").GetComponent<Button>();
        _optionBtn= transform.Find("Main/OptionBtn").GetComponent<Button>();

        _option = transform.Find("Option").gameObject;
        _returnBtn= transform.Find("Option/ReturnBtn").GetComponent<Button>();

        _gameStartBtn.onClick = new Button.ButtonClickedEvent();
        _gameStartBtn.onClick.AddListener(GameStart);

        _gameEndBtn.onClick = new Button.ButtonClickedEvent();
        _gameEndBtn.onClick.AddListener(GameEnd);

        _optionBtn.onClick = new Button.ButtonClickedEvent();
        _optionBtn.onClick.AddListener(Option);

        _returnBtn.onClick = new Button.ButtonClickedEvent();
        _returnBtn.onClick.AddListener(() =>
        {
            _main.SetActive(true);

            _option.SetActive(false);
        });
    }
	

	void Update () {
		
	}


    private void GameStart()
    {
        MessageCenter.GlobalEvent.SendMessage((int)MsgType.GameStart);
    }

    private void GameEnd()
    {
        Application.Quit();
    }

    private void Option()
    {
        _main.SetActive(false);

        _option.SetActive(true);
    }
}
