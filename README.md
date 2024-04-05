# numberToWordConverter
#project folder description<br/>
1. CoreConverter is the core logic for number to word convertion
2. ConverterUnitTest is test file to test the convertion
3. NumberToWordConverter is the project using .net 7 and this is ASP .NET CORE WEB APP (Model-View-Controller)

#Approach Reason<br/>
1. The reason i create multiple project is to make sure that the code tested by creating unit test project ,and separating the core logic from web application,
by using this approach, the core logic can be extended and used into other application if in future i need to add another project on different platform such as WPF or Window form.
2. My implementation can convert number up until DUOSEXAGINTILLION which 10 power of 120
