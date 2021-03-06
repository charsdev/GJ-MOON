using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] public float TimeOfDay;
    [Header("Cada unidad son 24 segundos adicionales")]
    public float seconds = 1;
    [SerializeField]
    private ShineCounter shineCounter;
    public Material skybox;
    public PostProcessVolume m_Volume;
    private Bloom bloom;

    private void Start()
    {
        TimeOfDay = 7.0f;
        if (m_Volume != null)
        {
            bloom = m_Volume.profile.GetSetting<Bloom>();
        }
    }

    private void FixedUpdate()
    {
        if (Preset == null)
            return;
        
        if (Application.isPlaying)
        {
            if (Input.GetKey(KeyCode.T))
            {

                TimeOfDay += Time.deltaTime*10;
                TimeOfDay %= 24;
                UpdateLighting(TimeOfDay / 24f);
            }
            else
            {
                TimeOfDay += Time.deltaTime/seconds;
                TimeOfDay %= 24;
                UpdateLighting(TimeOfDay / 24f);
            }

            if(TimeOfDay >= 6 && TimeOfDay <= 6.1f)
            {
                shineCounter.UpdateShines(0);
            }
            GameManager.GameManagerInstance.isDay = TimeOfDay >= 6 && TimeOfDay <= 19 ?  true : false;
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
        if (bloom != null)
        {
            if (TimeOfDay > 16)
            {
                bloom.intensity.value = Mathf.Lerp(bloom.intensity, 1, Time.deltaTime);
            }
            else
            {
                bloom.intensity.value = Mathf.Lerp(bloom.intensity, 0, Time.deltaTime);
            }
        }
    }
    
    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
        
        
        if (skybox != null)
        {
            skybox.SetColor("_GradientSkyColor", Preset.AmbientColor.Evaluate(timePercent));
        }
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 0f, 180f, 0));
        }
    }
    
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
