   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	    CaesarEncryptionPracticeWPF,   &CaesarEncryptionPracticeWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	     � Title$  Ave Caesar!��5   	    � Icon$ Images/89605290.ico��6   $	��600��68   $	��650��6E   .��5      �  � RowDefinitions 5   
   �� 5	      $��75 �6   �� 5
      $��* �6   �� 5      $��* �6   �� 5      $��75 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   o� $	��Top=�6   $��3��6'   .@�5      m� $
��File��6   .@�5      m� -   5        $��MenuItemSave��5      $
��Save��6/   6=   m� 5      -   5        $��MenuItemSaveAs��5      $��SaveAs��61   6A   m� 5      -   5        $��MenuItemOpen��5      $
��Open��6/   6=   5      5      �� 5   
   $��Images/ceasar.jpg��6   $��3��6+   $��1��6?   $��0,0,0,0q�6L   �� 5   
   -   5         ��Name$ TextBoxFirst��5       �� TextWrapping$
 Wrap=�6(   $��0��6<   $��1��6L   �� 5   
   -   5        $ TextBoxSecond��5      $
 Wrap=�6)   $��2��6=   $��1��6M    �� 
IsReadOnly . 6Z   �� 5   
   -   5         ��Name$ EncryptionButton��5      $��
Encryption��6+   $��0,20,0,0q�6@   $	��Top=�6R   $��Center=�6j   $��80��6�   $��1��6�   $��1��6�   6�   �� 5   
   -   5        $ DecryptionButton��5      $��
Decryption��6+   $��0,0,0,20q�6@   $��Bottom=�6R   $��Center=�6n   $��80��6�   $��1��6�   $��1��6�   6�   �� 5   
   -   5        $ 
TextBoxROT��5      $��107,90,65,92q�6&   $��Center=�6<   $��Center=�6W   $��1��6t   $��1��6�   $��30��6�   $��42��6�   �� 5    
   -	   5         ��Name$ ROTLabel��5       $��Center=�6"   $��Center=�6F   $	��ROT��6h   $��69,90,114,92q�6v   $��Center=�6�   $��Center=�6�   $��1��6�   $��1��6�   $��30��6�   >   8System.Windows.Controls.DataVisualization.Charting.Chart  5"   
   -
   5        $��columnChart��5"       $��2��63   	   Title$#	 Column diagram of repetitions��6A   $��3��6g   
   Series.
 5#      E   ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DependentValuePath$ Value��6+   ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ letter��6F      IndependentValuePath$	 Key��6U      ItemsSource 6p   �� 5$      �� 5&   
   -   5        $��TextBlockLegend��5&      $��16(�6(   $��Center=�67   $��Center=�6[   $��3��6}   $��0��6�   $��0,20,0,0q�6�   .��6�   OMAve Caesar! The program for encryption and decryption of the cipher of Caesar5(      �� 5)   
   -   5        $��TextBlockNumberOfROT��5)      $��16(�6,   $��Center=�6:   $��Center=�6^   $��3��6�   $��3��6�   .��6�   #!The expected shift for this text:5+      5-      5.      