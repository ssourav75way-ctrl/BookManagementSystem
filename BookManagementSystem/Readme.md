# 📚 Book Library – ASP.NET Core MVC Project

## Overview

This is a simple **Book Library web application** built using **ASP.NET Core MVC**. It allows users to:

* View a list of books
* See **highlighted books** (recently added)
* Filter books by **genre**
* View **book details**
* Dynamically see **total book count** based on filter

The project demonstrates **MVC architecture**, **partial views**, **form-based filtering**, and **dynamic updates**.

---

## Features

### ✅ Core Features

1. **Books List**

    * Displays all books in a card layout
    * Shows title, author, genre, availability, and description
    * Each book links to a **Details page**

2. **Highlighted Books**

    * Shows books added in the last 3 days
    * Rendered using a **partial view** for reusability

3. **Filter by Genre**

    * Dropdown allows users to filter books by genre
    * Filter button reloads the page with filtered results
    * **Total book count** updates dynamically

4. **Details Page**

    * Shows full information of a selected book

---

### 🖼 UI / Layout

* **Bootstrap 5** used for responsive card layout
* Highlighted books appear above the main list
* Filter form placed at the top for easy access
* Clean and minimalistic design

---

## Project Structure

```
/BookLibrary
│
├─ /Controllers
│    └─ BooksController.cs      # Handles Index, Details, and filtering logic
│
├─ /Models
│    └─ Book.cs                 # Book model with data annotations
│
├─ /Data
│    └─ StaticBookData.cs             # Static book list (mock database)
│
├─ /Views
│    ├─ /Books
│    │    ├─ Index.cshtml       # Main page with books and filter form
│    │    ├─ Details.cshtml     # Book details page
│    │    ├─ _BooksList.cshtml  # Partial view for book cards
│    │   
│    └─ /Shared
│         └─ _Layout.cshtml
          └─ _HighlightedBooks.cshtml # Partial view for highlights
│
├─ /wwwroot                     # Static assets (CSS, JS, images)
└─ appsettings.json             # App configuration
```

---

## Getting Started

### Prerequisites

* [.NET 6/7 SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 / VS Code
* Optional: SQL Server / database (currently uses in-memory static data)

---

### Installation

1. Clone the repository:

```bash
git clone https://github.com/your-username/BookLibrary.git
cd BookLibrary
```

2. Restore NuGet packages:

```bash
dotnet restore
```

3. Run the application:

```bash
dotnet run
```

4. Open the browser at:

```
https://localhost:5001
```

---

### Usage

* Navigate to **Books** page
* View **highlighted books** at the top
* Use the **genre filter dropdown** and click **Filter**
* Click **View Details →** on any book to see detailed info

---

### Notes / Improvements

* Currently uses **in-memory static book data**
* Can be extended to use **database with EF Core**
* Filtering is **server-side with page reload**
* Can be enhanced to **AJAX-based filtering** for smoother UX
* Highlighted books currently show all regardless of genre (can be made dynamic)

---

### .gitignore Recommendations

```
bin/
obj/
.vs/
*.user
*.suo
appsettings.*.json
.env
node_modules/
wwwroot/dist/
```

---



