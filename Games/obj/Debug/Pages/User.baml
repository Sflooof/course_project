   M S B A M L   `   `   `  ����@  <Games, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Games.PagesGames.Pages  5          Games.Pages.User   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Games.Pages     5      -   5          N� Title$
  User��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      $��* �6   6)   �� 5      $��35 �6   6*   .+�5   
   � $��0��6   
�������.+�5      �� $��Пользователи��6   $��28(�6,   $��Center=�6:   6Y   5      � 5   
   $��2��6   ���#FF9F40.+�5      �� -   5         ��Name$ Btn_back��5      $��
Назад��6>   $
��Left=�6N   $	��180��6i   �� 5      -   5        $��Bt_add_user��5   5   $/��)Добавить пользователя��6   $��Right=�6H   $	��200��6d   $��0,0,5,0q�6�   5      �� 5   
   -   5         ��Name$ listviewUser��5      $��1��6)   ��5      �� 5      .R�5      � $��20q�6   $
��1000��6'    � ColumnDefinitions 5      �� 5      $	��100 �6/   6=   �� 5      $	��100 �6/   6=   �� 5      $	��100 �6/   6=   �� 5       $	��180 �6/   6=   �� 5!      $	��120 �6/   6=   �� 5"      $��30 �6/   6<   �� 5#      $	��171 �6/   6=   �� 5$      $	��171 �6/   6=   .+�5&      �� $��Center=�6=    �� TextAlignment$ Center=�6X   $
��auto��6o   $	��5 5q�6|   $��0��6�   ��6$   �� *	surname+6�   �� 5'      $��Center=�6:   $ Center=�6U   $
��auto��6l   $	��5 5q�6y   $��1��6�   ��6$   �� *name+6�   �� 5(      $��Center=�6@   $ Center=�6[   $
��auto��6r   $	��5 5q�6   $��2��6�   ��6$   �� *
patronymic+6�   �� 5)      $��Center=�6;   $ Center=�6V   $
��auto��6m   $	��5 5q�6z   $��3��6�   ��6$   �� *email+6�   �� 5*      $��Center=�6>   $ Center=�6Y   $
��auto��6p   $	��5 5q�6}   $��4��6�   ��6$   �� *
password+6�   �� 5+      $��Center=�6:   $ Center=�6U   $
��auto��6l   $	��5 5q�6y   $��5��6�   ��6$   �� *role+6�   �� 5,      $��Bt_del��63   -   5        $��Удалить��5,   !   $	��171��6A   $��6��6b   �� 5-      $��Bt_edit��69   -   5        $ ��Редактировать��5-   !   $	��171��6H   $��7��6j   5.      5/      51      52      53      