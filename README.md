# 🚗 Car Insurance Database Management System

This project is a **SQL Server-based Car Insurance Database** designed to manage and analyze data related to customers, cars, insurance policies, accidents, claims, and payments. It includes a comprehensive schema, useful views, triggers, stored procedures, and sample data for demonstration and testing.

## 📁 Contents

- [Features](#features)
- [Schema Overview](#schema-overview)
- [Views](#views)
- [Triggers](#triggers)
- [Stored Procedures](#stored-procedures)
- [Sample Data](#sample-data)
- [Setup Instructions](#setup-instructions)
- [License](#license)

---

## ✅ Features

- Manage customer, car, and insurance policy data
- Track car ownership and accident records
- File and manage insurance claims and payments
- Automatically trigger data validation and logging
- View statistics and historical data using stored procedures and views

---

## 🗂️ Schema Overview

The database includes the following core tables:

- **Customer** – Stores customer details
- **Car** – Stores car details
- **InsurancePolicy** – Holds insurance policy data
- **Ownership** – Tracks car ownership history
- **Accident** – Stores accident records
- **Claim** – Manages insurance claims
- **Payment** – Manages claim-related payments

---

## 👁️ Views

- **`vw_ActivePolicies`** – Lists active insurance policies
- **`vw_CustomerClaimsHistory`** – Shows customers' past claims and accident data

---

## ⚙️ Triggers

- **`trg_UpdatePolicyStatus`** – Automatically sets `PolicyStatus` (Active, Expired, Future)
- **`trg_ValidateCarLicenseDates`** – Ensures license end date isn’t earlier than start date
- **`trg_LogClaimStatusChanges`** – Logs claim status changes to `ClaimStatusLog`
- **`trg_SetInitialPaymentStatus`** – Automatically sets payment status to `'Pending'` if none is provided

---

## 🧠 Stored Procedures

Includes a variety of stored procedures to query and manipulate the database:

### Policy Management
- `sp_CreateNewPolicy` – Creates and inserts a new policy
- `sp_GetPremiumStatistics` – Retrieves premium statistics by policy type

### Claims & Accidents
- `sp_FileNewClaim` – Files a new insurance claim
- `sp_AccidentsByModel` – Counts accidents for a specific car model
- `sp_AccidentsInvolvedCount_2017` – Counts unique owners involved in 2017 accidents
- `sp_GetAccidentCountForAhmedMohamed` – Accident count for a specific customer
- `sp_MaxAccidentModel_2017` – Model with the most accidents in 2017
- `sp_MinAccidentModel_2017` – Model with the least accidents in 2017
- `sp_GetModelsWithZeroAccidentsIn2017` – Car models with no accidents in 2017
- `sp_MostCommonAccidentType_2017` – Most frequent accident type in 2017
- `Retrieve_information` – Retrieves customer info for cars involved in 2017 accidents

---

## 🧪 Sample Data

To help you get started, the script includes sample data for:

- 5 customers
- 10 cars
- 15 ownership entries
- 10 accident records

---

## ⚙️ Setup Instructions

1. Open SQL Server Management Studio.
2. Run the script `car_insurance_db.sql` in the query editor.
3. (Optional) Uncomment the `CREATE DATABASE` line if the database doesn’t exist.
4. Execute each section step-by-step or run the entire script.

---

## 📜 License

This project is provided under the [MIT License](https://opensource.org/licenses/MIT). Feel free to use, modify, and distribute it.

---

## 👨‍💻 Author

Designed and maintained by [Mohamed Nabil, Mohamed Ahmed, Amr Khaled, Mostafa Mahmoud, Mohamed Gafour, Nour Maged]. Contributions and feedback are welcome!

