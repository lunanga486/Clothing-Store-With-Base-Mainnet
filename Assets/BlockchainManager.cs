using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Thirdweb;
using UnityEngine.UI;
using TMPro;
using System;

public class BlockchainManager : MonoBehaviour
{
    public string Address { get; private set; }

    string savageTeeAddressSmartContract = "0xea7823DD9E21A7907579e8E3f7Bd74F6Dcf14B8D";
    string stealthWindbreakerAddressSmartContract = "0xC5F372144fe086744521596eFbe60C0eECe83Abb";
    string phantomCrewneckAddressSmartContract = "0x1C716337fCd751cb5549972A07D5725bb9Adea86";
    string rebelHoodieAddressSmartContract = "0xf2C2248FBD6F8d3d65026169fe180497c9Faa456";
    string vortexUtilityBagAddressSmartContract = "0x3E7aa3e2521b59Df1De3c3e0Cad01896F2557cB0";

    public Button savageTeeBuyButton;
    public Button stealthWindbreakerBuyButton;
    public Button phantomCrewneckBuyButton;
    public Button rebelHoodieBuyButton;
    public Button vortexUtilityBagBuyButton;

    public Button savageTeeBackButton;
    public Button stealthWindbreakerBackButton;
    public Button phantomCrewneckBackButton;
    public Button rebelHoodieBackButton;
    public Button vortexUtilityBagBackButton;

    public TextMeshProUGUI savageTeeBuyingStatusText;
    public TextMeshProUGUI stealthWindbreakerBuyingStatusText;
    public TextMeshProUGUI phantomCrewneckBuyingStatusText;
    public TextMeshProUGUI rebelHoodieBuyingStatusText;
    public TextMeshProUGUI vortexUtilityBagBuyingStatusText;

    public TextMeshProUGUI savageTeeBalanceText;
    public TextMeshProUGUI stealthWindbreakerBalanceText;
    public TextMeshProUGUI phantomCrewneckBalanceText;
    public TextMeshProUGUI rebelHoodieBalanceText;
    public TextMeshProUGUI vortexUtilityBagBalanceText;

    private void Start()
    {
        savageTeeBuyingStatusText.gameObject.SetActive(false);
        stealthWindbreakerBuyingStatusText.gameObject.SetActive(false);
        phantomCrewneckBuyingStatusText.gameObject.SetActive(false);
        rebelHoodieBuyingStatusText.gameObject.SetActive(false);
        vortexUtilityBagBuyingStatusText.gameObject.SetActive(false);


        UpdateBalance();

    }

