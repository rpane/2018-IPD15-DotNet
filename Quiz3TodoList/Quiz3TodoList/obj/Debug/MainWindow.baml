   M S B A M L   `   `   `  ����H  DQuiz3TodoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Quiz3TodoListQuiz3TodoList  5   	       Quiz3TodoList.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Quiz3TodoList     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5         m�Name$ miExport��5      $��_Export to csv...��6-   6H   �� 5      m� 5      -   5        $ miExit��5      $��_Exit��6+   6:   5      5      �� 5   
   $��Bottom=�6   .@�5      �� .��5      �� -   5        $��	lblStatus��5      5      5      �� 5   
   -   5        $��lvTask��5       $��10q�6   $	��554��6Y    � ContextMenu 5      �� 5      .@�5      m� -   5        $��miDelete��5   /   $��Delete��6   6?   5       �� View 5      �� 5      .P�5      �� $
��Task��6%    �� Width$	 250��63    �� DisplayMemberBinding 6?   �� *Task+�� 5      $��DueDate��6%   $	 100��66    6B   �� *	DueDate+ �� StringFormat$ 
yyyy-MM-dd���� 5       $��Status��6%   $	 200��65    6A   �� *
taskStatus+5!      5$      �� 5%   
   $��Right=�6   $	��200��6*   .@�5&      �� -   5         ��Name$ btnAdd��5&      $	��Add��6%   $	��177��63   $��60��6?   6K   �� 5'      $��Sort By:��6   	� 5(      -   5         	�Name$ 
rbSortTask��5(      $
��Task��6.   	 d� 	IsChecked$
	 TrueY�6=   6N   	� 5)      -   5        $ rbSortDD��5)      $��Due Date��6,   6?   5*      5,      5-      