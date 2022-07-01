using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class scr_disp_tokenids : MonoBehaviour
{
    public GameObject player;
    public Button[] nft_btn;
    public GameObject[] nft_inst;
    
    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    async void Start()
    {
        nft_btn = new Button[9];
        nft_inst = new GameObject[9];

        for (int i = 0; i < 9; i++){
            string tag = "nft_btn"+(i+1);
            Debug.Log(tag);
            nft_inst[i] = GameObject.Find(tag);
            nft_btn[i] = nft_inst[i].GetComponent<Button>();
            
            nft_btn[i].onClick.AddListener(OnMouseDown);
            nft_inst[i].SetActive(false);
        }

        // // display nfts
        // string account = ConnectAccount();
        // int balance = await ERC721.BalanceOf("ethereum", "rinkeby", "0x402c6894B2A6E974BDe4AaDecB9Df8Fc5DffF3a6", account);
        // int token_id = 0;
        // for (int i = 0; i<balance; i++) {
        //     token_id = await ERC721Enumerable.tokenOfOwnerByIndex("ethereum", "rinkeby", "0x402c6894B2A6E974BDe4AaDecB9Df8Fc5DffF3a6", account, i.ToString());
        //     nft_inst[i].SetActive(true);
        //     Text txtTokenId = nft_inst[i].transform.Find("txtTokenId").GetComponent<Text>();
        //     txtTokenId.text = "#" + token_id.ToString();

        // }

        for (int i = 0; i<5; i++) {
            int token_id = i+1;
            string tag = "nft_btn"+(i+1);
            nft_inst[i].SetActive(true);
            Text txtTokenId = nft_inst[i].transform.Find("txtTokenId").GetComponent<Text>();
            txtTokenId.text = "#" + token_id.ToString();

        }
    }

    void Update()
    {
        
    }
    public void OnMouseDown() {
        Debug.Log("BUTTON PRESSED");
        player.GetComponent<scr_birdcontrols>().state = 3;
        player.GetComponent<scr_birdcontrols>().canlol = true;
        player.GetComponent<scr_birdcontrols>().canjump = true;
    }
}