    private async void UpdateBalance() {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        var contractSavageTee = ThirdwebManager.Instance.SDK.GetContract(savageTeeAddressSmartContract);
        try
        {
            List<NFT> nftList = await contractSavageTee.ERC721.GetOwned(Address);
            if (nftList.Count == 0)
            {
                savageTeeBalanceText.text = "00";
            }
            else
            {
                savageTeeBalanceText.text = nftList.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
        }

        var contractStealthWindbreaker = ThirdwebManager.Instance.SDK.GetContract(stealthWindbreakerAddressSmartContract);
        try
        {
            List<NFT> nftList = await contractStealthWindbreaker.ERC721.GetOwned(Address);
            if (nftList.Count == 0)
            {
                stealthWindbreakerBalanceText.text = "00";
            }
            else
            {
                stealthWindbreakerBalanceText.text = nftList.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
        }

        var contractPhantomCrewneck = ThirdwebManager.Instance.SDK.GetContract(phantomCrewneckAddressSmartContract);
        try
        {
            List<NFT> nftList = await contractPhantomCrewneck.ERC721.GetOwned(Address);
            if (nftList.Count == 0)
            {
                phantomCrewneckBalanceText.text = "00";
            }
            else
            {
                phantomCrewneckBalanceText.text = nftList.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
        }

        var contractRebelHoodie = ThirdwebManager.Instance.SDK.GetContract(rebelHoodieAddressSmartContract);
        try
        {
            List<NFT> nftList = await contractRebelHoodie.ERC721.GetOwned(Address);
            if (nftList.Count == 0)
            {
                rebelHoodieBalanceText.text = "00";
            }
            else
            {
                rebelHoodieBalanceText.text = nftList.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
        }

        var contractVortexUtilityBag = ThirdwebManager.Instance.SDK.GetContract(vortexUtilityBagAddressSmartContract);
        try
        {
            List<NFT> nftList = await contractVortexUtilityBag.ERC721.GetOwned(Address);
            if (nftList.Count == 0)
            {
                vortexUtilityBagBalanceText.text = "00";
            }
            else
            {
                vortexUtilityBagBalanceText.text = nftList.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
        }
    }
    public async void BuySavageTee()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        savageTeeBuyingStatusText.text = "Buying...";
        savageTeeBuyingStatusText.gameObject.SetActive(true);
        savageTeeBuyButton.interactable = false;
        savageTeeBackButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract(savageTeeAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            savageTeeBuyingStatusText.text = "Bought 1 Savage Tee!";
            savageTeeBuyingStatusText.gameObject.SetActive(true);
            savageTeeBuyButton.interactable = true;
            savageTeeBackButton.interactable = true;

            var contractSavageTee = ThirdwebManager.Instance.SDK.GetContract(savageTeeAddressSmartContract);
            try
            {
                List<NFT> nftList = await contractSavageTee.ERC721.GetOwned(Address);
                if (nftList.Count == 0)
                {
                    savageTeeBalanceText.text = "00";
                }
                else
                {
                    savageTeeBalanceText.text = nftList.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
            }

        }
        catch (Exception ex)
        {
            // Handle the exception, for example, log it or display an error message
            savageTeeBuyingStatusText.text = "Error: " + ex.Message;
            savageTeeBuyingStatusText.gameObject.SetActive(true);
            savageTeeBuyButton.interactable = true; 
            savageTeeBackButton.interactable = true; 
        }
    }

    public async void BuyStealthWindbreaker()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        stealthWindbreakerBuyingStatusText.text = "Buying...";
        stealthWindbreakerBuyingStatusText.gameObject.SetActive(true);
        stealthWindbreakerBuyButton.interactable = false;
        stealthWindbreakerBackButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract(stealthWindbreakerAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            stealthWindbreakerBuyingStatusText.text = "Bought 1 Stealth Windbreaker!";
            stealthWindbreakerBuyingStatusText.gameObject.SetActive(true);
            stealthWindbreakerBuyButton.interactable = true;
            stealthWindbreakerBackButton.interactable = true;

            var contractStealthWindbreaker = ThirdwebManager.Instance.SDK.GetContract(stealthWindbreakerAddressSmartContract);
            try
            {
                List<NFT> nftList = await contractStealthWindbreaker.ERC721.GetOwned(Address);
                if (nftList.Count == 0)
                {
                    stealthWindbreakerBalanceText.text = "00";
                }
                else
                {
                    stealthWindbreakerBalanceText.text = nftList.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Handle the exception, for example, log it or display an error message
            stealthWindbreakerBuyingStatusText.text = "Error: " + ex.Message;
            stealthWindbreakerBuyingStatusText.gameObject.SetActive(true);
            stealthWindbreakerBuyButton.interactable = true;
            stealthWindbreakerBackButton.interactable = true;
        }
    }
    public async void BuyPhantomCrewneck()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        phantomCrewneckBuyingStatusText.text = "Buying...";
        phantomCrewneckBuyingStatusText.gameObject.SetActive(true);
        phantomCrewneckBuyButton.interactable = false;
        phantomCrewneckBackButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract(phantomCrewneckAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            phantomCrewneckBuyingStatusText.text = "Bought 1 Phantom Crewneck!";
            phantomCrewneckBuyingStatusText.gameObject.SetActive(true);
            phantomCrewneckBuyButton.interactable = true;
            phantomCrewneckBackButton.interactable = true;

            var contractPhantomCrewneck = ThirdwebManager.Instance.SDK.GetContract(phantomCrewneckAddressSmartContract);
            try
            {
                List<NFT> nftList = await contractPhantomCrewneck.ERC721.GetOwned(Address);
                if (nftList.Count == 0)
                {
                    phantomCrewneckBalanceText.text = "00";
                }
                else
                {
                    phantomCrewneckBalanceText.text = nftList.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Handle the exception, for example, log it or display an error message
            phantomCrewneckBuyingStatusText.text = "Error: " + ex.Message;
            phantomCrewneckBuyingStatusText.gameObject.SetActive(true);
            phantomCrewneckBuyButton.interactable = true;
            phantomCrewneckBackButton.interactable = true;
        }
    }
    public async void BuyRebelHoodie()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        rebelHoodieBuyingStatusText.text = "Buying...";
        rebelHoodieBuyingStatusText.gameObject.SetActive(true);
        rebelHoodieBuyButton.interactable = false;
        rebelHoodieBackButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract(rebelHoodieAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            rebelHoodieBuyingStatusText.text = "Bought 1 Rebel Hoodie!";
            rebelHoodieBuyingStatusText.gameObject.SetActive(true);
            rebelHoodieBuyButton.interactable = true;
            rebelHoodieBackButton.interactable = true;

            var contractRebelHoodie = ThirdwebManager.Instance.SDK.GetContract(rebelHoodieAddressSmartContract);
            try
            {
                List<NFT> nftList = await contractRebelHoodie.ERC721.GetOwned(Address);
                if (nftList.Count == 0)
                {
                    rebelHoodieBalanceText.text = "00";
                }
                else
                {
                    rebelHoodieBalanceText.text = nftList.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
            }

        }
        catch (Exception ex)
        {
            // Handle the exception, for example, log it or display an error message
            rebelHoodieBuyingStatusText.text = "Error: " + ex.Message;
            rebelHoodieBuyingStatusText.gameObject.SetActive(true);
            rebelHoodieBuyButton.interactable = true;
            rebelHoodieBackButton.interactable = true;
        }
    }
    public async void BuyVortexUtilityBag()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        vortexUtilityBagBuyingStatusText.text = "Buying...";
        vortexUtilityBagBuyingStatusText.gameObject.SetActive(true);
        vortexUtilityBagBuyButton.interactable = false;
        vortexUtilityBagBackButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract(vortexUtilityBagAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            vortexUtilityBagBuyingStatusText.text = "Bought 1 Vortex Utility Bag!";
            vortexUtilityBagBuyingStatusText.gameObject.SetActive(true);
            vortexUtilityBagBuyButton.interactable = true;
            vortexUtilityBagBackButton.interactable = true;

            var contractVortexUtilityBag = ThirdwebManager.Instance.SDK.GetContract(vortexUtilityBagAddressSmartContract);
            try
            {
                List<NFT> nftList = await contractVortexUtilityBag.ERC721.GetOwned(Address);
                if (nftList.Count == 0)
                {
                    vortexUtilityBagBalanceText.text = "00";
                }
                else
                {
                    vortexUtilityBagBalanceText.text = nftList.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
            }

        }
        catch (Exception ex)
        {
            // Handle the exception, for example, log it or display an error message
            vortexUtilityBagBuyingStatusText.text = "Error: " + ex.Message;
            vortexUtilityBagBuyingStatusText.gameObject.SetActive(true);
            vortexUtilityBagBuyButton.interactable = true;
            vortexUtilityBagBackButton.interactable = true;
        }
    }
}
