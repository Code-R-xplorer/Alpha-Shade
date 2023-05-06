using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private Renderer _renderer;

    [SerializeField] private Material normal;
    [SerializeField] private Material chasing;
    [SerializeField] private Material searching;
    [SerializeField] private Material investigating;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeMaterial(Materials material)
    {
        _renderer.material = material switch
        {
            Materials.Normal => normal,
            Materials.Chasing => chasing,
            Materials.Searching => searching,
            Materials.Investigate => investigating,
            _ => throw new ArgumentOutOfRangeException(nameof(material), material, null)
        };
    }

    public enum Materials
    {
        Normal,
        Chasing,
        Searching,
        Investigate
    }
}
