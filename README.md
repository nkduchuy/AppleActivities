
# Apple Activities 

Apple Activities is a web-based platform that allows users to create, manage, and participate in social activities. Users can create profiles, upload photos, follow each other, join activities, and chat live under each event. The app also provides filters to sort activities by date or type.

## Features

- Create, manage, and cancel activities
- Browse and filter list of future activities
- Create and customize user profile and follow other users
- Live chat under each social activity

## Main Technologies Used

- **Backend**: .NET 7 WebAPI, Clean Architecture, CQRS & Mediator patterns, SignalR
- **Frontend**: React 18, TypeScript, MobX, React Router
- **Database**: Entity Framework, PostgreSQL
- **Others**: JWT for auth, Docker for containerization

## Running the application locally

1. Clone the project

```bash
  git clone https://github.com/nkduchuy/AppleActivities
```

2. Open the project in VS Code and go to the AppleActivities directory in a terminal:

```bash
  cd AppleActivities
```

3. Ensure you have Docker Desktop installed on your machine. If not download and install from Docker and review the instructions for your OS [here](https://docs.docker.com/desktop/).

4. Create a local PostgreSQL instance with Docker:

```bash
  docker run --name dev -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=secret -p 5432:5432 -d
```

5. Go to the API directory and run the project:

```bash
  cd API
  dotnet run
```
NOTE: The `dotnet run` command will run both the front-end and back-end.

6. You can now access the app through browser using the URL http://localhost:5000