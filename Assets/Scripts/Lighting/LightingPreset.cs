﻿using System;
using UnityEngine;

namespace Lighting
{
    [Serializable]
    [CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
    public class LightingPreset : ScriptableObject
    {
        public Gradient AmbientColor;
        public Gradient DirectionalColor;
        public Gradient FogColor;
    }
}