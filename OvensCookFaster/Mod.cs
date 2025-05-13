using MelonLoader;

[assembly: MelonInfo(typeof(OvensCookFaster.OvensCookFasterMod), "OvensCookFaster", "1.0.0", "lasersquid", null)]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace OvensCookFaster
{
    public class OvensCookFasterMod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("OvensCookFaster mod initialized.");
        }
    }
}