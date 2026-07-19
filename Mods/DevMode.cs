using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestMod.Mods {

    internal class DevMode {
        public DevMode() {
            RCMManager.ConnectMod("DevModeEnabler v1").ContinueWith(t => {
                RCMModUI mod = t.Result;

                // begin mod UI construction here...
                mod.CreateLabelField("dev mode is enabled.");


            }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
