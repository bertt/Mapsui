﻿using System.IO;
using Mapsui.Layers;
using System.Collections.Generic;

namespace Mapsui.Rendering
{
    public interface IRenderer
    {
        void Render(IViewport viewport, IEnumerable<ILayer> layers);
        MemoryStream RenderToBitmapStream(IViewport viewport, IEnumerable<ILayer> layers);
    }
}