   M S B A M L   `   `   `  ����K  GLocalImageTagger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:LocalImageTagger.ViewsLocalImageTagger.Views  5   	   *    $LocalImageTagger.Views.NewFileWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:LocalImageTagger.Views     5   	   -   5          �Name$  
FileWindow��5   	    � Title$ Import New Files��5	   	   $	��300��5
   	   $	��400��6   $	��200��5   	   $	��200��6    � WindowStartupLocation$ CenterOwner=�5   	    � 	Resources 5         BoolToVisibility��%   &	        �� 5   
   6'   5      .��5      ]� .+�5   
   �� $	��Top=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��3,0,3,0q�6D   $��10q�6V   $
��Left=�6�   $��60��6�   ��6   �� *ButtonTextReplaceFiles+��6b   �� *AddNewFilesCommand+6�   �� 5      $��3,0,3,0q�6D   $��10q�6V   $
��Left=�6�   $��60��6�   ��6   �� *ButtonTextAddMoreFiles+��6b   �� *AddMoreFilesCommand+y�6�   �� *FilesSelected+ �� 	Converter# [  5      5      �� 5   
   $��Bottom=�6   $��Right=�6-   $ 
Horizontal=�6I   $��Bottom=�6b   .+�5      �� $	��_OK��6   $��10q�6#   $��60��6/   ��5      �� *SaveAndClose+��66   ��  �� ElementName$ 
FileWindow���� 5       $��_Cancel��6    �� IsCancel$
 True��6'   $��10q�67   $��60��6C   ��5!      �� *Close+��6/   �� $ 
FileWindow��5"      �� 5$   
   $
��Auto=�6   $
��Auto=�6:   .��5%      �� $��10q�6   ��6'   �� *Files+��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6%   .+�5)      �� ��6(   �� *
FileName+�� 5*      $�� (��6(   �� 5+      ��6(   �� *
FullPath+�� 5,      $��)��6(   5-      5.      50      51      53      54      