# Library Management System API

##  How to Run

1. Clone the repo:
   bash or terminal 
   git clone https://github.com/Adeolasheriff/Library_Management_System.git
   cd your repo

2 . dotnet Clean and Build 
  . dotnet restore

  3.Update Connection string if needed and update-migration.... ConnectionStrings: {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;TrustServercertificatte = true"
}
4. Run the Application
 1. Dotnet run on vscode or hit the https on visual studio

 ## How to test
 Once the application begins to run on swagger 
 1 . Use auth/register to create a user.
 2 . Login auth/login to get a JWT token.
 Click "Authorize" on Swagger

 in the space provided to input the token the bearer should be inputted first eg bearer then the token generated
 3. Now test /api/books endpoints.
 And also a user friendly message is returned if the user input the wrong token 

