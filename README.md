# Local Image Tagger
 A Windows program to tag, search, and sort locally saved images (and eventually other files too).

 The purpose of this program is to help sort reference images for art to allow for rapidly finding good references from a local collection. Thus the ease of searching is as important as the ease of tagging, and descriptive tags are more important than photo metadata. Additionally, all images can be directly opened in other apps.
 
 There are already several good free options for tagging and searching photographs. Notably there is Adobe Bridge and [FastPhotoTagger](https://sourceforge.net/projects/fastphototagger/). However, while both are good for keeping photos in check, they aren't very easy or intuitive for my purposes.
 
 Internet access or local servers are not required once the images are stored locally. Already existing metadata won't be disturbed, and file sizes won't be inflated, since the tags are stored in a program specific database. While photo metadata is secondary behind descriptive tags, one could use another photo specific program to bake in metadata, and use this program for accessing it by description.

Can natively work with the filetypes: BMP, JPEG, PNG, TIFF, Windows Media Photo, GIF, and ICON. Other codecs will also be added, but are less critical. Eventually, also video files will load, and tags can be loaded from standard metadata forms.


### Technical Details:

The program was created using C# in visual studio 2019 as a wpf project. The MVVM style is used, but not kept strictly. That is in the interest of actually finishing the project, since I am learning as I go. To make this easier on myself and due to the small scale of the program, small amounts of code behind are used (primarily for open/close behaviors that get unwieldy in MVVM), and the solution is not properly split into projects that seperate the WPF dependency. This also means that it will stay windows exclusive until I fix that up, but if anyone greatly wants this for a different OS, you can submit an [Feature Request](https://github.com/brookstco/Local-Image-Tagger/issues), and I might start work on that, but no guarantees.

The tag database is a three-table system that is based on the system that is often called Toxi. Speed for adding and editing is slightly sacrificed for search speed, but it is not fully denormalised. Speeds should be extrememly fast for any reasonable amount of tags and files for a single user. 

