# Ride-Along

## 🚗 Ride-Sharing Console App

A simple and modular C# Console Application for managing a ride-sharing system. Users can register as drivers or passengers, request rides, accept and complete them, manage virtual wallets, and calculate ride fares. The system uses file-based storage and follows C# best practices like OOP, interfaces, LINQ, and exception handling.

---

## 📋 Features

- **User Management**
  - Register as Passenger or Driver
  - Login with email and password

- **Driver Features**
  - View available ride requests
  - Accept or cancel rides
  - Complete rides and receive fare
  - Track earnings

- **Passenger Features**
  - Request a ride (pickup & drop-off location)
  - View wallet balance and add funds
  - View ride history

- **Payment System**
  - Fare = Distance × R5.00/km
  - Wallet-based simulation
  - Fare deducted from passenger, credited to driver

---

## 📊 Technologies Used

- C#
- .NET Console Application
- LINQ
- OOP Principles
- File-based storage using JSON
- Exception handling

---

## 🚀 Getting Started

### 🔧 Prerequisites

- .NET SDK (7.0 or later recommended)
- IDE (e.g., Visual Studio, VS Code)

### 🛠️ Setup

1. Clone the repository or download the source:
   - [GitHub Repository](https://github.com/WillemBarendKruger/Ride-Along-Ride-Sharing-System)
2. Open the solution in your preferred IDE.
3. Build and run the project.
4. Follow the on-screen console menu.

---

## 💡 Sample Flow

1. Open the app.
2. Register as a Passenger.
3. Request a ride.
4. Logout and login as a Driver.
5. View and accept the ride request.
6. Complete the ride and earn payment.

---

## ✅ Best Practices Implemented

- Inheritance (`User` → `Passenger` / `Driver`)
- Interfaces (`IRideable`, `IPayable`)
- LINQ filtering (e.g., get available rides)
- Exception handling (invalid input, insufficient funds)
- Encapsulation and modular services
- Separation of concerns (data, logic, UI)

---

## 📌 Future Improvements (Ideas)

- Admin dashboard (flag low-rated drivers, generate reports)
- Rating system
- Unit testing
- Distance-based driver filtering
- File encryption or database support

---

## 🧑‍💻 Author

**Willem Barend Kruger**  
Built as part of a university capstone / portfolio-ready project for showcasing object-oriented design and system interactions in C#.