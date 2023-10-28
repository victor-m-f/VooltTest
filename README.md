# Website Blocks API

## 🎯 Objective

This project aims to provide a backend API to manage different "Blocks" that can be used to construct the structure of a business website. Each page of the website is composed of multiple reusable blocks, which can be manipulated via this API.

## 📋 Requirements

- **Backend**: .NET Core
- **API Documentation**: Swagger

## 🏗 Project Structure

- **Domain**: Contains all the domain entities (Pages, Blocks, CTAButton, etc...).
- **Application (UseCases)**: Handles the business logic and use cases (CreateNewPage, GetPage, UpdatePageBlock, DeletePageBlock).
- **Presentation**: API Endpoints

## ⚙️ API Functionality

### Types of Blocks
1. **Website Header**: Includes ID, block order, business name, logo, navigation menu, and CTA button settings.
2. **Website Hero Block**: Includes ID, block order, headline text, description text, and CTA button settings.
3. **Services Block**: Includes ID, block order, headline text, and service cards with specific settings.

### Endpoints
- `POST /Pages`: Create a new page.
- `GET /Pages/{key}`: Get an existing page.
- `PUT /Pages/{key}/PageBlocks/{sectionID}`: Update a specific block.
- `DELETE /Pages/{key}/PageBlocks/{sectionID}`: Delete a specific block.

## 🚀 How to Run

1. Restore all NuGet packages.
2. Build the project.
3. Run the application.
4. Navigate to Swagger for API documentation and testing.

## 📝 Example Requests

### Update Header Block

```json
{
  "updatedBlock": "{\"id\": 1, \"businessName\": \"CodeCafe\", \"logoDisplayed\": true, \"menu\": {\"link\": {\"displayName\": \"Home\", \"url\": \"/home\"}, \"subMenus\": [{\"displayName\": \"About\", \"url\": \"/about\"}, {\"displayName\": \"Contact\", \"url\": \"/contact\"}]}, \"cta\": {\"text\": \"Sign Up\", \"displayStatus\": true, \"icon\": \"user\", \"buttonEvent\": \"signup\"}, \"blockOrder\": 1}"
}
```

### Update Hero Block

```json
{
  "updatedBlock": "{\"id\": 1, \"headlineText\": \"Welcome to CodeWorld\", \"descriptionText\": \"Where coding meets creativity.\", \"cta\": {\"text\": \"Get Started\", \"displayStatus\": true, \"icon\": \"rocket\", \"buttonEvent\": \"getStarted\"}, \"heroImage\": \"hero-background.jpg\", \"imageAlignment\": \"center\", \"contentAlignment\": \"left\", \"blockOrder\": 1}"
}
```

### Update Services Block

```json
{
  "updatedBlock": "{\"id\": 2, \"headlineText\": \"Our Awesome Services\", \"serviceCards\": [{\"name\": \"Web Development\", \"description\": \"Create stunning websites\", \"image\": \"webdev.jpg\", \"cta\": {\"text\": \"Learn More\", \"displayStatus\": true, \"icon\": \"info\", \"buttonEvent\": \"learnMore\"}}], \"blockOrder\": 2}"
}
```