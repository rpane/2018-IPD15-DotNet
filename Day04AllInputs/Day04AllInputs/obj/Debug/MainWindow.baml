   M S B A M L   `   `   `  ����I  EDay04AllInputs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Day04AllInputsDay04AllInputs  5   	       Day04AllInputs.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Day04AllInputs     5   	     � Title$  
MainWindow��5   	   $��270.455��6   $��417.045��6-   .��5	      � .+�5
   
   �� $��Name:��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N    J� RenderTransformOrigin$ -0.407,-0.39&�6f   �� 5   
   -   5         ��Name$ tbName��5      $
��Left=�6"   $��23��6=   $��	66,10,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   �� 5   
   $
��Age:��6   $
��Left=�6   $��	10,41,0,0q�6:   $	��Top=�6M   �� 5   
   $��Pets:��6   $
��Left=�6    $��	10,67,0,0q�6;   $	��Top=�6N   �� 5   
   $��Continent of Residence��6   $
��Left=�61   $��	10,98,0,0q�6L   $	��Top=�6_   �� 5   
   $��Prefered temp °C��6   $
��Left=�6+   $��
10,135,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5         ��Name$ slTemp��5       �� IsSnapToTickEnabled . $
��Left=�6<   $��148,143,0,0q�6W   $	��Top=�6l   $	��178��6�   $ -0.011,-0.015&�6�    � Maximum$ 35Q�6�    � Minimum$ 15Q�6�    � Value$ 25Q�6�   	 �� AutoToolTipPlacement$	 TopLeft=�6�   
 � SmallChange$
 1Q�6�   �� 5   
   -   5         ��Name$ btnRegister��5      $��Register Me��6@   $
��Left=�6V   $��166,189,0,0q�6q   $	��Top=�6�   $��75��6�   	� 5   
   -   5         	�Name$ 	rbBelow18��5       	� 	GroupName$	 Age��6E   $��Below 18��6U   $
��Left=�6h   $��	58,47,0,0q�6�   $	��Top=�6�   	� 5   
   -   5        $ rb18_35��5      $	 Age��6C   $��18-35��6S   $
��Left=�6c   $��
148,47,0,0q�6~   $	��Top=�6�   	� 5   
   -   5        $ rb36_��5      $	 Age��6A   $��	36 and Up��6Q   $
��Left=�6e   $��
233,47,0,0q�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ cbCat��5      $	��Cat��6"   $
��Left=�60   $��	54,73,0,0q�6K   $	��Top=�6^   �� 5   
   -   5        $ cbDog��5      $	��Dog��6"   $
��Left=�60   $��
130,73,0,0q�6K   $	��Top=�6_   �� 5   
   -	   5        $ cbOther��5      $��Other��6$   $
��Left=�64   $��
201,73,0,0q�6O   $	��Top=�6c   �� 5   
   -
   5         ��Name$ cbContinents��5      $
��Left=�6)   $��167,103,0,0q�6D   $	��Top=�6Y   $	��120��6q    �� SelectedIndex$ 0��6}   .@�5      �� $��Africa��6   �� 5      $��	Antartica��6   �� 5      $
��Asia��6   �� 5      $��Europe��6   �� 5      $��North America��6   �� 5      $��South America��6   �� 5      $��
Austrailia��6   5       �� 5!   
   -   5         ��Name$ lblSliderVal��5!      $
��Left=�6X   $��341,135,0,0q�6s   $	��Top=�6�   ��6&   ��  �� ElementName$ slTemp�� �� Path$ Value�6�   5#      5$      