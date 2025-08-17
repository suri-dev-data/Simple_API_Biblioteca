# 📚 Simple Library API (C#)

A RESTful API built with ASP.NET Core for managing a library system. It provides full CRUD operations for the core entities: `Livro`, `Pessoa`, `Endereco`, `Emprestimo`, and `Livraria`.

## 🚀 Features

- Manage books (`Livro`)
- Handle user data (`Pessoa`)
- Store address information (`Endereco`)
- Track loans and returns (`Emprestimo`)
- Represent the library (`Livraria`)

## 🛠️ Technologies

- ASP.NET Core Web API
- C#
- JSON for data exchange
- Optional: Entity Framework Core

## 📬 HTTP Endpoints

Each entity supports the following operations:

| Entity       | Method  | Endpoint                 | Description                              |
|--------------|---------|--------------------------|------------------------------------------|
| **Livro**     | GET     | `/livro`                 | List all books                           |
|              | GET     | `/livro/{id}`            | Get a specific book                      |
|              | POST    | `/livro`                 | Add a new book                           |
|              | PUT     | `/livro/{id}`            | Replace book data                        |
|              | PATCH   | `/livro/{id}`            | Update book fields                       |
|              | DELETE  | `/livro/{id}`            | Delete a book                            |
| **Pessoa**    | GET     | `/pessoa`                | List all users                           |
|              | GET     | `/pessoa/{id}`           | Get a specific user                      |
|              | POST    | `/pessoa`                | Add a new user                           |
|              | PUT     | `/pessoa/{id}`           | Replace user data                        |
|              | PATCH   | `/pessoa/{id}`           | Update user fields                       |
|              | DELETE  | `/pessoa/{id}`           | Delete a user                            |
| **Endereco**  | GET     | `/endereco`              | List all addresses                       |
|              | GET     | `/endereco/{id}`         | Get a specific address                   |
|              | POST    | `/endereco`              | Add a new address                        |
|              | PUT     | `/endereco/{id}`         | Replace address data                     |
|              | PATCH   | `/endereco/{id}`         | Update address fields                    |
|              | DELETE  | `/endereco/{id}`         | Delete an address                        |
| **Emprestimo**| GET     | `/emprestimo`            | List all loans                           |
|              | GET     | `/emprestimo/{id}`       | Get a specific loan                      |
|              | POST    | `/emprestimo`            | Register a new loan                      |
|              | PUT     | `/emprestimo/{id}`       | Replace loan data                        |
|              | PATCH   | `/emprestimo/{id}`       | Update loan fields                       |
|              | DELETE  | `/emprestimo/{id}`       | Delete a loan                            |
| **Livraria**  | GET     | `/livraria`              | List all libraries                       |
|              | GET     | `/livraria/{id}`         | Get a specific library                   |
|              | POST    | `/livraria`              | Add a new library                        |
|              | PUT     | `/livraria/{id}`         | Replace library data                     |
|              | PATCH   | `/livraria/{id}`         | Update library fields                    |
|              | DELETE  | `/livraria/{id}`         | Delete a library                         |

## 📦 Setup

