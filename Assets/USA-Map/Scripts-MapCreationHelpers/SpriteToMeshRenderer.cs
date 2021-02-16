using UnityEngine;
using UnityEngine.UI;

// Helper to convert SpriteRenderers to MeshRenderers
[ExecuteInEditMode]
public class SpriteToMeshRenderer : MonoBehaviour
{
    public MeshRenderer CloneSource;
    public Material[] SourceMaterials;

    public float Scale;
    public bool DoSwap;

    void Update()
    {
        if (!DoSwap) return;
        DoSwap = false;

        swapToMesh();
    }


    void swapToMesh()
    {
        Sprite s = getSprite();
        if (s == null)
            return;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) DestroyImmediate(sr);

        GameObject newGob = Instantiate(CloneSource.gameObject) as GameObject;
        var mr = newGob.GetComponent<MeshRenderer>();

        newGob.transform.parent = CloneSource.transform.parent;
        newGob.transform.localPosition = transform.localPosition;
        newGob.transform.localScale = new Vector3(s.bounds.size.x, s.bounds.size.y, 1) * Scale;
        newGob.name = gameObject.name;


        for (int i = 0; i < SourceMaterials.Length; i++)
        {
            if (SourceMaterials[i].name == gameObject.name)
            {
                mr.sharedMaterial = SourceMaterials[i];
                break;
            }
        }

        gameObject.SetActive(false);
    }


    Sprite getSprite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) return sr.sprite;

        Image uiImg = GetComponent<Image>();
        if (uiImg != null) return uiImg.sprite;

        return null;
    }
}
