# Local Image Tagger
 Small program to tag, search, and sort locally saved images as a project to practice coding.
WPF Project built in Visual studio with C#

 There are already several good free options for tagging and searching photographs. Notably there is Adobe Bridge and [FastPhotoTagger](https://sourceforge.net/projects/fastphototagger/). However, while both are good for keeping photos in check, they aren't very easy for what I want.
 
 The purpose of this program is to help sort reference images for art to allow for rapidly finding good references from a local collection. Thus the ease of searching is as important as the ease of tagging, and descriptive tags are more important than photo metadata. Additionally, all images can be directly opened in other apps
 
 Internet access or local servers are not required once the images are stored locally. Photo metadata is secondary behind descriptive tags. Already existing metadata won't be disturbed though, and file sizes won't be inflated, since the tags are stored in a program specific database. So one could use another photo sepcfic program to bake in EXIF, and use this for accessing it for art.

Can natively work with the filetypes: BMP, JPEG, PNG, TIFF, Windows Media Photo, GIF, and ICON. Other codecs will also be added, but are less critical. Eventually, also video files will load, and tags can be loaded from the standard metadata forms: Exchangeable image file (Exif), tEXt (PNG Textual Data), image file directory (IFD), International Press Telecommunications Council (IPTC), and Extensible Metadata Platform (XMP)).


Technical Details:
The program was created in visual studio 2019 as a wpf project in the MVVM style. The tag database is a 3-table system that is based on the three-table system that is often called Toxi.
