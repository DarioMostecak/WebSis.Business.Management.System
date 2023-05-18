# WebSis Business Managment Api

## Description
Our application is designed to provide businesses with a centralized platform to manage their day-to-day operations more efficiently. We understand that managing various aspects of a business, including finance, sales, customer relationships, inventory, and human resources, can be challenging. That's why we've created an all-in-one solution that can help you streamline your tasks and track your performance metrics.

# Table of contents

* [1 Introduction](#1-introduction)
  * [1.1 Authentication](#11-authentication)
  * [1.2 User roles](#12-user-roles)
* [2 Api enpoints](#2-api-enpoints)
  * [2.1 Users](#21-users)



## 1.1 Authentication 
Our application is secured using JWT bearer tokens. When a user logs in, they receive a token which they can use to access the protected endpoints of our application. The token includes information about the user's role, which is used to determine what endpoints they can access.

## 1.2 User roles
Our application has several different user roles. Each role has a different level of access to the application's endpoints:
* Admin: This role has full access to all of the application's endpoints.
* Warehouse Employee: This role is intended for employees who work in the warehouse and need access to the resources and tools provided by our application.

Access controls for each endpoint is in api endpoints documentation we ensure that only users with the appropriate role can access sensitive information or perform actions that require elevated privileges. This helps to protect our application from unauthorized access and ensure that our users have the appropriate level of access to the resources they need.


 # 2. API enpoints

## 2.1 Users

#### Get user by Id

```http
  GET /api/v1/users?id
```

#### Authentication
Requires an Authorization header with a bearer token (JWT) and user must have Admin role.

#### Parameters
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `userId` | `guid` | **Required.** Id of user |

#### response
```json
{
  "token":"jwt token"
}
```

#### Errors
- UserValidationException - 
- UserDependencyValidationException -
- UserDependencyException -
- UserServiceException -

#### Error response
```json
{
  "status": error code,
  "type": rfc url,
  "title": message from exception,
  "errors": {
    "detail": error detials
}

```
