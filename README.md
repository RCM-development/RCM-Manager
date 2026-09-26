RCM Manager (Also labelled: RCM GUI) is the central UI interface for all RCM mods, meaning its required to be installed along with any of those mods.
RCM meaning Rogue Command Modding.

# BEPINEX 5 INSTALLATION

Firstly you need BepInEx 5
- download from https://github.com/BepInEx/BepInEx/releases
- if using windows 10/11 look for `BepInEx_win_x64_5.X.XX.X.zip` (X will be version numbers here, just click the blue link for it under the "Assets" header)

Finding your Rogue Command installation folder
- if manually navigating with file explorer, the path will look something like `C:\Program Files (x86)\Steam\steamapps\common\Rogue Command`
- otherwise you can get there by navigating via steam -> Library -> click Rogue Command -> Settings cog icon under game banner -> Manage -> Browse Local files

Then installing BepInEx 5
- unzip BepInEx zip into Rogue Command folder
- you should now have a path like `C:\Program Files (x86)\Steam\steamapps\common\Rogue Command\BepInEx\plugins`

Verifying it installed correctly
- simply launch Rogue Command from steam or the exe or any shortcuts you have
- watch for a console window popping up with Rogue Command debug logs, this means it worked
- this console popup can be disabled if desired, see https://github.com/BepInEx/BepInEx/wiki/Configuration#console

# RCM MODS INSTALLATION (make sure bepinex is installed first)

Installing content.zip mods
- unzip content, then copy the `BepInEx` inside that into your Rogue Command game folder
- if prompted to overwrite files, just say yes. this is just overwriting RCM GUI, which is provided with each mod
- Specifcally the folder to paste your BepInEx folder into should look something like `C:\Program Files (x86)\Steam\steamapps\common\Rogue Command`

Installing RCM_XXXX.dll mods
- these will go straight into your BepInEx plugins folder
- folder should look something like `C:\Program Files (x86)\Steam\steamapps\common\Rogue Command\BepInEx\plugins`
