   M S B A M L   `   `   `  ����G  CLaborProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:LaborProject.Modules.TestCmdWindow.Views(LaborProject.Modules.TestCmdWindow.Views  5      A =Gemini, Version=0.7.0.0, Culture=neutral, PublicKeyToken=nullW8clr-namespace:Gemini.Framework.Behaviors;assembly=GeminiGemini.Framework.Behaviors 5      @    :LaborProject.Modules.TestCmdWindow.Views.TestCmdWindowView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:LaborProject.Modules.TestCmdWindow.Views     5      N	behaviors8clr-namespace:Gemini.Framework.Behaviors;assembly=Gemini     5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      ��5   
   �� 5       �� Color$ White��6   .+�5   
   �� -   5         ��Name$ 	TreePanel��5      $��0��6(   $��0��68   $��Stretch=�5      $��0q�63   $��Stretch=�6>   .+�5      R� -   5         R�Name$ treeView��5      $��0q�6)   
�������$��0q�6H   $��Stretch=�5      $��Stretch=�65   .@�5       Q� $
��Port��6   $
��Auto��6-   .@�5!      Q� -   5        $��
Tree_Port0��5!   #   $��Port0��65   5"   #   Q� 5#      -   5        $��
Tree_Port1��5#   #   $��Port1��65   5$   #   Q� 5%      -   5        $��
Tree_Port2��5%   #   $��Port2��65   5&   #   Q� 5'      -   5        $��
Tree_Port3��5'   #   $��Port3��65   5(   #   5)      5*      5+      �� 5.   
   -   5        $��ButtonPanel��5.      $��1��5/      $��0��6%   $	��Top=�50      $��0q�51      .+�52      �� $��Center=�6   .��61   AREA 169   �� 54      -   5        $��OpenComButton��54      $��Hit__To__Open__COM��55      $��5q�56      57      �� 59      -	   5        $��InitializeButton��59      $��Hit__To__Initialize��5:      $��5q�5;      5<      �� 5>      -
   5         ��Name$ ResetButton��5>      $��Hit__to__Reset��5?      $��5q�5@      5A      �� 5D      -   5        $ 
TestButton��5D      $��Hit__to__Test��5E      $��5q�5F       J� RenderTransformOrigin$ 	0.501,0.5&�6    5G      �� 5J      -   5        $ TestButton2��5J      $��Hit__to__Test2��5K      $��5q�5L      $ 	0.501,0.5&�6    5M      5N      �� 5Q   
   -   5        $��OutputWindow��5Q      $��3��5R      $��Center=�5S      $��10,10,10,10q�6#   $��24(�5T      $
��Wrap=�5U       �� TextAlignment 5R   $   �� *TextAlignment+ �� FallbackValue$ Center����5T      �� *Text+&$This is the Prototype of the Project��5W      �� 5X       6"   �� *
Foreground+$ Black��5Z      �� 5]   
   -   5        $��
TheTextBox��5]      $��2��5^      $��10q�6"   	 �� 
IsReadOnly	 . "
 �� VerticalScrollBarVisibility$

 Auto=�5`      
�������.��5a   %   输出内容显示区域5d      �� 5h   
   
�������$��0 0 1 0q�6(   6E   �� 5i   
   $��4��6   
�������$��0 0 0 1q�6<   6Y   �� 5m   
   $��Center=�6   $��0��6-   $��1��6=   $��4��6J   .��6^   AREA 2: Port Area6q   �� 5o   
   -   5        $��
Port0Panel��5o      $��0��5p      $��1��6%   $��4��62   $��Stretch=�5q      $��Stretch=�61   $��0q�5r      $y�Hidden=�6    .+�5s      �� -   5         ��Name$ textBlock_Port0_Name��5s      $
��Wrap=�66   $��Port 0��6J   $��0,0,0,10q�5t      �� 5u      -   5        $ textBlock_Port0_Ip��5u      $
��Wrap=�64   $��
IP Address��6H   $��0q�5v      �� 5w      �� 5x      -   5        $ textBlock_Port0_Mac��5x      $
��Wrap=�65   $��Mac Address��6I   $��0q�5y      �� 5z      5{      �� 5}   
   -   5        $��
Port1Panel��5}      $��0��5~      $��1��6%   $��4��62   $��Stretch=�5      $��Stretch=�61   $��0q�5�      $y�Hidden=�6    .+�5�      �� -   5        $ textBlock_Port1_Name��5�      $
��Wrap=�66   $��Port 1��6J   $��0,0,0,10q�5�      �� 5�      -   5        $ textBlock_Port1_Ip��5�      $
��Wrap=�64   $��
IP Address��6H   $��0q�5�      �� 5�      �� 5�      -   5        $ textBlock_Port1_Mac��5�      $
��Wrap=�65   $��Mac Address��6I   $��0q�5�      �� 5�      5�      �� 5�   
   -   5        $��
Port2Panel��5�      $��0��5�      $��1��6%   $��4��62   $��Stretch=�5�      $��Stretch=�61   $��0q�5�      $y�Hidden=�6    .+�5�      �� -   5        $ textBlock_Port2_Name��5�      $
��Wrap=�66   $��Port 2��6J   $��0,0,0,10q�5�      �� 5�      -   5        $ textBlock_Port2_Ip��5�      $
��Wrap=�64   $��
IP Address��6H   $��0q�5�      �� 5�      �� 5�      -   5        $ textBlock_Port2_Mac��5�      $
��Wrap=�65   $��Mac Address��6I   $��0q�5�      �� 5�      5�      �� 5�   
   -   5        $��
Port3Panel��5�      $��0��5�      $��1��6%   $��4��62   $��Stretch=�5�      $��Stretch=�61   $��0q�5�      $y�Hidden=�6    .+�5�      �� -   5        $ textBlock_Port3_Name��5�      $
��Wrap=�66   $��Port 3��6J   $��0,0,0,10q�5�      �� 5�      -   5        $ textBlock_Port3_Ip��5�      $
��Wrap=�64   $��
IP Address��6H   $��0q�5�      �� 5�      �� 5�      -   5        $ textBlock_Port3_Mac��5�      $
��Wrap=�65   $��Mac Address��6I   $��0q�5�      �� 5�      5�      5�      5�      