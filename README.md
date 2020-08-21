# Local Image Tagger

**Note:** This project is going on hold for a while because of school. I was hoping to get v0.1 before I went back, but I still learned a lot. I will keep working on this when I have time, but there is no guarantee that I can finish much more before winter break, depending on how busy I am.

 Local Image Tagger is a Windows program to tag, search, sort, and view locally saved images (and eventually other files too). This program allows you to tag files with keywords, and then search the files by keyword tag. The searched images will load in a gallery form, and can then be opened in the built-in image viewer, or opened in any other program.

 The primary purpose of this program is to help sort reference images for art to allow for rapidly finding good references from a local collection; therefore:
- Tagging files is convenient, but the UI is optimized for searching and viewing. Once the files are imported, you can find an image by description almost instantly.
- The original files are not modified or moved in any way. Any artwork you include will be safe. All of the tag data is stored in a database with the program. Unfortunately, this means that moving or renaming files after importing them will require reconnecting them in the program.
- All Files can be opened with the standard open-with command to quickly use them in other apps, or viewed in the built-in image viewer. 
- The image viewer has zoom and pan controls so you can easily focus on the whole image or a specific part, and can switch between Linear and Nearest Neighbor rendering to make viewing pixel art alongside high-resolution images easy. 

 This program is completely local and does not ever connect to the internet. Check back every so often, since that means it will not currently check for updates either. 

Can currently open the filetypes: BMP, JPEG, PNG, and TIFF. More filetypes will be added in the future. Definitely more image sources. Hopefully animated images, videos, folders and anything else will follow.


### Suggestions and Warnings:

Users should take note of these suggestions and warnings to prevent annoyances or catastrophic results. The bugs will be fixed as the program develops, and many will be fixed by planned future features.

- Since this program does not connect to the internet, user information is not automatically backed up. All tag information is saved in ./Database/TagDatabase.db, so it is recommended that you frequently back this database up to at least another drive if not to the cloud or a separate storage device. While unlikely, this program is a small project from a new developer, so corruption is probably just a matter of time. Having backups is always good, but even more so when the program is not super thoroughly tested.

- Files are saved using absolute paths. This means that tagged files cannot be moved, renamed, or have one of the folders that they are nested in be renamed or Local Image Tagger will not be able to find them. Because of this, it is recommended that any files that you import are saved in a passable file structure before importing. Don’t leave a bunch of images on your desktop. It will just add more work for you later. In version 0.1, the files cannot be easily reconnected if changed, so you will have to just import it again and copy the data over from the old one. Even once I add a prompt for reconnecting, this program will not be able to automatically know if you move or rename a file.

- WARNING: Right now, files are not checked to see if they match their filetype in their filename. This will not cause an issue if a .jpg is named as .png, but if the program attempts to display a filetype that is not an image and is totally different (for example, an .exe that was renamed to .jpg), it may behave very badly. This behavior is undefined, so it could be inconsequential or crash the program. Either way, avoid loading non-image files with image file extensions until I fix up the image viewer.


### Technical Details:

The program is created using C# in visual studio 2019 as a WPF project. The MVVM style is used, but not kept strictly. Since the project is still fairly small in scale, MVVM is broken to help move the project to completion faster rather than rigidly following it. For example, some code behind is used for behaviors that get unwieldy in MVVM, and the solution is not properly split into projects that separate the WPF dependency. 

The tag database uses [SQLite](https://www.sqlite.org) to prevent the need for user installations and the server overhead. The database design is primarily a three-table system that is based on the system often called Toxi. Speed for adding and editing is slightly sacrificed for search speed, and some extra space is used to speed up searches but it is not fully denormalised. Speeds should be extremely fast for any reasonable amount of tags and files for a single user with a reasonable amount of images and tags (even searches with several thousand images should never exceed a second on a okay computer). 

I have been looking into AvaloniaUI as an option to allow for releasing on OSes other than Windows. It is based on WPF, but has some differences, so UI and some more complex WPF based features won’t be worked on until the transition is finished or rejected.

All code that I did not write (packages and other code) is licensed either under [Public Domain](https://fairuse.stanford.edu/overview/public-domain/welcome/#:~:text=The%20term%20%E2%80%9Cpublic%20domain%E2%80%9D%20refers,one%20can%20ever%20own%20it.), the MIT license (which Local Image Tagger is also licensed under), [Apache 2.0](https://www.apache.org/licenses/LICENSE-2.0), or [CPOL](https://www.codeproject.com/info/cpol10.aspx), all of which permit my usage of the code. Individual creators are credited in comments in the code if an entire package was not used.


### Alternatives:

This program is small, unfinished and written by a fairly new programmer. (Plus it isn't even usable right now.) While I am trying to get it working robustly and efficiently, a more developed solution might be better if you do not need the particular features that I am making this for. There are already several good free options for tagging and searching files and photographs that I found before deciding to make my own.

First off, windows files explorer has a built in tag system. It is not very robust, but if you need simple tagging, it is very easy.

[TagSpaces]( https://www.tagspaces.org/) and [tabbles]( https://tabbles.net/) both look to be fairly powerful and are able to tag any type of file, but focus less on image convenience because of the general use. Still very powerful options though.

For more image focused programs, notably there is [Adobe Bridge](https://helpx.adobe.com/bridge/using/keywords-adobe-bridge.html), [FastPhotoTagger](https://sourceforge.net/projects/fastphototagger/), and [Hydrus](https://github.com/hydrusnetwork/hydrus). However, these are good for keeping photos in check or working as a gallery, they are not very easy or intuitive for my purposes, and all of them have undesirable behaviors for a reference art utility. Bridge is very powerful and its integration with the other adobe products can make many creative purposes easier, but its primary purpose is not tag based searching, and all adobe software is relatively heavy, so it is quite inconvenient for rapid use or use outside of Adobe. FastPhotoTagger seems to be made for dealing with large numbers of photos, such as dumping the memory of a camera, and does that well; however, it has limited filetype support and is slow and restrictive for rapidly finding results. Hydrus is focused on being a local version of online tag based image boards, so it does an excellent job at dealing with many images and importing from other sources, but it saves files only in its own location (which is probably a deal breaker if you are an artist including your own working files), and has a restrictive interface to increase its own power due to its focus on bulk.
