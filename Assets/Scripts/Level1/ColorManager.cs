using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // Variables =======================================================================================
    public bool isEquivalent;
    public float tolerance;
    public Material refMaterial;
    public Material environmentMaterial;

    private Color _medianColor;
    private WebCamTexture _TextureFromWebcam;

    // Start ===========================================================================================
    void Start()
    {
        _TextureFromWebcam = new WebCamTexture();
        _TextureFromWebcam.Play();
    }

    // Update ==========================================================================================
    void Update()
    {
        _medianColor = GetMedianColor();
        SetColorOnAll();

        // Are Materials equivalent?
        isEquivalent = ColorEquivalence();
    }

    // Color Equivalence ===============================================================================
    bool ColorEquivalence()
    {
        return Mathf.Abs(refMaterial.color.r - _medianColor.r) + Mathf.Abs(refMaterial.color.g - _medianColor.g) + Mathf.Abs(refMaterial.color.b - _medianColor.b) < tolerance * 3;
    }

    // Get Median Color ===============================================================================
    //Get the average color of the three channels for every pixel in the texture
    private Color GetMedianColor()
    {
        Vector3 _sumOfAllColors = Vector3.zero;
        Color[] _allColors = _TextureFromWebcam.GetPixels();
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