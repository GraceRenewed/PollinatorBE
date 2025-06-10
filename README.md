

<h1 align="center" style="font-weight: bold;">Planting for Pollinators</h1>

<p align="center">
<a href="#tech">Technologies</a>
<a href="#started">Getting Started</a>
<a href="#contribute">Contribute</a> 
</p>


<p align="center">Pollinator populations are decreasing and many people want to help. This app will give people the tools they need to support them. This repository includes all the backend connections, calls, and unit tests for the application.</p>

<h2 id="feature"> Features</h2>  

This application gives users the ability to create gardens based on pollinators that they would like to help and attract. It enables people create their own garden by selecting plants they would like to include in their garden. They are able to select pollinators and view the types of plants that they are attracted to. It gives the user full CRUD on their User Profile, Garden, Plants, and Pollinators and the ability to Crud on their specific garden by the addition of a join table between Gardens and Plants.

<p align="center">
<a href="https://github.com/GraceRenewed/PollinatorBE/"> Visit this Project</a>
<a href="https://docs.google.com/presentation/d/16FfCE0A8rwL9ZbVFrgeazzTcfgQc6p0My5CoAg6qO0A/edit?usp=sharing"> Project Slide Presentation
</p>

<h2 id="depolyment"> Deployed API </h2>

[API Documentation](https://documenter.getpostman.com/view/36650801/2sB2x3msj5)

<h2 id="apiCalls"> API Call Videos </h2>
 
[Postman Video 1](https://www.loom.com/share/c95f3072f3594491beebc460d4db9477?sid=e704af40-61e8-4a0b-9539-51ac5267649d)

[Postman Video 2](https://www.loom.com/share/8890f5913d3641e19bbc55cd2425ebba?sid=12ae9162-ff7f-437e-8d91-7e7ba144b518)

<h2 id="user"> Description of Ideal User </h2>

Any individual who enjoys pollinators and likes plants would be the ideal user. This app would help them support their local pollinator population by allowing the user to plan their flower selections for the flower pots or garden with plants that they feed on. 

<h2 id="technologies">💻 Technologies</h2>

- .NET 9 
- C# 13.0 
- ASP.NET Core 
- Entity Framework Core 
- xUnit 
- Moq 
- Swashbuckle.AspNetCore 
- Visual Studio 
- Microsoft.NET.Test.Sdk
- System.ComponentModel.DataAnnotations 
- JSON configuration 
- Postman
- PostgreSQL(PgAdmin)

<h2 id="started">🚀 Getting started</h2>

What you need to do to run PollinatorBE project locally

<h3>Prerequisites</h3>


- [.NET 9 SDK](https://dotnet.microsoft.com./en-us/)
- [Git](https://git-scm.com/)
- [Visual Studio 2022/2025](https://visualstudio.microsoft.com/) (or later) with .NET desktop and ASP.NET workloads
- [PgAdmin](https://www.postgresql.org/download/)

<h3>Cloning</h3>

How to clone 

```bash
git clone <https://github.com/GraceRenewed/PollinatorBE.git>
cd <PollinatorBE>
```

<h3>Starting</h3>

How to start 

- Restore Dependencies
```bash
dotnet restore
```
- Build the Solution
```bash
dotnet build
```
- Run the Application 
```bash
dotnet run --project PollinatorBE/PollinatorBE.csproj
```
- Run the Tests
```bash
dotnet test
```
- Tip:
Check appsettings.json for any required configuration (like connection strings) and update as needed.

<h2 id="apiCalls">📫 Endpoints</h2>
 


 <h2 id="unitTest"> Unit Tests</h2>

[Video of tests](https://www.loom.com/share/26787eeada0740898c75a50bed275fae?sid=0c375c07-312d-4397-b9dc-655ac45ed5ee)

<h2 id="projboard"> Project Board</h2>

[GitHub Project Board](https://github.com/users/GraceRenewed/projects/6)

<h2 id="colab">🤝 Collaborators</h2>

<p>Special thank you for my classmates in Cohort 28 for all your support!</p>
<table>
<tr>

<td align="center">
<a href="https://github.com/GraceRenewed">
<img src="https://avatars.githubusercontent.com/u/171828567?v=4" width="100px;" alt="Christina Vieau Profile Picture"/><br>
<sub>
<b>Christina Vieau</b>
</sub>
</a>
</td>

<h2 id="contribute">📫 Contribute</h2>

Here you will explain how other developers can contribute to your project. For example, explaining how can create their branches, which patterns to follow and how to open an pull request

1. `git clone https://github.com/GraceRenewed/text-editor.git`
2. `git checkout -b feature/NAME`
3. Follow commit patterns
4. Open a Pull Request explaining the problem solved or feature made, if exists, append screenshot of visual modifications and wait for the review!

<h3>Documentations that might help</h3>

[📝 How to create a Pull Request](https://www.atlassian.com/br/git/tutorials/making-a-pull-request)

