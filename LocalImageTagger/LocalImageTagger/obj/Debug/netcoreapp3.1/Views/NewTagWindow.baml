   M S B A M L   `   `   `  ����K  GLocalImageTagger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LocalImageTaggerLocalImageTagger  5   	   #    LocalImageTagger.NewTagWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LocalImageTagger     5   	   -   5          �Name$  	TagWindow��5   	    � Title$ Add New Tag��5	   	   $	��300��6   $	��400��6*    � WindowStartupLocation$ CenterOwner=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��    StandardStyleLabelBold#��[  6   $��Right=�6i   $��	10,10,0,0q�6�   $	��Top=�6�    �� Target 6@   ��  �� ElementName$ 	txtBoxTag��.��6�   _Tag6�   �� 5   
   -   5        $��	txtBoxTag��5      $��2q�6#   $��1��6/   $
��Left=�6?   $��10q�6Z   $	��Top=�6f   $	��250��6~    � ToolTip$Q K(Required) Enter the new tag.
It should have no spaces. Use - or _ instead.��6�   �� 5   
   $��	_Category��6   #��[  6$   $��1��6T   $��Right=�6�   $��10,0,0,0q�6�   $	��Top=�6�    6a   �� $ 	txtBoxCat��6�   �� 5!   
   -   5        $��comboBoxCategory��5!      $��1��6*   $��1��6:   $��
10,0,10,10q�6G   $< 6(Required) Select the category that the tag belongs to��6[   �� 5#   
   $
��_New��6   $��2��6    $
��Left=�60   $��0,0,10,0q�6K   $	��Top=�6]   $ Add a new category��6u   $��1��6�   �� 5%   
   $��_Aliases��6   $��2��6N   $��Right=�6[   $��10,0,0,0q�6w   $	��Top=�6�    6#   �� $ txtBoxAlias��6�   �� 5&   
   -   5        $��txtBoxAlias��5&      $��2q�6%   $��2��61   $��1��6>   $
��Left=�6N   $��	10,0,0,10q�6i   $	��Top=�6|   $	��250��6�   $� �(Optional) Enter alternative searchable tags that lead to this tag. Each should be seperated by a space.
For example, "mum" for "Chrysanthemum" or "p" as a shortcut for "photo".��6�   �� 5(   
   $��_Parents��6   $��3��6O   $��Right=�6\   $��10,0,0,0q�6x   $	��Top=�6�    6#   �� $ txtBoxParent��6�   �� 5)   
   -   5        $��txtBoxParent��5)      $��2q�6&   $��3��62   $��1��6?   $
��Left=�6O   $��	10,0,0,10q�6j   $	��Top=�6}   $	��250��6�   $� �(Optional) Enter any other tags that this tag implies exists. Those tag will be automatically added to an image when it is given this tag.
For example, if "flower" is a parent of "rose", when you tag an image with "rose" that image can be found with both the tags "rose" and "flower"��6�   �� 5+   
   $��_Description��6   $��4��6Q   $��Right=�6^   $��10,0,0,0q�6z   $	��Top=�6�    6'   �� $ 
txtBoxDesc��6�   �� 5,   
   -   5        $��
txtBoxDesc��5,      $��2q�6$   $��4��60   $��1��6=   $
��Left=�6M   $��	10,0,0,10q�6h   	 �� TextWrapping$
	 Wrap=�6{   
 �� AcceptsReturn$

 True��6�   $	��Top=�6�   $	��250��6�   $��70��6�   $c ](Optional) Enter the description for the new tag. This will be visible in the tag dictionary.��6�   �� 5.   
    �� Orientation$ 
Horizontal=�6   $��5��6.   $��Bottom=�6;   $��Right=�6V   $��3��6r   .+�5/      �� $	��_OK��6   $��10q�6#   $��60��6/   ��50      �� *SaveAndClose+��66   �� $ 	TagWindow���� 51      $��_Cancel��6    �� IsCancel$
 True��6'   $��10q�67   $��60��6C   ��52      �� *Close+��6/   �� $ 	TagWindow��53      57      58      