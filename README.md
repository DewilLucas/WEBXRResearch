# WEBXRResearch
![Alt Text]([https://example.com/image.png](https://ibb.co/QMh0Mbn))
# Installation Guide

Author: Lucas Dewil

## Table of Contents
1. [Introduction](#introduction)
2. [Actions to be Performed](#actions-to-be-performed)
    - [Downloading the Application](#downloading-the-application)
    - [Local Application Installation/Startup](#local-application-installationstartup)
    - [Placing the Application Online](#placing-the-application-online)

---

## Introduction

This guide provides step-by-step instructions for installing the Indoornavigation App. This app is designed to smoothly navigate users through The Penta in Kortrijk, both in augmented reality (AR) and virtual reality (VR). Follow the instructions to install the app and prepare it for use.

## Actions to be Performed

- **Downloading the Application**
- **Navigating to the correct folder**
- **Running the application, both locally and online**

---

### Downloading the Application

1. **Navigate to GitHub**
    - To obtain the application, navigate to: [GitHub Repository](https://github.com/DewilLucas/WEBXRResearch)

2. **Download ZIP**
    - Click on the "<> Code" button and then select 'Download ZIP' to download the zip file.
    - Wait for the zip file to download.

3. **Open and Extract ZIP File**
    - After downloading the zip file, open it and extract it as follows:
        1. Navigate to the location of your Zip file.
        2. Right-click and select "Extract All".
        3. Choose the location where you want to save the application and click "Extract".

### Local Application Installation/Startup

#### Downloading Necessary Tools

**Prerequisites:**
- Git bash: [Git - Downloads](https://git-scm.com/downloads)
- NodeJS: [Node.js — Download](https://nodejs.org)
- http-server npm: [http-server - npm](https://www.npmjs.com/package/http-server)

#### Installing Git Bash

1. Go to [Git Downloads](https://git-scm.com/downloads) and choose your OS (mac/linux/Windows).
2. Click on "click here to download" and wait for it to download.
3. Open the installer.
4. Click "Next" all the time until "Install" and install the application. (leave everything default)

#### Installing NodeJS

1. Go to [Node.js Download](https://nodejs.org/en/download/)
2. Download the installer for your OS.
3. Open the installer and click "Next" until you reach this page, check "install the necessary tools".
4. Click "Next" and on the last page, click "Install".

#### Installing http-server

1. In the 'buildstest' folder, right-click.
2. Click on "Show more options" and then click on “Open GIT bash here”.
3. Copy and paste the following command into the terminal and press Enter:
    ```
    npm install --global http-server
    ```

### Local Application Startup

1. Open Git Bash in the 'buildstest' folder.
2. To start the application locally, execute the following command:
    ```
    http-server -S -C cert.pem -o
    ```
3. If everything has gone well, this page should open in your browser:

#### Surfing Locally on Different Devices

Multiple IP addresses are accessible in the terminal. Use the IP address that does not end with ".1", also remember to append ":8080" after your IP address and use https!
Example:
[https://192.168.0.151:8080](https://192.168.0.151:8080)

### Placing the Application Online

#### GitHub

**Prerequisites:**
- Git bash

**Setting Up:**

1. Go to [GitHub](https://github.com/) and log in/create an account.
2. Once logged in, click on "New" on the left.
3. Give your repository a name and click on "Create repository".
4. Once you have clicked on "Create Repository", you will be taken to this page:

5. Click the copy button.

6. Open your file explorer and go to the 'buildstest' folder that you downloaded.

7. Right-click and select "Show more options".

8. Select "Git Bash here".

9. Paste the copied commands (point 5) into the terminal by right-clicking in the terminal and selecting "paste".

10. Press Enter.

11. If everything went well, you should see the following on your GitHub repository:

12. Execute the following commands one after the other in the terminal:
    ```
    git add -A .
    git add buildstest
    git commit -m "first commit"
    git push
    ```

13. If it went well, you should now see all the files on GitHub:

14. Go to the "Settings" page.

15. Click on "Pages".

16. Click on the dropdown under "Default branch" and select "main". Then press "Save".

17. Click on the "Actions" tab.

18. Wait until the check mark turns green and then click on "pages build and deployment with artifacts-next".

19. If all steps are successful, you should find a link under "deploy", click on this link, this is the link that has been placed online.

20. This is the result you should have once you click on the link:

If this is not your result, please go through all the previous steps again.
