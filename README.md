# Local Image Tagger
 A Windows program to tag, search, and sort locally saved images (and eventually other files too).

 The purpose of this program is to help sort reference images for art to allow for rapidly finding good references from a local collection. Thus the ease of searching is as important as the ease of tagging, while tagging should still be convienent for individual files and small batches from any source. Descriptive tags are more important than photo metadata, and none of that metadata should affect the original file. The files are accessed without moving them to a directory for this program, although moving them after importing will break the connection. Additionally, the program has its own image viewer with support for switching between rendering a zoom modes (to accomodate pixel art), and all files can be directly opened in other apps.
 
 This program is completely local and does not ever connect to the internet. Internet access or local servers are not required once the images are stored locally. Already existing metadata won't be disturbed, and file sizes won't be inflated, since the tags are stored in a program specific database. While photo metadata is secondary behind descriptive tags, one could use another photo specific program to bake in metadata, and use this program for accessing it by description.

Can natively work with the filetypes: BMP, JPEG, PNG, TIFF, Windows Media Photo, GIF, and ICON. Other codecs will also be added, but are less critical. Eventually, also video files will load, and tags can be loaded from standard metadata forms.


### Alternatives

This program is small, unfinished and written by a fairly new programmer. While I am trying to get it working robustly and efficiently, a more developed solution might be better if you don't need the particular features that I am making this for. 

There are already several good free options for tagging and searching photographs that I have found. Notably there is [Adobe Bridge](https://helpx.adobe.com/bridge/using/keywords-adobe-bridge.html), [FastPhotoTagger](https://sourceforge.net/projects/fastphototagger/), and [Hydrus](https://github.com/hydrusnetwork/hydrus). However, these are good for keeping photos in check or working as a gallery, they aren't very easy or intuitive for my purposes, and all of them have undesirable behaviors for a reference art utility. Bridge is very powerful and its integration with the other adobe products can make many creative purposes easier, but its primary purpose is not tag based searching, and all adobe software is relatively heavy, so it is quite inconvienent for rapid use or use outside of Adobe. FastPhotoTagger seems to be optimised for dealing with large numbers of photos, such as dumping the memory of a camera, and does that well; however, it has limited filetype support and is slow and restrictive for rapid results. Hydrus is focused on being a local version of online tag based image boards, so it does an excellent job at dealing with many images and importing from other sources, but it saves files only in its own location, and has a restrictive interface to increase its own power due to its focus on bulk.


### Technical Details:

The program was created using C# in visual studio 2019 as a wpf project. The MVVM style is used, but not kept strictly. That is in the interest of actually finishing the project, since I am learning as I go. To make this easier on myself and due to the small scale of the program, small amounts of code behind are used (primarily for open/close behaviors that get unwieldy in MVVM), and the solution is not properly split into projects that seperate the WPF dependency. This also means that it will stay windows exclusive until I fix that up, but if anyone greatly wants this for a different OS, you can submit an [Feature Request](https://github.com/brookstco/Local-Image-Tagger/issues), and I might start work on that, but no guarantees.

The tag database uses SQLite to prevent the need for user installations and the server overhead. It is a three-table system that is based on the system that is often called Toxi. Speed for adding and editing is slightly sacrificed for search speed, but it is not fully denormalised. Speeds should be extrememly fast for any reasonable amount of tags and files for a single user. 

