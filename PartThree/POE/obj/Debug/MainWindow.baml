   M S B A M L   `   `   `  ����>  :POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:POEPOE  5   	       POE.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:POE     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowState$ 	Maximized=�65   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5      �� -   5         ��Name$ RecipeNameTextBlock��5      $��Recipe Name:��65   $��Center=�6I   $
��Bold"�6d   �� 5      -   5         ��Name$ RecipeNameTextBox��5      $��80��61   $��5q�6<   �� 5      -   5        $ IngredientNumberTextBlock��5      $��No. of Ingredients:��6;   $��Center=�6V   $
��Bold"�6q   �� 5      -   5        $ IngredientNumberTextBox��5      $��50��67   $��5q�6B   �� 5      -   5        $ StepNumberTextBlock��5      $��No. of Steps:��65   $��Center=�6J   $��20,0,0,0q�6e   $
��Bold"�6w   �� 5      -   5        $ StepNumberTextBox��5      $��50��61   $��5q�6<   �� 5      -   5         ��Name$ CreateRecipeButton��5      $��Create Recipe��61   $��5q�6j   $
��Bold"�6u   
������ 6�   5      �� 5   
   $��1��6   .��5      �� -   5         ��Name$ recipeDetails��5      $��10q�60   .+�5      �� -	   5         ��Name$ RecipeRichTextBox��5      $��10q�69   	 �� 
IsReadOnly	 . 
������ 6W   5      5      �� 5    
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5!      �� -
   5        $ ListRecipeButton��5!      $��List Recipes��6/   $��5q�6e   $
��Bold"�6p   
������ 6�   �� 5"      -   5        $ FilterRecipesButton��5"      $��Filter Recipes��62   $��5q�6m   $
��Bold"�6x   
������ 6�   �� 5#      -   5        $ ScalingFactorTextBlock��5#      $��Scaling factor:��68   $��Center=�6O   $
��Bold"�6j   �� 5$      -   5        $ ScalingFactorTextBox��5$      $��50��64   $��5q�6?   �� 5%      -   5        $ ScaleRecipeButton��5%      $��Scale Recipe��60   $��5q�6g   $
��Bold"�6r   
������ 6�   �� 5&      -   5        $ ResetQuantitiesButton��5&      $��Reset Quantities��64   $��5q�6s   $
��Bold"�6~   
������ 6�   �� 5'      -   5        $ ClearRecipeButton��5'      $��Clear Recipe��60   $��5q�6g   $
��Bold"�6r   
������ 6�   5(      5*      5+      