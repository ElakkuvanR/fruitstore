# escape=`

ARG BASE_IMAGE

FROM ${BASE_IMAGE} as base

## Included these lines to avoid garbage collection errors during npm install
ENV GENERATE_SOURCEMAP false
ENV NODE_OPTIONS=--max-old-space-size=8192
EXPOSE 3000

# set your working directory  
WORKDIR /App

# COPY  package.json .
COPY src/UI/buyerstores/package.json ./  
COPY src/UI/buyerstores/package-lock.json ./

RUN npm ci --ignore-scripts --loglevel warn

RUN npm install --silent
COPY src/UI/buyerstores/public/* ./public/
COPY src/UI/buyerstores/src/* ./src/
COPY src/UI/buyerstores/package.json ./
COPY src/UI/buyerstores/package-lock.json ./

EXPOSE 3000
# # will start app  
ENTRYPOINT "npm run start"