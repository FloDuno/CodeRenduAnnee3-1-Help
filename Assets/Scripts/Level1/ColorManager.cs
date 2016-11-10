using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // Variables =======================================================================================
    public bool _isEquivalent;
    public float _tolerance;
    public Material _refMaterial;
    public Material _environmentMaterial;
    Color _medianColor;
    WebCamTexture _TextureFromWebcam;

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
        _isEquivalent = ColorEquivalence();
    }

    // Color Equivalence ===============================================================================
    bool ColorEquivalence()
    {
        return Mathf.Abs(_refMaterial.color.r - _medianColor.r) + Mathf.Abs(_refMaterial.color.g - _medianColor.g) + Mathf.Abs(_refMaterial.color.b - _medianColor.b) < _tolerance * 3;
    }

    // Get Median Color ===============================================================================
    private Color GetMedianColor()
    {
        Color MedianColor = new Color();
        Vector3 SumOfAllColors = Vector3.zero;
        Color[] AllColors = _TextureFromWebcam.GetPixels();
        for (int i = 0; i < AllColors.Length; i++)
        {
            SumOfAllColors += new Vector3(AllColors[i].r, AllColors[i].g, AllColors[i].b);
        }
        SumOfAllColors = SumOfAllColors / AllColors.Length;
        MedianColor = new Color(SumOfAllColors.x, SumOfAllColors.y, SumOfAllColors.z);
        return MedianColor;
    }

    // Set Color on all GO ============================================================================
    private void SetColorOnAll()
    {
        _environmentMaterial.color = _medianColor;
    }
}