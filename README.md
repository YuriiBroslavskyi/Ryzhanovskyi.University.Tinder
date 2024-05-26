## Tinder project

The TinderClone Web App is a platform designed to replicate the functionality of the popular dating application Tinder. It allows users to create profiles, view profiles of other users, and engage in mutual liking, messaging, and potential dating matches. This documentation provides an overview of the features, installation instructions, usage guidelines, and maintenance procedures for the TinderClone Web App.



## Author
Mykhailo Ryzkhanovskyi

midzkage@gmail.com

https://t.me/muchailoliluzivert

site on azure - https://gnomelove.azurewebsites.net/

## Getting Started
- To start project in the terminal firtst you to go to the project:
- cd .\TinderClone\
- pip install -r requirements. txt
- and run the server:
- python manage.py runserver

For models migration 
  - manage.py makemigrations
  - manage.py migrate
For connect database 
  - in settings.py scroll down and here
```python
DATABASES = {
    "default": {
        "ENGINE": "mssql",
        "NAME": "your database name",
        "USER": "your database server username",
        "PASSWORD": "your database server password",
        "HOST": "your database address",
        "PORT": "1433",
        "OPTIONS": {
            "driver": "ODBC Driver 18 for SQL Server",
            "timeout": 300,
        },
    },
}
```
## Project Task Decomposition
Add your task decomposition here.

### Week 1:
- Implement feature: User Registration with Google OAuth 2.0 ✔️
- Set up Github repository ✔️
- Configure welcome email after successful registration ✔️
- Create initial project structure ✔️
- Define database schema and models ✔️

### Week 2:
- Implement feature: Profile Creation ✔️
- Design user interface wireframes ✔️
- Set up basic authentication and authorization middleware ✔️
- Create user profile database functionality ✔️
- Begin frontend development for profile creation page ✔️

### Week 3:
- Implement feature: Swipe Functionality ✔️
- Develop backend logic for swipe actions ✔️
- Implement swipe gestures in frontend 
- Test swipe functionality with mock data
- Refine swipe algorithm for better user experience

### Week 4:
- Implement feature: Matching Algorithm ✔️
- Develop backend algorithms for match suggestions ✔️
- Integrate matching algorithm with frontend UI ✔️
- Test matching algorithm with sample data ✔️
- Fine-tune algorithm parameters for accuracy ✔️

### Week 5:
- Implement feature: Chat Messaging
- Set up WebSocket server for real-time messaging
- Develop backend API endpoints for sending and receiving messages
- Implement chat UI in frontend
- Test messaging functionality with multiple users

### Week 6:
- Implement feature: Premium Features
- Design premium subscription models
- Develop backend logic for premium features
- Implement subscription management UI in frontend
- Test premium features with mock subscriptions

### Week 7:
- Implement feature: Email Notification ✔️
- Set up email service integration ✔️
- Develop backend logic for sending welcome emails ✔️
- Test email notification system ✔️
- Handle email verification and user opt-in settings ✔️

### Week 8:
- Implement feature: Privacy and Security Enhancements
- Review and implement security best practices
- Enhance user data encryption and protection measures ✔️
- Implement user privacy settings 
- Perform security testing and audits

### Week 9:
- Implement feature: Customizable Preferences ✔️
- Develop UI for adjusting match preferences ✔️
- Implement backend logic for updating user preferences ✔️
- Test preference customization with various scenarios ✔️
- Optimize preference settings for performance ✔️

### Week 10:
- Implement feature: Report and Block Functionality ✔️
- Develop backend endpoints for reporting and blocking users ✔️
- Design UI for reporting and blocking features ✔️
- Test reporting and blocking functionality ✔️
- Implement moderation tools for handling reports

### Week 11:
- Implement feature: Feedback System ✔️
- Set up feedback submission form ✔️
- Develop backend functionality for processing feedback ✔️
- Design admin interface for reviewing feedback
- Test feedback submission and response workflow ✔️

### Week 12:
- Conduct final testing and bug fixing  
- Prepare for deployment to production environment ✔️
- Create documentation for project setup and maintenance ✔️
- Perform load testing and performance optimization 
- Launch Love Connect to the public ✔️
