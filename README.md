# Bug Tracker

This is a full-stack, responsive web application that allows users to report bugs and make topic suggestions while administrators examine and approve new requests.

## Table of contents

- [Overview](#overview)
  - [The challenge](#the-challenge)
  - [Screenshot](#screenshot)
  - [Links](#links)
- [My process](#my-process)
  - [Built with](#built-with)
  - [What I learned](#what-i-learned)
  - [Continued development](#continued-development)
  - [Useful resources](#useful-resources)
- [Author](#author)
- [Acknowledgments](#acknowledgments)

## Overview

Bug Tracker uses modern software development and DevOps practices to develop, test, debug, and deploy software. This project was built with guidance and help from Tim Corey. His example project, Suggestion Site app, has greatly aided me in developing my bug tracker app.You can find out more about Tim at his website: https://www.iamtimcorey.com/

### The challenge

- Structure webpage with Blazor Server 
- Create and store data with MongoDB Atlas
- Authorization and authentication with Azure Active Directory B2C

### Screenshot

[BugTracker]()

### Links

- [Github source code](https://github.com/francisphamsd/BugTracker.git)
- [Live site](Work in progress)

## My process

First, I have to think about the components I need on the webapp. These include user reports, how to organize and sort all the bug reports, how to store those data in MongoDB, and finally, how to have the user authorization and authentication system work out.

This bug tracker webapp is built upon the foundation of the Suggestion Site app project by Tim Corey. However, it has completely different front-end elements and back-end data.

I chose to write it in C# with Blazor Server because it has both server-side and client-side processing. While it is easy to display the webpage using bootstrap and HTML, Blazor Server also allows fast and secure connection with a database management system (DBMS). Because of its ease of use and its scalability, I chose MongoDB Atlas multi-cloud database as the DBMS for this application. Finally, I chose Azure Active Directory B2C to handle authorization and authentication because of its scalability in the future.

### Built with

- C# ASP.NET
- Blazor Server
- MongoDB Atlas
- Azure Active Directory B2C
- Semantic HTML5 markup
- Bootstrap 5
- Advance CSS

### What I learned

Through this project, I got more practice with C# and ASP.NET. I learned the design process of how to create a.NET 6 application that implements object-oriented programming. I learned how to use the MongoDB database alongside the Blazor Server. Finally, I got to brush up on my basic front-end skills like Bootstrap, CSS, and HTML.
### Continued development

In the future, I might add more options to the webapp, such as

- The ability to add extra bug categories and statuses. 
- Adding more themes like light and dark mode.
- Adding basic user and admin user login for demo purposes.

### Useful resources

- [Tim Corey Course](https://www.iamtimcorey.com) - Tim Corey's tutorial really help me understand .NET 6 Blazor and MongoDB database.

- [Mongo DB Atlas](https://www.mongodb.com/atlas/database) - Thank you MongoDB for sponsoring which allows Tim to share this tutorial free for everyone.

- [Bootstrap doc](https://getbootstrap.com/docs/5.0/getting-started/introduction/) - bootstrap documentation help me with building the component for the webapp

- [Vector background](https://www.vecteezy.com) - This website provide me with exceptional background to use in this project

## Author

- Website - [Frank Pham](https://www.franciswebdev.com)
- Github - [francisphamsd](https://github.com/francisphamsd)

## Acknowledgments

Thank you, Tim Corey and MongoDB, for making this tutorial free for everyone. Thanks to them, I am able to create my own bug tracking software and show it off to the world.
