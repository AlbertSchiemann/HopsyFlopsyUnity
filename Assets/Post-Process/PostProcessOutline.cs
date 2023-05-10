﻿using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessOutlineRenderer), PostProcessEvent.BeforeStack, "Roystan/Post Process Outline")]
public sealed class PostProcessOutline : PostProcessEffectSettings
{
    public IntParameter scale = new IntParameter { value = 1 };

    public FloatParameter depthThreshold = new FloatParameter { value = 1.5f };
}

public sealed class PostProcessOutlineRenderer : PostProcessEffectRenderer<PostProcessOutline>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Roystan/Outline Post Process"));
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);

        sheet.properties.SetFloat("_Scale", settings.scale);

        sheet.properties.SetFloat("_DepthThreshold", settings.depthThreshold);
    }
}