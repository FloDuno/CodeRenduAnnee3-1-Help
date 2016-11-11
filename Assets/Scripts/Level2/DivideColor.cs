using UnityEngine;

public class DivideColor : MonoBehaviour {

    // Variables =======================================================================================
    public Material environmentMaterial;

    private Color _medianColor;
    private WebCamTexture _extureFromWebcam;

    // Start ===========================================================================================
    void Start()
    {
        _extureFromWebcam = new WebCamTexture();
        _extureFromWebcam.Play();
    }

    // Update ==========================================================================================
    void Update()
    {
        _medianColor = GetMedianColor();
        SetColorOnAll();
    }

    // Get Median Color ===============================================================================
    //Make the average of all channels from every pixel in the screen
    private Color GetMedianColor()
    {
        Vector3 _sumOfAllColors = Vector3.zero;
        Color[] _allColors = _extureFromWebcam.GetPixels();
        for (int _i = 0; _i < _allColors.Length; _i++)
        {
            _sumOfAllColors += new Vector3(_allColors[_i].r, _allColors[_i].g, _allColors[_i].b);
        }
        _sumOfAllColors = _sumOfAllColors / _allColors.Length;
        Color _medianColorTemp = new Color(_sumOfAllColors.x, _sumOfAllColors.y, _sumOfAllColors.z);
        return _medianColorTemp;
    }

    // Set Color on all GO ============================================================================
    private void SetColorOnAll()
    {
        environmentMaterial.color = _medianColor;
    }
}
