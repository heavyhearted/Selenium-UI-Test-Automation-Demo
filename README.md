# Overview
This project is a Selenium-based test automation framework designed for testing a public web application, which serves as a demo web app for UI testing. It utilizes NUnit as the testing framework, and the Page Object Model design pattern for test automation.

The framework is modular, extensible, and uses Selenium WebDriver for browser automation across different browsers like Chrome, Firefox, and Edge.

# Directory Breakdown
- **CoreFramework**: Contains the core framework classes and interfaces.
    - **Configuration:** Defines classes and constants for configuring browser settings, such as BrowserSettings and SettingsConstants.
  - **Enums**: Contains enumerations (e.g., BrowserType, GenderType) to standardize browser selection and user attributes.
  - **Models:** Includes classes representing core data structures, such as TestUser, encapsulating user-related data.
  - **Utilities:** Provides helper classes for URL handling (WebAppUrls, WebAppUrlValidationHelper).
  - **WebDriver:** Contains classes for setting up and managing WebDriver instances (WebDriverFactory, WebDriverWindowManager).
- **Locators:** Houses locator files for each page, defining the elements’ identifiers (e.g., AboutPageLocators, BlogPageLocators). 
- **Pages:** Implements page classes for specific pages on the website, facilitating interactions and actions on each page (e.g., AboutPage, BlogPage). 
- **Sections:** Contains reusable UI sections like headers and footers (FooterSection, HeaderSection). 
- **Tests:** Contains test classes organized by page, which validate the behavior of each page (e.g., AboutPageTests, SampleAppPageTests). 
- **.runsettings:** JSON files for browser-specific configurations (browser_settings.Chrome.json, browser_settings.Edge.json, browser_settings.Firefox.json).

## WebDriver Factory
The WebDriverFactory class is the core component for setting up WebDriver instances based on the specified browser configuration. This class supports multiple environments and allows flexibility in setting up WebDriver configurations for both local and non-local (e.g. Development, Staging) environments.

### Configuration with ConfigurationBuilder

The ConfigurationBuilder in WebDriverFactory loads the browser configuration based on environment variables and JSON files. This setup can easily be adapted to load configurations from alternative sources, such as cloud services, making the framework flexible for different deployment environments.

## Running Tests
**Before** running the tests, **ensure Docker is installed and running on your machine**.

To run tests locally, use the .runsettings JSON files. You can specify the browser and configuration in files like _browser_settings.Chrome.json, browser_settings.Firefox.json_, etc. Ensure that _BROWSER_ENVIRONMENT_ is set to the local browser you wish to test with.

**To start a test**, navigate to the Test Explorer within the IDE and run the tests.









 