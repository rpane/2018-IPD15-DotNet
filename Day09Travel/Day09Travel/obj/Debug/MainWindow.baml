   M S B A M L   `   `   `  ����F  BDay09Travel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Day09TravelDay09Travel  5   	       Day09Travel.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Day09Travel     5   	     � Title$  
MainWindow��5   	   $��351.103��6   $��666.326��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��13* �6   �� 5      $
��600* �6   .+�5   
   �� -   5         ��Name$ 
btnSaveSel��5      $��Save Selected��6%   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6k   $��75��6�   $��2��6�   6�   �� 5   
   -   5         ��Name$ lvTrips��5      $
��Left=�6$   $	��274��6?   $��	10,35,0,0q�6L   $	��Top=�6_   $	��636��6w   $��2��6�    �� View 5      �� 5      .P�5      �� -   5        gvID�� �� Width$ 30��5   3    �� DisplayMemberBinding 6>   �� *Id+��5      �� 5      -   5         ��Name$ 
gvIDHeader��5   3   
 � Tag$ id��6G   .��6i   #6l   5      �� 5      $	 100��6&    62   �� *Destination+��5      �� 5      -   5        $ gvDestinationHeader��5   3   $ Destination��6P   .��6�   Destination6�   5      �� 5      $	 100��6&    62   �� *Name+��5      �� 5      -   5        $ gvNameHeader��5   3   $
 Name��6I   .��6o   Name6u   5       �� 5!      $��Passport No.��6%   $	 100��6;    6G   �� *
PassportNo+�� 5"      $��	Departure��6%   $	 100��68    6D   �� *	Departure+	 �� StringFormat$	 
yyyy-MM-dd���� 5#      $��Return��6%   $	 100��65    6A   �� *
ReturnDate+$	 
yyyy-MM-dd���� 5$      $��	Transport��6%   $	 100��68    6D   �� *	Transport+5%      5'      �� 5(   
   -   5        $ btnAdd��5(      $��Add Trip��6!   $
��Left=�64   $��
556,10,0,0q�6O   $	��Top=�6c   $��75��6{   $��1��6�   6�   5*      5+      