# Smingate Infrastructure Challenge

## Introduction

Welcome to the Smingate infrastructure challenge! A new team needs your expertise to containerize their .NET Web API and a PostgreSQL database, both running in Kubernetes. Additionally, they require you to automate the build, test, and deploy process using your CI/CD skills. The application will be deployed in different environments in the future, so it's important to use Helm templating to keep it easily extendable without duplicating manifests.

## Task Description

### Containerize the .NET Application

- Create a Dockerfile to containerize the existing .NET Web API (Asset.API).

### Deploy PostgreSQL Using Helm

- Deploy a PostgreSQL database using a Helm chart.
- The PostgreSQL instance should have a database called `asset` with a user `asset_admin` and password `admin`.
- Deploy the PostgreSQL instance in the `database` namespace.

### Create Helm Manifests for .NET Web API

- Use Helm templating to create YAML manifests for the .NET Web API (Asset.API).
- Ensure the application is exposed and reachable on your local machine using an ingress.
- The API should be reachable on http://asset-api.local/api.

### Testing the API

- After deployment, add a new asset to the database using the POST endpoint.
- Confirm the new asset has been added to the database by retrieving it using the GET endpoint.

### Set Up CI/CD Pipeline

- Create a gitlab-ci.yml file for basic CI/CD steps:
  - **Build**: Build the Docker image for the .NET Web API.
  - **Test**: Run unit tests for the application.
  - **Deploy**: Deploy the application to Kubernetes using Helm, ensuring the correct image version is used.

## Prerequisites

Before starting the task, ensure you have the following set up on your local machine:

- **Docker**: To build and run Docker images.
- **Minikube**: To create a local Kubernetes cluster.
- **Kubectl**: To interact with the Kubernetes cluster.
- **Helm**: To manage Kubernetes applications with Helm charts.
- **.NET SDK**: To build and run the .NET Web API.
- **Git**: To clone repositories and manage version control.
- **GitHub Account**: To store and manage your code repository.
- **Postman (optional)**: To test the API endpoints.

### Setup Instructions

1. **Install Docker**: Follow the installation guide on the [Docker website](https://docs.docker.com/engine/install/).
2. **Install Minikube**: Follow the installation guide on the [Minikube website](https://minikube.sigs.k8s.io/docs/start/).
3. **Install Kubectl**: Follow the installation guide on the [Kubernetes website](https://kubernetes.io/docs/tasks/tools/).
4. **Install Helm**: Follow the installation guide on the [Helm website](https://helm.sh/docs/intro/install/).
5. **Install .NET SDK**: Follow the installation guide on the [.NET website](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).
6. **Install VS Code (optional)**: Follow the installation guide on the [VS Code website](https://code.visualstudio.com/download)
7. **Start Minikube**: Run minikube start to create a local Kubernetes cluster.

## Requirements

- Ensure that the solution is easily extendable to different environments without duplicating manifests.
- Use best practices for containerization, deployment, and CI/CD.

Good luck, and we look forward to seeing your solution!
