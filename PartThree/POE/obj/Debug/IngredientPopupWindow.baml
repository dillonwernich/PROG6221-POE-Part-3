   M S B A M L   `   `   `  ����  POE    POE.IngredientPopupWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Ingredient Popup��5   	   $	��400��6"   $	��350��6/    � WindowState$ 	Maximized=�6;   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Ingredient Name:��6   $
��Bold"�6,   �� 5   
   -   5         ��Name$ IngredientNameTextBox��5      $��1��61   $	��200��6>   $��	0,5,130,5q�6J   �� 5   
   $��	Quantity:��6   $
��Bold"�6%   $��2��67   $��0,10,0,0q�6D   �� 5   
   -   5        $ IngredientQuantityTextBox��5      $��3��65   $	��200��6B   $��	0,5,130,5q�6N   �� 5   
   $��Unit of Measurement:��6   $
��Bold"�60   $��4��6B   $��0,10,0,0q�6O   �� 5   
   -   5        $ IngredientUnitTextBox��5      $��5��61   $	��200��6>   $��	0,5,130,5q�6J   �� 5   
   $��	Calories:��6   $
��Bold"�6%   $��6��67   $��0,10,0,0q�6D   �� 5   
   -   5        $ IngredientCaloriesTextBox��5      $��7��65   $	��200��6B   $��
0,5,130,29q�6N   $��17.96��6b   �� 5   
   $��Food Group:��6   $
��Bold"�6'   $��7��69   $��0,39,0,1q�6F   �� 5   
   -   5        $  IngredientFoodGroupTextBox��5      $��7��66   $	��200��6C   $��0,67,130,-25q�6O   $��17.96��6e   �� 5    
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��7��6K   $��0,106,0,-86q�6X   .+�5!      �� -   5         ��Name$ OkButton��5!      $��OK��6'   $��80��64   $��10q�6?   6K   �� 5"      -   5        $ CancelButton��5"      $��Cancel��6+   $��80��6<   $��10q�6G   6S   5#      5$      5%      