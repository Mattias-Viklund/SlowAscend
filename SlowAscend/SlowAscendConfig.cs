using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMLHelper.V2.Json;
using SMLHelper.V2.Utility;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;

namespace SlowAscend
{
    [Menu("Slow Ascent")]
    public class SlowAscendConfig : ConfigFile
    {
        [Slider("Ascent Multiplier", 0.1f, 1.0f, DefaultValue = 0.25f, Format = "{0:F2}", Step = 0.01f)]
        public float ascentMultiplier = 0.25f;

        [Slider("Descent Multiplier", 0.1f, 1.0f, DefaultValue = 1.0f, Format = "{0:F2}", Step = 0.01f)]
        public float descentMultiplier = 1.0f;

    }
}
