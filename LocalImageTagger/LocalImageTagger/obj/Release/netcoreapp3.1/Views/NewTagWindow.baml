   M S B A M L   `   `   `  ���� K  GLocalImageTagger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LocalImageTaggerLocalImageTagger  #    LocalImageTagger.NewTagWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:LocalImageTagger       � Title$  Add New Tag��$	��300��$	��400�� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+���    StandardStyleLabelBold#��[  $��Right=�$��	10,10,0,0q�$	��Top=� �� Target ��  �� ElementName$ 	txtBoxTag��.��_Tag�� -   $��	txtBoxTag��$��2q�$��1��$
��Left=�$��10q�$	��Top=�$	��250�� � ToolTip$Q K(Required) Enter the new tag.
It should have no spaces. Use - or _ instead.���� $��	_Category��#��[  $��1��$��Right=�$��10,0,0,0q�$	��Top=� �� $ 	txtBoxCat���� -   $��comboBoxCategory��$��1��$��1��$��
10,0,10,10q�$< 6(Required) Select the category that the tag belongs to���� $
��_New��$��2��$
��Left=�$��0,0,10,0q�$	��Top=�$ Add a new category��$��1���� $��_Description��$��2��$��Right=�$��10,0,0,0q�$	��Top=� �� $ 
txtBoxDesc���� -   $��
txtBoxDesc��$��2q�$��2��$��1��$
��Left=�$��	10,0,0,10q� �� TextWrapping$
 Wrap=�	 �� AcceptsReturn$
	 True��$	��Top=�$	��250��$��70��$c ](Optional) Enter the description for the new tag. This will be visible in the tag dictionary.���� $��_Aliases��$��3��$��Right=�$��10,0,0,0q�$	��Top=� �� $ txtBoxAlias���� -   $��txtBoxAlias��$��2q�$��3��$��1��$
��Left=�$��	10,0,0,10q�$	��Top=�$	��250��$� �(Optional) Enter alternative searchable tags that lead to this tag. Each should be seperated by a space.
For example, "mum" for "Chrysanthemum" or "p" as a shortcut for "photo".���� $��_Parents��$��4��$��Right=�$��10,0,0,0q�$	��Top=� �� $ txtBoxParent���� -   $��txtBoxParent��$��2q�$��4��$��1��$
��Left=�$��	10,0,0,10q�$	��Top=�$	��250��$� �(Optional) Enter any other tags that this tag implies exists. Those tag will be automatically added to an image when it is given this tag.
For example, if "flower" is a parent of "rose", when you tag an image with "rose" that image can be found with both the tags "rose" and "flower"���� 
 �� Orientation$
 
Horizontal=�$��5��$��3��$��Center=�.+��� $��Add Ta_g��$��10q�$��Bottom=�$��60���� -   $��	btnCancel��$��Ca_ncel�� �� IsCancel$
 True�� �� 	IsDefault$
 True��$��
0,10,10,10q�$��Bottom=�$��60��