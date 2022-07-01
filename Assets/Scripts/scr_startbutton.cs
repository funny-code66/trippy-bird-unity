using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class scr_startbutton : MonoBehaviour
{
    private bool canTask;
    public Button yourButton;
    public GameObject guideButton;
    public GameObject exitButton;
    public Image yourImage;
    public GameObject player;
    public GameObject menuplayer;
    public GameObject thiscanvas;
    public GameObject startbird;
    public AudioSource swooshsound;
    public UnityEngine.UI.Text txtWalletAddress;
    public UnityEngine.UI.Text txtWalletNFTs;
    public bool isConnected;
    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account; 

    // Start is called before the first frame update
    async void Start()
    {
        Application.targetFrameRate = 60;
        account = "";
        isConnected = false;
        yourButton.onClick.AddListener(TaskOnClick);
        //GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().mute = false;
        // Web3Connect();
        canTask = true;

        // int balance = await ERC721.BalanceOf("ethereum", "rinkeby", "0x402c6894B2A6E974BDe4AaDecB9Df8Fc5DffF3a6", "0x29c0222C3CBbc8690eb8c043Bf356356eC9E78eC");
        // print(balance);
        // string token_ids = "";
        // int token_id = 0;
        // for (int i = 0; i<balance; i++) {
        //     token_id = await ERC721Enumerable.tokenOfOwnerByIndex("ethereum", "rinkeby", "0x402c6894B2A6E974BDe4AaDecB9Df8Fc5DffF3a6", "0x29c0222C3CBbc8690eb8c043Bf356356eC9E78eC", i.ToString());
        //     token_ids += ", ";
        //     token_ids += token_id.ToString();
        // }
        // txtWalletNFTs.text = token_ids;
    }

    void TaskOnClick()
    {
        // Web3Connect();
        if (isConnected && canTask)
            task();
    }


    // Update is called once per frame
    async void Update()
    {
        // account = ConnectAccount();
        // if (account != "") {
        //     // yourButton.SetActive(true);
        //     txtWalletAddress.text = account;
        //     isConnected = true;
        //     // txtWalletNFTs.text = AllErc721("rinkeby", "testnet", "0xbcfa449ad7CBDFfdC1187885b4421E0c57D50F88", "0x2444de6CaBA6E864c12aAfE730f6BDa28bC2117B", 500, 0);
        // }
        // else {
        //     // yourButton.SetActive(false);
        // }
        if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
        {
            if (canTask)
                task();
        }
        // string owner = await ERC721.OwnerOf("ethereum", "rinkeby", "0x2444de6CaBA6E864c12aAfE730f6BDa28bC2117B", "1");
        // print(owner);
        // txtWalletNFTs.text = owner;
        
    }

    void task()
    {
        startbird.SetActive(false);
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<scr_birdcontrols>().state = 2;
        player.GetComponent<scr_birdcontrols>().gameovercanvas.SetActive(false);
        guideButton.SetActive(true);
        thiscanvas.SetActive(false);
        Destroy(gameObject);
        canTask = false;
    }

    public void OnLogin()
    {
        Web3Connect();
        OnConnected();
    }

    private void OnConnected()
    {
        account = ConnectAccount();
        while (account == "") {
            // await new WaitForSeconds(1f);
            account = ConnectAccount();
        };
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        // reset login message
        SetConnectAccount("");
        // load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnSkip()
    {
        // burner account for skipped sign in screen
        PlayerPrefs.SetString("Account", "");
        // move to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
