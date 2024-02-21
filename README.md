# GordonEssentials
<p align="center">
  <a>
    <img alt="Made With Unity" src="https://img.shields.io/badge/made%20with-Unity-57b9d3.svg?logo=Unity">
  </a>
  <a>
  <img alt="License" src="https://img.shields.io/github/license/szejkerek/com.szejkerek.gordonessentials?logo=github">
  </a>
  <a>
    <img alt="Last Commit" src="https://img.shields.io/github/last-commit/szejkerek/com.szejkerek.gordonessentials?logo=Mapbox&color=orange">
  </a>
  <a>
    <img alt="Repo Size" src="https://img.shields.io/github/repo-size/szejkerek/com.szejkerek.gordonessentials?logo=VirtualBox">
  </a>
  <a>
    <img alt="Downloads" src="https://img.shields.io/github/downloads/szejkerek/com.szejkerek.gordonessentials/total?color=brightgreen">
  </a>
  <a>
    <img alt="Last Release" src="https://img.shields.io/github/v/release/szejkerek/com.szejkerek.gordonessentials?include_prereleases&logo=Dropbox&color=yellow">
  </a>
  <a>
    <img alt="GitHub stars" src="https://img.shields.io/github/stars/szejkerek/com.szejkerek.gordonessentials?branch=main&label=Stars&logo=GitHub&logoColor=ffffff&labelColor=282828&color=informational&style=flat">
  </a>
  <a>
    <img alt="GitHub user stars" src="https://img.shields.io/github/stars/szejkerek?affiliations=OWNER&branch=main&label=User%20Stars&logo=GitHub&logoColor=ffffff&labelColor=282828&color=informational&style=flat">
  </a>
</p>

## Unity package for starting new project.

### Overview of functions
- **Scene Changer**: Smoothly transition between scenes.
- **Fade Screen**: Screen fading effect for transitions.
- **Setup Project Folders**: Auto organize project files and directories.
- **Create Basic Colors**: Generate fundamental color materials.
- **Serialization of data in JSON**.
- **Singleton** base class.
- **Systems**: Create persistent prefab.
- **Find "Missing scripts" in project**.
- **Tick engine**.
- **Audio Manager** (Specialized for 3D Sounds).
- **Useful List Extensions**: Enhance list functionality with utilities like "Pick Random Item" or "Shuffle.
- **Interval Type** (Similar to Pair): Store two values in a more descriptive way, improving code readability.

## To do
- **Screenshot Utility**: Capturing screenshots within the application.

## Setup
- **Option A)** Clone or download the repository and drop it in your Unity project.
- **Option B)** Add the repository to the package manifest (go in YourProject/Packages/ and open the "manifest.json" file and add "com..." line in the depenencies section). If you don't have Git installed, Unity will require you to install it.
```
{
  "dependencies": {
      ...
      "com.szejkerek.gordonessentials": "https://github.com/szejkerek/com.szejkerek.gordonessentials.git"
      ...
  }
}
```
- **Option C)** Add the repository to the Unity Package Manager using the Package Manager dropdown.
