# numberToWordConverter
#project folder description<br/>
1. CoreConverter is the core logic for number to word convertion
2. ConverterUnitTest is test file to test the convertion
3. NumberToWordConverter is the project using .net 7 and this is ASP .NET CORE WEB APP (Model-View-Controller)

#Approach Reason<br/>
1. The reason i create multiple project is to make sure that the code tested by creating unit test project ,and separating the core logic from web application,
by using this approach, the core logic can be extended and used into other application if in future i need to add another project on different platform such as WPF or Window form.
2. My implementation can convert number up until DUOSEXAGINTILLION which is up to 190 digit number

# How To Run Application?
1. if you have visual studio,open the solution file and run NumberToWordConverter
2. if you dont have visual studio but have dotnet sdk installed, go to the directory of  NumberToWordConverter and open command line under the directory and type "dotnet run"


# How To Run Unit Test?
1. go to the ConverterUnitTest,open cmd and type "dotnet test"
