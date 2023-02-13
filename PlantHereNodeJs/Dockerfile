FROM node:18.12.1

RUN mkdir -p /app/

WORKDIR /app

COPY PlantHereNodeJs/Core/PlantHere.Aplication/ /app/Core/PlantHere.Aplication
WORKDIR /app/Core/PlantHere.Aplication/
RUN npm install

COPY PlantHereNodeJs/Core/PlantHere.Domain/ /app/Core/PlantHere.Domain
WORKDIR /app/Core/PlantHere.Domain/
RUN npm install

COPY  PlantHereNodeJs/Infrastructure/PlantHere.Infrastructure/ /app/Infrastructure/PlantHere.Infrastructure
COPY  PlantHereNodeJs/Infrastructure/PlantHere.Persistance/ /app/Infrastructure/PlantHere.Persistance
WORKDIR /app/Infrastructure/PlantHere.Persistance/
RUN npm install

COPY PlantHereNodeJs/Presentation/PlantHere.WebAPI/ /app/Presentation/PlantHere.WebAPI
WORKDIR /app/Presentation/PlantHere.WebAPI/
RUN npm install

WORKDIR /app/Presentation/PlantHere.WebAPI
CMD ["node", "index.js"]