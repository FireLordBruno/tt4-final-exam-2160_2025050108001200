# Use official Node.js LTS image
FROM node:23-slim

# Create and set working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of your application code
COPY . .

# Expose backend port (change if needed)
EXPOSE 5000

# Start the backend server (change server.js if your entry is index.js)
CMD ["node", "server.js"]