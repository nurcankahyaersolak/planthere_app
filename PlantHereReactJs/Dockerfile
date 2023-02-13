FROM node:18.12.1

RUN mkdir ui

WORKDIR /ui 

COPY PlantHereReactJs/plant-here-reactjs/package.json /ui/package.json

RUN npm i

COPY ./PlantHereReactJs/plant-here-reactjs /ui

RUN npm run build

CMD ["npm", "start"]