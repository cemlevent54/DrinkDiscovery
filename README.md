# 🥤 DrinkDiscovery Project Overview

**DrinkDiscovery** is a comprehensive e-commerce platform designed to efficiently manage drinks, categories, users, roles, and comments through an intuitive admin panel. The project is divided into two main components:

- **Admin Panel:** Handles all management tasks, including product catalog updates, user and role administration, and comment moderation.

- **User Panel:** Enables seamless interaction with drink listings, shopping cart management, and order processing.
  This system offers a robust and scalable solution, providing essential features required for any e-commerce platform to streamline product management and enhance user experience.

---

## ✨ Features

### 👤 Admin Panel

1. **Product Management:** Admins can efficiently add, update, view, or delete drinks, desserts, and other products.
2. **User Management:** Admins can manage registered users by updating their information or removing them if necessary.
3. **Role Management:** Admins can create, view, update, and delete roles, as well as assign roles to users.
4. **Comment Management:** Admins have control over user comments, including the ability to approve, reject, or delete them.

### 👥 User Panel

1. **Homepage:** The user dashboard features a product slider, a highlighted beverage of the week, and popular desserts.
2. **Beverages:** Users can explore beverages by category, leave comments, and interact with existing comments by liking or disliking them.
3. **Desserts:** Users can browse desserts by category, post comments, and engage with other users' comments through likes and dislikes.
4. **Products:** Users can view products categorized by type, share feedback through comments, interact with comments, and add items to their cart for purchase.
5. **Order and Cart:** Users can manage their cart, finalize purchases, and track their orders through their account.

6. **Email Confirmation:** Once payment details are submitted, users are directed to confirm their order via an email link. Upon confirmation, the order is finalized and becomes visible in the `"Orders"` section of their account.

---

## 🛠️ Installation

Follow these steps to set up the project:

### 🛠 Prerequisites

1. **.NET SDK**

   - Download the latest version from the official [.NET site](https://dotnet.microsoft.com/en-us/download).

2. **Visual Studio 2022 or later**
   - Install SQL Server and SQL Server Management Studio (SSMS).

### ⚙️ Setup Steps

1. **Open a terminal or command prompt.**

2. **Clone the repository or download the source code.**

   ```bash
   git clone https://github.com/cemlevent54/DrinkDiscovery.git
   ```

3. **Go to the .sln folder and open it.**

   ```bash
   DrinkDiscovery.sln
   ```

4. **Configure Database**

   - Open the `appsettings.json` files for both `DrinkDiscovery_Revised` and `DrinkDiscovery_Admin_Revised` projects.
   - Update the connection strings with your SQL Server instance name (`YOUR
_SERVER`) and configure the database as follows:

   **DrinkDiscovery_Revised Project:**

   ```bash
       "ConnectionStrings": {
           "DrinkDiscovery_Revised_ContextConnection": "Server=YOUR_SERVER;  Database=DrinkDiscovery_Revised;Trusted_Connection=True;"
       }
   ```

   **DrinkDiscovery_Admin_Revised Project:**

   ```bash
       "ConnectionStrings": {
            "IdentityDbConnection": "Server=DESKTOP-YOUR_SERVER;Database=DrinkDiscovery_Revised;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=True;",

            "DrinkDiscovery_Admin_Revised_ContextConnection": "Server=YOUR_SERVER;Database=DrinkDiscovery_Revised;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
        }
   ```

   - Use `SQL Server Management Studio (SSMS)` to restore the database backups. Restore the `DrinkDiscovery_Admin` and `DrinkDiscovery_Revised` databases from the provided backup files.

5. **SMTP**

- Open the `appsettings.json` file in the `DrinkDiscovery_Revised` project and update the `SmtpSettings` section with your email service credentials:
  ```bash
      "SmtpSettings": {
      "Host": "smtp.gmail.com",
      "Port": 587,
      "SenderName": "DrinkDiscovery",
      "SenderEmail": "yoursenderemail@gmail.com",
      "UserName": "yourusername",
      "Password": "your-app-password-from-google"
      }
  ```

6. **Run the Project**
   - In `Visual Studio`, set the desired project (`DrinkDiscovery_Revised` or `DrinkDiscovery_Admin_Revised`) as the startup project:
   - Right-click the project in `Solution Explorer > Set` as `Startup Project`.

---

## ▶️ Project Demo

## [![Watch the Project Demo](https://img.youtube.com/vi/B1z3VAlzajc/0.jpg)](https://www.youtube.com/watch?v=B1z3VAlzajc)
