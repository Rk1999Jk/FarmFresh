# Farm Fresh
Farmfresh connects farmers to buyers without any third party involved.It has 2 types of users with the following functionality for each user.
  ![MicrosoftTeams-image (7)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/72a30b0e-04da-44d3-974b-f540be741d5f)
**FARMER**

- **Login/Signup** New farmers can register their farm in the application and existing ones can login to the system
  ![MicrosoftTeams-image (6)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/9d2c0866-b3d9-45a0-a3ec-f0ad3480e179)
- **Add items** Farmers can add the products that they have under 6 categories -Vegetables,Fruits,Herbs,Green,Grain,Honey along with their Quantity,Pricing and Date of Harvest
  ![MicrosoftTeams-image (8)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/63d3d6e7-8dd1-4c74-b5df-daa83c88663e)
- **Edit Farmer Information**- They can edit their business details
  ![MicrosoftTeams-image (9)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/f0f3a279-b8d8-4d08-b781-dc3cb3ee3180)

- **Edit product details**- Edit the quantity,price of their products
  ![MicrosoftTeams-image (10)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/9063f86c-e44d-4acd-b397-4be701106767)

- **Delete the product**- Farmers can also delete any product from their account
  ![MicrosoftTeams-image (11)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/e8469a52-4be3-465f-a080-9b321ea512a0)

- **Logout**- Logout of the system at all times
  
**CUSTOMER**
-   **Login/Signup**  New customers can register their details in the application and existing ones can login to the system
  
    ![MicrosoftTeams-image](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/d0a48de5-d3ee-4db5-8f6e-e0b8d21a8020)

-   **Edit Customer Information**- They can edit their personal details
-   **Surf through products by chosing the category**- User can choose a category of the item they want to purchase
  
    ![MicrosoftTeams-image (1)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/da1b7e5c-2bdd-4c3f-a317-c99a7ea1b1d7)
-   **Selecting Available product**- Users can add their selected product to the cart and also choose the quantity to be added

    ![MicrosoftTeams-image (2)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/fc4917c2-3806-44db-8660-25db66789e96)
  
-   **View Cart**- View user cart that shows the item, their price and the quantity in a table format.
    ![MicrosoftTeams-image (3)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/a3682350-81e5-45f0-8a89-c114e05f7830)
-   **Edit Cart**- User cart can be edited for the products quantity in the cart.
-   **Delete a product from cart**- Users can delete a product from their cart
-   **Make payment**- Users can make payments for the items in the cart the system calculates the total amount to be paid.
    ![MicrosoftTeams-image (4)](https://github.com/Rk1999Jk/FarmFresh/assets/115196734/c4b556cd-170f-41ea-96d1-64973e296d9e)
-   **Logout**-Customers can logout of the system at all times.
  
**SPECIAL FEATURES**
- The system calculates a freshness value for each of the product automatically based on the date of harvest from the farmers input. When a customer is surfing through the application the products with a low freshness value will not be displayed deleting the record from the DB automatically.
- This code uses Entity Framework, which is an Object-Relational Mapping (ORM) framework for .NET. It provides an abstraction over relational databases.
- It also adds an anti-forgery token validation, a security measure against cross-site request forgery attacks
  
