using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    public Transform CharacterPos;
    public GameObject CharacterUrpPrefab, CharacterOmniPrefab;
    public Text txtShaderName;

    bool URPShader = false;

    // Start is called before the first frame update
    void Start()
    {
        txtShaderName.text = "URP Shaders";
        SpawnCharacter(CharacterUrpPrefab);

    }

    float x=-1F,z=-1F;
    private void SpawnCharacter(GameObject prefab)
    {
       var charTemp = GameObject.Instantiate(prefab, CharacterPos);

        charTemp.transform.localPosition = new Vector3(x,0,z);
        charTemp.transform.localRotation = Quaternion.identity;

        z += Random.Range(0, 0.5F);
        x += Random.Range(0, 0.5F);

        if (x >= 1F)
            x = -1F;

        if (z >= 1F)
            z = -1F;


    }

    public void URPCharacter() {

        if (!URPShader)
            Clear();

        URPShader = true;

        SpawnCharacter(CharacterUrpPrefab);
        txtShaderName.text = "URP Shaders " + CharacterPos.childCount;
    }

    public void OmniCharacter() {

        if (URPShader)
            Clear();
        URPShader = false;

        txtShaderName.text = "OMNI Shaders " + CharacterPos.childCount;
        SpawnCharacter(CharacterOmniPrefab);
    }

    public void Clear() {
        txtShaderName.text = "";
        while (CharacterPos.childCount > 0)
        {
            var child = CharacterPos.GetChild(0);
            child.SetParent(null);
            GameObject.Destroy(child.gameObject);
        }
    }

}
