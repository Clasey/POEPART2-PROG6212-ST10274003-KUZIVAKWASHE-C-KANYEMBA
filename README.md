# Contract Monthly Claim System (CMCS)

## Project Overview

The **Contract Monthly Claim System (CMCS)** is a .NET WPF application designed to streamline the submission and approval process for monthly claims made by Independent Contractor lecturers. The application includes a basic login, claim submission, and document upload functionalities, as well as options to approve or reject submitted claims. This prototype allows users to explore and test the interface for the system.

### Key Features
- **User Login**: A basic login form to authenticate lecturers before they submit claims.
- **Claim Submission**: Input fields to enter the hours worked, hourly rate, and automatic calculation of the total claim amount.
- **Document Upload**: Allows users to upload supporting documents (PDF, DOCX, XLSX) with a maximum file size limit of 5MB.
- **Claim Approval and Rejection**: The application enables users to approve or reject claims from a pending list.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Class Overview](#class-overview)
- [Contributing](#contributing)
- [License](#license)

## Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Clasey/POEPART2-PROG6212-ST10274003-KUZIVAKWASHE-C-KANYEMBA.git

2. Open in Visual Studio: Open the .sln file in Visual Studio.

3. Build the Solution: Go to Build > Build Solution or press Ctrl+Shift+B.

4. Run the Application: Press F5 to start the application.

Usage
Login:

Enter the credentials for a lecturer (default username: lecturer, password: password123) and click the Login button.
Submit a Claim:

Enter the hours worked and hourly rate in the respective text boxes.
Click the Submit Claim button to calculate and submit the claim.
A message will confirm if the claim was submitted successfully.
Upload a Supporting Document:

Click Upload Document to select a document file.
Only .pdf, .docx, and .xlsx files up to 5MB are accepted.
Approve or Reject a Claim:

Select a claim from the list and click Approve or Reject to change the claim's status.
The ListView will update to reflect the status change.
Logout:

Click the Yes button on the logout prompt to log out.
