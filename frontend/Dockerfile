# Stage 1: Build Angular app
FROM node:23-slim AS builder

# Set the working directory in the container
WORKDIR /app

# Copy the package.json and package-lock.json files to the container
COPY frontend/package*.json ./

# Install dependencies for the Angular project
RUN npm install

# Copy the rest of the frontend source code to the container
COPY frontend/ .

# Build the Angular app in production mode
RUN npm run build --prod

# Stage 2: Serve with Nginx
FROM nginx:alpine

# Copy the custom Nginx configuration to the container
COPY default.conf /etc/nginx/conf.d/default.conf

# Copy the built Angular app from the builder stage to Nginx's web server directory
COPY --from=builder /app/dist/frontend /usr/share/nginx/html

# Expose port 80 to access the app via HTTP
EXPOSE 80

# Run Nginx in the foreground
CMD ["nginx", "-g", "daemon off;"]