using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;

public class QRCodeReaderScript : MonoBehaviour
{
    [SerializeField] private RawImage _rawImagebg;
    [SerializeField] private AspectRatioFitter _aspectRatioFitter;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private RectTransform _scanZone;

    private bool _isCamAvailable;

    private WebCamTexture _webCamTexture;


    // Start is called before the first frame update
    void Start()
    {
        SetUpCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCameraRender();
    }

    private void UpdateCameraRender()
    {
        if (_isCamAvailable == false)
        {
            return;
        }
        float ratio = (float)_webCamTexture.width / (float)_webCamTexture.height;
        _aspectRatioFitter.aspectRatio = ratio;

        int orientation = -_webCamTexture.videoRotationAngle;
        _rawImagebg.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }
    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            _isCamAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == false) _webCamTexture = new WebCamTexture(devices[i].name, (int)_scanZone.rect.width, (int)-_scanZone.rect.height);
        }
        _webCamTexture.Play();
        _rawImagebg.texture = _webCamTexture;
        _isCamAvailable = true;
    }

    private void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_webCamTexture.GetPixels32(), _webCamTexture.width, _webCamTexture.height);
            if (result != null)
            {
                _textMeshProUGUI.text = result.Text;
            }
            else
            {
                _textMeshProUGUI.text = "Failed to read qr";
            }
        }
        catch (Exception e)
        {
            _textMeshProUGUI.text = "FAILED";
            throw;
        }
    }

    public void OnClickScan()
    {
        Scan();
    }
}
