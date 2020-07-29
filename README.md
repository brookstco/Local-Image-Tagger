# Local Image Tagger
 Local Image Tagger is a Windows program to tag, search, and sort locally saved images (and possibly eventually other files too). This program allows you to tag images with keywords, and then search through them all by keyword. The search images will load in a gallery form, and the files can then be opened in an in-app viewer or with another app. The image viewer has zoom and pan controls so you can easily focus on the whole image or a specific part, and can switch between Linear and Nearest Neighbor rendering to make viewing Pixel Art alongside high-resolution images easy.

 The primary purpose of this program is to help sort reference images for art to allow for rapidly finding good references from a local collection. Thus the ease of searching is as important as the ease of tagging, while tagging should still be convienent for individual files and small batches from any source. Descriptive tags are more important than photo metadata, and none of that metadata should affect the original file. The files are accessed without moving them to a directory for this program, although moving them after importing will break the connection. Additionally, the program has its own image viewer with support for switching between rendering a zoom modes (to accomodate pixel art), and all files can be directly opened in other apps.
 
 This program is completely local and does not ever connect to the internet. Internet access or local servers are not required once the images are stored locally. Already existing metadata won't be disturbed, and file sizes won't be inflated, since the tags are stored in a program specific database. While photo metadata is secondary behind descriptive tags, one could use another photo specific program to bake in metadata, and use this program for accessing it by description.

Can currently open the filetypes: BMP, JPEG, PNG, TIFF, Windows Media Photo, GIF, and ICON. However, animations and multiimage files will only display the base image.


### Planned Features:

This is not a roadmap, since there is no timeline or direction, but these are things I plan to add. They are in no particular order.

- Other image filetypes. I would like this to work with any common filetype at least, but it is most of the way there with just the major ones right now.

- Animated image support. Play gifs at least. apngs would be good too.

- Video support. Although not an image, they are a visual medium, so I would like to be able to play them too. Once added, I have considered adding the ability to bookmark specific frames in the video, to have it work as references more easily.

- Support for non-image filetypes. Most of the necessities for supporting any type of file are already in place, so expanding support to any filetype at all shouldn't be hard if video is already supported.

- Make the image viewer able to open image files outside of the program like any other viewer app. I work with pixel art a lot, so the viewer has benefits, and it is already installed, so making it more versatile is good.

- Read in image metadata. It should be easy just a bit time consuming, but it wasn't critical, so I haven't supported it yet.

- Allow for basic file editing. Changing file/directory names. This makes keeping the DB updated easier if you do it in-app rather than outside.

- Tags that change program settings. I want this so I can give a rendering tag to pixel art images, so that the image viewer will automatically have them render NN and everything else linear. 

- Profiles. Have seperate tag databases and settings based on the selected profile. Benefits seperate user, different use cases, and really bad computers that can't handle a massive DB.


### Alternatives:

This program is small, unfinished and written by a fairly new programmer. While I am trying to get it working robustly and efficiently, a more developed solution might be better if you don't need the particular features that I am making this for. 

There are already several good free options for tagging and searching photographs that I found before deciding to make my own. Notably there is [Adobe Bridge](https://helpx.adobe.com/bridge/using/keywords-adobe-bridge.html), [FastPhotoTagger](https://sourceforge.net/projects/fastphototagger/), and [Hydrus](https://github.com/hydrusnetwork/hydrus). However, these are good for keeping photos in check or working as a gallery, they aren't very easy or intuitive for my purposes, and all of them have undesirable behaviors for a reference art utility. Bridge is very powerful and its integration with the other adobe products can make many creative purposes easier, but its primary purpose is not tag based searching, and all adobe software is relatively heavy, so it is quite inconvienent for rapid use or use outside of Adobe. FastPhotoTagger seems to be made for dealing with large numbers of photos, such as dumping the memory of a camera, and does that well; however, it has limited filetype support and is slow and restrictive for rapidly finding results. Hydrus is focused on being a local version of online tag based image boards, so it does an excellent job at dealing with many images and importing from other sources, but it saves files only in its own location (which is probably a deal breaker if you are an artist including your own working files), and has a restrictive interface to increase its own power due to its focus on bulk.


### Technical Details:

The program was created using C# in visual studio 2019 as a wpf project. The MVVM style is used, but not kept strictly. Since the project is still fairly small in scale, MVVM is broken to help move the project to complettion faster over rigidly following it. For example, some code behind is used for behaviors that get unwieldy in MVVM, and the solution is not properly split into projects that seperate the WPF dependency. This also means that it will stay windows exclusive until I fix that up (or convert to somethings multiplatform), but if anyone greatly wants this for a different OS, you can submit an [Feature Request](https://github.com/brookstco/Local-Image-Tagger/issues), and I might start work on that, but no guarantees.

The tag database uses SQLite to prevent the need for user installations and the server overhead. The database design is primarily a three-table system that is based on the system often called Toxi. Speed for adding and editing is slightly sacrificed for search speed, and some extra space is used to speed up searches but it is not fully denormalised. Speeds should be extrememly fast for any reasonable amount of tags and files for a single user with a reasonable amount of images and tags (even several thousand images shouldn't exceed a second on a decent computer). 

